// stdafx.cpp : source file that includes just the standard includes
// MyExplorer.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "Resource.h"
#include <winbase.h>
#include <shellapi.h>
#include "MyStatusBar.h"
#include "MyToolBar.h"
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
extern HINSTANCE		hInst;
extern HWND hwndTreeView;
extern HWND hwndListView;
extern HWND hwndComboBox;
extern CMyStatusBar statusBar;
extern CMyToolBar toolBar;
extern ThongTin HienHanh; // Thong tin ve thu muc hien hanh
extern HTREEITEM BackForward[10];	// Dung cho nut Back va Forward
extern int iIndex;					// Dung de luu chi so hien tai cua mang BackForward
extern BOOL bFlag;					// true: vua nhan nut Back hoac Forward
DWORD DWErr; // Bien kiem tra loi
//  ---------------------------------------------------------------------
//    doCreate_TreeView Function
//		Ham tao lap 1 Tree View
//  ---------------------------------------------------------------------
void doCreate_TreeView(HWND hWnd)
{
	// Kich thuoc vung Client
	RECT rcClient;  
 
    GetClientRect(hWnd, &rcClient); 
	hwndTreeView = CreateWindowEx(WS_EX_ACCEPTFILES, 
		WC_TREEVIEW, 
		_T("tree view"),
		WS_CHILD | WS_BORDER | TVS_EDITLABELS | TVS_LINESATROOT |
		TVS_HASBUTTONS | TVS_HASLINES | TVS_SHOWSELALWAYS | WS_VISIBLE,
		0, 0, 0, 0, 
		hWnd,
		(HMENU) IDTV_TREEVIEW,
		hInst,
		NULL);

//	initTreeViewItems();
//	
	//TreeView_SetBkColor(HTreeViewWnd,RGB(0,54,100));
	//TreeView_SetTextColor(HTreeViewWnd,RGB(133,54,100));

	// Add cac phan tu vao TreeView
    if (!initTreeViewImageLists() || !initTreeViewItems()) 
	{ 
		MessageBox(hWnd, _T("Khong khoi tao duoc Image-list hay khong add duoc cac item vao TreeView. \nHuy bo TreeView."), 
					_T("Add error"), MB_OK);
		DestroyWindow(hwndTreeView); 
		hwndTreeView = NULL; 
		return;
	}
} 

//  ---------------------------------------------------------------------
//    initTreeViewItems Function
//		Ham khoi tao va Add cac item vao TreeView
//		Cac item duoc lay tu My Computer
//  ---------------------------------------------------------------------
BOOL initTreeViewItems() 
{ 	
	HTREEITEM hParent = TVI_ROOT;
	HTREEITEM hPrev = NULL;
	// Them My Computer vao TreeView
	addItemToTree(_T("My Computer"), NULL, hParent, hPrev, TRUE);
	// Them cac o dia vao TreeView	
	TV_ThemODia();
	
	return TRUE;
} 
//  ---------------------------------------------------------------------
//    addItemToTree Function
//		Ham Add 1 item vao TreeView
//		+ bChildren:	= TRUE: item nay co con, nguoc lai: item nay khong co con
//		+ hParent:		handle cua parent item
//		+ hPrev:		handle cua item dung truoc
//  ---------------------------------------------------------------------
HTREEITEM addItemToTree(TCHAR *szItemText, TCHAR* szLParam, HTREEITEM &hParent, HTREEITEM &hPrev, BOOL bChildren)
{
	// Cau truc 1 thanh phan (Item) cua Tree-View
	TVITEM tvi; // tvi.LParam chua dia chi cua chuoi duong dan, va phan tu cuoi
				// cung cua chuoi cho biet o dia hay thu muc da duoc mo hay chua
    TVINSERTSTRUCT tvins; 
	SHFILEINFO psfi;

	HIMAGELIST himl1 = TreeView_GetImageList(hwndTreeView, TVSIL_NORMAL);
//	HIMAGELIST himl2 = TreeView_GetImageList(hwndTreeView, TVSIL_STATE);
	// Khoi tao 1 item cua Tree-View
	
	// Open icon
//	SHGetFileInfo(szLParam, 0, &psfi2, sizeof ( SHFILEINFO ), SHGFI_ICON | SHGFI_OPENICON);
//	ImageList_AddIcon(himl2, psfi2.hIcon);
	
	// Normal icon
	SHGetFileInfo(szLParam, 0, &psfi, sizeof ( SHFILEINFO ), SHGFI_ICON 
		| SHGFI_SMALLICON);
	ImageList_AddIcon(himl1, psfi.hIcon);	

	tvi.mask = TVIF_TEXT | TVIF_PARAM | TVIF_CHILDREN  | TVIF_SELECTEDIMAGE | TVIF_IMAGE;
	tvi.cChildren = bChildren;
	tvi.pszText = szItemText;
	tvi.lParam = (LPARAM) szLParam;
	tvi.iImage = ImageList_GetImageCount(himl1) - 1;
	tvi.iSelectedImage = tvi.iImage;

	// Image cua item - default la IDB_DOC
//	tvi.iImage = 0;					// Index cua anh, dung cho trang thai closed (non-selected)
  //  tvi.iSelectedImage = 0;			// Index cua anh, dung cho trang thai opened (selected)
  
	// Khoi tao cau truc TVINSERTSTRUCT dung de them 1 item vao Tree-View
	
	// Xac dinh vi tri cua item can them
	// Neu la phan tu dau tien -> la goc

	tvins.item = tvi;
	tvins.hParent = hParent;
	tvins.hInsertAfter = hPrev;
	// Add item vao Tree-View
	HTREEITEM kq = TreeView_InsertItem(hwndTreeView, &tvins);
	// Cap nhat Image cua Parent -> IDB_CLOSED / IDB_OPENED
//	if (nLevel > 0) {
  //      tvi.mask = TVIF_IMAGE | TVIF_SELECTEDIMAGE; 
    //    tvi.hItem = hParent; 
      //  tvi.iImage = 1; 
//        //tvi.iSelectedImage = 2; 
  //      TreeView_SetItem(HTreeViewWnd, &tvi); 
	//}
	return kq;
}

