// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__C046582A_E505_4C7B_8A35_7DB57D47C2FC__INCLUDED_)
#define AFX_STDAFX_H__C046582A_E505_4C7B_8A35_7DB57D47C2FC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct diem
{
	float x;
	float y;
};
typedef struct diem DIEM;

struct node
{
	DIEM info;
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
NODE *getnode(DIEM );
void addhead(LIST &,NODE *);
int input(char [],LIST &);
void lietke(LIST );
DIEM tunglonnhat(LIST );
void xuat(DIEM);
void sapxepgiam(LIST &);
int output(char [],LIST );
float khoangcach(DIEM ,DIEM );

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__C046582A_E505_4C7B_8A35_7DB57D47C2FC__INCLUDED_)
