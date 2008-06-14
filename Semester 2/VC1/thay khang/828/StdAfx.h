// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__6C7FA10A_EF37_4A97_A4DF_BEE5034675E6__INCLUDED_)
#define AFX_STDAFX_H__6C7FA10A_EF37_4A97_A4DF_BEE5034675E6__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct sach
{
	char tensach[51];
	char tentacgia[31];
	int nam;
};
typedef struct sach SACH;

struct node 
{
	SACH info;
	struct node *pnext;
};
typedef struct node NODE;

struct list
{
	NODE *phead;
	NODE *ptail;
};
typedef struct list LIST;

void init(LIST &);
NODE *getnode(SACH );
void addtail(LIST &,NODE *);
void nhapsach(SACH &);
void xuatsach(SACH );
void nhap_ds(LIST &);
void xuat_ds(LIST );
int input(char *,LIST &);
int output(char *,LIST );
SACH timsach(LIST );
int timnam(LIST );
void lietke(LIST ,int );

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__6C7FA10A_EF37_4A97_A4DF_BEE5034675E6__INCLUDED_)
