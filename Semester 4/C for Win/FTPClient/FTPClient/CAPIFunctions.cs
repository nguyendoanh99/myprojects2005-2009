using System;
using System.Runtime.InteropServices;
using System.Text;

public class CAPIFunctions
{    
    [DllImport("kernel32.dll", EntryPoint = "SetCurrentDirectory",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool SetCurrentDirectory(
      string lpPathName
    );

    [DllImport("kernel32.dll", EntryPoint = "GetCurrentDirectory",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern uint GetCurrentDirectory(
      uint nBufferLength,
      StringBuilder lpBuffer
    );

    [DllImport("kernel32.dll", EntryPoint = "GetLastError",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern uint GetLastError();

    [DllImport("kernel32.dll", EntryPoint = "FindFirstFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern IntPtr FindFirstFile(
        string lpFileName,
        [In, Out] WIN32_FIND_DATA lpFindFileData
    );

    [DllImport("kernel32.dll", EntryPoint = "FindNextFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FindNextFile(
      IntPtr hFindFile,
      [In, Out] WIN32_FIND_DATA lpFindFileData
    );

    [DllImport("kernel32.dll", EntryPoint = "FindNextFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FindClose(
      IntPtr hFindFile
    );


}

