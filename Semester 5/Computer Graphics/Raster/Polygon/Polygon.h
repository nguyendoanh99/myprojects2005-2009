// Polygon.h : main header file for the Polygon application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CPolygonApp:
// See Polygon.cpp for the implementation of this class
//

class CPolygonApp : public CWinApp
{
public:
	CPolygonApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CPolygonApp theApp;