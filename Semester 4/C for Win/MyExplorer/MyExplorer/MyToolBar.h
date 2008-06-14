#pragma once

class CMyToolBar
{
public: 
	HWND hToolBar;
	HINSTANCE hInstance;
public:
	CMyToolBar(void);
public:
	~CMyToolBar(void);
public:
	HWND CreateToolBar(int styles, HWND hParent, int id , HINSTANCE hInst);
public:
	BOOL AddButton(BYTE fsState, BYTE fsStyle, int iBitmap, int idCommand, LPTSTR iString, DWORD_PTR dwData);
public:
	void SetButtonImages(int cx,int cy,int idb_Image,int btnNums);
public:
	HWND AddNonButtonControl(LPTSTR className,int styles,int ID,int width,int height,int btnIndex,int iCommand);
	BOOL DoNotify(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam);

};
