// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__FEC587AF_AA7F_4873_892E_FAB8E9D86857__INCLUDED_)
#define AFX_STDAFX_H__FEC587AF_AA7F_4873_892E_FAB8E9D86857__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"

struct mathang
{
	char tenhang[21];	
	int dongia;
	int luongton;
};
typedef struct mathang MATHANG;
struct node
{
	MATHANG info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(MATHANG);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST );
void xuat(MATHANG);
MATHANG tim(LIST);
int demmathang(LIST);
void output(LIST);
void _input(char *,LIST &);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__FEC587AF_AA7F_4873_892E_FAB8E9D86857__INCLUDED_)
