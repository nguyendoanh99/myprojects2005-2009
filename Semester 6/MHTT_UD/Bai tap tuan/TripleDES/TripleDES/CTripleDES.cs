using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// Summary description for Class1
/// </summary>
public class CTripleDES
{
    public static void EcryptFile(string inputFile, string outputFile, string szSecureKey, int iKeySize)
    {
        FileStream inStream, outStream;
        
        TripleDESCryptoServiceProvider myDES = new TripleDESCryptoServiceProvider();
        myDES.Padding = PaddingMode.PKCS7;
        myDES.KeySize = iKeySize;
        myDES.Key = ASCIIEncoding.ASCII.GetBytes(szSecureKey);
        myDES.IV = ASCIIEncoding.ASCII.GetBytes(szSecureKey.Substring(0, 8));

        inStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
        outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
        ICryptoTransform myDES_Ecryptor = myDES.CreateEncryptor();
        CryptoStream myEncryptStream;
        myEncryptStream = new CryptoStream(outStream, myDES_Ecryptor, CryptoStreamMode.Write);

        byte[] byteBuffer = new byte[100];
        long nTotalByteInput = inStream.Length, nTotalByteWritten = 0;
        int nCurReadLen = 0;
        while (nTotalByteWritten < nTotalByteInput)
        {
            nCurReadLen = inStream.Read(byteBuffer, 0, byteBuffer.Length);
            myEncryptStream.Write(byteBuffer, 0, nCurReadLen);
            nTotalByteWritten += nCurReadLen;
        }
        myEncryptStream.Close();
        outStream.Close();
        inStream.Close();
    }
    public static void DecryptFile(string inputFile, string outputFile, string szSecureKey, int iKeySize)
    {
        FileStream inStream, outStream;
        inStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
        outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
        TripleDESCryptoServiceProvider myDES = new TripleDESCryptoServiceProvider();
        myDES.KeySize = iKeySize;
        myDES.Key = ASCIIEncoding.ASCII.GetBytes(szSecureKey);
        myDES.IV = ASCIIEncoding.ASCII.GetBytes(szSecureKey.Substring(0, 8));
        myDES.Padding = PaddingMode.PKCS7;
        ICryptoTransform myDES_Ecryptor = myDES.CreateDecryptor();
        CryptoStream myEncryptStream;
        myEncryptStream = new CryptoStream(outStream, myDES_Ecryptor, CryptoStreamMode.Write);
        byte[] byteBuffer = new byte[100];
        long nTotalByteInput = inStream.Length, nTotalByteWritten = 0;
        int nCurReadLen = 0;
        while (nTotalByteWritten < nTotalByteInput)
        {
            nCurReadLen = inStream.Read(byteBuffer, 0, byteBuffer.Length);
            myEncryptStream.Write(byteBuffer, 0, nCurReadLen);
            nTotalByteWritten += nCurReadLen;
        }
        myEncryptStream.Close();
        outStream.Close();
        inStream.Close();
    }
}
