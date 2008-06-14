// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D6C7CE41_70A8_44A8_B0BE_77801009DCCE__INCLUDED_)
#define AFX_STDAFX_H__D6C7CE41_70A8_44A8_B0BE_77801009DCCE__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct node 
{
	int info;
	struct node* pNext;
};
typedef struct node NODE;

struct list
{
	NODE* pHead;
	NODE* pTail;
};
typedef struct list LIST;

void init(LIST &);
NODE* getnode(int);
void addHead(LIST &,NODE*);
void addTail(LIST &,NODE*);
void RemoveAfter(LIST&,NODE*);
int timtrung(LIST,int);

int input(char*,LIST &,int&);
int output(char*,LIST &);

void xoaphantutrung(LIST&);
int delNode(LIST &,int);

void nguyento(LIST &);
int ktnt(int);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D6C7CE41_70A8_44A8_B0BE_77801009DCCE__INCLUDED_)
