// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__4F889488_A97B_4BC1_8C36_51687763D28B__INCLUDED_)
#define AFX_STDAFX_H__4F889488_A97B_4BC1_8C36_51687763D28B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct node
{
	int info;
	int count;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;
void nhapbaotoan(LIST &);
void init(LIST &);
NODE *getnode(int);
void addAfter(LIST &,NODE *,NODE *);
void xuat(LIST);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__4F889488_A97B_4BC1_8C36_51687763D28B__INCLUDED_)
