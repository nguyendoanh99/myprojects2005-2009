using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
unsafe public class CLocal
{
    /// <summary>
    ///**************************************************/
    /// Them tat ca tap tin va thu muc tai thu muc hien hanh tren may tram
    /// vao ListView lsV    
    ///**************************************************/
    /// </summary>    
    public static void FillLocalListView(ListView lsV)
    {
        string strFileName;
        WIN32_FIND_DATA FindFileData = new WIN32_FIND_DATA();
        IntPtr hFindFile;
        int index = new int();

        lsV.Clear();

        string str = Directory.GetCurrentDirectory();
        if (str.LastIndexOf('\\') == str.Length - 1)
        {
            str += "*";
        }
        else
            str += "\\*";
        
        hFindFile = CAPIFunctions.FindFirstFile(str, FindFileData);        

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

            bool kq;
            while (kq = CAPIFunctions.FindNextFile(hFindFile, FindFileData))
            {
                if ((FindFileData.dwFileAttributes & FileAttribute.FILE_ATTRIBUTE_DIRECTORY) == FileAttribute.FILE_ATTRIBUTE_DIRECTORY)
                {
                    index = 0;
                    strFileName = FindFileData.cFileName + " <DIR>";
                }
                else
                {
                    strFileName = FindFileData.cFileName;
                    string temp = strFileName.Substring(strFileName.Length - 3, 3);
                    index = FTPClient.Form1.IndexImage(strFileName.Substring(strFileName.Length - 3, 3));
                }
                lsV.Items.Add(strFileName, index);
            }
///            CAPIFunctions.FindClose(hFindFile);
        }
    }
    /// <summary>
    ///**************************************************/
    /// Them tat ca tap tin va thu muc tai thu muc strFolder tren may tram
    /// vao ListView lsV  
    ///**************************************************/
    /// </summary>  
    public static void FillLocalListView(ListView lsV, String strFolder)
    {
        //set the new local working directory
        try
        {
            CAPIFunctions.SetCurrentDirectory(strFolder);
        }
        catch (DirectoryNotFoundException e)
        {
            MessageBox.Show("loi, SetCurrentDirectory");
        }
        //re-fill the local list with new directory
        FillLocalListView(lsV);
    }
}