void LayThongTinODia(TCHAR *szODia, TCHAR *szThongTin)
{
	// Nhung bien nay dung cho ham GetVolumeInformation
	TCHAR szVolumeName[256];
	DWORD DWVolumeSerialNumber;
	DWORD DWMaximumComponentLength;
	DWORD DWFileSystemFlags;
	
	// Tat cac thong bao loi
	SetErrorMode(SEM_FAILCRITICALERRORS);

	DWErr = GetVolumeInformation(szODia, 
			szVolumeName, 256,
			&DWVolumeSerialNumber,
			&DWMaximumComponentLength,
			&DWFileSystemFlags,
			NULL, 0);
	if (DWErr == 0)
	{
		if (GetLastError() == 21) // Loi khong co dia trong o dia mem hoac CD-ROM
		{
			UINT t = GetDriveType(szODia);
			switch (t)
			{
			case DRIVE_CDROM:
				wcscpy_s(szVolumeName, _T("CD-ROM Drive"));
				break;
			case DRIVE_REMOVABLE:
				wcscpy_s(szVolumeName, _T("Floppy Drive"));
				break;
			}
		}
		else
			ErrorExit(_T("\"GetVolumeInformation\""));		
	}

	// Truong hop o dia khong co ten
	if (_tcslen(szVolumeName) == 0)
	{
		UINT t = GetDriveType(szODia);
		switch (t)
		{
		case DRIVE_CDROM:
			wcscpy_s(szVolumeName, _T("CD-ROM Drive"));
			break;
		case DRIVE_REMOVABLE:
			wcscpy_s(szVolumeName, _T("Removable Hard Disk"));
			break;
		case DRIVE_RAMDISK:
			wcscpy_s(szVolumeName, _T("RAM Disk"));
			break;
		case DRIVE_FIXED:
			wcscpy_s(szVolumeName, _T("Local Disk"));
			break;
		}
	}

	szODia[2] = '\0';
	wsprintf(szThongTin, _T("%s (%s)"), szVolumeName, szODia); 
	szODia[2] = '\\';

	// Bat lai cac thong bao loi
	SetErrorMode(0);
}

