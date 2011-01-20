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
using System.Text;
using System.Net.Mail;
using System.Net;
/// <summary>
/// Summary description for Utilities
/// </summary>
/// //     void mail()
//     {
// 
//         
// 
//     }
public class Utilities
{
    // Acc google
    // username: "ec0809.1.13@gmail.com"
    // password: "mouse2monitor"
    public static string SendMail(String from, String to, string subject, string body)
    {
        try
        {
            MailMessage mail = new MailMessage(from, to, subject, body);
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Credentials = new NetworkCredential(from, "mouse2monitor");
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(mail);
        }
        catch (Exception e)
        {
            return e.ToString();
        }
        return "";
    }
	public Utilities()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    static public string SHA1(string str)
    {
        HashAlgorithm ha = new SHA1CryptoServiceProvider();
        string result = "";
        try
        {
            Encoding e = new ASCIIEncoding();
            byte[] inStr = e.GetBytes(str);
            byte[] hash = ha.ComputeHash(inStr);
            result = ConvertToHexa(hash);
        }
        catch (System.Exception e1)
        {
        }
        return result;
    }
    public static string ConvertToHexa(byte[] obj)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < obj.Length; ++i)
        {
            result.Append(string.Format("{0,2:X}", obj[i]).Replace(' ', '0'));

        }
        return result.ToString();
    }
}
