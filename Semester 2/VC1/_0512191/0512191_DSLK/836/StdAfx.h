// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__610538CB_014B_4AFE_9BC7_9FE5EF5F2941__INCLUDED_)
#define AFX_STDAFX_H__610538CB_014B_4AFE_9BC7_9FE5EF5F2941__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"

struct luanvan
{
	char maLV[11];
	char tenLV[101];
	char hotenSV[31];
	char hotenGV[31];
	int nam;
};
typedef struct luanvan LUANVAN;
struct node
{
	LUANVAN info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(LUANVAN);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(LUANVAN);
void output(LIST);
int timnam(LIST);
void lietke(LIST,int);
int timnamgannhat(LIST);
void _input(char *,LIST&);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__610538CB_014B_4AFE_9BC7_9FE5EF5F2941__INCLUDED_)
