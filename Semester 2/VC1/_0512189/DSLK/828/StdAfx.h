// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__0B254C17_1C41_4AC9_A47E_5ACEB1D3E6A9__INCLUDED_)
#define AFX_STDAFX_H__0B254C17_1C41_4AC9_A47E_5ACEB1D3E6A9__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct sach
{
	char tensach[51];
	char tacgia[31];
	int namxb;
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


void init(LIST&);
NODE *getNode(SACH );
void addTail(LIST&,NODE*);

int input(char*,LIST&);
int output(char*,LIST);
void input(LIST&);
void output(LIST);

void xuat(SACH);
void nhap(SACH &);

SACH tim(LIST);
int timnam(LIST);
void lietke(LIST,int);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__0B254C17_1C41_4AC9_A47E_5ACEB1D3E6A9__INCLUDED_)
