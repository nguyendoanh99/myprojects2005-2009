// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__430EA41B_098A_4368_B2AA_B968C4EB107B__INCLUDED_)
#define AFX_STDAFX_H__430EA41B_098A_4368_B2AA_B968C4EB107B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct node
{
	char info;
	struct node *pnext;
	struct node *pprev;
};
typedef struct node NODE;

struct bigint
{
	NODE *phead;
	NODE *ptail;
	int dau;
};
typedef struct bigint BIGINT;

struct nodestack
{
	void *info;
	struct nodestack *pnext;
};
typedef struct nodestack NODESTACK;

struct stack
{

	NODESTACK *phead;
	NODESTACK *ptail;
};
typedef struct stack STACK;


void init(BIGINT &);

void addhead(BIGINT &,NODE *);
void addtail(BIGINT &,NODE *);
NODE *getnode(int);

int input(char *,char[][]);
void init(STACK &);
NODESTACK *getnode(void *);
void Push(STACK &,NODESTACK *);
void *Pop(STACK &);
int IsEmty(STACK );
BIGINT *TinhToan(char *);
void xuly(STACK &,STACK &,NODESTACK *);



void input(BIGINT &,char []);
void output(BIGINT );
int ss(BIGINT ,BIGINT );  
void cong(BIGINT ,BIGINT ,BIGINT & );
void tru(BIGINT ,BIGINT ,BIGINT &);
void nhan(BIGINT ,BIGINT ,BIGINT &);
int sosanh(BIGINT ,BIGINT );
void phepnhanluythua(BIGINT ,BIGINT &);
int length(BIGINT);
void xoa0dau(BIGINT &);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__430EA41B_098A_4368_B2AA_B968C4EB107B__INCLUDED_)
