#include "StdAfx.h"
#include "resource.h"
#include "MyToolBar.h"


CMyToolBar::CMyToolBar(void)
{
}

CMyToolBar::~CMyToolBar(void)
{
}

HWND CMyToolBar::CreateToolBar(int styles, HWND hParent,  int id , HINSTANCE hInst)
{
	InitCommonControls();
	
	hInstance=hInst;
	hToolBar=CreateWindow( TOOLBARCLASSNAME,  NULL, styles 
        , 0, 0, 0, 0, hParent, 
		(HMENU) id, hInst, NULL); 	

	SendMessage(hToolBar,TB_BUTTONSTRUCTSIZE,sizeof(TBBUTTON),0);		
	//SendMessage(hToolBar,TB_SETEXTENDEDSTYLE,0,TBSTYLE_EX_DRAWDDARROWS);		
	//SendMessage(hToolBar, TB_SETBUTTONWIDTH,0,MAKELONG(32,32));
	return hToolBar;
}

BOOL CMyToolBar::AddButton(BYTE fsState, BYTE fsStyle, int iBitmap, int idCommand, LPTSTR iString, DWORD_PTR dwData)
{
	int iStr = SendMessage(hToolBar, TB_ADDSTRING, 0, (LPARAM) iString); 	
	TBBUTTON button[1];	
	button[0].dwData=dwData;
	button[0].fsState=fsState|TBSTATE_ENABLED;
	button[0].iBitmap=STD_COPY;//iBitmap;
	button[0].fsStyle=fsStyle;
	button[0].idCommand=idCommand;
	button[0].iString=iStr;//(INT_PTR)iString;
	BOOL kq=SendMessage(hToolBar,TB_ADDBUTTONS ,1,(LPARAM)&button);		
	return kq;
}

void CMyToolBar::SetButtonImages(int cx,int cy, int idb_Image,int btnNums)
{
	SendMessage(hToolBar,TB_SETBITMAPSIZE,0,MAKELONG(cx,cy));
	TBADDBITMAP tbAddBitmap;
	tbAddBitmap.hInst=HINST_COMMCTRL;//hInstance;
	tbAddBitmap.nID=IDB_STD_LARGE_COLOR;//IDB_BITMAP1;
	SendMessage(hToolBar,TB_ADDBITMAP,btnNums,(LPARAM)&tbAddBitmap);
}
//Neu goi ham nay nhieu lan thi phai goi theo thu tu btnIndex tang dan
HWND CMyToolBar::AddNonButtonControl(LPTSTR className,int styles,int ID,int width,int height,int btnIndex,int iCommand)
{

	TBBUTTON button;		
	button.fsState=TBSTATE_ENABLED;	
	button.fsStyle=BTNS_SEP;
	button.idCommand=iCommand;	
	BOOL kq=SendMessage(hToolBar,TB_INSERTBUTTON ,btnIndex,(LPARAM)&button);
	
	TBBUTTONINFO info;
	info.cbSize=sizeof(TBBUTTONINFO);
	info.dwMask=TBIF_SIZE;
	info.cx=width;	
	SendMessage(hToolBar,TB_SETBUTTONINFO,iCommand,(LPARAM)&info);

	
	RECT rect;
	SendMessage(hToolBar,TB_GETITEMRECT,btnIndex,(LPARAM) &rect);	
	//Neu height=0 thi chieu cao se duoc tinh bang bottom-top
	//Neu height<>0 thi chieu cao se la height 
	HWND hWnd=CreateWindow( className, NULL, styles, rect.left,rect.top, rect.right-rect.left, height==0?rect.bottom-rect.top:height, hToolBar, (HMENU) ID, hInstance, 0 );
		
	return hWnd;
}
BOOL CMyToolBar::DoNotify(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	#define lpnm   ((LPNMHDR)lParam)
	#define lpnmTB ((LPNMTOOLBAR)lParam)

   RECT      rc;
   TPMPARAMS tpm;
//   HMENU     hPopupMenu = NULL;
//   HMENU     hMenuLoaded;
   BOOL      bRet = FALSE;
	
   switch(lpnm->idFrom)
   {
	   case 32883:
	   {
		   int t;
		   t=8;
		   break;
	   }
   }
   switch(lpnm->code)
   {
   
   case TBN_DROPDOWN:
	{   
		 SendMessage(lpnmTB->hdr.hwndFrom, TB_GETRECT,
                     (WPARAM)lpnmTB->iItem, (LPARAM)&rc);

         MapWindowPoints(lpnmTB->hdr.hwndFrom,
                         HWND_DESKTOP, (LPPOINT)&rc, 2);                         

         tpm.cbSize = sizeof(TPMPARAMS);
         tpm.rcExclude = rc;
		 
//		 hMenuLoaded = LoadMenu(hInstance, MAKEINTRESOURCE(IDR_MENU1)); 
         
//		 hPopupMenu = GetSubMenu(hMenuLoaded,0);

//         TrackPopupMenuEx(hPopupMenu,
//           TPM_LEFTALIGN|TPM_LEFTBUTTON|TPM_VERTICAL,               
//            rc.left, rc.bottom, hToolBar, &tpm); 

//        DestroyMenu(hMenuLoaded);			
	 }
	
	break;	

   }
   return FALSE;	
}

