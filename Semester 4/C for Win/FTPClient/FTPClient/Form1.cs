using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FTPClient
{
    public partial class Form1 : Form
    {
        private CFtp m_ftp;
        private static int index = 0;        // Dung cho combobox
        /// <summary>
        /// Lay chi so index cua image tuong ung voi loai tap tin
        /// Tham so:
        ///  str: ten loai tap tin
        /// Tra ve:
        ///  chi so cua image
        /// </summary>
        public static int IndexImage(string str)
        {
            switch (str)
            {
                case ".doc":
                    return 2;
                case ".xls":
                    return 3;
                case ".ppt":
                    return 4;
                case ".mdb":
                    return 5;
                case ".txt":
                    return 6;
                case ".zip":
                    return 7;
                case ".rar":
                    return 8;
                case ".pdf":
                    return 9;
                default:
                    return 1;
            }
        }
        public Form1()
        {
            InitializeComponent();
            // Sua thanh ten cua ung dung
            m_ftp = new CFtp();
        }

        private void lsVRemote_DoubleClick(object sender, EventArgs e)
        {
            String strFile;

            try
            {
                int t = lsVRemote.FocusedItem.Index;                    
            }
            catch (Exception e1)
            {
                return;
            }
            //get directory that user double-clicked
            strFile = lsVRemote.FocusedItem.Text;
            int iLen = strFile.Length;
            strFile = strFile.Replace(" <DIR>", "");
            if (strFile.Length == iLen)
                return;

            m_ftp.FillRemoteListView(lsVRemote, strFile);
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            String strFile;

            try
            {
                int t = lsVRemote.FocusedItem.Index;    
            }
            catch (Exception e1)
            {
                return;
            }
            //get directory that user double-clicked
            strFile = lsVRemote.FocusedItem.Text;
            int iLen = strFile.Length;
            strFile = strFile.Replace(" <DIR>", "");
            if (strFile.Length == iLen)
                return;

            if (m_ftp.DeleteFolder(strFile))
                lsVRemote.Items.RemoveAt(lsVRemote.FocusedItem.Index);
            else
            {
                MessageBox.Show("Lỗi !!! Không thể xóa " + strFile, "Thông báo");
            }
        }

        private void butDeleteFile_Click(object sender, EventArgs e)
        {
            String strFile;

            try
            {
                int t = lsVRemote.FocusedItem.Index;
            }
            catch (Exception e1)
            {
                return;
            }
            //get directory that user double-clicked
            strFile = lsVRemote.FocusedItem.Text;
            int iLen = strFile.Length;
            strFile = strFile.Replace(" <DIR>", "");
            if (strFile.Length != iLen)
                return;

            if (m_ftp.DeleteFile(strFile) == true)
                lsVRemote.Items.RemoveAt(lsVRemote.FocusedItem.Index);
            else
            {
                MessageBox.Show("Lỗi !!! Không thể xóa " + strFile, "Thông báo");
            }
        }

        private void butCreateFolder_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();            
            frm.Text = "Create New Folder";
            frm.lblCaption.Text = "Folder Name";            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (m_ftp.CreateFolder(Program.strInput))
                {
                    Program.strInput += " <DIR>";
                    lsVRemote.Items.Add(Program.strInput, 0);
                }
                else
                {
                    MessageBox.Show("Lỗi !!! Không thể tạo thư mục " + Program.strInput + " được.", "Thông báo");
                }
            }
        }

        private void butRename_Click(object sender, EventArgs e)
        {
            String strFile;
            try
            {
                int t = lsVRemote.FocusedItem.Index;
            }
            catch
            {
                return;
            }            

            Form2 frm = new Form2();
            frm.Text = "Rename";
            frm.lblCaption.Text = "New File Name";            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bool flag = false;
                strFile = lsVRemote.FocusedItem.Text;
                int iLen = strFile.Length;
                strFile = strFile.Replace(" <DIR>", "");
                if (strFile.Length != iLen)
                    flag = true;

                if (m_ftp.Rename(strFile, Program.strInput))
                {
                    if (flag)
                        Program.strInput += " <DIR>";
                    lsVRemote.FocusedItem.Text = Program.strInput;
                }
                else
                {
                    MessageBox.Show("Lỗi !!! Không thể đổi tên được.", "Thông báo");
                }
            }            
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (butDisconnect.Enabled == true)
            {
                if (MessageBox.Show("Bạn đang kết nối với FTP server. Bạn có muốn ngắt kết nối đó không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    flag = m_ftp.Disconnect();
                    if (flag == true)
                    {
                        lsVRemote.Clear();
                        KichHoat(false);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi !!! Không thể ngắt kết nối được");
                    }
                }
                else
                    return;
            }

            flag = false;
            if (new FormLogIn().ShowDialog() == DialogResult.OK)
            {
                flag = m_ftp.Connect(Program.strHostname, Program.strUsername, Program.strPassword);
                if (flag == true)
                {
                    m_ftp.FillRemoteListView(lsVRemote);
                }
                else
                {
                    MessageBox.Show("Lỗi !!! Không đăng nhập được.");
                }                
            }

            KichHoat(flag);
        }

        private void butDisconnect_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn ngắt kết nối không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool flag = m_ftp.Disconnect();
                if (flag == true)
                {
                    lsVRemote.Clear();
                    KichHoat(false);
                }
                else
                {
                    MessageBox.Show("Lỗi !!! Không thể ngắt kết nối được");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] t = DriveInfo.GetDrives();
            for (int i = 0; i < t.Length; ++i)
            {
                try
                {
                    cmb.Items.Add(t[i].Name + " (" + t[i].VolumeLabel + ")");
                }
                catch (Exception e1)
                {
                    cmb.Items.Add(t[i].Name);
                }
            }

            cmb.SelectedIndex = 0;            
        }

        private void lsVLocal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String strFile;

            try
            {
                int t = lsVLocal.FocusedItem.Index;                    
            }
            catch (Exception e1)
            {
                return;
            }
            //get directory that user double-clicked
            strFile = lsVLocal.FocusedItem.Text;
            int iLen = strFile.Length;
            strFile = strFile.Replace(" <DIR>", "");
            if (strFile.Length == iLen)
                return;

            CLocal.FillLocalListView(lsVLocal, strFile);
        }

        private void lsVRemote_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsVLocal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butDownload_Click(object sender, EventArgs e)
        {            
            String strFile;

            try
            {
                int t = lsVRemote.FocusedItem.Index;
            }
            catch (Exception e1)
            {
                return;
            }

            //get directory that user double-clicked
            strFile = lsVRemote.FocusedItem.Text;
            int iLen = strFile.Length;
            strFile = strFile.Replace(" <DIR>", "");
            // Tap tin
            bool flag = new bool();
            if (strFile.Length == iLen)
                flag = m_ftp.DownloadFile(strFile);
            else // Thu muc
                flag = m_ftp.DownloadFolder(strFile);

            if (flag == true)
                lsVLocal.Items.Add(lsVRemote.FocusedItem.Text, lsVRemote.FocusedItem.ImageIndex);
            else
            {
                MessageBox.Show("Lỗi !!! Không thể download "+ strFile, "Thông báo");
            }
        }

        private void butUpload_Click(object sender, EventArgs e)
        {
            String strFile;

            try
            {
                int t = lsVLocal.FocusedItem.Index;                    
            }
            catch (Exception e1)
            {
                return;
            }
            //get directory that user double-clicked
            strFile = lsVLocal.FocusedItem.Text;
            int iLen = strFile.Length;
            strFile = strFile.Replace(" <DIR>", "");
            // Tap tin
            bool flag = new bool();
            if (strFile.Length == iLen)
                flag = m_ftp.UploadFile(strFile);
            else // Thu muc
                flag = m_ftp.UploadFolder(strFile);

            if (flag == true)
            {
                lsVRemote.Items.Add(lsVLocal.FocusedItem.Text, lsVLocal.FocusedItem.ImageIndex);
            }
            else
            {
                MessageBox.Show("Lỗi !!! Không thể upload " + strFile, "Thông báo");
            }
        }
        // Bat hoac tat cac nut duoc chi dinh
        void KichHoat(bool flag)
        {
            butDisconnect.Enabled = flag;
            butDeleteFile.Enabled = flag;
            butDownload.Enabled = flag;
            butUpload.Enabled = flag;
            butCreateFolder.Enabled = flag;
            butDeleteFolder.Enabled = flag;
            butRename.Enabled = flag;
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //set the new remote working directory

            //Set the current directory.
            try
            {
                Directory.SetCurrentDirectory(cmb.SelectedItem.ToString().Substring(0,3));
                CLocal.FillLocalListView(lsVLocal);
                index = cmb.SelectedIndex;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Lỗi !!! Không thể truy cập ổ đĩa " + cmb.SelectedItem.ToString().Substring(0, 3));
                cmb.SelectedIndex = index;
            }            
        }
    }
}