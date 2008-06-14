// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__923A5E93_7796_446A_8B87_F58B22C7A47F__INCLUDED_)
#define AFX_STDAFX_H__923A5E93_7796_446A_8B87_F58B22C7A47F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here

struct mathang
{
	char ten[21];
	long gia;
	long luongton;
};
typedef struct mathang MATHANG;

struct node
{
	MATHANG info;
	struct node*pNext;
};
typedef struct node NODE ;

struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST ;

void init(LIST &);
NODE *getnode(MATHANG );
void addhead(LIST &,NODE *);
int input1(char *,LIST &);
int input(char *,LIST &);
int output(char *,LIST );

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__923A5E93_7796_446A_8B87_F58B22C7A47F__INCLUDED_)
