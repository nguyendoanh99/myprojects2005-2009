// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D566D377_EDCA_4C8D_9DF7_D65F7E160B85__INCLUDED_)
#define AFX_STDAFX_H__D566D377_EDCA_4C8D_9DF7_D65F7E160B85__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"
#define filename3 "data3.out"
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
NODE *getnode(HOPSUA);
void init(LIST&);
void addhead(LIST&,NODE*);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(NGAY);
void xuat(HOPSUA);
int demhopsua(LIST);
HOPSUA timhopmoi(LIST);
void sapxeptang(LIST &);
void hoanvi(LIST &,NODE *,NODE *);
int sosanh(NGAY,NGAY);
void output(LIST);
void _input(char *,LIST &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__D566D377_EDCA_4C8D_9DF7_D65F7E160B85__INCLUDED_)
