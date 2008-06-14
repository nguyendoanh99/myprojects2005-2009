// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__1B35D535_99AC_4786_81A2_778E4A598DEA__INCLUDED_)
#define AFX_STDAFX_H__1B35D535_99AC_4786_81A2_778E4A598DEA__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

// TODO: reference additional headers your program requires here
struct donthuc
{
	float a;
	int n;
};
typedef struct donthuc DONTHUC;
void nhap(DONTHUC &);
void xuat(DONTHUC);
float luythua(float,int);
DONTHUC tich(DONTHUC,DONTHUC);
DONTHUC thuong(DONTHUC,DONTHUC);
DONTHUC daoham(DONTHUC);
DONTHUC daoham(DONTHUC,int);
float tinhf(DONTHUC,float);
DONTHUC operator*(DONTHUC,DONTHUC);
DONTHUC operator/(DONTHUC,DONTHUC);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__1B35D535_99AC_4786_81A2_778E4A598DEA__INCLUDED_)
