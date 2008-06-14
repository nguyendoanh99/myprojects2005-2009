// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__357A086F_92CE_4CF1_9737_E359F27BDB66__INCLUDED_)
#define AFX_STDAFX_H__357A086F_92CE_4CF1_9737_E359F27BDB66__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

// TODO: reference additional headers your program requires here
struct dathuc
{
	float a[100];
	int n;
};
typedef struct dathuc DATHUC;
void nhap(DATHUC &);
void xuat(DATHUC);
DATHUC tong(DATHUC,DATHUC);
DATHUC hieu(DATHUC,DATHUC);
DATHUC tich(DATHUC,DATHUC);
DATHUC thuong(DATHUC,DATHUC);
DATHUC phandu(DATHUC,DATHUC);
DATHUC daoham(DATHUC);
DATHUC daoham(DATHUC,int);
float tinhf(DATHUC,float);
DATHUC operator+(DATHUC,DATHUC);
DATHUC operator-(DATHUC,DATHUC);
DATHUC operator*(DATHUC,DATHUC);
DATHUC operator/(DATHUC,DATHUC);
float timnghiem(DATHUC,float,float);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__357A086F_92CE_4CF1_9737_E359F27BDB66__INCLUDED_)
