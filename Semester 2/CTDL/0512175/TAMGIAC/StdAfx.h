// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__8C051D1E_D15A_4FAB_B50F_61FEBD1E6946__INCLUDED_)
#define AFX_STDAFX_H__8C051D1E_D15A_4FAB_B50F_61FEBD1E6946__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
// Bai 581
struct diem
{
	float x;
	float y;
};
typedef struct diem DIEM;
struct tamgiac
{
	DIEM A;
	DIEM B;
	DIEM C;
};
typedef struct tamgiac TAMGIAC;
void nhap(DIEM&);
void nhap(TAMGIAC&);

void xuat(DIEM);
void xuat(TAMGIAC);

float khoangcach(DIEM,DIEM);
float khoangcachbinhphuong(DIEM,DIEM);
int kiemtra(TAMGIAC);

float chuvi(TAMGIAC);
float dientich(TAMGIAC);
DIEM trongtam(TAMGIAC);
DIEM hoanhlonnhat(TAMGIAC);
DIEM tungthapnhat(TAMGIAC);
float tongkhoangcach(TAMGIAC,DIEM);
int ktthuoc(TAMGIAC,DIEM);
int dangtamgiac(TAMGIAC);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__8C051D1E_D15A_4FAB_B50F_61FEBD1E6946__INCLUDED_)
