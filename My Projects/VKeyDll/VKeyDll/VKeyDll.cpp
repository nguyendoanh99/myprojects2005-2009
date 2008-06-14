// VKeyDll.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "stdlib.h"

#ifdef _MANAGED
#pragma managed(push, off)
#endif
HHOOK hHook;
HINSTANCE	 hInstDLL;
FILE* f1;
BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	hInstDLL = (HINSTANCE) hModule;
    return TRUE;
}

LRESULT CALLBACK XuLyPhim(int nCode, WPARAM wParam, LPARAM  lParam)
{
	HWND hW=GetFocus();
	TCHAR str[100];
//	itoa(hW, str, 10);
	_itow((int) hW,str,10);
	
//	SendMessage(hW,WM_SETTEXT,0,(LPARAM) TEXT("12"));
	f1=fopen("c:\\report.txt","a+");
	fwrite(&str,2,10,f1);
//	MessageBox(NULL,(LPCWSTR) hW,TEXT("123"),1);
	return CallNextHookEx(hHook, nCode, wParam, lParam);
}

DLLEXPORT void doSetGlobalHook()
{
	hHook = SetWindowsHookEx(WH_KEYBOARD, (HOOKPROC) XuLyPhim, hInstDLL, 0);	
}

DLLEXPORT void doRemoveGlobalHook()
{
	UnhookWindowsHookEx(hHook);
}
#ifdef _MANAGED
#pragma managed(pop)
#endif

