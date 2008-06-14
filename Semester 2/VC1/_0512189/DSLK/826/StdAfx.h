// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__548EAE76_1AA7_4349_9C82_5DCAB04C6314__INCLUDED_)
#define AFX_STDAFX_H__548EAE76_1AA7_4349_9C82_5DCAB04C6314__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct ngay
{
	int ng;
	int th;
	int nm;
};
typedef struct ngay NGAY;

struct hopsua
{
	char nhanhieu[21];
	float trongluong;
	NGAY hsd;
};
typedef struct hopsua HOPSUA;

struct node
{
	HOPSUA info;
	struct node *pNext;
};
typedef struct node NODE;

struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;


void init(LIST&);
NODE *getNode(HOPSUA );
void addTail(LIST&,NODE*);

int input(char*,LIST&);
int output(char*,LIST);
void input(LIST&);
void output(LIST);

void xuat(HOPSUA);
void nhap(HOPSUA &);
void xuat(NGAY);
void nhap(NGAY &);

int dem(LIST);
HOPSUA moinhat(LIST);
void sapxep(LIST &);
int sosanh(NGAY,NGAY);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__548EAE76_1AA7_4349_9C82_5DCAB04C6314__INCLUDED_)
