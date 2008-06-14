// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__C5B310F2_F652_447B_B64C_498BE59FB976__INCLUDED_)
#define AFX_STDAFX_H__C5B310F2_F652_447B_B64C_498BE59FB976__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct hocsinh
{
	char hoten[31];
	float toan;
	float van;
	float dtb;
};
typedef struct hocsinh HOCSINH;

struct node
{
	HOCSINH info;
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
NODE *getNode(HOCSINH );
void addTail(LIST&,NODE*);

int input(char*,LIST&);
int output(char*,LIST);
void input(LIST&);
void output(LIST);

void xuat(HOCSINH);
void nhap(HOCSINH &);


void lietke(LIST);
int demhs(LIST);
void sapxep(LIST&);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__C5B310F2_F652_447B_B64C_498BE59FB976__INCLUDED_)
