// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D53A9BB7_2CAD_4CF5_B2A8_62CC0115ABF9__INCLUDED_)
#define AFX_STDAFX_H__D53A9BB7_2CAD_4CF5_B2A8_62CC0115ABF9__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct phanso
{
	int tu;
	int mau;
};
typedef struct phanso PHANSO;

void nhap(PHANSO&);
void xuat(PHANSO);
int UCLN(int,int);
int BCNN(int,int);
void rutgon(PHANSO&);
PHANSO tong(PHANSO,PHANSO);
PHANSO hieu(PHANSO,PHANSO);
PHANSO tich(PHANSO,PHANSO);
PHANSO thuong(PHANSO,PHANSO);
int kttoigian(PHANSO);
void quidong(PHANSO&,PHANSO&);
int ktduong(PHANSO);
int ktam(PHANSO);
int sosanh(PHANSO,PHANSO);
PHANSO operator+(PHANSO,PHANSO);
PHANSO operator-(PHANSO,PHANSO);
PHANSO operator*(PHANSO,PHANSO);
PHANSO operator/(PHANSO,PHANSO);
PHANSO operator++(PHANSO&);
PHANSO operator--(PHANSO&);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D53A9BB7_2CAD_4CF5_B2A8_62CC0115ABF9__INCLUDED_)
