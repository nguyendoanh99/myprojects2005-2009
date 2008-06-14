// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__449B9D5A_8668_4481_9293_A85081C89BD8__INCLUDED_)
#define AFX_STDAFX_H__449B9D5A_8668_4481_9293_A85081C89BD8__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here

struct phong
{
	char maphong[6];
	char tenphong[31];
	float giathue;
	int sogiuong;
	int tinhtrang; //0:ranh 1:ban
};
typedef struct phong PHONG;

struct node
{
	PHONG info;
	struct node*pNext;
};
typedef struct node NODE ;

struct list 
{
	NODE *pHead;
	NODE *pTail;
};
typedef struct list LIST ;

void init(LIST &);
void addtail(LIST &,NODE *);
NODE *getnode(PHONG );
void nhapphong(PHONG &);
void xuatphong(PHONG );
void nhap_ds(LIST &);
void xuat_ds(LIST );
int input(char *,LIST &);
int output(char *,LIST );
void lk_phongtrong(LIST );
int tonggiuong(LIST );
void selection_sort(LIST &);
void saptang(LIST );

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__449B9D5A_8668_4481_9293_A85081C89BD8__INCLUDED_)
