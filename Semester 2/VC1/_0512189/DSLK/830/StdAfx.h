// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__F59F7E59_3BCC_4DC7_BD0C_C3437E93632B__INCLUDED_)
#define AFX_STDAFX_H__F59F7E59_3BCC_4DC7_BD0C_C3437E93632B__INCLUDED_

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
	struct node *pNext;
};
typedef struct node NODE;

struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;


void init(LIST&);
NODE *getNode(VE );
void addTail(LIST&,NODE*);

int input(char*,LIST&);
int output(char*,LIST);
void input(LIST&);
void output(LIST);

void xuat(VE);
void nhap(VE &);
void xuat(NGAY);
void nhap(NGAY &);
void xuat(THOIGIAN);
void nhap(THOIGIAN &);

long tonggiatien(LIST);
void sapxep(LIST&);


//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__F59F7E59_3BCC_4DC7_BD0C_C3437E93632B__INCLUDED_)
