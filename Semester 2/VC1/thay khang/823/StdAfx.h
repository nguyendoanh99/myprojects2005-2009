// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__74AB73C6_AB55_4F8E_A44D_E7293BC135D1__INCLUDED_)
#define AFX_STDAFX_H__74AB73C6_AB55_4F8E_A44D_E7293BC135D1__INCLUDED_

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
	int gioitinh;
};
typedef struct nhanvien  NHANVIEN;

struct node
{
	NHANVIEN info;
	struct node *pnext;
};
typedef struct node NODE;

struct list
{
	NODE *phead;
	NODE *ptail;
};
typedef struct list LIST;


void init(LIST &);
NODE *getnode(NHANVIEN );
void addhead(LIST &,NODE *);
void output(LIST );
void input(char [],LIST &);
void output(char [],LIST );
void lietke(LIST );
int dem(LIST );
void sosanh(NGAY ,NGAY );
void sapxepgiam(LIST &);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__74AB73C6_AB55_4F8E_A44D_E7293BC135D1__INCLUDED_)
