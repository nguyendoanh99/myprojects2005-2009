// Head.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "Head.h"

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
LRESULT CALLBACK	ListProc(HWND, UINT, WPARAM, LPARAM);

WNDPROC OldList;

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
	LoadString(hInstance, IDC_HEAD, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_HEAD));

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
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_HEAD));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_HEAD);
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
	static BOOL			bValidFile;
	static BYTE			buffer[MAXREAD];
	static HWND			hwndList, hwndText;
	static RECT			rect;
	static TCHAR		szFile[MAX_PATH + 1];
	HANDLE				hFile;
	int					i, cxChar, cyChar;
	TCHAR				szBuffer[MAX_PATH + 1];
	switch (message)
	{
	case WM_CREATE:
		cxChar = LOWORD(GetDialogBaseUnits());
		cyChar = HIWORD(GetDialogBaseUnits());

		rect.left = 20 * cxChar;
		rect.top = 3 * cyChar;

		hwndList = CreateWindow(_T("listbox"), NULL, WS_CHILDWINDOW | WS_VISIBLE | LBS_STANDARD,
			cxChar, cyChar * 3, cxChar * 13 + GetSystemMetrics(SM_CXVSCROLL), cyChar * 10, hWnd, (HMENU) ID_LIST, 
			(HINSTANCE) GetWindowLong(hWnd, GWL_HINSTANCE), NULL);

		GetCurrentDirectory(MAX_PATH + 1, szBuffer);

		hwndText = CreateWindow(_T("static"), szBuffer, WS_CHILDWINDOW | WS_VISIBLE | SS_LEFT,
			cxChar, cyChar, cxChar * MAX_PATH, cyChar, hWnd, (HMENU) ID_TEXT, (HINSTANCE) GetWindowLong(hWnd, GWL_HINSTANCE), NULL);

		OldList = (WNDPROC) SetWindowLong(hwndList, GWL_WNDPROC, (LPARAM) ListProc);
		
		SendMessage(hwndList, LB_DIR, DIRATTR, (LPARAM) _T("*.*"));
		return 0;
	case WM_SIZE:
		rect.right = LOWORD(lParam);
		rect.bottom = HIWORD(lParam);
		return 0;
	case WM_SETFOCUS:
		SetFocus(hwndList);
		return 0;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case ID_LIST:
			if (wmEvent == LBN_DBLCLK)
			{
				if (LB_ERR == (i = SendMessage(hwndList, LB_GETCURSEL, 0, 0)))
					break;

				SendMessage(hwndList, LB_GETTEXT, i, (LPARAM) szBuffer);

				if (INVALID_HANDLE_VALUE != (hFile = CreateFile(szBuffer, GENERIC_READ, 
					FILE_SHARE_READ, NULL, OPEN_EXISTING, 0, NULL)))
				{
					CloseHandle(hFile);
					bValidFile = TRUE;
					lstrcpy(szFile, szBuffer);
					GetCurrentDirectory(MAX_PATH + 1,szBuffer);

					if (szBuffer[lstrlen(szBuffer) - 1] != '\\')
						lstrcat(szBuffer, _T("\\"));

					SetWindowText(hwndText, lstrcat(szBuffer, szFile));
				}
				else
				{
					bValidFile = FALSE;
					szBuffer[lstrlen(szBuffer) - 1] = '\0';
					if (!SetCurrentDirectory(szBuffer + 1))
					{
						szBuffer[3] = ':';
						szBuffer[4] = '\0';
						SetCurrentDirectory(szBuffer + 2);
					}
					GetCurrentDirectory(MAX_PATH + 1, szBuffer);
					SetWindowText(hwndText, szBuffer);
					SendMessage(hwndList, LB_RESETCONTENT, 0, 0);
					SendMessage(hwndList, LB_DIR, DIRATTR, (LPARAM) _T("*.*"));
				}
				InvalidateRect(hWnd, NULL, TRUE);
			}
			return 0;
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		if (!bValidFile)
			break;
		
		if (INVALID_HANDLE_VALUE == (hFile = CreateFile(szFile, GENERIC_READ, FILE_SHARE_READ, NULL,
			OPEN_EXISTING, 0, NULL)))
		{
			bValidFile = FALSE;
			break;
		}

		ReadFile(hFile, buffer, MAXREAD, (LPDWORD) &i, NULL);
		CloseHandle(hFile);

		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		SelectObject(hdc, GetStockObject(SYSTEM_FIXED_FONT));
		SetTextColor(hdc, GetSysColor(COLOR_BTNTEXT));
		SetBkColor(hdc, GetSysColor(COLOR_BTNFACE));
		DrawTextA(hdc, (LPCSTR) buffer, i, &rect, DTFLAGS);
		EndPaint(hWnd, &ps);
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

LRESULT CALLBACK ListProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	if (message == WM_KEYDOWN && wParam == VK_RETURN)
		SendMessage(GetParent(hWnd), WM_COMMAND, MAKELONG(1, LBN_DBLCLK), (LPARAM) hWnd);

	return CallWindowProc(OldList, hWnd, message, wParam, lParam);
}