// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__78FD652B_0B50_4A22_89FD_A6DF8B6409E8__INCLUDED_)
#define AFX_STDAFX_H__78FD652B_0B50_4A22_89FD_A6DF8B6409E8__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
// Bai 574
struct diemkg
{
	float x;
	float y;
	float z;
};
typedef struct diemkg DIEMKG;
struct hinhcau
{
	DIEMKG I;
	float R;
};
typedef struct hinhcau HINHCAU;
void nhap(DIEMKG&);
void nhap(HINHCAU&);
void xuat(DIEMKG);
void xuat(HINHCAU);

float dientichxungquanh(HINHCAU);
float thetich(HINHCAU);
float khoangcach(DIEMKG,DIEMKG);
int tuongdoi(HINHCAU,HINHCAU);
int ktthuoc(HINHCAU,DIEMKG);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__78FD652B_0B50_4A22_89FD_A6DF8B6409E8__INCLUDED_)
