// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__38A32C99_B341_4224_B5BD_5EDF8210D8A9__INCLUDED_)
#define AFX_STDAFX_H__38A32C99_B341_4224_B5BD_5EDF8210D8A9__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"

struct thoigian
{
	int gio;
	int phut;
	int giay;
};
typedef struct thoigian THOIGIAN;
struct ngay
{
	int ng;
	int th;
	int nm;
};
typedef struct ngay NGAY;

struct chuyenbay
{
	char machuyenbay[6];
	NGAY ngaybay;
	THOIGIAN giobay;
	char noidi[21];
	char noiden[21];
typedef struct chuyenbay CHUYENBAY;
struct node
{
	CHUYENBAY info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(CHUYENBAY);
void init(LIST);
void addtail(LIST ,NODE *);
int input(char *,LIST &);
int output(char *,LIST );
void xuat(THOIGIAN);
void xuat(NGAY);
void xuat(CHUYENBAY);
NGAY timngay(LIST);
int timchuyenbay(LIST,char *,CHUYENBAY &);
void output(LIST);
int tansuat(LIST,NGAY);
int sosanh(NGAY,NGAY);
void _input(char *,LIST &)

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__38A32C99_B341_4224_B5BD_5EDF8210D8A9__INCLUDED_)
