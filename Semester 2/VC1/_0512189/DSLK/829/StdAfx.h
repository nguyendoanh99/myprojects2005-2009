// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__EF0CFEBC_FA3A_4D96_8731_6FB96C263BAD__INCLUDED_)
#define AFX_STDAFX_H__EF0CFEBC_FA3A_4D96_8731_6FB96C263BAD__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct tinh
{
	char ten[31];
	float dientich;
	long danso;
};
typedef struct tinh TINH;

struct node
{
	TINH info;
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
NODE *getNode(TINH );
void addTail(LIST&,NODE*);

int input(char*,LIST&);
int output(char*,LIST);
void input(LIST&);
void output(LIST);

void xuat(TINH);
void nhap(TINH &);

float tongdt(LIST);
NODE* dientichln(LIST);
TINH dansoln(LIST);
void sapxep(LIST &);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__EF0CFEBC_FA3A_4D96_8731_6FB96C263BAD__INCLUDED_)
