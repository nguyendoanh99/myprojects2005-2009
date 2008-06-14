// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__FB537BC1_D907_41AB_8267_60FBB7282AA8__INCLUDED_)
#define AFX_STDAFX_H__FB537BC1_D907_41AB_8267_60FBB7282AA8__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#define MAX 100000
struct node
{
	int info;
	struct node *pNext;
	struct node *pPre;

};
typedef struct node NODE;

struct bigint
{
	NODE *pHead;
	NODE *pTail;
	int sign;
};
typedef struct bigint BIGINT;

void init(BIGINT &);
NODE* getnode(int);
void addhead(BIGINT &,NODE*);
void addtail(BIGINT &,NODE*);

void input(BIGINT&);
void output(BIGINT);

BIGINT CreateBigint(char*);	//tao 1 so BIGINT tu 1 chuoi
BIGINT CreateBigint(BIGINT);//tao 1 so BIGINT giong BIGINT tham so
void DeleteBigint(BIGINT&);//xoa so BIGINT

void xoa0(BIGINT &); // Xoa cac so 0 vo nghia dung dau 1 so
int kiemtra0(BIGINT);//Kiem tra 1 so co = 0 ko ?

BIGINT cong(BIGINT,BIGINT);
BIGINT tru(BIGINT,BIGINT);
BIGINT nhan(BIGINT,BIGINT);

BIGINT operator*(BIGINT,BIGINT);
BIGINT operator+(BIGINT,BIGINT);
BIGINT operator-(BIGINT,BIGINT);

int ss(BIGINT,BIGINT);	//So sanh tri tuyet doi cua hai so
int sosanh(BIGINT,BIGINT);
void hoanvi(BIGINT &,BIGINT &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__FB537BC1_D907_41AB_8267_60FBB7282AA8__INCLUDED_)
