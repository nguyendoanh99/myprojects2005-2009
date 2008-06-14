// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__AE3514ED_5A70_43E8_8A02_E4051B28462C__INCLUDED_)
#define AFX_STDAFX_H__AE3514ED_5A70_43E8_8A02_E4051B28462C__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here

struct thoigian
{
	int gio;
	int phut;
	int giay;
};
typedef struct thoigian THOIGIAN;

struct ngay
{
	int ng;
	int th;
	int nm;
};
typedef struct ngay NGAY;

struct ve
{
	char tenphim[21];
	long giatien;
	THOIGIAN xuatchieu;
	NGAY ngayxem;
};
typedef struct ve VE;

struct node
{
	VE info;
	struct node*pNext;
};
typedef struct node NODE;

struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

int input(char *filename,LIST&);
void init(LIST &);
NODE *getnode(int);
void addhead(LIST &,NODE*);
void output(LIST );
void xuat(THOIGIAN );
void xuat (NGAY );
void xuat(VE );
long tongtien(LIST );
void saptang(LIST);
int sosanh(VE,VE);
int sosanh(NGAY,NGAY);
int sosanh(THOIGIAN,THOIGIAN);
int output(char *,LIST);
void nhap(THOIGIAN &);
void nhap(NGAY &);
void nhap(VE &);
void nhap(LIST &);




//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__AE3514ED_5A70_43E8_8A02_E4051B28462C__INCLUDED_)
