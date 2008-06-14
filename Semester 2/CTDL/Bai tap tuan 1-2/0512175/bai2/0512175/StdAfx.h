// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__08E7B6C4_CA17_48F3_828D_EB752F110C12__INCLUDED_)
#define AFX_STDAFX_H__08E7B6C4_CA17_48F3_828D_EB752F110C12__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct sv
{
	char mssv[11];
	char hoten[41];
	char diachi[51];
	float dtb;
};
typedef struct sv SV;
void input(char*,SV**,int &,int &,char *);
void output(char*,int);
int tuantu(SV*,int ,char*);
int nhiphan(SV*,int ,char*);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__08E7B6C4_CA17_48F3_828D_EB752F110C12__INCLUDED_)
