// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

// Modify the following defines if you have to target a platform prior to the ones specified below.
// Refer to MSDN for the latest info on corresponding values for different platforms.
#ifndef WINVER				// Allow use of features specific to Windows XP or later.
#define WINVER 0x0501		// Change this to the appropriate value to target other versions of Windows.
#endif

#ifndef _WIN32_WINNT		// Allow use of features specific to Windows XP or later.                   
#define _WIN32_WINNT 0x0501	// Change this to the appropriate value to target other versions of Windows.
#endif						

#ifndef _WIN32_WINDOWS		// Allow use of features specific to Windows 98 or later.
#define _WIN32_WINDOWS 0x0410 // Change this to the appropriate value to target Windows Me or later.
#endif

#ifndef _WIN32_IE			// Allow use of features specific to IE 6.0 or later.
#define _WIN32_IE 0x0600	// Change this to the appropriate value to target other versions of IE.
#endif

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
// Windows Header Files:
#include <windows.h>

// C RunTime Header Files
#include <stdlib.h>
#include <malloc.h>
#include <memory.h>
#include <tchar.h>

// TODO: reference additional headers your program requires here
#include <commctrl.h>

typedef TCHAR* (*ham) (PWIN32_FIND_DATA); // Khai bao kieu con tro toi ham

struct ThongTin
{
	__int64 iKichThuoc;		// Kich thuoc cua thu muc (chi tinh cac file con, 
							// khong xet cac kich thuoc cac folder con)
	int iFolderCount;		// Tong so folder con hien co trong thu muc
	int iFileCount;			// Tong so file con hien co trong thu muc
};

#define	TREEVIEW_ITEM_MAX_LEN	128
#define	LISTVIEW_ITEM_MAX_LEN	128
#define PATHFILE_MAX_LEN		260
#define KHOANGCACH				5
#define NUM_COLUMN				4

#define	CX_ICON_SMALL		16
#define	CY_ICON_SMALL		16

#define	CX_ICON_LARGE		32
#define	CY_ICON_LARGE		32

#define NUM_ICONS			1

// Cac ham xu ly chung
void ThemPhay(TCHAR *t); // Them mot so dau phay de ngan cach cum 3 chu so trong chuoi so t
void LayThongTinODia(TCHAR *szODia, TCHAR *szThongTin); // Lay cac thong tin cua o dia
void ErrorExit(LPTSTR lpszFunction); // Ham thong bao loi
//__int64 DuyetThuMuc(TCHAR *szDuongDan); // Lay kich thuoc cua thu muc
TCHAR * HienThiDungLuong(__int64 size); // size tinh bang byte chuyen thanh KB, MB, GB ... 

TCHAR* GetSize(PWIN32_FIND_DATA FindFileData); // Lay kich thuoc cua tap tin
TCHAR* GetAttribute(PWIN32_FIND_DATA FindFileData); // Lay thuoc tinh cua tap tin
TCHAR* GetDateModified(PWIN32_FIND_DATA FindFileData); // Lay ngay cap nhat moi nhat cua tap tin

// Cac ham lien quan den TreeView
void doCreate_TreeView(HWND hWnd);
BOOL initTreeViewItems();
HTREEITEM addItemToTree(TCHAR *szItemText, TCHAR *szLParam, HTREEITEM &hParent, HTREEITEM &hPrev, BOOL bChildren);
BOOL CoChuaThuMucCon(TCHAR* szDuongDan); 
BOOL TV_ThemThuMucCon(TCHAR* sjzDuongDan, const HTREEITEM&);
BOOL TV_ThemODia();
void XuLy_TVNITEMEXPAND(HWND hWnd, WPARAM wParam, LPARAM lParam);
void XuLy_TVNSELCHANGE(HWND hWnd, WPARAM wParam, LPARAM lParam);
HTREEITEM TV_FindItem(HTREEITEM hParent, TCHAR *sz);
BOOL initTreeViewImageLists();

// Cac ham lien quan den ListView
void doCreate_ListView(HWND hWnd);
BOOL initListViewItems();
BOOL addInfoToListView(HTREEITEM hParent);
int LV_ThemFie(TCHAR* szDuongDan, int index); // Tra ve tong so tap tin tim thay
void XuLy_LV_NMDBLCLK(HWND hWnd, WPARAM wParam, LPARAM lParam);
void XuLy_LV_ITEMCHANGING(HWND hWnd, WPARAM wParam, LPARAM lParam);
BOOL initListViewColumns();
void doListView_ViewOption(HWND hWnd, int nViewStyle);//, int IdMenuChecked);
BOOL initListViewImageLists();

// Cac ham lien quan den status bar
void CapNhatStatusBar();

// Cac ham lien quan den Toolbar
void doCreate_Toolbar(HWND hWnd);
void XuLy_PB_BACK_CLICKED();
void XuLy_PB_FORWARD_CLICKED();
void XuLy_PB_UP_CLICKED();
void XuLy_PB_SEARCH_CLICKED(HWND hWnd, WPARAM wParam, LPARAM lParam);
void XuLy_PB_MOVETO_CLICKED(HWND hWnd, WPARAM wParam, LPARAM lParam);
void XuLy_PB_COPYTO_CLICKED(HWND hWnd, WPARAM wParam, LPARAM lParam);
void XuLy_PB_DELETE_CLICKED(HWND hWnd, WPARAM wParam, LPARAM lParam);
void XuLy_ComboBox();