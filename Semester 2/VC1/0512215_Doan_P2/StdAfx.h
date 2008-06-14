// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__D9EF9692_2AB6_4ADD_83DD_A6927ECBC365__INCLUDED_)
#define AFX_STDAFX_H__D9EF9692_2AB6_4ADD_83DD_A6927ECBC365__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>


// TODO: reference additional headers your program requires here
struct node
{
	unsigned char info;
	struct node *pNext;
	struct node *pPrev;
};
typedef struct node NODE;


struct lnode
{
	char data[10000];
	struct lnode *next;
};
typedef struct lnode LNODE;

struct list
{
	LNODE *head;
	LNODE *tail;
};
typedef struct list LIST;


struct bigint
{
	NODE *pHead;
	NODE *pTail;
	bool sign;
};
typedef struct bigint BigInt;


void init(BigInt &l);
void init(LIST &l);
NODE *getnode(unsigned char x);
void addhead(BigInt &l,NODE *p);
void addtail(BigInt &l,NODE *p);
void taoxautuchuoi(BigInt &l,char *a);
void output(BigInt l);

BigInt operator + (BigInt &l,BigInt h);
BigInt operator - (BigInt &l,BigInt h);

char* file_to_mang(FILE *fp,char *a[],int &n,char *temp);
void xuatmang(char *a[],int n);
BigInt tinhmotbieuthuc(char *a[],int n);

int operation(char *filename);

int sosanh2soduong(BigInt l,BigInt h);
int ktlatoantu(char *a);


//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__AD8E0912_9AF2_4341_8CEC_16937BC7E05B__INCLUDED_)
