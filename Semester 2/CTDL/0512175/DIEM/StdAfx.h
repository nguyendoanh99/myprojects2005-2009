// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__B48D496A_5E91_43FB_85CF_334BBCD03EA3__INCLUDED_)
#define AFX_STDAFX_H__B48D496A_5E91_43FB_85CF_334BBCD03EA3__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
// Bai 540
struct diem
{
	float x;
	float y;
};
typedef struct diem DIEM;
void nhap(DIEM&);
void xuat(DIEM);
float khoangcach(DIEM,DIEM);
float khoangcachx(DIEM,DIEM);
float khoangcachy(DIEM,DIEM);
DIEM dxgoc(DIEM);
DIEM dxox(DIEM);
DIEM dxoy(DIEM);
DIEM dxpg1(DIEM);
DIEM dxpg2(DIEM);
int ktphantu1(DIEM);
int ktphantu2(DIEM);
int ktphantu3(DIEM);
int ktphantu4(DIEM);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__B48D496A_5E91_43FB_85CF_334BBCD03EA3__INCLUDED_)
