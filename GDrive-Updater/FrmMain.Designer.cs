namespace GDrive_Updater
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.fileBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowseLocalFile = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnBrowseCred = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCredentialsPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResultMessage = new System.Windows.Forms.TextBox();
            this.prgDownload = new System.Windows.Forms.ProgressBar();
            this.lblPercent = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkUseLogs = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLogfile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Local Path:";
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Location = new System.Drawing.Point(97, 95);
            this.txtLocalPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(164, 20);
            this.txtLocalPath.TabIndex = 4;
            this.txtLocalPath.Text = "C:/DriveData";
            // 
            // btnBrowseLocalFile
            // 
            this.btnBrowseLocalFile.Location = new System.Drawing.Point(271, 95);
            this.btnBrowseLocalFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowseLocalFile.Name = "btnBrowseLocalFile";
            this.btnBrowseLocalFile.Size = new System.Drawing.Size(64, 20);
            this.btnBrowseLocalFile.TabIndex = 6;
            this.btnBrowseLocalFile.Text = "Browse";
            this.btnBrowseLocalFile.UseVisualStyleBackColor = true;
            this.btnBrowseLocalFile.Click += new System.EventHandler(this.btnBrowseLocalFile_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(128, 294);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(102, 22);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnBrowseCred
            // 
            this.btnBrowseCred.Location = new System.Drawing.Point(271, 69);
            this.btnBrowseCred.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowseCred.Name = "btnBrowseCred";
            this.btnBrowseCred.Size = new System.Drawing.Size(64, 23);
            this.btnBrowseCred.TabIndex = 10;
            this.btnBrowseCred.Text = "Browse";
            this.btnBrowseCred.UseVisualStyleBackColor = true;
            this.btnBrowseCred.Click += new System.EventHandler(this.btnBrowseCred_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Credentials Path:";
            // 
            // txtCredentialsPath
            // 
            this.txtCredentialsPath.Location = new System.Drawing.Point(97, 69);
            this.txtCredentialsPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCredentialsPath.Name = "txtCredentialsPath";
            this.txtCredentialsPath.Size = new System.Drawing.Size(164, 20);
            this.txtCredentialsPath.TabIndex = 8;
            this.txtCredentialsPath.Text = "../../Data/credentials.json";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Result Message:";
            // 
            // txtResultMessage
            // 
            this.txtResultMessage.Location = new System.Drawing.Point(92, 128);
            this.txtResultMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtResultMessage.Multiline = true;
            this.txtResultMessage.Name = "txtResultMessage";
            this.txtResultMessage.Size = new System.Drawing.Size(243, 122);
            this.txtResultMessage.TabIndex = 12;
            // 
            // prgDownload
            // 
            this.prgDownload.Location = new System.Drawing.Point(92, 260);
            this.prgDownload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.prgDownload.Name = "prgDownload";
            this.prgDownload.Size = new System.Drawing.Size(208, 20);
            this.prgDownload.TabIndex = 13;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(304, 261);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(36, 13);
            this.lblPercent.TabIndex = 15;
            this.lblPercent.Text = "100 %";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Folder Id:";
            // 
            // txtFolderId
            // 
            this.txtFolderId.Location = new System.Drawing.Point(97, 43);
            this.txtFolderId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.Size = new System.Drawing.Size(164, 20);
            this.txtFolderId.TabIndex = 16;
            this.txtFolderId.Text = "1xQK8jMK5-rgvaUhaRFtVWAxsplIF73iZ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Progress:";
            // 
            // chkUseLogs
            // 
            this.chkUseLogs.AutoSize = true;
            this.chkUseLogs.Location = new System.Drawing.Point(271, 16);
            this.chkUseLogs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkUseLogs.Name = "chkUseLogs";
            this.chkUseLogs.Size = new System.Drawing.Size(73, 17);
            this.chkUseLogs.TabIndex = 18;
            this.chkUseLogs.Text = "Use logs?";
            this.chkUseLogs.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Log File:";
            // 
            // txtLogfile
            // 
            this.txtLogfile.Location = new System.Drawing.Point(97, 16);
            this.txtLogfile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLogfile.Name = "txtLogfile";
            this.txtLogfile.Size = new System.Drawing.Size(164, 20);
            this.txtLogfile.TabIndex = 19;
            this.txtLogfile.Text = "C:/log.txt";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 323);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLogfile);
            this.Controls.Add(this.chkUseLogs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFolderId);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.prgDownload);
            this.Controls.Add(this.txtResultMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBrowseCred);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCredentialsPath);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnBrowseLocalFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocalPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GDrive Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.FolderBrowserDialog fileBrowser;
        private System.Windows.Forms.Button btnBrowseLocalFile;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBrowseCred;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCredentialsPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResultMessage;
        private System.Windows.Forms.ProgressBar prgDownload;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFolderId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkUseLogs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLogfile;
    }
}

