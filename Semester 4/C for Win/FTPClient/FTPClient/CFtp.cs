using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FTPClient;
/// <summary>
/// Summary description for Class1
/// </summary>
unsafe public class CFtp
{    
    private IntPtr m_HConnect;   // giu handle cua InternetConnect
    private Form3 frm;
	public CFtp()
	{        
		//
		// TODO: Add constructor logic here
		//
        m_HConnect = new IntPtr(0);
	} 
    /// <summary>
    ///**************************************************/
    /// Tao ket noi den FTP
    /// Tham so:
    ///  lpszServerNam:  IP hoac ten may muon ket noi toi
    ///  lpszUsername:   Username dung de ket noi
    ///  lpszPassword:   Password dung de ket noi
    /// Tra ve:
    ///  true:   thanh cong
    ///  false:  that bai
    ///**************************************************/
    /// </summary>    
    public bool Connect(string lpszServerName, string lpszUsername, string lpszPassword)
    {
        if (m_HConnect.ToPointer() != null)
        {
            // Xu ly neu da co ket noi den FTP roi
            CWinINet.InternetCloseHandle(m_HConnect);
        }
        
        m_HConnect = CWinINet.InternetConnect(FTPClient.Program.m_HOpen, lpszServerName, CWinINet.INTERNET_DEFAULT_FTP_PORT,
                    lpszUsername, lpszPassword, CWinINet.INTERNET_SERVICE_FTP, 0x08000000, 0);

//        bool k = CWinINet.FtpSetCurrentDirectory(m_HConnect, "12");
//        uint err = new uint();
//        StringBuilder subBlock = new StringBuilder(256);
//        uint len = 260;
//        bool kq2 = CWinINet.InternetGetLastResponseInfo(ref err, subBlock, ref len);
//        bool kq2 = CWinINet.FtpGetCurrentDirectory(m_HConnect, subBlock, ref len);
//        bool kq2 = CWinINet.FtpDeleteFile(m_HConnect, "12.txt"); 
//        CAPIFunctions.SetCurrentDirectory("C:\\");
//       bool kq2 = CWinINet.FtpRemoveDirectory(m_HConnect, "2/3");
//        bool kq2 = CWinINet.FtpPutFile(m_HConnect, "Chuyen Tinh Ao Ca - Quang Linh.mp3",
//            "Chuyen Tinh Ao Ca - Quang Linh.mp3", CWinINet.FTP_TRANSFER_TYPE_BINARY, 0);
//        bool kq2 = CWinINet.FtpGetFile(m_HConnect, "kv.txt", "kv.txt", false, 0x00000080, CWinINet.FTP_TRANSFER_TYPE_BINARY, 0);
//        uint err = CAPIFunctions.GetLastError();
//        IntPtr h = CWinINet.FtpOpenFile(m_HConnect, "kv.txt", 
//            CWinINet.GENERIC_READ, CWinINet.FTP_TRANSFER_TYPE_BINARY, 0);
//        uint len2 = new uint();
//        uint len1 = CWinINet.FtpGetFileSize(h, ref len2);
//        CWinINet.InternetCloseHandle(h);
//        CWinINet.FtpRenameFile(m_HConnect, "kv.txt", "kv2.txt");      
//        WIN32_FIND_DATA t = new WIN32_FIND_DATA();
//        IntPtr kq = CWinINet.FtpFindFirstFile(m_HConnect, null, t, 0x80000000, 0);
//        bool kq1 = CWinINet.InternetFindNextFile(kq, t);
//        kq1 = CWinINet.InternetFindNextFile(kq, t);
//        kq1 = CWinINet.InternetFindNextFile(kq, t);
        return m_HConnect.ToPointer() != null;
    }
    /// <summary>
    ///**************************************************/
    /// Them tat ca tap tin va thu muc tai thu muc hien hanh tren FTP server
    /// vao ListView lsV    
    ///**************************************************/
    /// </summary>    
    public void FillRemoteListView(ListView lsV)
    {
        string strFileName;
        WIN32_FIND_DATA FindFileData = new WIN32_FIND_DATA();
        IntPtr hFindFile;
        int index = new int();

        lsV.Clear();

        hFindFile = CWinINet.FtpFindFirstFile(m_HConnect, null, FindFileData, 
            CWinINet.INTERNET_FLAG_RELOAD, 0);
        if (hFindFile.ToPointer() != null)
        {
            if ((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY)
            {
                index = 0;
                strFileName = FindFileData.cFileName + " <DIR>";
            }
            else
            {
                strFileName = FindFileData.cFileName;                
                index = FTPClient.Form1.IndexImage(strFileName.Substring(strFileName.Length - 3, 3));                
            }
            lsV.Items.Add(strFileName, index);

            bool kq;
            while (kq = CWinINet.InternetFindNextFile(hFindFile, FindFileData))
            {
                if ((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY)
                {
                    index = 0;
                    strFileName = FindFileData.cFileName + " <DIR>";
                }
                else
                {
                    strFileName = FindFileData.cFileName;

                    string temp = "";
                    try
                    {
                        temp = strFileName.Substring(strFileName.Length - 4, 4);                        
                    }
                    catch (Exception e1)
                    {
                    }
                    index = FTPClient.Form1.IndexImage(temp);
                }
                lsV.Items.Add(strFileName, index);
            }
            CWinINet.InternetCloseHandle(hFindFile);
        }
    }
    /// <summary>
    ///**************************************************/
    /// Them tat ca tap tin va thu muc tai thu muc strFolder tren FTP server
    /// vao ListView lsV  
    ///**************************************************/
    /// </summary>  
    public void FillRemoteListView(ListView lsV, String strFolder)
    {      
        //set the new remote working directory
        if (!CWinINet.FtpSetCurrentDirectory(m_HConnect, strFolder))
        {
            Console.WriteLine("loi, FtpSetCurrentDirectory");
            //ProcessInternetError();
        }

        //re-fill the remote list with new directory
        FillRemoteListView(lsV);
    }
    /// <summary>
    /// Xoa tat ca cac tap tin va thu muc con ben trong thu muc strFolder
    /// tren FTP server
    /// Tham so:
    ///  strFolder: ten thu muc muon xoa
    /// </summary>  
    private bool _DeleteFolder(String strFolder)
    {
        StringBuilder szPath = new StringBuilder(256);
        uint uiLen = 256;
        WIN32_FIND_DATA FindFileData = new WIN32_FIND_DATA();
        IntPtr hFindFile;

        if (CWinINet.FtpSetCurrentDirectory(m_HConnect, strFolder) == false)
            return false;

        hFindFile = CWinINet.FtpFindFirstFile(m_HConnect, null, FindFileData, 
            CWinINet.INTERNET_FLAG_RELOAD, 0);

        if (hFindFile.ToPointer() != null)
        {
            // Xoa tat ca cac tap tin
            if (!((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY))
                if (CWinINet.FtpDeleteFile(m_HConnect, FindFileData.cFileName) == false)
                    return false;
     
            while (CWinINet.InternetFindNextFile(hFindFile, FindFileData))
            {
                if (!((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY))
                    if (!CWinINet.FtpDeleteFile(m_HConnect, FindFileData.cFileName))
                        return false;
            }

            CWinINet.InternetCloseHandle(hFindFile);
            // Xoa tat ca cac thu muc 
            do
            {
                hFindFile = CWinINet.FtpFindFirstFile(m_HConnect, null, FindFileData,
                CWinINet.INTERNET_FLAG_RELOAD, 0);

                if (hFindFile.ToPointer() != null)
                {
                    CWinINet.InternetFindNextFile(hFindFile, FindFileData); // Bo qua thu muc ".."
                    if (CWinINet.InternetFindNextFile(hFindFile, FindFileData))
                    {
                        CWinINet.InternetCloseHandle(hFindFile);
                        return _DeleteFolder(FindFileData.cFileName);

                        if (!CWinINet.FtpRemoveDirectory(m_HConnect, FindFileData.cFileName))
                            return false;
                    }
                    else
                    {
                        CWinINet.InternetCloseHandle(hFindFile);
                        break;
                    }
                }
                else
                    break;
            }
            while (true);
            // Tra ve thu muc hien hanh
            uiLen = 256;
            if (CWinINet.FtpGetCurrentDirectory(m_HConnect, szPath, ref uiLen) == false)
                return false;
            if (CWinINet.FtpSetCurrentDirectory(m_HConnect, szPath.ToString() + "//..") == false)
                return false;
        }
        return true;
    }
    /// <summary>
    /// Xoa tat ca cac tap tin va thu muc con ben trong thu muc strFolder,
    /// va ca thu muc strFolder tren FTP server
    /// Tham so:
    ///  strFolder: ten thu muc muon xoa
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>  
    public bool DeleteFolder(String strFolder)
    {
        bool flag = _DeleteFolder(strFolder); 
        return flag && CWinINet.FtpRemoveDirectory(m_HConnect, strFolder);
    }
    /// <summary>
    /// Xoa tap tin strFile tai thu muc hien hanh tren FTP server
    /// Tham so:
    ///  strFile: ten file muon xoa
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>
    public bool DeleteFile(String strFile)
    {
        return CWinINet.FtpDeleteFile(m_HConnect, strFile);
    }
    /// <summary>
    /// Tao thu muc moi tai thu muc hien hanh tren FTP server
    /// Tham so:
    ///  strFolder: ten thu muc muon tao moi
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>
    public bool CreateFolder(String strFolder)
    {
        if (CWinINet.FtpSetCurrentDirectory(m_HConnect, strFolder) == true)
        {
            CWinINet.FtpSetCurrentDirectory(m_HConnect, "..");
            return false;
        }
        return CWinINet.FtpCreateDirectory(m_HConnect, strFolder);
    }
    /// <summary>
    /// Doi ten thu muc (hay tap tin) tai thu muc hien hanh tren FTP server
    /// Tham so:
    ///  strFolder: ten thu muc (tap tin) muon doi ten
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>
    public bool Rename(String strOld, String strNew)
    {
        return CWinINet.FtpRenameFile(m_HConnect, strOld, strNew);
    }
    /// <summary>
    /// Ngat ket noi voi FTP server
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>
    public bool Disconnect()
    {
        bool kq = CWinINet.InternetCloseHandle(m_HConnect);
        m_HConnect = new IntPtr(0);

        return kq;
    }
    /// <summary>
    /// Download tat ca cac tap tin va thu muc con ben trong thu muc strFolder
    /// tren FTP server
    /// Tham so:
    ///  strFolder: ten thu muc muon download   
    /// </summary>  
    private bool _DownloadFolder(String strFolder)
    {
        StringBuilder szPath = new StringBuilder(256);
        String arrFolder = null;        
        uint uiLen = 256;
        WIN32_FIND_DATA FindFileData = new WIN32_FIND_DATA();
        IntPtr hFindFile;

        if (CWinINet.FtpSetCurrentDirectory(m_HConnect, strFolder) == false)
            return false;

        try
        {
            Directory.SetCurrentDirectory(strFolder);
        }
        catch (Exception e)
        {
            return false;
        }

        hFindFile = CWinINet.FtpFindFirstFile(m_HConnect, null, FindFileData,
            CWinINet.INTERNET_FLAG_RELOAD, 0);
        if (hFindFile.ToPointer() != null)
        {
            // Download tat ca cac tap tin ve may tram
            if (!((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY))
            {
                if (!CWinINet.FtpGetFile(m_HConnect, FindFileData.cFileName, FindFileData.cFileName,
                        true, FileAttribute.FILE_ATTRIBUTE_NORMAL, CWinINet.FTP_TRANSFER_TYPE_BINARY, 0))
                    return false;
            }
            else // Thu muc
            {
                if (FindFileData.cFileName != ".")
                {
                    arrFolder += "|" + FindFileData.cFileName;
                }
            }

            while (CWinINet.InternetFindNextFile(hFindFile, FindFileData))
            {
                if (!((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY))
                {
                    if (!CWinINet.FtpGetFile(m_HConnect, FindFileData.cFileName, FindFileData.cFileName,
                        true, FileAttribute.FILE_ATTRIBUTE_NORMAL, CWinINet.FTP_TRANSFER_TYPE_BINARY, 0))
                        return false;
                }
                else // Thu muc
                    if (FindFileData.cFileName != "..")
                    {
                        arrFolder += "|" + FindFileData.cFileName;
                    }
            }
            if (CWinINet.InternetCloseHandle(hFindFile) == false)
                return false;
            // Download tat ca cac thu muc ve may tram
            if (arrFolder != null)
            {
                string[] arr = arrFolder.Split('|');
                for (int i = 1; i < arr.Length; ++i)
                {
                    try
                    {
                        Directory.CreateDirectory(arr[i]);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }

                    return _DownloadFolder(arr[i]);
                }
            }
            // Tra ve thu muc hien hanh
            uiLen = 256;
            if (CWinINet.FtpGetCurrentDirectory(m_HConnect, szPath, ref uiLen) == false)
                return false;

            if (CWinINet.FtpSetCurrentDirectory(m_HConnect, szPath.ToString() + "//..") == false)
                return false;

            try
            {
                Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "\\..");
            }
            catch (Exception e)
            {
                return false;
            }            
        }
        return true;
    }
    /// <summary>
    /// Download tat ca cac tap tin va thu muc con ben trong thu muc strFolder,
    /// va ca thu muc strFolder tren FTP server
    /// Tham so:
    ///  strFolder: ten thu muc muon download
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>  
    public bool DownloadFolder(String strFolder)
    {
        try
        {
            Directory.SetCurrentDirectory(strFolder);
            Directory.SetCurrentDirectory("..");
            return false;
        }
        catch (Exception e)
        {            
        }

        try
        {
            Directory.CreateDirectory(strFolder);
        }
        catch (FileNotFoundException e)
        {
            return false;
        }

        return _DownloadFolder(strFolder);        
    }
    /// <summary>
    /// Download tap tin strFile tai thu muc hien hanh tren FTP server
    /// Tham so:
    ///  strFile: ten file muon download
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>
    public bool DownloadFile(String strFile)
    {
        return CWinINet.FtpGetFile(m_HConnect, strFile, strFile,
                    true, FileAttribute.FILE_ATTRIBUTE_NORMAL, CWinINet.FTP_TRANSFER_TYPE_BINARY, 0);
    }
    /// <summary>
    /// Upload tat ca cac tap tin va thu muc con ben trong thu muc strFolder
    /// cua may tram len FTP server
    /// Tham so:
    ///  strFolder: ten thu muc muon Upload
    /// </summary>  
    private bool _UploadFolder(String strFolder)
    {
        StringBuilder szPath = new StringBuilder(256);
        String arrFolder = null;
        uint uiLen = 256;
        WIN32_FIND_DATA FindFileData = new WIN32_FIND_DATA();
        IntPtr hFindFile;

        if (CWinINet.FtpSetCurrentDirectory(m_HConnect, strFolder) == false)
            return false;
        else
        {
            uiLen = 256;
            CWinINet.FtpGetCurrentDirectory(m_HConnect, szPath, ref uiLen);
        }

        try
        {
            Directory.SetCurrentDirectory(strFolder);
        }
        catch (Exception e)
        {
            return false;
        }

        string str = Directory.GetCurrentDirectory();
        if (str.LastIndexOf('\\') == str.Length - 1) // O dia        
            str += "*";        
        else // Thu muc
            str += "\\*";

        hFindFile = CAPIFunctions.FindFirstFile(str, FindFileData);
        if (hFindFile.ToPointer() != null)
        {
            // Upload tat ca cac tap tin len FTP server
            if (!((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY))
            {
                if (!CWinINet.FtpPutFile(m_HConnect, FindFileData.cFileName, FindFileData.cFileName,
                        CWinINet.FTP_TRANSFER_TYPE_BINARY, 0))
                    return false;
                else
                    frm.lbl.Text = szPath + "\\"+ FindFileData.cFileName;
            }
            else // Thu muc
            {
                if (FindFileData.cFileName != ".")                
                    arrFolder += "|" + FindFileData.cFileName;                
            }

            while (CAPIFunctions.FindNextFile(hFindFile, FindFileData))
            {
                if (!((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY))
                {
                    if (!CWinINet.FtpPutFile(m_HConnect, FindFileData.cFileName, FindFileData.cFileName,
                        CWinINet.FTP_TRANSFER_TYPE_BINARY, 0))
                        return false;
                    else
                        frm.lbl.Text = szPath +"\\" +FindFileData.cFileName;
                }
                else // Thu muc
                    if (FindFileData.cFileName != "..")
                    {
                        arrFolder += "|" + FindFileData.cFileName;
                    }
            }
            CWinINet.InternetCloseHandle(hFindFile);
            // Upload tat ca cac thu muc ve FTP Server
            if (arrFolder != null)
            {
                string[] arr = arrFolder.Split('|');
                for (int i = 1; i < arr.Length; ++i)
                {
                    try
                    {
                        CWinINet.FtpCreateDirectory(m_HConnect, arr[i]);
                    }
                    catch (FileNotFoundException e)
                    {
                        return false;
                    }

                    return _UploadFolder(arr[i]);
                }
            }
            // Tra ve thu muc hien hanh
            uiLen = 256;
            if (CWinINet.FtpGetCurrentDirectory(m_HConnect, szPath, ref uiLen) == false)
                return false;
            if (CWinINet.FtpSetCurrentDirectory(m_HConnect, szPath.ToString() + "//..") == false)
                return false;

            try
            {
                Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "\\..");
            }
            catch (Exception e)
            {
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// Upload tat ca cac tap tin va thu muc con ben trong thu muc strFolder,
    /// va ca thu muc strFolder cua may tram len FTP server
    /// Tham so:
    ///  strFolder: ten thu muc muon upload
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>  
    public bool UploadFolder(String strFolder)
    {
        if (CWinINet.FtpSetCurrentDirectory(m_HConnect, strFolder) == true)
        {
            CWinINet.FtpSetCurrentDirectory(m_HConnect, "..");
            return false;
        }

        try
        {
            CWinINet.FtpCreateDirectory(m_HConnect, strFolder);
        }
        catch (FileNotFoundException e)
        {
            return false;
        }

//        frm = new Form3();
//        frm.Show();
        bool flag = _UploadFolder(strFolder);
//        frm.Close();
        return flag;        
    }
    /// <summary>
    /// Upload tap tin strFile tai may tram len FTP server
    /// Tham so:
    ///  strFile: ten file muon upload
    /// Tra ve:
    ///  true: thanh cong
    ///  false: that bai
    /// </summary>
    public bool UploadFile(String strFile)
    {
        IntPtr t = CWinINet.FtpOpenFile(m_HConnect, strFile, CWinINet.GENERIC_READ, CWinINet.FTP_TRANSFER_TYPE_BINARY, 0);
        if (t.ToPointer() != null)
        {
            CWinINet.InternetCloseHandle(t);
            return false;
        }
        return CWinINet.FtpPutFile(m_HConnect, strFile, strFile,
                    CWinINet.FTP_TRANSFER_TYPE_BINARY, 0);
    }
}