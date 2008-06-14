// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__02AABB13_5924_4874_8872_2ED9B9058F69__INCLUDED_)
#define AFX_STDAFX_H__02AABB13_5924_4874_8872_2ED9B9058F69__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct hocsinh
{
	char hoten[31];
	float toan;
	float van;
	float tb;
};
typedef struct hocsinh HOCSINH;

struct node
{
	HOCSINH info;
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
NODE *getnode(HOCSINH);
void addhead(LIST &,NODE *);
void output(LIST );
void input(char [],LIST &);
void output(char [],LIST );
void lietke(LIST);
int dem(LIST );
void sapxepgiam(LIST );

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__02AABB13_5924_4874_8872_2ED9B9058F69__INCLUDED_)
