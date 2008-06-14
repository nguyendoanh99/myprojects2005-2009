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
    public static Boolean Ghi(String Chuoi,String TenFile)
    {
        Boolean flag=true;
        try
        {
            StreamWriter Bo_ghi = new StreamWriter(TenFile);
            Bo_ghi.Write(Chuoi);
            Bo_ghi.Flush();
            Bo_ghi.Close();
        }
        catch (Exception e)
        {
            flag = false;
        }
        return flag;
    }
   }

