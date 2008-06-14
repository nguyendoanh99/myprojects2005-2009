// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__AD8E0912_9AF2_4341_8CEC_16937BC7E05B__INCLUDED_)
#define AFX_STDAFX_H__AD8E0912_9AF2_4341_8CEC_16937BC7E05B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>
#include<ctype.h>

// TODO: reference additional headers your program requires here
struct node
{
	union type
	{
		unsigned char cinfo;
		char *sinfo;
	}t;
	
	struct node *pNext;
	struct node *pPrev;
};
typedef struct node NODE;


struct bigint
{
	NODE *pHead;
	NODE *pTail;
	bool sign;
};
typedef struct bigint BigInt;


void init(BigInt &l);

NODE *getnode1(unsigned char x);
NODE *getnode2(char x[]);
void addhead(BigInt &l,NODE *p);
void addtail(BigInt &l,NODE *p);

int ktlatoantu(char x);
int OPERATION(char *filename);
void output_s(BigInt l);
void output_c(BigInt l);

BigInt hauto(NODE *q,NODE *p);
int IsEmpty(BigInt stack);
void push(BigInt &stack,NODE *p);
NODE *pop(BigInt &stack);
char *pop_char(BigInt &stack);
int kiemtrauutien(char x,char y);


void taoxautuchuoi(BigInt &l,char *a);
void output_s(BigInt l);
void output_c(BigInt l);

BigInt operator + (BigInt &l,BigInt h);
BigInt operator - (BigInt &l,BigInt h);
BigInt operator*(BigInt l,BigInt h);

BigInt nhanxauvoiso(BigInt l,unsigned char k);

BigInt CreateBigInt(char *x);
BigInt tinh2xau(BigInt l,BigInt h,char x);
BigInt tinhmotbieuthuc(BigInt l);
void push_bigint(BigInt stack[],int &t,BigInt x);
BigInt pop_bigint(BigInt stack[],int &t);
void tach_to_bigint(char *x,BigInt &bieuthuc);

void remove_0(BigInt &l);
int sosanh2soduong(BigInt l,BigInt h);

char IsEmpty(char *s,int t);
void push(char *s,int &t,char x);
char pop(char *s,int &t);
int ktuutien(char *s,int t,char a,char b);
void addstack(char *a[],int n,char *b[],int &m,char *s,int &t);
void xuatmang(char *b,int m);


//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__AD8E0912_9AF2_4341_8CEC_16937BC7E05B__INCLUDED_)
