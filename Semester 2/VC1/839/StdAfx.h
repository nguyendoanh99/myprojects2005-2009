// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__1FCDBEC3_075F_45C3_9284_EF681CE0B46E__INCLUDED_)
#define AFX_STDAFX_H__1FCDBEC3_075F_45C3_9284_EF681CE0B46E__INCLUDED_

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
typedef struct ngay NGAY;
struct daily
{
	char madaily[6];
	char tendaily[31];
	int dienthoai;
	NGAY ngaytiepnhan;
	char diachi[51];
	char email[51];
};
typedef struct daily DAILY;
struct node
{
	DAILY info;
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
NODE *getnode(DAILY);
void addtail(LIST &,NODE*);
void input(char *,LIST );
int output(char *,LIST);
void output(LIST);
void xuat(DAILY);
void xuat(NGAY);
int timten(LIST,char*,DAILY&);
DAILY timtiepnhan(LIST);
int sosanh(NGAY,NGAY);
void _input(char *,LIST &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__1FCDBEC3_075F_45C3_9284_EF681CE0B46E__INCLUDED_)
