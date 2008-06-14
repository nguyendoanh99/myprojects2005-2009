// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__1C81C935_13EE_4041_98FA_F2376B2719B5__INCLUDED_)
#define AFX_STDAFX_H__1C81C935_13EE_4041_98FA_F2376B2719B5__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct node
{
	int info;
	struct node *pLeft;
	struct node *pRight;
};
typedef struct node NODE;
typedef struct node *TREE;

int input(char *,TREE &);
void init(TREE &);
int insert(TREE &,int);
int delnode(TREE&,int );
void searchStandFor(TREE &,TREE &);
void NLR(TREE);
void LNR(TREE);
void LRN(TREE);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__1C81C935_13EE_4041_98FA_F2376B2719B5__INCLUDED_)
