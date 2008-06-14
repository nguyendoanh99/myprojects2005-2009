// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__4EC05726_C312_43B1_B7A3_86091B287A97__INCLUDED_)
#define AFX_STDAFX_H__4EC05726_C312_43B1_B7A3_86091B287A97__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"
#define filename3 "data3.out"
struct nhanvien
{
	char manv[6];
	char tennv[31];
	float luong;
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

NODE *getnode(NHANVIEN);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(NHANVIEN);
void output(LIST);
NHANVIEN timnhanvien(LIST);
float tongluong(LIST);
void sapxeptang(LIST &);
void hoanvi(LIST &,NODE *,NODE *);
void _input(char *,LIST &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__4EC05726_C312_43B1_B7A3_86091B287A97__INCLUDED_)
