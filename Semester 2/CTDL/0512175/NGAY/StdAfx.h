// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__8FFD656E_C734_4600_8EEB_9C9F0E093A4B__INCLUDED_)
#define AFX_STDAFX_H__8FFD656E_C734_4600_8EEB_9C9F0E093A4B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
// So ngay cua thang
int thangngay[12]={31,28,31,30,31,30,31,31,30,31,30,31};
// Bai 593
struct ngay
{
	int ng;
	int th;
	int nm;
};
typedef struct ngay NGAY;
void nhap(NGAY&);
void xuat(NGAY);
int ktnamnhuan(int);
int thutungaynam(NGAY);
int thutungay(NGAY);
NGAY timngay(int,int);
NGAY timngay(int);
NGAY ngayketiep(NGAY);
NGAY ngayhomqua(NGAY);
NGAY ngayke(NGAY,int);
NGAY ngaytruoc(NGAY,int);
int khoangcach(NGAY,NGAY);
int sosanh(NGAY,NGAY);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__8FFD656E_C734_4600_8EEB_9C9F0E093A4B__INCLUDED_)
