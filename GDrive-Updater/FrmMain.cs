using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IO = System.IO;

namespace GDrive_Updater
{
    public partial class FrmMain : Form
    {
        string DEFAULT_CREDENTIALS_PATH;
        string DEFAULT_LOCAL_PATH;
        string DEFAULT_FOLDER_ID;

        string credentialsPath = "";
        string localSavePath = "";
        string folderId = "";
        bool _useLogs = false;
        string _applicationName = "Drive API .NET Quickstart";
        List<string> _scopes = new List<string>() { DriveService.Scope.DriveReadonly };
        List<FileModel> _fileModels = null;
        List<Task<IDownloadProgress>> _downloadTasks = null;
        Dictionary<string, double> _filesDownloadedBytes = new Dictionary<string, double>();
        Dictionary<string, Task<IDownloadProgress>> _downloadTaskMap = new Dictionary<string, Task<IDownloadProgress>>();
        Stopwatch _watch = new Stopwatch();
        int _downloadedCount = 0;

        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            credentialsPath = DEFAULT_CREDENTIALS_PATH = txtCredentialsPath.Text;
            localSavePath = DEFAULT_LOCAL_PATH = txtLocalPath.Text;
            folderId = DEFAULT_FOLDER_ID = txtFolderId.Text;
            UpdateProgressBar();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            PrepData();
            PrepLogs();

            btnDownload.Enabled = false;
            try
            {
                _watch.Restart();
                await DownloadAsync();
            }
            catch (Exception ex)
            {
                Log(@"Error while downloading:" + ex.Message);
                Log(ex.StackTrace);
            }

            btnDownload.Enabled = true;
        }

        private void PrepLogs()
        {
            _useLogs = chkUseLogs.Checked;
            try
            {
                if (IO.File.Exists(txtLogfile.Text))
                    IO.File.Delete(txtLogfile.Text);
            }
            catch
            {
                _useLogs = false;
            }
        }

        private void PrepData()
        {
            _downloadedCount = 0;
            _downloadTaskMap.Clear();
            _filesDownloadedBytes.Clear();
            prgDownload.Value = 0;
            prgDownload.Value = 0;
            txtResultMessage.Text = "";
            credentialsPath = DEFAULT_CREDENTIALS_PATH;
            localSavePath = DEFAULT_LOCAL_PATH;
            folderId = DEFAULT_FOLDER_ID;

            if (!string.IsNullOrEmpty(txtFolderId.Text))
                folderId = txtFolderId.Text;

            if (!string.IsNullOrEmpty(txtCredentialsPath.Text))
                credentialsPath = txtCredentialsPath.Text;

            if (!string.IsNullOrEmpty(txtLocalPath.Text))
                localSavePath = txtLocalPath.Text;

            prgDownload.Value = 0;
            prgDownload.Maximum = 100;
            _fileModels = new List<FileModel>();
            _downloadTasks = new List<Task<IDownloadProgress>>();
            _filesDownloadedBytes = new Dictionary<string, double>();
            _downloadTaskMap = new Dictionary<string, Task<IDownloadProgress>>();
            _watch = new Stopwatch();
        }

