using Google.Apis.Download;
using System.IO;
using System.Threading.Tasks;

namespace GDrive_Updater
{
    class FileModel
    {
        public string LocalFilePath { get; set; }
        public string LocalFolderPath { get; set; }
        public string FileName { get; set; }
        public double Size { get; set; }

        public int WritePosition { get; set; }
        public Task<IDownloadProgress> DownloadTask { get; set; }

        public MemoryStream DownloadStream { get; set; }
        public FileStream WriteStream { get; set; }
    }
}
