// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__099C92B6_3B39_4FCC_8930_DC718857FDBD__INCLUDED_)
#define AFX_STDAFX_H__099C92B6_3B39_4FCC_8930_DC718857FDBD__INCLUDED_

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

struct kdl
{
	char hoten[31];
	NGAY ngaysinh;
	float luong;
	int gioitinh;
};
typedef struct kdl NHANVIEN;
struct node
{
	NHANVIEN info;
	struct node *pNext;
};
typedef struct node NODE;
struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

void addtail(LIST &,NODE *);
NODE * getnode(NHANVIEN);
void init(LIST &);
int input(char *,LIST &);
int output(char *,LIST );
void xuat(NGAY);
void xuat(NHANVIEN);
void lietke(LIST);
int demluong(LIST );
void sapxepgiam(LIST &);
void hoanvi(LIST &l,NODE *,NODE *);
void output(LIST);
void _input(char *,LIST &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__099C92B6_3B39_4FCC_8930_DC718857FDBD__INCLUDED_)
