// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__44730A23_D13C_45A5_BF2B_2980482C584F__INCLUDED_)
#define AFX_STDAFX_H__44730A23_D13C_45A5_BF2B_2980482C584F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
// Bai 566
struct diem
{
	float x;
	float y;	
};
typedef struct diem DIEM;
struct duongtron
{
	DIEM I;
	float R;
};
typedef struct duongtron DUONGTRON;
void nhap(DIEM&);
void nhap(DUONGTRON&);
void xuat(DIEM);
void xuat(DUONGTRON);

float chuvi(DUONGTRON);
float dientich(DUONGTRON);

float khoangcach(DIEM,DIEM);
int tuongdoi(DUONGTRON,DUONGTRON);
int ktthuoc(DUONGTRON,DIEM);
float dientichphu(DUONGTRON,DUONGTRON);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__44730A23_D13C_45A5_BF2B_2980482C584F__INCLUDED_)
