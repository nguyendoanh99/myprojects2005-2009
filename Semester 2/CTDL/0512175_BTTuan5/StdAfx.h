// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__ED3B2897_EAA1_4C93_90D0_9EAE063AEFDA__INCLUDED_)
#define AFX_STDAFX_H__ED3B2897_EAA1_4C93_90D0_9EAE063AEFDA__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct node 
{
	int info;
	struct node *pNext;
};
typedef struct node NODE;
struct list 
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

int ktnt(int );
int input(char *,LIST &,int &x);
int output(char *,LIST);
void xoatrung(LIST &);
NODE *timtrung(NODE *,int);
void tim_thaythe(LIST );
void hoanvi(int &,int &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__ED3B2897_EAA1_4C93_90D0_9EAE063AEFDA__INCLUDED_)