        private async Task DownloadAsync()
        {
            var credentials = await GetCredentialsAsync();

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = _applicationName,
            });

            var lstRequest = service.Files.List();
            lstRequest.PageSize = 10;
            lstRequest.Fields = "nextPageToken, files(id, name, size)";
            lstRequest.Q = $"'{folderId }' in parents";

            var fileList = await lstRequest.ExecuteAsync();
            DeleteExistingFiles(fileList);
            CreateFileModelsAndTasks(fileList, service);

            _fileModels.ForEach(f =>
            {
                _filesDownloadedBytes[f.FileName] = 0;
                this.Invoke((MethodInvoker)delegate { UpdateProgressBar(); });
            });


            Log("Begin retrieving files...");
            await Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(_downloadTasks, async (task) =>
                {
                    FileModel file = null;
                    foreach (var tsk in _downloadTaskMap)
                    {
                        if (tsk.Value == task)
                        {
                            file = _fileModels.Find(f => f.FileName == tsk.Key);

                        }
                    }
                    var result = await task;
                    _filesDownloadedBytes[file.FileName] += result.BytesDownloaded;
                    if (result.Status == DownloadStatus.Completed)
                    {
                        Log($"Download of {file.LocalFilePath} successful");
                        ++_downloadedCount;
                        if (_downloadedCount == _fileModels.Count)
                        {
                            _watch.Stop();
                            Log($"Process completed in {_watch.ElapsedMilliseconds / 1000f} seconds");
                        }
                    }
                    await SaveFileAsync(file);

                    file.DownloadStream.Close();
                    file.WriteStream.Close();

                    this.Invoke((MethodInvoker)delegate { UpdateProgressBar(); });
                });
            });
        }

        private void CreateFileModelsAndTasks(FileList fileList, DriveService service)
        {
            _downloadTasks = new List<Task<IDownloadProgress>>();
            _fileModels = new List<FileModel>();

            if (fileList != null && fileList.Files != null && fileList.Files.Count > 0)
            {
                foreach (var file in fileList.Files)
                {
                    if (!file.Size.HasValue)
                        continue;
                    if (!Directory.Exists(localSavePath))
                        Directory.CreateDirectory(localSavePath);
                    MemoryStream downloadStream = new MemoryStream();
                    var downloadTask = service.Files.Get(file.Id).DownloadAsync(downloadStream);
                    string path = Path.Combine(localSavePath, file.Name);
                    FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    path = Path.GetFullPath(path);
                    path = path.Replace(@"\\", "/");
                    _downloadTasks.Add(downloadTask);
                    _downloadTaskMap[file.Name] = downloadTask;
                    _fileModels.Add(new FileModel()
                    {
                        Size = file.Size.Value,
                        FileName = file.Name,
                        LocalFilePath = path,
                        DownloadTask = downloadTask,
                        DownloadStream = downloadStream,
                        WriteStream = fs
                    });
                }
            }
        }

        private void DeleteExistingFiles(FileList fileList)
        {
            if (fileList == null || fileList.Files == null || fileList.Files.Count == 0)
                return;

            foreach (var file in fileList.Files)
            {
                string fullPath = Path.Combine(localSavePath, file.Name);
                if (IO.File.Exists(fullPath))
                    IO.File.Delete(fullPath);
            }
        }

        async Task<UserCredential> GetCredentialsAsync()
        {
            UserCredential credentials = null;
            try
            {
                if (!string.IsNullOrEmpty(txtCredentialsPath.Text) && IO.File.Exists(txtCredentialsPath.Text) && txtCredentialsPath.Text.EndsWith(".json"))
                {
                    credentialsPath = txtCredentialsPath.Text;
                }

                using (var stream =
                    new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    Log("Getting Authorization");
                    string credPath = "token.json";
                    credentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        _scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true));
                }
            }
            catch(Exception ex)
            {
                Log("Failed to get credentials");
                Log(ex.Message);
                Log(ex.StackTrace);
            }

            return credentials;
        }

        private void UpdateProgressBar()
        {
            double totalBytes = 0;
            double currentBytes = 0;

            foreach (var pair in _filesDownloadedBytes)
            {
                totalBytes += pair.Value;
                if (_filesDownloadedBytes.ContainsKey(pair.Key))
                {
                    currentBytes += _filesDownloadedBytes[pair.Key];
                }
            }

            if (totalBytes == 0)
                prgDownload.Value = 0;
            else
                prgDownload.Value = (int)Math.Round((currentBytes / totalBytes) * 100);
            lblPercent.Text = prgDownload.Value + " %";
            lblPercent.Invalidate();
            lblPercent.Update();
            lblPercent.Refresh();
            Application.DoEvents();
        }

        private void btnBrowseCred_Click(object sender, EventArgs e)
        {
            var result = fileBrowser.ShowDialog();
            if (result == DialogResult.OK)
                txtCredentialsPath.Text = credentialsPath = fileBrowser.SelectedPath;
        }

        private void btnBrowseLocalFile_Click(object sender, EventArgs e)
        {
            var result = fileBrowser.ShowDialog();
            if (result == DialogResult.OK)
                txtLocalPath.Text = localSavePath = fileBrowser.SelectedPath;
        }

        void Log(string message)
        {
            Console.WriteLine(message);
            if (_useLogs)
                LogToFile(message);
            this.Invoke((MethodInvoker)delegate
            {
                txtResultMessage.AppendText(message);
                txtResultMessage.AppendText(Environment.NewLine);
                txtResultMessage.Invalidate();
                txtResultMessage.Update();
                txtResultMessage.Refresh();
                Application.DoEvents();
            });

        }

        private void LogToFile(string message)
        {
            FileStream stream = null;
            try
            {
                using (stream = IO.File.Open(txtLogfile.Text, FileMode.Append))
                {
                    var bytes = Encoding.ASCII.GetBytes(message + '\n');
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
                stream = null;
            }
            catch (Exception ex)
            {
                _useLogs = false;
                Console.WriteLine("exception while logging:" + ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        private async Task SaveFileAsync(FileModel file)
        {
            var writeStream = file.WriteStream;
            var downloadStream = file.DownloadStream;
            int nbBytesToRead = (downloadStream.Length - file.WritePosition) > 256 ? 256 : (int)(downloadStream.Length - file.WritePosition);

            while (writeStream.Position < downloadStream.Length && downloadStream.CanRead && writeStream.CanWrite)
            {
                downloadStream.Position = (int)writeStream.Position;
                byte[] data = new byte[nbBytesToRead];
                int nbBytes = await downloadStream.ReadAsync(data, 0, nbBytesToRead);

                byte[] buffer = data.ToArray();
                if (nbBytes > 0)
                {
                    writeStream.Position = (int)writeStream.Position;
                    await writeStream.WriteAsync(buffer, 0, nbBytes);
                    file.WritePosition += nbBytes;
                }
            }
        }
    }
}
