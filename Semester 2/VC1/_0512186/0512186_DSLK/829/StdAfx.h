// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__246E9815_57EA_4B3E_A5FB_EFF9E1F65F5F__INCLUDED_)
#define AFX_STDAFX_H__246E9815_57EA_4B3E_A5FB_EFF9E1F65F5F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"
#define filename3 "data3.out"
#define filename4 "data4.out"
struct tinh
{
	char tentinh[31];
	float dientich;
	int danso;
};
typedef struct tinh TINH;
struct node
{
	TINH info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(TINH);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST );
void xuat(TINH);
float tongdientich(LIST);
NODE *diachinode(LIST);
TINH timtinh(LIST);
void sapxeptang(LIST&);
void hoanvi(LIST &,NODE *,NODE *);
void output(LIST);
void _input(char *,LIST &);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__246E9815_57EA_4B3E_A5FB_EFF9E1F65F5F__INCLUDED_)
