// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D9E8A444_C3A6_41A1_9876_95ED90D55368__INCLUDED_)
#define AFX_STDAFX_H__D9E8A444_C3A6_41A1_9876_95ED90D55368__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"
#define filename3 "data3.out"
struct phong 
{
	char maphong[6];
	char tenphong[30];
	float dongia;
	int soluong;
	unsigned char tinhtrang;
};
typedef struct phong PHONG;
struct node
{
	PHONG info;
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
NODE *getnode(PHONG);
void addhead(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(PHONG);
void lietkephong(LIST);
int tonggiuong(LIST);
void sapxeptang(LIST &);
void hoanvi(LIST&,NODE *,NODE *);
void output(LIST);
void _input(char *,LIST &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D9E8A444_C3A6_41A1_9876_95ED90D55368__INCLUDED_)
