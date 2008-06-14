// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__8BBC40DF_1EB0_4D3C_AC93_1AEBB50CBC2E__INCLUDED_)
#define AFX_STDAFX_H__8BBC40DF_1EB0_4D3C_AC93_1AEBB50CBC2E__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#include <stdio.h>
#define LH -1
#define EH 0
#define RH 1
struct AVLnode
{
	int balFactor;
	int info;
	struct AVLnode *pLeft;
	struct AVLnode *pRight;
};
typedef struct AVLnode *AVLTREE;
typedef struct AVLnode AVLNODE;

int insertNode(AVLTREE&,int );
int delNode(AVLTREE&,int);
int searchStandFor(AVLTREE&,AVLTREE&);
void rotateLL(AVLTREE&);
void rotateRR(AVLTREE&);
void rotateLR(AVLTREE&);
void rotateRR(AVLTREE&);
int balanceLeft(AVLTREE &);
int balanceRight(AVLTREE &);
void init(AVLTREE&);
int input(char *,AVLTREE&,int &);
void output(char *,AVLTREE,int);
int ktcp(int );
void NLR(AVLTREE,FILE*);
void LNR(AVLTREE,FILE*);
void LRN(AVLTREE,FILE*);
int tim(AVLTREE,int );
void XoaChinhPhuong(AVLTREE&);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__8BBC40DF_1EB0_4D3C_AC93_1AEBB50CBC2E__INCLUDED_)
