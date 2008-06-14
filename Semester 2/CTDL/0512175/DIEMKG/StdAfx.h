// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__6829CC9A_F711_40B0_9025_035FE804CF23__INCLUDED_)
#define AFX_STDAFX_H__6829CC9A_F711_40B0_9025_035FE804CF23__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
// Bai 555
struct diemkg
{
	float x;
	float y;
	float z;
};
typedef struct diemkg DIEMKG;
void nhap(DIEMKG&);
void xuat(DIEMKG);
float khoangcach(DIEMKG,DIEMKG);
float khoangcachx(DIEMKG,DIEMKG);
float khoangcachy(DIEMKG,DIEMKG);
float khoangcachz(DIEMKG,DIEMKG);
DIEMKG dxgoc(DIEMKG);
DIEMKG dxoxy(DIEMKG);
DIEMKG dxoxz(DIEMKG);
DIEMKG dxoyz(DIEMKG);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__6829CC9A_F711_40B0_9025_035FE804CF23__INCLUDED_)
