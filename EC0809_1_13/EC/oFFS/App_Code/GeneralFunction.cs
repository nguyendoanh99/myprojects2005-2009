using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;


/// <summary>
/// Summary description for GeneralFunction
/// </summary>
public class GeneralFunction
{
    //convert hex to byte[]
    
    public static byte[] StringHex_To_Bytes(string strInput)
    {
        // i variable used to hold position in string
        int i = 0;
        // x variable used to hold byte array element position
        int x = 0;
        // allocate byte array based on half of string length
        byte[] bytes = new byte[(strInput.Length) / 2];
        // loop through the string - 2 bytes at a time converting it to decimal equivalent and store in byte array
        while (strInput.Length > i + 1)
        {
            long lngDecimal = Convert.ToInt32(strInput.Substring(i, 2), 16);
            bytes[x] = Convert.ToByte(lngDecimal);

            
            i = i + 2;
            ++x;
        }
        // return the finished byte array of decimal values
        return bytes;
    }

    public static string Bytes_To_String(byte[] bytes_Input)
    {
        // convert the byte array back to a true string
        string strTemp = "";
        for (int x = 0; x <= bytes_Input.GetUpperBound(0); x++)
        {
            //int number = int.Parse(bytes_Input[x].ToString());
            //strTemp += number.ToString("X").PadLeft(2, '0');
            strTemp += bytes_Input[x].ToString();
        }
        // return the finished string of hex values
        return strTemp;
    }
}
