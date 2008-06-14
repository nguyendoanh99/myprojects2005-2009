// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__FA401837_FFC2_42EE_A95B_55F14BCAEA55__INCLUDED_)
#define AFX_STDAFX_H__FA401837_FFC2_42EE_A95B_55F14BCAEA55__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"

struct hocsinh
{
	char hoten[30];
	float toan;
	float van;
	float dtb;
};
typedef struct hocsinh HOCSINH;
struct lophoc
{
	char tenlop[31];
	int siso;
	HOCSINH dslop[50];
};
typedef struct lophoc LOPHOC;
struct node
{
	LOPHOC info;
	struct node *pNext;
};
typedef struct node NODE;
struct list 
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(LOPHOC);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(LOPHOC);
void xuat(HOCSINH);
void output(LIST);
LOPHOC timlop(LIST);
HOCSINH timhocsinh(LIST);
void _input(char *,LIST&);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__FA401837_FFC2_42EE_A95B_55F14BCAEA55__INCLUDED_)
