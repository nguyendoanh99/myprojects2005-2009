#include "StdAfx.h"
#include "MyStatusBar.h"

CMyStatusBar::CMyStatusBar(void)
{
}

CMyStatusBar::~CMyStatusBar(void)
{
}
HWND CMyStatusBar::CreateStatusBar(int styles, HWND hParent,  int id , HINSTANCE hInst)
{
	InitCommonControls();
	
	hInstance=hInst;
	hStatusBar=CreateWindow( STATUSCLASSNAME,  NULL, styles
        , 0, 0, 0, 0, hParent, 
		(HMENU) id, hInst, NULL); 	
	return hStatusBar;
}
HWND CMyStatusBar::GetHandle()
{
	return hStatusBar;
}