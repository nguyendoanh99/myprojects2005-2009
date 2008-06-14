// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__0FD4483A_D134_4CEC_95E5_CE285C50CDAF__INCLUDED_)
#define AFX_STDAFX_H__0FD4483A_D134_4CEC_95E5_CE285C50CDAF__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define filename1 "data1.out"
#define filename2 "data2.out"

struct thisinh
{
	char mathisinh[6];
	char hoten[31];
	float toan;
	float ly;
	float hoa;
	float dtongcong;
};
typedef struct thisinh THISINH;
struct node 
{
	THISINH info;
	struct node *pNext;
};
typedef struct node NODE;
struct list 
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST;

NODE *getnode(THISINH);
void init(LIST &);
void addtail(LIST &,NODE *);
int input(char *,LIST &);
int output(char *,LIST);
void xuat(THISINH);
void output(LIST);
void lietke(LIST);
void sapxepgiam(LIST &);
void hoanvi(LIST&,NODE *,NODE *);
void _input(char *,LIST &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__0FD4483A_D134_4CEC_95E5_CE285C50CDAF__INCLUDED_)
