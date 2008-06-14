using System;
using System.Runtime.InteropServices;

public class FileAttribute
{
    public static uint FILE_ATTRIBUTE_READONLY             = 0x00000001;
    public static uint FILE_ATTRIBUTE_HIDDEN               = 0x00000002;  
    public static uint FILE_ATTRIBUTE_SYSTEM               = 0x00000004;  
    public static uint FILE_ATTRIBUTE_DIRECTORY            = 0x00000010;  
    public static uint FILE_ATTRIBUTE_ARCHIVE              = 0x00000020;  
    public static uint FILE_ATTRIBUTE_DEVICE               = 0x00000040;  
    public static uint FILE_ATTRIBUTE_NORMAL               = 0x00000080;  
    public static uint FILE_ATTRIBUTE_TEMPORARY            = 0x00000100;  
    public static uint FILE_ATTRIBUTE_SPARSE_FILE          = 0x00000200;  
    public static uint FILE_ATTRIBUTE_REPARSE_POINT        = 0x00000400;  
    public static uint FILE_ATTRIBUTE_COMPRESSED           = 0x00000800;  
    public static uint FILE_ATTRIBUTE_OFFLINE              = 0x00001000;  
    public static uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED  = 0x00002000;  
    public static uint FILE_ATTRIBUTE_ENCRYPTED            = 0x00004000;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class WIN32_FIND_DATA
{
    public int dwFileAttributes = 0;

    // creationTime was embedded FILETIME structure
    public int ftCreationTime_lowDateTime = 0;
    public int ftCreationTime_highDateTime = 0;

    // lastAccessTime was embedded FILETIME structure
    public int ftLastAccessTime_lowDateTime = 0;
    public int ftLastAccessTime_highDateTime = 0;

    // lastWriteTime was embedded FILETIME structure
    public int ftLastWriteTime_lowDateTime = 0;
    public int ftLastWriteTime_highDateTime = 0;

    public int nFileSizeHigh = 0;
    public int nFileSizeLow = 0;
    public int dwReserved0 = 0;
    public int dwReserved1 = 0;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public String cFileName = null;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
    public String cAlternateFileName = null;
}
/*
[StructLayout(LayoutKind.Sequential)]
public class WIN32_FIND_DATA
{
    
    public uint dwFileAttributes;  
//    public FILETIME ftCreationTime;  
//    public FILETIME ftLastAccessTime;  
//    public FILETIME ftLastWriteTime;

    public ulong ftCreationTime;
    public ulong ftLastAccessTime;
    public ulong ftLastWriteTime;  
    public uint nFileSizeHigh;  
    public uint nFileSizeLow;  
    public uint dwReserved0;  
    public uint dwReserved1;  
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
    public string cFileName; 
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=14)]
    public string cAlternateFileName;
}

*/