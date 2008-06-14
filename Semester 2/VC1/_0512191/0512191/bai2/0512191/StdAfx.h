// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__85BB2528_81F5_4998_828B_882E1B134BB4__INCLUDED_)
#define AFX_STDAFX_H__85BB2528_81F5_4998_828B_882E1B134BB4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct danhsach
{
	char MSSV[11];
	char hoten[41];
	char diachi[51];
	float dtb;
};
typedef struct danhsach DANHSACH;

int timtuyentinh(DANHSACH [],int ,char []);
int timnhiphan(DANHSACH [],int ,char []);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__85BB2528_81F5_4998_828B_882E1B134BB4__INCLUDED_)
