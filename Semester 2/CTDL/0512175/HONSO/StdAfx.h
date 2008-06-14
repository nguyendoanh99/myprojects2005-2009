// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__E69238FD_F7EC_4771_ABE2_7A783C7E5F5D__INCLUDED_)
#define AFX_STDAFX_H__E69238FD_F7EC_4771_ABE2_7A783C7E5F5D__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
// Bai 522
struct honso
{
	int nguyen;
	int tu;
	int mau;
};
typedef struct honso HONSO;

void nhap(HONSO&);
void xuat(HONSO);
int UCLN(int,int);
int BCNN(int,int);
void rutgon(HONSO&);
HONSO tong(HONSO,HONSO);
HONSO hieu(HONSO,HONSO);
HONSO tich(HONSO,HONSO);
HONSO thuong(HONSO,HONSO);
int kttoigian(HONSO);
void quidong(HONSO &,HONSO &);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__E69238FD_F7EC_4771_ABE2_7A783C7E5F5D__INCLUDED_)
