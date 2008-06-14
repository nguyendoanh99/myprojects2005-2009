// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__7EAA35DE_2D40_46CF_BAAD_56865E23CF0E__INCLUDED_)
#define AFX_STDAFX_H__7EAA35DE_2D40_46CF_BAAD_56865E23CF0E__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct phong
{
	char maphong[6];
	char tenphong[31];
	float giathue;
	int sogiuong;
	int tinhtrang;	
};
typedef struct phong PHONG;

struct node
{
	PHONG info;
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
NODE *getNode(PHONG );
void addTail(LIST&,NODE*);

int input(char*,LIST&);
int output(char*,LIST);
void input(LIST&);
void output(LIST);

void xuat(PHONG);
void nhap(PHONG &);

void lietke(LIST);
int tonggiuong(LIST);
void sapxep(LIST&);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__7EAA35DE_2D40_46CF_BAAD_56865E23CF0E__INCLUDED_)
