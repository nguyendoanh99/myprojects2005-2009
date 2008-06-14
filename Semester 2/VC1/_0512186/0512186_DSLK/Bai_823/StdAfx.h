// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__4196E81B_3A7F_4087_969C_D0A888E3030B__INCLUDED_)
#define AFX_STDAFX_H__4196E81B_3A7F_4087_969C_D0A888E3030B__INCLUDED_

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

struct nhanvien
{
	char hoten[31];
	NGAY ngaysinh;
	float luong;
	int gioitinh;// 0:Nu , 1:Nam
};
typedef struct nhanvien NHANVIEN;

struct node
{
	NHANVIEN info;
	struct node*pNext;
};
typedef struct node NODE;

struct list
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

void init(LIST);
void addhead(LIST &, NODE *);
NODE *getnode(NHANVIEN);
void nhapds(LIST &);
void xuatds(LIST );
void nhapngay(NGAY &);
void xuatngay(NGAY );
void nhapnv(NHANVIEN &);
void xuatnv(NHANVIEN);
void input(LIST &);
void output(LIST);

void lietke(LIST );
int demluong(LIST);
void sapgiam(LIST);

int input(char *,LIST &);
int output(char*,LIST );


//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__4196E81B_3A7F_4087_969C_D0A888E3030B__INCLUDED_)
