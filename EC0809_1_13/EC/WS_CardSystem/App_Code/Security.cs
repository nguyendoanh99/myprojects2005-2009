using System;
using System.Text;
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
/// Summary description for Security
/// </summary>
public class Security
{
    static private string _keyValue = "oFFS";
    public string KeyValue
    {
        set { _keyValue = value; }
        get { return _keyValue; }
    }
    /*
	static public string Decrypt(string code)
	{
        string de_code = "";
        byte[] inputByteArray = Convert.FromBase64String(code);

        de_code = Encoding.UTF8.GetString(inputByteArray);

        return de_code.Substring(0, de_code.Length - _keyValue.Length);

        //byte[] data = new byte[DATA_SIZE];
        //byte[] result;

        //SHA1 sha = new SHA1CryptoServiceProvider();
        // This is one implementation of the abstract class SHA1.
        //result = sha.ComputeHash(data);
	}
*/

    static public string Decrypt(string code)
    {
        string result = "";
        Byte[] hashbytes = Encoding.UTF8.GetBytes(code);
        SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
        Byte[] de_code = sha.ComputeHash(hashbytes);
        Convert.ToBase64String(de_code);

        foreach(char n in de_code)
        {
            result += n;
        }
        return result;
    }

    /*
    Public Function EncryptPassword(ByVal password As String) As String

Dim encoding As New UnicodeEncoding

Dim b As Byte

Dim strReturn As String = ""
    
Dim hashBytes As Byte() = encoding.GetBytes(password)

' Compute the SHA-1 hash

Dim sha1 As New SHA1CryptoServiceProvider

Dim cryptPassword = sha1.ComputeHash(hashBytes)

Return Convert.ToBase64String(cryptPassword)

For Each b In cryptPassword

strReturn = strReturn & b

Next b

Return strReturn

End Function

    */
}
