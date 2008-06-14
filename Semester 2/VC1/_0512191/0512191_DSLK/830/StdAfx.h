// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__76BEF4E5_A66F_43AF_BC3B_FD4EB2E76BA5__INCLUDED_)
#define AFX_STDAFX_H__76BEF4E5_A66F_43AF_BC3B_FD4EB2E76BA5__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"
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
	int giatien;
	THOIGIAN xuatchieu;
	NGAY ngayxem;
};
typedef struct ve VE;
struct node
{
	VE info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(VE);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST );
void xuat(VE);
void xuat(NGAY);
void xuat(THOIGIAN);
int tongtien(LIST);
void sapxeptang(LIST&);
void hoanvi(LIST &,NODE *,NODE *);
void output(LIST);
int sosanh(THOIGIAN,THOIGIAN);
int sosanh(NGAY,NGAY);
int sosanh(VE,VE);
void _input(char *,LIST &);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__76BEF4E5_A66F_43AF_BC3B_FD4EB2E76BA5__INCLUDED_)
