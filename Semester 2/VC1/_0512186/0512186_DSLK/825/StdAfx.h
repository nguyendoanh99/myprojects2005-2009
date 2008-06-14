// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__C4FBA5E8_CCFE_4BA9_B916_F79496D230F1__INCLUDED_)
#define AFX_STDAFX_H__C4FBA5E8_CCFE_4BA9_B916_F79496D230F1__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"
#define filename3 "data3.out"
struct diem
{
	float x;
	float y;
};
typedef struct diem DIEM;
struct node 
{
	DIEM info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(DIEM);
void init(LIST &);
void addhead(LIST &,NODE*);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(DIEM);
void lietke(LIST);
DIEM timdiem(LIST);
void sapxepgiam(LIST &);
float khoangcach0(DIEM,DIEM);
void hoanvi(LIST &,NODE *,NODE *);
void output(LIST);
void _input(char *,LIST &);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__C4FBA5E8_CCFE_4BA9_B916_F79496D230F1__INCLUDED_)
