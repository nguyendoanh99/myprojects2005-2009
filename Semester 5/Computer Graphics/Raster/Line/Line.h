// Line.h : main header file for the Line application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CLineApp:
// See Line.cpp for the implementation of this class
//

class CLineApp : public CWinApp
{
public:
	CLineApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CLineApp theApp;