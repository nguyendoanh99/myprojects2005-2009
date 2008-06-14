// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__AD8E0912_9AF2_4341_8CEC_16937BC7E05B__INCLUDED_)
#define AFX_STDAFX_H__AD8E0912_9AF2_4341_8CEC_16937BC7E05B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct dnode
{
	unsigned char info;
	struct dnode *pNext;
	struct dnode *pPrev;
};
typedef struct dnode DNODE;


struct dlist
{
	DNODE *pHead;
	DNODE *pTail;
};
typedef struct dlist DLIST;


struct bigint
{
	DNODE *pHead;
	DNODE *pTail;
	bool sign;
};
typedef struct bigint BigInt;


void init(BigInt &l);
DNODE *getdnode(unsigned char x);
void addhead(BigInt &l,DNODE *p);
void addtail(BigInt &l,DNODE *p);
void taoxautuchuoi(BigInt &l,char *a);
void output(BigInt l);
BigInt cong2xau(BigInt l,BigInt h);
BigInt tru2xau(BigInt l,BigInt h);
int sosanh(BigInt l,BigInt h);
int sosanh2xau(BigInt l,BigInt h);

BigInt nhanxauvoiso(BigInt l,unsigned char k);
BigInt nhanxauvoixau(BigInt l,BigInt h);
void tinhtoan(BigInt l,BigInt h,unsigned char x);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__AD8E0912_9AF2_4341_8CEC_16937BC7E05B__INCLUDED_)
