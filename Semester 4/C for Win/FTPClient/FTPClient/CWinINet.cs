using System;
using System.Runtime.InteropServices;
using System.Text;
/// <summary>
/// Summary description for Class1
/// </summary>
public class CWinINet
{    
    // InternetConnect --> uint dwAccessType 
    public static uint INTERNET_OPEN_TYPE_PRECONFIG                     = 0;   // use registry configuration    
    public static uint INTERNET_OPEN_TYPE_DIRECT                        = 1;   // direct to net
    public static uint INTERNET_OPEN_TYPE_PROXY                         = 3;   // via named proxy
    public static uint INTERNET_OPEN_TYPE_PRECONFIG_WITH_NO_AUTOPROXY   = 4;   // prevent using java/script/INS
    // InternetOpen --> uint dwFlags
    public static uint INTERNET_FLAG_ASYNC = 0x10000000;  // this request is asynchronous (where supported)
    public static uint INTERNET_FLAG_FROM_CACHE = 0x01000000;  // use offline semantics
    public static uint INTERNET_FLAG_OFFLINE = INTERNET_FLAG_FROM_CACHE;
    // InternetConnect --> ushort nServerPort
    public static ushort INTERNET_INVALID_PORT_NUMBER    = 0;           // use the protocol-specific default
    public static ushort INTERNET_DEFAULT_FTP_PORT       = 21;          // default for FTP servers
    public static ushort INTERNET_DEFAULT_GOPHER_PORT    = 70;          //    "     "  gopher "
    public static ushort INTERNET_DEFAULT_HTTP_PORT      = 80;          //    "     "  HTTP   "
    public static ushort INTERNET_DEFAULT_HTTPS_PORT     = 443;         //    "     "  HTTPS  "
    public static ushort INTERNET_DEFAULT_SOCKS_PORT     = 1080;        // default for SOCKS firewall servers.
    // InternetConnect --> uint dwService
    public static uint INTERNET_SERVICE_FTP     = 1;
    public static uint INTERNET_SERVICE_GOPHER  = 2;
    public static uint INTERNET_SERVICE_HTTP    = 3;
    // FtpGetFile --> uint dwFlags 
    public static uint FTP_TRANSFER_TYPE_UNKNOWN        = 0x00000000;
    public static uint FTP_TRANSFER_TYPE_ASCII          = 0x00000001;
    public static uint FTP_TRANSFER_TYPE_BINARY         = 0x00000002;
    public static uint INTERNET_FLAG_TRANSFER_ASCII     = FTP_TRANSFER_TYPE_ASCII;     // 0x00000001
    public static uint INTERNET_FLAG_TRANSFER_BINARY    = FTP_TRANSFER_TYPE_BINARY;    // 0x00000002
    // FtpFindFirstFile --> uint dwFlags 
    public static uint INTERNET_FLAG_NO_CACHE_WRITE    = 0x04000000;  // don't write this item to the cache
    public static uint INTERNET_FLAG_RESYNCHRONIZE     = 0x00000800;  // asking wininet to update an item if it is newer
    public static uint INTERNET_FLAG_HYPERLINK         = 0x00000400;  // asking wininet to do hyperlinking semantic which works right for scripts
    public static uint INTERNET_FLAG_NEED_FILE         = 0x00000010;  // need a file for this request
    public static uint INTERNET_FLAG_RELOAD            = 0x80000000;  // retrieve the original item

    public static uint GENERIC_READ                     = 0x80000000;
    public static uint GENERIC_WRITE                    = 0x40000000;

    [DllImport("Wininet.dll", EntryPoint="InternetOpen",
        ExactSpelling=false, CharSet=CharSet.Auto,
        SetLastError=true)]
    unsafe public static extern IntPtr InternetOpen(
      string lpszAgent,
      uint dwAccessType,
      string lpszProxyName,
      string lpszProxyBypass,
      uint dwFlags
    );

    [DllImport("Wininet.dll", EntryPoint = "InternetConnect",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern IntPtr InternetConnect(
      IntPtr hInternet,
      string lpszServerName,
      ushort nServerPort,
      string lpszUsername,
      string lpszPassword,
      uint dwService,
      uint dwFlags,
      uint dwContext
    );

    [DllImport("Wininet.dll", EntryPoint="FtpFindFirstFile",
        ExactSpelling=false, CharSet=CharSet.Auto,
        SetLastError=true)]
    unsafe public static extern IntPtr FtpFindFirstFile(
      IntPtr hConnect,
      string lpszSearchFile,      
      [In, Out] WIN32_FIND_DATA lpFindFileData,
      uint dwFlags,
      uint dwContext
    );

    [DllImport("Wininet.dll", EntryPoint = "InternetFindNextFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool InternetFindNextFile(
      IntPtr hFind,      
      [In, Out] WIN32_FIND_DATA lpvFindData
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpCreateDirectory",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FtpCreateDirectory(
      IntPtr hConnect,
      string lpszDirectory
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpDeleteFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FtpDeleteFile(
      IntPtr hConnect,
      string lpszFileName
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpGetCurrentDirectory",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FtpGetCurrentDirectory(
      IntPtr hConnect,
      StringBuilder lpszCurrentDirectory,
      ref uint lpdwCurrentDirectory
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpGetFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FtpGetFile(
      IntPtr hConnect,
      string lpszRemoteFile,
      string lpszNewFile,
      bool fFailIfExists,
      uint dwFlagsAndAttributes,
      uint dwFlags,
      uint dwContext
    );    

    [DllImport("Wininet.dll", EntryPoint = "FtpGetFileSize",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern uint FtpGetFileSize(
      IntPtr hFile,
      ref uint lpdwFileSizeHigh
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpOpenFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern IntPtr FtpOpenFile(
      IntPtr hConnect,
      string lpszFileName,
      uint dwAccess,
      uint dwFlags,
      uint dwContext
    );

    [DllImport("Wininet.dll", EntryPoint = "InternetCloseHandle",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool InternetCloseHandle(
      IntPtr hInternet
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpPutFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FtpPutFile(
      IntPtr hConnect,
      string lpszLocalFile,
      string lpszNewRemoteFile,
      uint dwFlags,
      uint dwContext
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpRemoveDirectory",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FtpRemoveDirectory(
      IntPtr hConnect,
      string lpszDirectory
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpRenameFile",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FtpRenameFile(
      IntPtr hConnect,
      string lpszExisting,
      string lpszNew
    );

    [DllImport("Wininet.dll", EntryPoint = "FtpSetCurrentDirectory",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool FtpSetCurrentDirectory(
      IntPtr hConnect,
      string lpszDirectory
    );

    [DllImport("Wininet.dll", EntryPoint = "InternetGetLastResponseInfo",
        ExactSpelling = false, CharSet = CharSet.Auto,
        SetLastError = true)]
    unsafe public static extern bool InternetGetLastResponseInfo(
      ref uint lpdwError,
      StringBuilder lpszBuffer,
      ref uint lpdwBufferLength
    );

}