// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__598D94D7_F8FF_46BF_A711_09E770B4B204__INCLUDED_)
#define AFX_STDAFX_H__598D94D7_F8FF_46BF_A711_09E770B4B204__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#include <string>
#include <vector>
#include <iostream>

using namespace std;
typedef vector<string> VecStr;
bool DocFile(char *, vector<VecStr> &);
bool GhiFile(char *, vector<VecStr> &);
bool Xuly(vector<string> &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__598D94D7_F8FF_46BF_A711_09E770B4B204__INCLUDED_)
