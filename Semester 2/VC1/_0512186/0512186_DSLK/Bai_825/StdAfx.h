// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__0677C8AE_B7C6_43B1_810C_531B33A4DAF2__INCLUDED_)
#define AFX_STDAFX_H__0677C8AE_B7C6_43B1_810C_531B33A4DAF2__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here

struct diem
{
	float x;
	float y;
};
typedef struct diem DIEM;

struct node
{
	DIEM info;
	struct node*pNext;
};
typedef struct node NODE ;

struct list 
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

//Cac thao tac co ban cua DSLK toa do cac diem trong mp Oxy
void init(LIST &);
NODE * getnode(DIEM );
void addtail(LIST &,NODE *);
void nhap_ds(LIST &);
void xuat_ds(LIST );
void nhapdiem(DIEM &);
void xuatdiem(DIEM );
int input(char *,LIST &);
int output(char *,LIST );

int input1(char *,LIST &);

int ktthuoc(DIEM );//Kiem tra 1 diem co thuoc phan tu thu nhat?
					// 1:co 0:khong	
float kc(DIEM );//Khoang cach tu 1 diem den goc O

void lietke(LIST );//Liet ke toa do cac diem trong phan tu thu nhat

DIEM tunglonnhat(LIST );
void sapgiam(LIST );
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__0677C8AE_B7C6_43B1_810C_531B33A4DAF2__INCLUDED_)
