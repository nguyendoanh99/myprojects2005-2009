using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class _FileProcess
{
    public static String ReadFile(String FileName)
    {
        String result = "";
        try
        {
            StreamReader sr = new StreamReader(FileName);
            result = sr.ReadToEnd();
            sr.Close();
        }
        catch (Exception e)
        {
            ;
        }
        return result;
    }
    public static Boolean WriteFile(String FileName, String str)
    {
        Boolean result = false;
        try
        {
            StreamWriter sw = new StreamWriter(FileName);
            sw.WriteLine(str);
            sw.Close();
            result = true;
        }
        catch (Exception e)
        {
            ;
        }
        return result;
    }
}

