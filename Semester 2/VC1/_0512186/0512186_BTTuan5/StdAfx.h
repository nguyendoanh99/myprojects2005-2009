// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__F4153C54_C79D_4ED7_9FBD_482A98E275AB__INCLUDED_)
#define AFX_STDAFX_H__F4153C54_C79D_4ED7_9FBD_482A98E275AB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here

struct node
{
	int info;
	struct node*pNext;
};
typedef struct node NODE;

struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

void init(LIST &);
NODE *getnode(int );
void addtail(LIST &,NODE *);
int input(char *,LIST &,int &,int &,int &,int &);
int output(char *,LIST ,int );
void removenode(LIST &,NODE *);
void xoatrung(LIST &,int &n);
//void themnode(LIST &,int [],int );
int ktnt(int );
void hoanvi(int &,int &);
int ntliensau(int );
void thaynt(LIST );
void selection_sort(LIST );
void insertion_sort(LIST &);
void interchange_sort(LIST );
void addbefore(LIST &,NODE *,NODE *,NODE *);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__F4153C54_C79D_4ED7_9FBD_482A98E275AB__INCLUDED_)
