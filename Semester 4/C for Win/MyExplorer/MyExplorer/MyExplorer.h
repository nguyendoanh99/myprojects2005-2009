#pragma once

#include "MyStatusBar.h"
#include "MyToolBar.h"
#include "resource.h"

HWND hwndTreeView;
HWND hwndListView;
HWND hwndComboBox;
CMyStatusBar statusBar;
CMyToolBar toolBar;
ThongTin HienHanh;			// Thong tin ve thu muc hien hanh
HTREEITEM BackForward[10];	// Dung cho nut Back va Forward
int iIndex;					// Dung de luu chi so hien tai cua mang BackForward
BOOL bFlag;					// true: vua nhan nut Back hoac Forward

// Xu ly Drap drop
// Xu ly resize, chinh kich thuoc cua listview, treeview
// Chua xu ly nut expand

//	GetLogicalDrives
//	GetLogicalDriveStrings 
//	GetDriveType
//	GetDiskFreeSpace
//	GetVolumeInformation
//	SHGetFileInfo
//	GetFileSize
//	GetFileAttributes
//	FindFirstFile
///	FindNextFile 
	//wsprintf
	//StrChr
//	GetCurrentDirectory
