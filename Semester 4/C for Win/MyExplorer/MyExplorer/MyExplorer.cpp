// MyExplorer.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "MyExplorer.h"
#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_MYEXPLORER, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MYEXPLORER));

	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MYEXPLORER));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_MYEXPLORER);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

	switch (message)
	{
	case WM_CREATE:
		// Nap thu vien Common Control DLL
		InitCommonControls(); 
		
		// Cho biet chua co thu muc nao duoc chon truoc do (su dung cho nut Back
		// va Forward)
		iIndex = -1;
		bFlag = FALSE;

		// Tao TreeView va ListView
		doCreate_TreeView(hWnd);
		doCreate_ListView(hWnd);

		// Tao status bar
		{
			statusBar.CreateStatusBar(WS_CHILD | WS_VISIBLE| SBARS_SIZEGRIP | 
				SBARS_TOOLTIPS ,
				hWnd, ID_STATUSBAR, hInst);
	   
			int Arr[] = {0, 0, 0};
			SendMessage(statusBar.GetHandle(),SB_SETPARTS, 3,(LPARAM)&Arr);
		}

		// Tao Toolbar
		doCreate_Toolbar(hWnd);
		break;
	case WM_NOTIFY:
		switch (LOWORD(wParam))
		{
		case IDTV_TREEVIEW:
			switch (((LPNMHDR) lParam)->code)
			{
			case  TVN_SELCHANGING:			
				XuLy_TVNSELCHANGE(hWnd, wParam, lParam);
				break;
			case TVN_ITEMEXPANDING:
				XuLy_TVNITEMEXPAND(hWnd, wParam, lParam);
				break;
			case NM_DBLCLK:
				//TreeView_Expand(hwndTreeView, kq->itemNew.hItem, TVE_EXPAND);
				break;
			}
			break;
		case IDLV_LISTVIEW:
			switch (((LPNMHDR) lParam)->code)
			{
			case NM_DBLCLK:
				XuLy_LV_NMDBLCLK(hWnd, wParam, lParam);
				break;
			case LVN_ITEMCHANGED:
				XuLy_LV_ITEMCHANGING(hWnd, wParam, lParam);
				break;
			case NM_CLICK:
			{
				LPNMLISTVIEW pnmv = (LPNMLISTVIEW) lParam;

				// Neu khong co item nao duoc chon thi cap nhat lai status bar
				if (pnmv->iItem == -1)
					CapNhatStatusBar();				
			}				
				break;
			}
			break;
		}
		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);	
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_CLOSE:
			DestroyWindow(hWnd);
			break;
		case ID_UP:
			XuLy_PB_UP_CLICKED();
			break;
		case ID_BACK:
			XuLy_PB_BACK_CLICKED();
			break;
		case ID_FORWARD:
			XuLy_PB_FORWARD_CLICKED();
			break;
		case ID_LVSTYLE:
			if (wmEvent == CBN_SELCHANGE)
				XuLy_ComboBox();
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		EndPaint(hWnd, &ps);
		break;

	case WM_SIZE:
	{
		SendMessage(statusBar.GetHandle(), WM_SIZE, 0, 0);
		SendMessage(toolBar.hToolBar, WM_SIZE, 0, 0);

		RECT rect; // status bar
		WINDOWPLACEMENT wndplTV; // TreeView
		RECT rcClient;  // Window
		RECT rcToolBar; // Tool bar
		GetClientRect(hWnd, &rcClient); 

		// Thay doi kich thuoc cac phan con trong status bar
		int Arr[] = {rcClient.right - 300, rcClient.right - 200, rcClient.right};
		SendMessage(statusBar.GetHandle(),SB_SETPARTS, 3,(LPARAM)&Arr);

		SendMessage(statusBar.GetHandle(), SB_GETRECT, 1,(LPARAM)&rect);		
		
		// Thay doi kich thuoc ToolBar Address
		GetClientRect(toolBar.hToolBar, &rcToolBar);
		
		// Thay doi kich thuoc TreeView
		MoveWindow(hwndTreeView, 0, rcToolBar.bottom + KHOANGCACH, (rcClient.right / 3),
			rcClient.bottom - rect.bottom - rcToolBar.bottom - KHOANGCACH, TRUE);

		// Thay doi kich thuoc ListView		
		wndplTV.length = sizeof(WINDOWPLACEMENT);
		GetWindowPlacement(hwndTreeView, &wndplTV);
		
		MoveWindow(hwndListView, wndplTV.rcNormalPosition.right + KHOANGCACH, 
			rcToolBar.bottom + KHOANGCACH, 
			rcClient.right - wndplTV.rcNormalPosition.right - KHOANGCACH, 
			rcClient.bottom - rect.bottom - rcToolBar.bottom- KHOANGCACH, TRUE);
	}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
