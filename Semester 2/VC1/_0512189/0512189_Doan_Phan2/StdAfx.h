// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__78842DC5_7263_4949_AF2C_68289E36E8C2__INCLUDED_)
#define AFX_STDAFX_H__78842DC5_7263_4949_AF2C_68289E36E8C2__INCLUDED_

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

struct bt
{
	char s[MAX];
	BIGINT kq;
	struct bt *pNext;
	struct bt *pPre;

};
typedef struct bt BT;

struct bieuthuc
{
	BT *pHead;
	BT *pTail;
};
typedef struct bieuthuc BIEUTHUC;


void Phan2();
BIGINT tinhbieuthuc(char *);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__78842DC5_7263_4949_AF2C_68289E36E8C2__INCLUDED_)
