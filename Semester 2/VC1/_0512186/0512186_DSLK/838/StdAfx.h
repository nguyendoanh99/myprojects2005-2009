// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__7A3DCF5C_DCC9_4071_A0C6_6F37CBA36650__INCLUDED_)
#define AFX_STDAFX_H__7A3DCF5C_DCC9_4071_A0C6_6F37CBA36650__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"

struct ngay
{
	int ng;
	int th;
	int nm;
};
typedef struct ngay NGAY;
struct sotietkiem
{
	char maso[6];
	char loai[11];
	char hoten[31];
	int cmnd;
	NGAY ngaymoso;
	float tiengoi;
};
typedef struct sotietkiem SOTIETKIEM;
struct node 
{
	SOTIETKIEM info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

void init(LIST &);
void addtail(LIST &,NODE *);
NODE *getnode(SOTIETKIEM);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(SOTIETKIEM);
void xuat(NGAY);
void output(LIST);
float tongtien(LIST);
NODE *timnode(LIST,int);
void _input(char *,LIST&);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__7A3DCF5C_DCC9_4071_A0C6_6F37CBA36650__INCLUDED_)
