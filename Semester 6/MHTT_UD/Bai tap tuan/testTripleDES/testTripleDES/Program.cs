/*
// This sample demonstrates using a key based on the cryptographic service provider (CSP) version
// of the Data Encryption Standard (DES)algorithm to encrypt a string to a byte array, and then 
// to decrypt the byte array back to a string.

using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

class CryptoMemoryStream
{
    // Main method.
    public static void Main()
    {
        // Create a new DES key.
        DESCryptoServiceProvider key = new DESCryptoServiceProvider();

        // Encrypt a string to a byte array.
        byte[] buffer = Encrypt("This is some plaintext!", key);
        
        // Decrypt the byte array back to a string.
        string plaintext = Decrypt(buffer, key);

        // Display the plaintext value to the console.
        Console.WriteLine(plaintext);
    }

    // Encrypt the string.
    public static byte[] Encrypt(string PlainText, SymmetricAlgorithm key)
    {
        // Create a memory stream.
        MemoryStream ms = new MemoryStream();

        // Create a CryptoStream using the memory stream and the 
        // CSP DES key.  
        CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(), CryptoStreamMode.Write);

        // Create a StreamWriter to write a string
        // to the stream.
        StreamWriter sw = new StreamWriter(encStream);

        // Write the plaintext to the stream.
        sw.WriteLine(PlainText);

        // Close the StreamWriter and CryptoStream.
        sw.Close();
        encStream.Close();

        // Get an array of bytes that represents
        // the memory stream.
        byte[] buffer = ms.ToArray();

        // Close the memory stream.
        ms.Close();

        // Return the encrypted byte array.
        return buffer;
    }

    // Decrypt the byte array.
    public static string Decrypt(byte[] CypherText, SymmetricAlgorithm key)
    {
        // Create a memory stream to the passed buffer.
        MemoryStream ms = new MemoryStream(CypherText);

        // Create a CryptoStream using the memory stream and the 
        // CSP DES key. 
        CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(), CryptoStreamMode.Read);

        // Create a StreamReader for reading the stream.
        StreamReader sr = new StreamReader(encStream);

        // Read the stream as a string.
        string val = sr.ReadLine();

        // Close the streams.
        sr.Close();
        encStream.Close();
        ms.Close();

        return val;
    }
}
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace testTripleDES
{
    class Program
    {
        static void Main(string[] args)
        {
            EcryptFile(@"e:\test.txt", @"e:\out.txt", "123456789012345678901234");
            DecryptFile(@"e:\out.txt", @"e:\outDE.txt", "123456789012345678901234");
        }
        static void EcryptFile(string inputFile, string outputFile, string szSecureKey)
        {
            FileStream inStream, outStream;
            inStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
            TripleDESCryptoServiceProvider myDES = new TripleDESCryptoServiceProvider();
            Console.WriteLine(myDES.KeySize);
            myDES.Padding = PaddingMode.PKCS7;
            myDES.Key = ASCIIEncoding.ASCII.GetBytes(szSecureKey);
            myDES.IV = ASCIIEncoding.ASCII.GetBytes(szSecureKey.Substring(0, 8));
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

        static void DecryptFile(string inputFile, string outputFile, string szSecureKey)
        {
            FileStream inStream, outStream;
            inStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
            TripleDESCryptoServiceProvider myDES = new TripleDESCryptoServiceProvider();            
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
}

