// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__E81D76F7_2607_4316_B79E_D65973CD97E0__INCLUDED_)
#define AFX_STDAFX_H__E81D76F7_2607_4316_B79E_D65973CD97E0__INCLUDED_

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
typedef struct nhanvien NHANVIEN;

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

void init(LIST&);
NODE *getNode(NHANVIEN );
void addTail(LIST&,NODE*);

void lietke(LIST);
int dem(LIST);
void sapxep(LIST&);

int input(char*,LIST&);
int output(char*,LIST);

void xuat(NHANVIEN);
void xuat(NGAY);

void nhap(LIST&);
void nhap(NGAY &);
void nhap(NHANVIEN &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__E81D76F7_2607_4316_B79E_D65973CD97E0__INCLUDED_)