void ErrorExit(LPTSTR lpszFunction) 
{
	TCHAR szBuf[80]; 
	LPVOID lpMsgBuf;
	DWORD dw = GetLastError(); 

	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER | 
		FORMAT_MESSAGE_FROM_SYSTEM,
		NULL,
		dw,
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		(LPTSTR) &lpMsgBuf,
		0, NULL );

	wsprintf(szBuf, 
		_T("%s failed with error %d: %s"), 
		 lpszFunction, dw, lpMsgBuf); 
 
	MessageBox(NULL, szBuf, _T("Error"), MB_OK); 
	LocalFree(lpMsgBuf);
    ExitProcess(dw); 
}
void XuLy_TVNITEMEXPAND(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	NMTREEVIEW* kq=(NMTREEVIEW*) lParam;	

//	kq->itemNew.mask = TVIF_PARAM;
	// Loi chua xac dinh
//	if (TreeView_GetItem(hwndTreeView, &kq->itemNew) == FALSE)
//	{
//		ErrorExit(_T("XuLy_ITEMEXPAND() \"TreeView_GetItem\""));
//	}
	TCHAR *temp = (TCHAR*) kq->itemNew.lParam;
	if (temp == NULL) // Nut My Computer
		return;
	
	size_t len = wcslen(temp);
	// Neu o dia, thu muc chua duoc expand lan nao thi moi them thu muc con vao
	// TreeView
	if (temp[len + 1] == 0)
	{
		TV_ThemThuMucCon(temp, kq->itemNew.hItem);
		temp[len + 1] = 1;
	}
	//MessageBox(hWnd, temp, _T("Thong bao"), 0);
}
// Kiem tra o dia, thu muc co rong hay khong
// Tra ve TRUE: O dia hay thu muc co chua thu muc 
// FALSE: O dia hay thu muc khong chua thu muc 
// O cuoi szDuongDan phai chua "\*" 
BOOL CoChuaThuMucCon(TCHAR* szDuongDan)
{
	  WIN32_FIND_DATA FindFileData;
	  HANDLE hFind;

	  // Tat tat ca cac thong bao loi
	  SetErrorMode(SEM_FAILCRITICALERRORS);

	  hFind = FindFirstFile(szDuongDan, &FindFileData);
	  if (hFind == INVALID_HANDLE_VALUE) 
	  {
		  int t = GetLastError();
		  if (t == 21 // O CD, Floppy disk chua co dia
			  || t == 2 // Khong tim thay file nao, tuc o dia rong
			  || t == 5 // Access is denied
			  )
		  {
			  // Bat cac thong bao loi
			  SetErrorMode(0);
			  return FALSE;
		  }
		  // Bat cac thong bao loi
		  SetErrorMode(0);
		  // Loi chua xac dinh
		  ErrorExit(_T("CoChuaThuMucCon() \"FindFirstFile\""));
	  }
	  else
	  {
		  // Bat cac thong bao loi
		  SetErrorMode(0);		
		  // La thu muc
		  if (wcscmp(FindFileData.cFileName, _T(".")) == 0)
		  {
			  FindNextFile(hFind, &FindFileData); //FindFileData.cFileName = ".."
			  // Khong co thu muc con
			  if (!FindNextFile(hFind, &FindFileData))
				  return FALSE;	
		  }
		  else; // La o dia
		  // Tim thu muc con dau tien
		  do
		  {
			  // Co thu muc con
			  if (FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
			  {
				  FindClose(hFind);
				  return TRUE;
			  }			  
		  } while (FindNextFile(hFind, &FindFileData));
		  // Khong co thu muc con
		  FindClose(hFind);
		  return FALSE;			 		
	  }
  }
// Them tat ca cac thu muc con vao TreeView tai nut dang duoc chon
BOOL TV_ThemThuMucCon(TCHAR* szDuongDan, const HTREEITEM& T)
{
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind;
	HTREEITEM hParent = T;
	HTREEITEM hPrev = NULL;
	TCHAR temp[265];
	
	wsprintf(temp, _T("%s*"), szDuongDan);
	hFind = FindFirstFile(temp, &FindFileData);
	if (hFind == INVALID_HANDLE_VALUE) 
	{
		int t = GetLastError();
		if (t == 21 // O CD, Floppy disk chua co dia
		  || t == 2) // Khong tim thay file nao, tuc o dia rong
		  return FALSE;
		// Loi chua xac dinh
		ErrorExit(_T("\"ThemThuMucCon() FindFirstFile\""));
	}

	// La thu muc
	if (wcscmp(FindFileData.cFileName, _T(".")) == 0)
	{
		// Bo qua thu muc ..
		FindNextFile(hFind, &FindFileData);
		FindNextFile(hFind, &FindFileData);
	}
	else; // La o dia

	bool flag = false;
	size_t len = wcslen(szDuongDan);

	wcscpy_s(temp, szDuongDan);
	
	// Tim tat ca cac thu muc con 
	size_t len1;
	do
	{
		// Thu muc
		if (FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
		{
			// Them vao cuoi chuoi duong dan cu ten thu muc vua tim duoc 
			// va chuoi "\*" de kiem tra thu muc nay co chua thu muc con hay khong
			temp[len] = 0;
			wcscat_s(temp, FindFileData.cFileName);
			len1 = wcslen(temp);
			temp[len1] = '\\';
			temp[len1 + 1] = '\0';
//			temp[len1 + 2] = '\0';

			// Tham so szLParam trong ham addItemToTree
			TCHAR *szLParam = new TCHAR[len1 + 3];
			wcscpy_s(szLParam, len1 + 3, temp);
			szLParam[len1 + 2] = 0; // Thong bao thu muc nay chua duoc expand lan nao

			temp[len1 + 1] = '*';
			temp[len1 + 2] = '\0';
			
			// Them thu muc con vao nut cha
			flag = true;
						
			hPrev = addItemToTree(FindFileData.cFileName, szLParam, hParent, hPrev, CoChuaThuMucCon(temp));
		}			  
	} while (FindNextFile(hFind, &FindFileData));
	FindClose(hFind);
	return flag;
}

// Them tat ca cac o dia hien co vao nut ROOT cua TreeView
BOOL TV_ThemODia()
{
	TCHAR szChuoiODia[101]; // Luu cac o dia hien co trong My Computer

	DWErr = GetLogicalDriveStrings(101, szChuoiODia); // Lay cac o dia co trong My Computer
	// Loi chua xac dinh
	if (DWErr == 0)
		ErrorExit(_T("ThemODia() \"GetLogicalDriveStrings\""));

	TCHAR szThongTin[PATHFILE_MAX_LEN];
	TCHAR *temp = szChuoiODia;
	TCHAR *szLParam; // szLParam[5] cho biet o dia da duoc expand lan nao chua
	TCHAR t[6];

	HTREEITEM hParent = TreeView_GetRoot(hwndTreeView);
	HTREEITEM hPrev = NULL;

	for (int i = 0; temp[i]; i += 4)
	{		
		szLParam = new TCHAR[5];
		wsprintf(szLParam, _T("%s"), temp + i);
		szLParam[4] = 0;

		// Lay thong tin ve o dia (Ten o dia)
		LayThongTinODia(temp + i, szThongTin);
		wsprintf(t, _T("%s*"), temp + i);	

		hPrev = addItemToTree(szThongTin, szLParam, hParent, hPrev, CoChuaThuMucCon(t));
	}

	return TRUE;
}

void XuLy_TVNSELCHANGE(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	NMTREEVIEW* kq=(NMTREEVIEW*) lParam;

//	kq->itemNew.mask = TVIF_HANDLE;
	// Loi chua xac dinh
//	if (TreeView_GetItem(hwndTreeView, &kq->itemNew) == FALSE)
//	{
//		ErrorExit(_T("XuLy_SELCHANGE() \"TreeView_GetItem\""));
//	}
	 
	TreeView_Expand(hwndTreeView, kq->itemNew.hItem, TVE_EXPAND);
	
	if (!bFlag)
	{
		// Neu da het cho de luu vet thi bo phan tu dau tien de co cho
		// luu vet
		if (iIndex >= 10)
		{
			for (int i = 0; i < iIndex; ++i)
				BackForward[i] = BackForward[i + 1];

			--iIndex;
		}
	
		BackForward[++iIndex] = kq->itemNew.hItem;
		// Bo cac ket qua cu
		if (iIndex + 1 < 10)
			BackForward[iIndex + 1] = NULL;
	}

	bFlag = FALSE;
	// Dua noi dung cua thu muc vua chon vao ListView
	addInfoToListView(kq->itemNew.hItem);
}

void doCreate_ListView(HWND hWnd)
{
	RECT rcClient; 
	RECT rcTreeView;

	
	GetClientRect(hWnd, &rcClient); 
	GetClientRect(hwndTreeView, &rcTreeView);
	// Tao List View
	hwndListView = CreateWindow(WC_LISTVIEW, NULL, 
						WS_VISIBLE | WS_CHILD | WS_BORDER| LVS_EDITLABELS 
						| LVS_ICON | LVS_ALIGNLEFT, 
						0, 0, 0, 0, 
						hWnd, 
						(HMENU) IDLV_LISTVIEW, 
						hInst, 
						NULL); 

	if (!initListViewColumns() || !initListViewItems() || !initListViewImageLists() )
	{ 
		MessageBox(hWnd, _T("Khong khoi tao duoc Image-list hay khong tao duoc cac item. \nHuy bo ListView."), 
					_T("Add error"), MB_OK);
		DestroyWindow(hwndListView); 
		hwndListView = NULL; 
		return;
	}

	
} 
//  ---------------------------------------------------------------------
//    initListViewItems Function
//		Ham khoi tao va Add cac item vao ListView
//  ---------------------------------------------------------------------
BOOL initListViewItems()
{
	LV_ITEM		lvItem;		// Cau truc mo ta 1 Item cua ListView
	TCHAR		szItemText[LISTVIEW_ITEM_MAX_LEN];	// Text (Label) cua item
	int			nItem;
	wcscpy_s(szItemText, _T("My Computer"));
	// Khoi tao cac gia tri cho item
	lvItem.mask = LVIF_TEXT | LVIF_PARAM;//| LVIF_STATE ;
//	lvItem.state = 0;
//	lvItem.stateMask = 0;

	for (int idx = 0; idx < 1; idx++)
	{
		lvItem.iItem = idx;
//		lvItem.iImage = idx;
		lvItem.iSubItem = 0;
		lvItem.pszText = szItemText;
		
		// Field lParam duoc dung trong ham so sanh (pfnCompare) khi can sort item
		// Truong hop nay, ta nen luu lai index cua item
		lvItem.lParam = idx;  
		// Chen item vao ListView
		nItem = ListView_InsertItem(hwndListView, &lvItem);
		if(nItem == -1)	return FALSE;
	}

	return TRUE;
}

// Dua cac thu muc con va tap tin cua thu muc chi dinh vao ListView (Doi voi thu muc)
// Dua cac o dia hien co vao ListView (Doi voi My Computer

BOOL addInfoToListView(HTREEITEM hParent)
{
	HIMAGELIST himl1 = ListView_GetImageList(hwndListView, LVSIL_SMALL);
	HIMAGELIST himl2 = ListView_GetImageList(hwndListView, LVSIL_NORMAL);

	SHFILEINFO psfi;
	LV_ITEM		lvItem;		// Cau truc mo ta 1 Item cua ListView
	int			nItem;
	TVITEM		kq;
	TCHAR		szText[PATHFILE_MAX_LEN];
	int			index = 0; // index cua item cua ListView
	HTREEITEM	hItem;
	// Tao gia tri ban dau cho thu muc hien hanh
	HienHanh.iFolderCount = 0; // So thu muc con co trong thu muc hien hanh
	HienHanh.iKichThuoc = 0;
	HienHanh.iFileCount = 0;
	// Xoa noi dung cu cua ListView
	ListView_DeleteAllItems(hwndListView);

	for (int i = 0; i < ImageList_GetImageCount(himl1); ++i)
	{
		DestroyIcon(ImageList_GetIcon(himl1, i, 0));
		DestroyIcon(ImageList_GetIcon(himl2, i, 0));
	}
	ImageList_RemoveAll(himl1);
	ImageList_RemoveAll(himl2);

	// Khoi tao cac gia tri cho item
	lvItem.mask = LVIF_TEXT | LVIF_IMAGE | LVIF_PARAM;
	kq.mask = TVIF_TEXT | TVIF_PARAM;
	kq.pszText = szText;
	kq.cchTextMax = PATHFILE_MAX_LEN;
	// Them thu muc vao ListView
	if (hItem = TreeView_GetChild(hwndTreeView, hParent))
	{
		do
		{
			kq.hItem = hItem;
			TreeView_GetItem(hwndTreeView, &kq);
			
			SHGetFileInfo((TCHAR*) kq.lParam, 0, &psfi, sizeof ( SHFILEINFO ), SHGFI_ICON 
				| SHGFI_SMALLICON);
			ImageList_AddIcon(himl1, psfi.hIcon);	
			
			SHGetFileInfo((TCHAR*) kq.lParam, 0, &psfi, sizeof ( SHFILEINFO ), SHGFI_ICON 
				| SHGFI_LARGEICON);
			ImageList_AddIcon(himl2, psfi.hIcon);	

			lvItem.pszText = szText;
			lvItem.iItem = index;
			lvItem.iImage = ImageList_GetImageCount(himl1) - 1;
			lvItem.iSubItem = 0;
			
			// Field lParam duoc dung trong ham so sanh (pfnCompare) khi can sort item
			// Truong hop nay, ta nen luu lai index cua item
			lvItem.lParam = index;  
			// Chen item vao ListView
			nItem = ListView_InsertItem(hwndListView, &lvItem);
			if(nItem == -1)	
				return FALSE;
	
			// Them thong tin cua cac cot con lai (Col #1, #2, #3) cho item 
//			GetDriveType
			WIN32_FIND_DATA FindFileData;
			TCHAR temp[PATHFILE_MAX_LEN];
			
			// Lay duong dan cua thu muc
			wcscpy_s(temp, (TCHAR*) kq.lParam);
			temp[wcslen(temp) - 1] = '\0';
			
			if (wcslen(temp) == 2 && temp[1] == ':') // O dia
			{
				// Thong tin cua o dia
			}
			else
			{
				HANDLE hFind = FindFirstFile(temp, &FindFileData);
				if (hFind == INVALID_HANDLE_VALUE) 
				{
					int t = GetLastError();
					if (t == 21 // O CD, Floppy disk chua co dia
					  || t == 2) // Khong tim thay file nao, tuc o dia rong
					  continue;
					// Loi chua xac dinh
					ErrorExit(_T("\"addInfoToListView() FindFirstFile\""));
				}
				
				TCHAR szItemText[LISTVIEW_ITEM_MAX_LEN];
				// Con tro ham
				ham f[3] = {GetSize,
							GetAttribute,
							GetDateModified};

				++HienHanh.iFolderCount;
				TCHAR *temp1;
				for(int c = 0; c < 3; c++)
				{
					temp1 = f[c](&FindFileData);
					wcscpy_s(szItemText, temp1);
					
					LV_ITEM		lvsItem;	
					lvsItem.mask = LVIF_TEXT;// | LVIF_IMAGE;
					lvsItem.iItem=nItem;
					lvsItem.iSubItem=c + 1;
					lvsItem.pszText=szItemText;
				//	lvsItem.iImage=2;
					ListView_SetItem(hwndListView,&lvsItem);
					delete []temp1;
				}
				FindClose(hFind);
			}
			++index;
		}	
		while (hItem = TreeView_GetNextSibling(hwndTreeView, hItem));
	}
	// Them file vao ListView
	kq.mask = TVIF_PARAM;
	kq.hItem = hParent;
	TreeView_GetItem(hwndTreeView, &kq);
	HienHanh.iFileCount = LV_ThemFie((TCHAR*) kq.lParam, index); 

	CapNhatStatusBar();
	return TRUE;
}
// Them cac tap tin trong thu muc duoc chi dinh vao ListView
// Index bat dau cua cac tap tin duoc them vao ListView
// Gia tri tra ve:
// TRUE:	them duoc file vao ListView
// FALSE:	khong them duoc file vao ListView
int LV_ThemFie(TCHAR* szDuongDan, int index)
{
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind;
	TCHAR temp[265];
	LVITEM lvItem;
	int nItem;
	int iCount = 0; // Tong so tap tin co trong thu muc 
	
	if (!szDuongDan)
		return iCount;

	wsprintf(temp, _T("%s*"), szDuongDan);
	hFind = FindFirstFile(temp, &FindFileData);
	if (hFind == INVALID_HANDLE_VALUE) 
	{
		int t = GetLastError();
		if (t == 21 // O CD, Floppy disk chua co dia
		  || t == 2 // Khong tim thay file nao, tuc o dia rong
		  || t == 5)// Tap tin khong duoc phep truy xuat
		  return iCount;
		// Loi chua xac dinh
		ErrorExit(_T("\"LV_ThemFile() FindFirstFile\""));
	}

	// La thu muc
	if (wcscmp(FindFileData.cFileName, _T(".")) == 0)
	{
		// Bo qua thu muc ..
		FindNextFile(hFind, &FindFileData);
		FindNextFile(hFind, &FindFileData);
	}
	else; // La o dia

	lvItem.mask = LVIF_TEXT | LVIF_PARAM | LVIF_IMAGE;
	HIMAGELIST himl1 = ListView_GetImageList(hwndListView, LVSIL_SMALL);
	HIMAGELIST himl2 = ListView_GetImageList(hwndListView, LVSIL_NORMAL);
	SHFILEINFO psfi;
	// Tim tat ca cac tap tin con 
	HienHanh.iKichThuoc = 0;
	do
	{
		// Lay tat ca cac file khong phai la thu muc
		if (!(FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY))
		{
			wsprintf(temp, _T("%s%s"), szDuongDan, FindFileData.cFileName);
			SHGetFileInfo(temp, 0, &psfi, sizeof ( SHFILEINFO ), SHGFI_ICON 
				| SHGFI_SMALLICON);
			ImageList_AddIcon(himl1, psfi.hIcon);	
			
			SHGetFileInfo(temp, 0, &psfi, sizeof ( SHFILEINFO ), SHGFI_ICON 
				| SHGFI_LARGEICON);
			ImageList_AddIcon(himl2, psfi.hIcon);

			++iCount;
			
			lvItem.pszText = FindFileData.cFileName;
			lvItem.iItem = index;
			lvItem.iImage = ImageList_GetImageCount(himl1) - 1;
			lvItem.iSubItem = 0;
			// Field lParam duoc dung trong ham so sanh (pfnCompare) khi can sort item
			// Truong hop nay, ta nen luu lai index cua item
			lvItem.lParam = index;  
			// Chen item vao ListView
			nItem = ListView_InsertItem(hwndListView, &lvItem);
			if(nItem == -1)	
				return 0;
			
			// Them thong tin cua cac cot con lai (Col #1, #2, #3) cho item 
			TCHAR szItemText[LISTVIEW_ITEM_MAX_LEN];
			// Con tro ham
			ham f[3] = {GetSize,
						GetAttribute,
						GetDateModified};
			// Cong kich thuoc cua file vao kich thuoc cua thu muc			
			HienHanh.iKichThuoc += (FindFileData.nFileSizeHigh * (__int64(MAXDWORD) + 1)) + FindFileData.nFileSizeLow;

			TCHAR *temp;
			for(int c = 0; c < 3; c++)
			{
				temp = f[c](&FindFileData);
				wcscpy_s(szItemText, temp);
				
				LV_ITEM		lvsItem;	
				lvsItem.mask = LVIF_TEXT;// | LVIF_IMAGE;
				lvsItem.iItem=nItem;
				lvsItem.iSubItem=c + 1;
				lvsItem.pszText=szItemText;
			//	lvsItem.iImage=2;
				ListView_SetItem(hwndListView,&lvsItem);
				delete []temp;
			}

			++index;
		}			  
	} while (FindNextFile(hFind, &FindFileData));
	FindClose(hFind);
	return iCount;
}

void XuLy_LV_NMDBLCLK(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
	NMITEMACTIVATE *lpnmitem = (LPNMITEMACTIVATE) lParam;
	// Neu khong co item nao duoc chon thi thoat
	if (lpnmitem->iItem == -1)
		return;

	LVITEM kq;
	TCHAR szFileName[PATHFILE_MAX_LEN];

	kq.mask = LVIF_TEXT;
	kq.iItem = lpnmitem->iItem;
	kq.iSubItem = 0;
	kq.pszText = szFileName;
	kq.cchTextMax = PATHFILE_MAX_LEN;

	ListView_GetItem(hwndListView, &kq);

	HTREEITEM hParent = TreeView_GetSelection(hwndTreeView);
	HTREEITEM hItem = TV_FindItem(hParent, kq.pszText);

	if (hItem == NULL) // Item la tap tin
	{
		// Lay duong dan cua thu muc cha roi noi voi ten tap tin de co duoc duong
		// dan thuc su cua file
		TVITEM k;
		k.hItem = hParent;
		k.mask = TVIF_PARAM;
		TreeView_GetItem(hwndTreeView, &k);		
		TCHAR szFile[PATHFILE_MAX_LEN];
		wsprintf(szFile, _T("%s\\%s"), (TCHAR*) k.lParam, kq.pszText);
		// Thuc thi file
		ShellExecute(NULL , _T("open"), szFile, NULL, NULL, SW_SHOWNORMAL);
	}
	else
		TreeView_SelectItem(hwndTreeView, hItem);	
}
// Tim item co text = sz tai nut hParent cua TreeView
HTREEITEM TV_FindItem(HTREEITEM hParent, TCHAR *sz)
{
	TVITEM kq;	
	TCHAR		szText[PATHFILE_MAX_LEN];
	HTREEITEM	hItem;
	int k;
	// Khoi tao cac gia tri cho item
	kq.mask = TVIF_TEXT;
	kq.pszText = szText;
	kq.cchTextMax = PATHFILE_MAX_LEN;
	// Them thu muc vao ListView
	if (hItem = TreeView_GetChild(hwndTreeView, hParent))
	{
		do
		{
			kq.hItem = hItem;
			TreeView_GetItem(hwndTreeView, &kq);
		
			k = wcscmp(kq.pszText, sz);
			if (k == 0) // Tim thay
				return hItem;

//			else
//				if (k > 0)
//					return NULL;
		}	
		while (hItem = TreeView_GetNextSibling(hwndTreeView, hItem));
	}

	return NULL;
}
//  ---------------------------------------------------------------------
//		initListViewColumns Function
//			Ham khoi tao cac Column, dung cho che do REPORT (Details)
//  ---------------------------------------------------------------------
BOOL initListViewColumns()
{
	LVCOLUMN	lvColumn;
	TCHAR		szColumnLabel[30];

	// Add columns, them vao dau
	lvColumn.mask = LVCF_FMT | LVCF_TEXT | LVCF_WIDTH;// |LVCF_IMAGE;
    lvColumn.cx = 125;					// Do rong cot, tinh bang pixel
    lvColumn.pszText = szColumnLabel;	// Column heading (chuoi text cua column)
//	lvColumn.iImage=3;
	lvColumn.fmt= LVCFMT_RIGHT;// | LVCFMT_IMAGE; 

	// Them cac column vao ListView	
	for (int i = 0; i < NUM_COLUMN; ++i)
	{
		// Load text tu resource
		LoadString(hInst, ID_COLUMN1 + i, szColumnLabel, 30);

		if (ListView_InsertColumn(hwndListView, i, &lvColumn) == -1)
		{
			ErrorExit(_T("\"initListViewColumns\" ListView_InsertColumn() "));
			return FALSE;
		}
	}

//	ListView_SetExtendedListViewStyle(hwndListView, LVS_EX_TRACKSELECT |LVS_EX_UNDERLINEHOT | LVS_EX_ONECLICKACTIVATE);
	return TRUE;
}
//  ---------------------------------------------------------------------
//		doListView_ViewOption Function
//			Thay doi View-Option cua ListView
//  ---------------------------------------------------------------------
void doListView_ViewOption(HWND hWnd, int nViewStyle)
{
	LONG dNotView = ~(LVS_ICON | LVS_SMALLICON | LVS_LIST | LVS_REPORT);

	// Xac dinh thuoc tinh View-Style moi cho ListView
	SetWindowLong(hwndListView, GWL_STYLE, 
		GetWindowLong(hwndListView, GWL_STYLE) & dNotView | nViewStyle);

}

TCHAR* GetSize(PWIN32_FIND_DATA FindFileData)
{
	// Chuyen so thanh chuoi
	TCHAR *temp = new TCHAR[30];

	if (FindFileData->dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) // Thu muc
	{
		wcscpy_s(temp, 2, _T(""));
		return temp;
	}

	__int64 kq = (FindFileData->nFileSizeHigh * (__int64(MAXDWORD) + 1)) + FindFileData->nFileSizeLow;

	return HienThiDungLuong(kq);
}

TCHAR* GetAttribute(PWIN32_FIND_DATA FindFileData)
{
	TCHAR *kq;
	size_t n;
	if (FindFileData->dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) // Thu muc
	{
		n = strlen("File Folder");
		kq = new TCHAR[n + 1];
		wcscpy_s(kq, n + 1, _T("File Folder"));
	}
	else // Tap tin
	{
		n = strlen("File");
		kq = new TCHAR[n + 1];
		wcscpy_s(kq, n + 1, _T("File"));
	}
	return kq;
}

TCHAR* GetDateModified(PWIN32_FIND_DATA FindFileData)
{
    SYSTEMTIME stUTC, stLocal;

	// Convert the last-write time to local time.
	FileTimeToSystemTime(&FindFileData->ftLastWriteTime, &stUTC);
    SystemTimeToTzSpecificLocalTime(NULL, &stUTC, &stLocal);

    // Build a string showing the date and time.
	TCHAR *szString = new TCHAR[17]; // Chieu dai thay doi khi dinh dang xuat ngay gio thay doi
    wsprintf(szString, TEXT("%02d/%02d/%d %02d:%02d"),
        stLocal.wMonth, stLocal.wDay, stLocal.wYear,
        stLocal.wHour, stLocal.wMinute);

    return szString;

}

void ThemPhay(TCHAR *t)
{
	int len = (int) wcslen(t);
	int iDoDoi = len / 3;

	if (len % 3 == 0)
		--iDoDoi;

	if (iDoDoi < 0)
		return;

	t[len + iDoDoi] = '\0';
	for (int i = len - 1; i >= 0; --i)
	{
		t[i + iDoDoi] = t[i];

		if ((len - i) % 3 == 0)
		{	
			--iDoDoi;
			if (iDoDoi < 0)				
				return;
			
			t[i + iDoDoi] = ',';			
		}
	}
}
// szDuongDan phai ket thuc bang "\\"
/*
__int64 DuyetThuMuc(TCHAR *szDuongDan)
{
	__int64 kq = 0; // Ket qua
	WIN32_FIND_DATA FindFileData;
	HANDLE hFind;
	TCHAR temp[265];
	
	wsprintf(temp, _T("%s*"), szDuongDan);
	hFind = FindFirstFile(temp, &FindFileData);
	if (hFind == INVALID_HANDLE_VALUE) 
	{
		int t = GetLastError();
		if (t == 21 // O CD, Floppy disk chua co dia
		  || t == 2) // Khong tim thay file nao, tuc o dia rong
		  return 0;
		// Loi chua xac dinh
		ErrorExit(temp);//_T("\"DuyetThuMuc() FindFirstFile\""));
	}

	// La thu muc
	if (wcscmp(FindFileData.cFileName, _T(".")) == 0)
	{
		// Bo qua thu muc ..
		FindNextFile(hFind, &FindFileData);
		if (!FindNextFile(hFind, &FindFileData)) // Thu muc rong
			return 0;
	}
	else; // La o dia

	bool flag = false;
	size_t len = wcslen(szDuongDan);

	wcscpy_s(temp, szDuongDan);
	
	// Tim tat ca cac thu muc con va tap tin
	do
	{
		// Thu muc
		if (FindFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
		{
			// Them vao cuoi chuoi duong dan cu ten thu muc vua tim duoc 
			// va chuoi "\*" de kiem tra thu muc nay co chua thu muc con hay khong
			temp[len] = 0;

			wsprintf(temp, _T("%s%s\\"), temp, FindFileData.cFileName);
			kq += DuyetThuMuc(temp);			
		}		
		else // Tap tin		
			kq += (FindFileData.nFileSizeHigh * (__int64(MAXDWORD) + 1)) + FindFileData.nFileSizeLow;
		
	} while (FindNextFile(hFind, &FindFileData));

	FindClose(hFind);
	return kq;
}
*/
TCHAR * HienThiDungLuong(__int64 size)
{
	TCHAR *temp = new TCHAR[30];
	TCHAR temp1[30];
	char arr[] = {' ','K', 'M', 'G', 'T'};
	int du;
	int dem = 0;
	for (;size >= 1024; ++dem)
	{
		du = int(size % 1024);
		size = size / 1024;
	}

	_i64tow_s(size, temp1, 30, 10);
	
	ThemPhay(temp1);
	if (dem > 0)
		wsprintf(temp, _T("%s.%d %cB"), temp1, int((size / 1024.0) * 100), arr[dem]);
	else // dung luong tinh bang byte
		wsprintf(temp, _T("%s bytes"), temp1);

	return temp;
}
void XuLy_LV_ITEMCHANGING(HWND hWnd, WPARAM wParam, LPARAM lParam)
{	
	LPNMLISTVIEW pnmv = (LPNMLISTVIEW) lParam;

	// Neu khong co item nao duoc chon thi cap nhat lai status bar
	if (pnmv->iItem == -1)
	{
		CapNhatStatusBar();
		return;
	}
	
	LVITEM kq;
	TCHAR szFileName[PATHFILE_MAX_LEN];

	kq.mask = LVIF_TEXT;
	kq.iItem = pnmv->iItem;
	kq.iSubItem = 0;
	kq.pszText = szFileName;
	kq.cchTextMax = PATHFILE_MAX_LEN;

	ListView_GetItem(hwndListView, &kq);

	HTREEITEM hParent = TreeView_GetSelection(hwndTreeView);
	HTREEITEM hItem = TV_FindItem(hParent, kq.pszText);

	// Lay duong dan cua thu muc cha roi noi voi ten tap tin (thu muc) de co duoc duong
	// dan thuc su
	TVITEM k;
	k.hItem = hParent;
	k.mask = TVIF_PARAM;
	TreeView_GetItem(hwndTreeView, &k);		
	// Chua xu ly o dia, My computer
	
	// Thay doi phan 1 cua status bar
	SendMessage(statusBar.GetHandle(), SB_SETTEXT, 0, (LPARAM) _T(""));
	
	// Thay doi phan 3 cua status bar
	SendMessage(statusBar.GetHandle(), SB_SETTEXT, 2, (LPARAM) kq.pszText);

	if (hItem == NULL) // Item la tap tin
	{	
		// Thay doi phan 2 cua status bar
		kq.iSubItem = 1;
		ListView_GetItem(hwndListView, &kq);
		SendMessage(statusBar.GetHandle(), SB_SETTEXT, 1, (LPARAM) kq.pszText);
	}
	else // Folder
	{
		// Thay doi phan 2 cua status bar
		SendMessage(statusBar.GetHandle(), SB_SETTEXT, 1, (LPARAM) _T(""));
	}
}

void CapNhatStatusBar()
{
	TCHAR temp[30];
	// Thay doi phan 1 cua status bar
	wsprintf(temp, _T("%d Folders, %d Files"), HienHanh.iFolderCount, HienHanh.iFileCount);
	SendMessage(statusBar.GetHandle(), SB_SETTEXT, 0, (LPARAM) temp);
	
	// Thay doi phan 2 cua status bar
	wsprintf(temp, _T("%s (File only)"), HienThiDungLuong(HienHanh.iKichThuoc));
	SendMessage(statusBar.GetHandle(), SB_SETTEXT, 1, (LPARAM) temp);

	// Thay doi phan 3 cua status bar
	SendMessage(statusBar.GetHandle(), SB_SETTEXT, 2, (LPARAM) _T(""));
}

void doCreate_Toolbar(HWND hWnd)
{
//	AddButton(BYTE fsState, BYTE fsStyle, int iBitmap, int idCommand,
//			LPTSTR iString, DWORD_PTR dwData)

	toolBar.CreateToolBar(WS_CHILD | WS_VISIBLE , hWnd, ID_TOOLBARADD, hInst);
	toolBar.AddButton(0, BTNS_BUTTON, 0, ID_BACK, _T("Back"), 0);
	toolBar.AddButton(0, BTNS_BUTTON, 0, ID_FORWARD, _T("Forward"), 0);
	toolBar.AddButton(0, BTNS_BUTTON, 0, ID_UP, _T("Up"), 0); 
	toolBar.AddButton(0, BTNS_BUTTON, 0, ID_SEARCH, _T("Search"), 0); 
	toolBar.AddButton(0, BTNS_BUTTON, 0, ID_MOVETO, _T("Move to"), 0); 
	toolBar.AddButton(0, BTNS_BUTTON, 0, ID_COPYTO, _T("Copy to"), 0); 
	toolBar.AddButton(0, BTNS_BUTTON, 0, ID_DELETE, _T("Delete"), 0);   
//	HWND CMyToolBar::AddNonButtonControl(LPTSTR className,int styles,int ID,
//		int width,int height,int btnIndex,int iCommand)
	hwndComboBox = toolBar.AddNonButtonControl(_T("combobox"),
		WS_CHILD | WS_VISIBLE | WS_BORDER | CBS_DROPDOWNLIST, 
		ID_LVSTYLE, 200, 300, 7, 545);
	// Them text vao combobox
	SendMessage(hwndComboBox, CB_ADDSTRING, 0, (LPARAM) _T("Tiles"));
	SendMessage(hwndComboBox, CB_ADDSTRING, 0, (LPARAM) _T("Icons"));
	SendMessage(hwndComboBox, CB_ADDSTRING, 0, (LPARAM) _T("List"));
	SendMessage(hwndComboBox, CB_ADDSTRING, 0, (LPARAM) _T("Details"));
	// Chon item dau tien cua combobox
	SendMessage(hwndComboBox, CB_SETCURSEL, 0, 0);
	XuLy_ComboBox();
}
// Xu ly khi nhan nut Back tren Toolbar
void XuLy_PB_BACK_CLICKED()
{
	if (iIndex > 0)
	{
		bFlag = TRUE;
		TreeView_SelectItem(hwndTreeView, BackForward[--iIndex]);
	}
}
// Xu ly khi nhan nut Forward tren Toolbar
void XuLy_PB_FORWARD_CLICKED()
{
	if (iIndex < 10 - 1 && BackForward[iIndex + 1] != NULL)
	{
		bFlag = TRUE;
		TreeView_SelectItem(hwndTreeView, BackForward[++iIndex]);
	}
}
// Xu ly khi nhan nut Up tren Toolbar
void XuLy_PB_UP_CLICKED()
{
	HTREEITEM hParent = TreeView_GetParent(hwndTreeView, TreeView_GetSelection(hwndTreeView));
	if (hParent)
		TreeView_SelectItem(hwndTreeView, hParent);
}
// Xu ly khi nhan nut Search tren Toolbar
void XuLy_PB_SEARCH_CLICKED(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
}
// Xu ly khi nhan nut Move to tren Toolbar
void XuLy_PB_MOVETO_CLICKED(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
}
// Xu ly khi nhan nut Copy to tren Toolbar
void XuLy_PB_COPYTO_CLICKED(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
}
// Xu ly khi nhan nut Delete tren Toolbar
void XuLy_PB_DELETE_CLICKED(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
}

void XuLy_ComboBox()
{
	int Style;
	switch (SendMessage(hwndComboBox, CB_GETCURSEL, 0, 0))
	{
	case 0:
		Style = LVS_SMALLICON;
		break;
	case 1:
		Style = LVS_ICON;
		break;
	case 2:
		Style = LVS_LIST;
		break;
	case 3:
		Style = LVS_REPORT;
		break;
	}

	doListView_ViewOption(hwndListView, Style);
}

BOOL initTreeViewImageLists() 
{
    HIMAGELIST	himl;  // handle cua image list 
	//HIMAGELIST	himl2;  // handle cua image list 
	SHFILEINFO	psfi;

    // Tao image list.
	// Tai sao Icon lai xau nhu vay
	if ((himl = ImageList_Create(16, 16, 
		ILC_COLOR32, NUM_ICONS, 1000)) == NULL) 
        return FALSE; 
	
//	if ((himl2 = ImageList_Create(16, 16, 
//		ILC_COLORDDB | ILC_MASK, NUM_ICONS, 1000)) == NULL) 
  //      return FALSE;
    // Add cac icon vao Image list
//	SHGetFileInfo(_T("C:\\"), 0, &psfi, sizeof ( SHFILEINFO ), SHGFI_ICON);
//	ImageList_AddIcon(himl, psfi.hIcon);
    // Neu so bitmap add vao < NUM_BITMAPS -> Error
//    if (ImageList_GetImageCount(himl) < NUM_ICONS) 
//        return FALSE; 

    // Gan image list cho Tree View control. 
	TreeView_SetImageList(hwndTreeView, himl, TVSIL_NORMAL); 
	TreeView_SetImageList(hwndTreeView, himl, TVSIL_STATE); 
    return TRUE; 
} 

BOOL initListViewImageLists() 
{ 
    HIMAGELIST	hILSmall;  // handle cua image list small
	HIMAGELIST	hILLarge;  // handle cua image list large

	// Tao lap cac Image list.
	hILSmall = ImageList_Create(CX_ICON_SMALL, CY_ICON_SMALL, ILC_COLOR32 | ILC_MASK, NUM_ICONS, 1000);
	hILLarge = ImageList_Create(CX_ICON_LARGE, CY_ICON_LARGE, ILC_COLOR32 | ILC_MASK, NUM_ICONS, 1000);

	// Add cac incon vao Image List
//	for(int idx = IDI_ICON1; idx < IDI_ICON1 + NUM_ICONS; idx++)
//	{
//		HICON hIcon = LoadIcon(HInstance, MAKEINTRESOURCE(idx));
//
//        ImageList_AddIcon(hILSmall, hIcon);
//		ImageList_AddIcon(hILLarge, hIcon);
//	}

	// Kiem tra so icon co trong Image list
//	if(ImageList_GetImageCount(hILSmall) < NUM_ICONS || ImageList_GetImageCount(hILLarge) < NUM_ICONS)
//		return FALSE;

	// Gan Image lists cho List View
	ListView_SetImageList(hwndListView, hILSmall, LVSIL_SMALL);
	ListView_SetImageList(hwndListView, hILLarge, LVSIL_NORMAL);

	return TRUE;
}
