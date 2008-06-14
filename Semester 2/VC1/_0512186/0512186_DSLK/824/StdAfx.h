// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D854BB6C_647D_4A17_8EED_5C11172E95DE__INCLUDED_)
#define AFX_STDAFX_H__D854BB6C_647D_4A17_8EED_5C11172E95DE__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"
#define filename3 "data3.out"
struct hocsinh
{
	char hoten[31];
	float toan;
	float van;
	float dtb;
};
typedef struct hocsinh HOCSINH;
struct node
{
	HOCSINH info;
	struct node *pNext;
};
typedef struct node NODE;
struct list 
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(HOCSINH);
void addtail(LIST &,NODE *);
void init(LIST &);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(HOCSINH);
void lietke(LIST);
int demdiem(LIST);
void sapxepgiam(LIST &);
void hoanvi(LIST &,NODE *,NODE *);
void output(LIST);
void _input(char *,LIST &);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D854BB6C_647D_4A17_8EED_5C11172E95DE__INCLUDED_)
