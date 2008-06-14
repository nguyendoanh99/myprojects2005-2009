// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__E4922076_2029_4130_99A1_DBF7B7791179__INCLUDED_)
#define AFX_STDAFX_H__E4922076_2029_4130_99A1_DBF7B7791179__INCLUDED_

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
NODE *getNode(DIEM );
void addTail(LIST&,NODE*);

int input(char*,LIST&);
int output(char*,LIST);
void input(LIST&);
void output(LIST);

void xuat(DIEM);
void nhap(DIEM &);

void lietkephantuI(LIST);
DIEM tungdoln(LIST);
void sapxep(LIST&);
float kctoigoc(DIEM);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__E4922076_2029_4130_99A1_DBF7B7791179__INCLUDED_)
