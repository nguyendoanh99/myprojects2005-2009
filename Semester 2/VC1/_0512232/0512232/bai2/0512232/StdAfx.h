// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__0BD85B0B_38A9_4475_96C0_25725498D21A__INCLUDED_)
#define AFX_STDAFX_H__0BD85B0B_38A9_4475_96C0_25725498D21A__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct danhsach
{
	char MSSV[10];
	char hoten[40];
	char diachi[50];
	float dtb;
};
typedef struct danhsach DANHSACH;

int timtuyentinh(DANHSACH [],int ,char []);
int timnhiphan(DANHSACH [],int ,char []);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__0BD85B0B_38A9_4475_96C0_25725498D21A__INCLUDED_)
