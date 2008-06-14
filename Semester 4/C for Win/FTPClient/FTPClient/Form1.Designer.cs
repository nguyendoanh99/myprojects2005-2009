namespace FTPClient
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lsVRemote = new System.Windows.Forms.ListView();
            this.imgLst = new System.Windows.Forms.ImageList(this.components);
            this.butDeleteFolder = new System.Windows.Forms.Button();
            this.butDeleteFile = new System.Windows.Forms.Button();
            this.butCreateFolder = new System.Windows.Forms.Button();
            this.butRename = new System.Windows.Forms.Button();
            this.butConnect = new System.Windows.Forms.Button();
            this.butDisconnect = new System.Windows.Forms.Button();
            this.lsVLocal = new System.Windows.Forms.ListView();
            this.butDownload = new System.Windows.Forms.Button();
            this.butUpload = new System.Windows.Forms.Button();
            this.cmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lsVRemote
            // 
            this.lsVRemote.HideSelection = false;
            this.lsVRemote.Location = new System.Drawing.Point(447, 56);
            this.lsVRemote.MultiSelect = false;
            this.lsVRemote.Name = "lsVRemote";
            this.lsVRemote.Size = new System.Drawing.Size(324, 391);
            this.lsVRemote.SmallImageList = this.imgLst;
            this.lsVRemote.TabIndex = 0;
            this.lsVRemote.UseCompatibleStateImageBehavior = false;
            this.lsVRemote.View = System.Windows.Forms.View.List;
            this.lsVRemote.DoubleClick += new System.EventHandler(this.lsVRemote_DoubleClick);
            this.lsVRemote.SelectedIndexChanged += new System.EventHandler(this.lsVRemote_SelectedIndexChanged);
            // 
            // imgLst
            // 
            this.imgLst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst.ImageStream")));
            this.imgLst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst.Images.SetKeyName(0, "folder.ico");
            this.imgLst.Images.SetKeyName(1, "file.ico");
            this.imgLst.Images.SetKeyName(2, "");
            this.imgLst.Images.SetKeyName(3, "");
            this.imgLst.Images.SetKeyName(4, "");
            this.imgLst.Images.SetKeyName(5, "mdb.ico");
            this.imgLst.Images.SetKeyName(6, "");
            this.imgLst.Images.SetKeyName(7, "zip.ico");
            this.imgLst.Images.SetKeyName(8, "");
            this.imgLst.Images.SetKeyName(9, "");
            // 
            // butDeleteFolder
            // 
            this.butDeleteFolder.Enabled = false;
            this.butDeleteFolder.Location = new System.Drawing.Point(331, 327);
            this.butDeleteFolder.Name = "butDeleteFolder";
            this.butDeleteFolder.Size = new System.Drawing.Size(95, 29);
            this.butDeleteFolder.TabIndex = 8;
            this.butDeleteFolder.Text = "Remove Folder";
            this.butDeleteFolder.UseVisualStyleBackColor = true;
            this.butDeleteFolder.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butDeleteFile
            // 
            this.butDeleteFile.Enabled = false;
            this.butDeleteFile.Location = new System.Drawing.Point(331, 284);
            this.butDeleteFile.Name = "butDeleteFile";
            this.butDeleteFile.Size = new System.Drawing.Size(95, 27);
            this.butDeleteFile.TabIndex = 9;
            this.butDeleteFile.Text = "Delete File";
            this.butDeleteFile.UseVisualStyleBackColor = true;
            this.butDeleteFile.Click += new System.EventHandler(this.butDeleteFile_Click);
            // 
            // butCreateFolder
            // 
            this.butCreateFolder.Enabled = false;
            this.butCreateFolder.Location = new System.Drawing.Point(331, 371);
            this.butCreateFolder.Name = "butCreateFolder";
            this.butCreateFolder.Size = new System.Drawing.Size(95, 30);
            this.butCreateFolder.TabIndex = 10;
            this.butCreateFolder.Text = "Create Folder";
            this.butCreateFolder.UseVisualStyleBackColor = true;
            this.butCreateFolder.Click += new System.EventHandler(this.butCreateFolder_Click);
            // 
            // butRename
            // 
            this.butRename.Enabled = false;
            this.butRename.Location = new System.Drawing.Point(331, 418);
            this.butRename.Name = "butRename";
            this.butRename.Size = new System.Drawing.Size(95, 29);
            this.butRename.TabIndex = 11;
            this.butRename.Text = "Rename";
            this.butRename.UseVisualStyleBackColor = true;
            this.butRename.Click += new System.EventHandler(this.butRename_Click);
            // 
            // butConnect
            // 
            this.butConnect.Location = new System.Drawing.Point(331, 12);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(95, 29);
            this.butConnect.TabIndex = 12;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // butDisconnect
            // 
            this.butDisconnect.Enabled = false;
            this.butDisconnect.Location = new System.Drawing.Point(447, 12);
            this.butDisconnect.Name = "butDisconnect";
            this.butDisconnect.Size = new System.Drawing.Size(89, 29);
            this.butDisconnect.TabIndex = 13;
            this.butDisconnect.Text = "Disconnect";
            this.butDisconnect.UseVisualStyleBackColor = true;
            this.butDisconnect.Click += new System.EventHandler(this.butDisconnect_Click);
            // 
            // lsVLocal
            // 
            this.lsVLocal.HideSelection = false;
            this.lsVLocal.Location = new System.Drawing.Point(1, 56);
            this.lsVLocal.Name = "lsVLocal";
            this.lsVLocal.Size = new System.Drawing.Size(324, 391);
            this.lsVLocal.SmallImageList = this.imgLst;
            this.lsVLocal.TabIndex = 14;
            this.lsVLocal.UseCompatibleStateImageBehavior = false;
            this.lsVLocal.View = System.Windows.Forms.View.List;
            this.lsVLocal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsVLocal_MouseDoubleClick);
            this.lsVLocal.SelectedIndexChanged += new System.EventHandler(this.lsVLocal_SelectedIndexChanged);
            // 
            // butDownload
            // 
            this.butDownload.Enabled = false;
            this.butDownload.Location = new System.Drawing.Point(332, 73);
            this.butDownload.Name = "butDownload";
            this.butDownload.Size = new System.Drawing.Size(94, 27);
            this.butDownload.TabIndex = 15;
            this.butDownload.Text = "Download <<";
            this.butDownload.UseVisualStyleBackColor = true;
            this.butDownload.Click += new System.EventHandler(this.butDownload_Click);
            // 
            // butUpload
            // 
            this.butUpload.Enabled = false;
            this.butUpload.Location = new System.Drawing.Point(332, 119);
            this.butUpload.Name = "butUpload";
            this.butUpload.Size = new System.Drawing.Size(94, 27);
            this.butUpload.TabIndex = 16;
            this.butUpload.Text = "Upload >>";
            this.butUpload.UseVisualStyleBackColor = true;
            this.butUpload.Click += new System.EventHandler(this.butUpload_Click);
            // 
            // cmb
            // 
            this.cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb.FormattingEnabled = true;
            this.cmb.Location = new System.Drawing.Point(1, 17);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(324, 21);
            this.cmb.TabIndex = 17;
            this.cmb.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 458);
            this.Controls.Add(this.cmb);
            this.Controls.Add(this.butUpload);
            this.Controls.Add(this.butDownload);
            this.Controls.Add(this.lsVLocal);
            this.Controls.Add(this.butDisconnect);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.butRename);
            this.Controls.Add(this.butCreateFolder);
            this.Controls.Add(this.butDeleteFile);
            this.Controls.Add(this.butDeleteFolder);
            this.Controls.Add(this.lsVRemote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsVRemote;
        private System.Windows.Forms.ImageList imgLst;
        private System.Windows.Forms.Button butDeleteFolder;
        private System.Windows.Forms.Button butDeleteFile;
        private System.Windows.Forms.Button butCreateFolder;
        private System.Windows.Forms.Button butRename;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.Button butDisconnect;
        private System.Windows.Forms.ListView lsVLocal;
        private System.Windows.Forms.Button butDownload;
        private System.Windows.Forms.Button butUpload;
        private System.Windows.Forms.ComboBox cmb;

    }
}

