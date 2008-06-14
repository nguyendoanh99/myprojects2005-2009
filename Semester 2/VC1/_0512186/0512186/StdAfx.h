// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__E59B6C17_A38A_4651_B9EC_58501884D7A9__INCLUDED_)
#define AFX_STDAFX_H__E59B6C17_A38A_4651_B9EC_58501884D7A9__INCLUDED_

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

void init(LIST);
NODE *getnode(int);
void addhead(LIST &,NODE*);
void input(LIST);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__E59B6C17_A38A_4651_B9EC_58501884D7A9__INCLUDED_)
