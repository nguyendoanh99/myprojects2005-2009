#pragma once
#ifndef _STATUSBAR
#define _STATUSBAR
class CMyStatusBar
{
private:
	HWND hStatusBar;
	HINSTANCE hInstance;
public:
	CMyStatusBar(void);
public:
	~CMyStatusBar(void);
	HWND CreateStatusBar(int styles, HWND hParent, int id , HINSTANCE hInst);
	HWND GetHandle();
};
#endif