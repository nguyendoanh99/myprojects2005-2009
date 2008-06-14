// AreaFilling.h : main header file for the AreaFilling application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CAreaFillingApp:
// See AreaFilling.cpp for the implementation of this class
//

class CAreaFillingApp : public CWinApp
{
public:
	CAreaFillingApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CAreaFillingApp theApp;