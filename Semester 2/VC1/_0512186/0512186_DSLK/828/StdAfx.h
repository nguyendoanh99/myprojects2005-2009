// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D2C41C5B_0D1D_47AE_9718_8B0A817FC031__INCLUDED_)
#define AFX_STDAFX_H__D2C41C5B_0D1D_47AE_9718_8B0A817FC031__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"

struct ngay
{
	int ng;
	int th;
	int nm;
};
typedef struct ngay NGAY;
struct sach
{
	char tensach[51];
	char tacgia[31];
	NGAY xuatban;
};
typedef struct sach SACH;
struct node
{
	SACH info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(SACH);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST );
void xuat(SACH);
void xuat(NGAY);
SACH timsach(LIST);
void lietke(LIST,int);
int timnam(LIST);
int tansuat(LIST,int);
int sosanh(NGAY,NGAY);
void _input(char *,LIST &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D2C41C5B_0D1D_47AE_9718_8B0A817FC031__INCLUDED_)
