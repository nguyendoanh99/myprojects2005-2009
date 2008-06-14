// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D6BCC66F_287D_4F0E_8410_73507605FB1E__INCLUDED_)
#define AFX_STDAFX_H__D6BCC66F_287D_4F0E_8410_73507605FB1E__INCLUDED_

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
struct cauthu
{
	char macauthu[11];
	char tencauthu[31];
	NGAY ngaysinh;
};
typedef struct cauthu CAUTHU;
struct node
{
	CAUTHU info;
	struct node *pNext;
};
typedef struct node NODE;
struct list 
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(CAUTHU);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(NGAY);
void xuat(CAUTHU);
void output(LIST);
NGAY tim(LIST);
void lietke(LIST,NGAY);
void sapxepgiam(LIST &);
void hoanvi(LIST &,NODE *,NODE *);
int sosanh(NGAY,NGAY);
void _input(char *,LIST&);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D6BCC66F_287D_4F0E_8410_73507605FB1E__INCLUDED_)
