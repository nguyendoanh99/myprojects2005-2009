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
    #region Attributes
    private string m_SecureKey = "";
    private int m_KeySize = 16;
    private string m_IV = "";
    private PaddingMode m_PaddingMode = PaddingMode.None;
    private CipherMode m_Mode = CipherMode.ECB;
    #endregion
    #region Properties
    public string SecureKey
    {
        get { return m_SecureKey; }
        set { m_SecureKey = value; }
    }
    public int KeySize
    {
        get { return m_KeySize; }
        set { m_KeySize = value; }
    }
    public string IV
    {
        get { return m_IV; }
        set { m_IV = value; }
    }
    public PaddingMode _PaddingMode
    {
        get { return m_PaddingMode; }
        set { m_PaddingMode = value; }
    }
    public CipherMode Mode
    {
        get { return m_Mode; }
        set { m_Mode = value; }
    }
    #endregion
    #region Contructors
    public CTripleDES()
    {
    }
    public CTripleDES(string szSecureKey, int iKeySize, string szIV, PaddingMode PM, CipherMode _Mode)
    {
        SecureKey = szSecureKey;
        KeySize = iKeySize;
        IV = szIV;
        _PaddingMode = PM;
        Mode = _Mode;
    }
    #endregion
    public void EcryptFile(string inputFile, string outputFile)
    {
        FileStream inStream, outStream;
        inStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
        outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
        try
        {
            TripleDESCryptoServiceProvider myDES = new TripleDESCryptoServiceProvider();
            MessageBox.Show(myDES.BlockSize.ToString());
            myDES.Padding = _PaddingMode;
            myDES.KeySize = KeySize;
            myDES.Key = ASCIIEncoding.ASCII.GetBytes(SecureKey);
            myDES.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            
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
        catch (System.Exception e)
        {
            outStream.Close();
            inStream.Close();
            throw;
        }
        
    }
    public void DecryptFile(string inputFile, string outputFile)
    {
        FileStream inStream, outStream;
        inStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
        outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
        try
        {
            TripleDESCryptoServiceProvider myDES = new TripleDESCryptoServiceProvider();
            myDES.KeySize = KeySize;
            myDES.Key = ASCIIEncoding.ASCII.GetBytes(SecureKey);
            myDES.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            myDES.Padding = _PaddingMode;
            myDES.Mode = Mode;

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
        catch (System.Exception e)
        {
            outStream.Close();
            inStream.Close();
            throw;
        }
        
    }
}
