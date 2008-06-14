// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__CBE320E3_B6A2_4D5A_B8B9_B2C7DD785321__INCLUDED_)
#define AFX_STDAFX_H__CBE320E3_B6A2_4D5A_B8B9_B2C7DD785321__INCLUDED_

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

void init(LIST *);
NODE *getnode(int x);
void addtail(LIST *,NODE *);
void QuickSort(LIST *);
void SelectionSort(LIST *);
void RadixSort(LIST *);
void RadixSort(int [],int n);
void MergeSort(LIST *);
void xuat(LIST);
void input(char *,LIST *);
int laychuso(int ,int);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__CBE320E3_B6A2_4D5A_B8B9_B2C7DD785321__INCLUDED_)
