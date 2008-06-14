// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__3470E1FC_2212_4D4F_A619_4AAF1862CBC9__INCLUDED_)
#define AFX_STDAFX_H__3470E1FC_2212_4D4F_A619_4AAF1862CBC9__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
// Bai 532
struct sophuc
{
	float thuc;
	float ao;
};
typedef struct sophuc SOPHUC;
void nhap(SOPHUC &);
void xuat(SOPHUC);
SOPHUC tong(SOPHUC,SOPHUC);
SOPHUC hieu(SOPHUC,SOPHUC);
SOPHUC tich(SOPHUC,SOPHUC);
SOPHUC thuong(SOPHUC,SOPHUC);
SOPHUC luythua(SOPHUC,int);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__3470E1FC_2212_4D4F_A619_4AAF1862CBC9__INCLUDED_)
