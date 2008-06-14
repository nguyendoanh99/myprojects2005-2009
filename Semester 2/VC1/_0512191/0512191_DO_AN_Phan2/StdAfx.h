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
	char dau;
};
typedef struct bigint BIGINT;
void init(BIGINT &);
void addhead(BIGINT &,NODE *);
void addtail(BIGINT &,NODE *);
NODE *getnode(char );
void input(BIGINT &,char []);
void output(BIGINT );
int ss(BIGINT ,BIGINT );  
void cong(BIGINT ,BIGINT ,BIGINT & );
void tru(BIGINT ,BIGINT ,BIGINT &);
void nhan(BIGINT ,BIGINT ,BIGINT &);
int sosanh(BIGINT ,BIGINT );
void huykhong(BIGINT &);
void phepnhanluythua(BIGINT ,BIGINT &);
int length(BIGINT);
BIGINT tinhbieuthuc(char *s);
void Phan2();
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__430EA41B_098A_4368_B2AA_B968C4EB107B__INCLUDED_)
