using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class XuLyTapTin
{
    public static Boolean KiemTra(String TenTapTin)
    {
        if (!File.Exists(TenTapTin))
        {
            Console.WriteLine("{0} khong ton tai.", TenTapTin);
            return false;
        }
        return true;
    }
    public static void Ghi(String TenFile,String NoiDung)
    {
        StreamWriter BoGhi = new StreamWriter(TenFile);
        BoGhi.Write(NoiDung);
        BoGhi.Close();
    }
    public static String Doc(String TenTapTin)
    {
        String temp = "";
        try
        {
            StreamReader BoDoc = new StreamReader(TenTapTin);
            temp = BoDoc.ReadToEnd();
            BoDoc.Close();
        }
        catch (Exception e)
        {
        }
        return temp;
    }
}

