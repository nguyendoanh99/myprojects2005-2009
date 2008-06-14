// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__F18353C4_A738_4652_8EA3_3AA2648265BB__INCLUDED_)
#define AFX_STDAFX_H__F18353C4_A738_4652_8EA3_3AA2648265BB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here

struct node
{
	char digit;
	struct node*pNext;
	struct node*pPrev;
};
typedef struct node NODE ;

struct bigint
{
	char dau; // 1:duong,-1:am
	NODE *pHead;
	NODE *pTail;
};
typedef struct bigint BIGINT;

void init(BIGINT &);
//NODE *getnode(char *);
NODE *getnode(int );
void addhead(BIGINT &,NODE *p);
void addtail(BIGINT &,NODE *p);
void input(BIGINT &,char []);
void xuat(BIGINT );
BIGINT *CongBIGINT(BIGINT ,BIGINT );
BIGINT *TruBIGINT(BIGINT ,BIGINT );
int sosanh1(BIGINT , BIGINT );
int cmp_length(BIGINT ,BIGINT );
int sosanh(BIGINT ,BIGINT );
void xoa0(BIGINT );
BIGINT *nhan_tam(BIGINT , int );
BIGINT *NhanBIGINT(BIGINT ,BIGINT );
BIGINT tinhbieuthuc(char *);
void Phan2();
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__F18353C4_A738_4652_8EA3_3AA2648265BB__INCLUDED_)
