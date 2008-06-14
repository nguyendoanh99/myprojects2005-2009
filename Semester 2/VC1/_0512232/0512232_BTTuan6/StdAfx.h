// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__CDB7CAA3_C7CA_4766_9310_EC4CECD0108F__INCLUDED_)
#define AFX_STDAFX_H__CDB7CAA3_C7CA_4766_9310_EC4CECD0108F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>
// TODO: reference additional headers your program requires here

// STACK
int SIsEmpty(char *s,int t);
int SIsFull(char *s,int n,int t);
void push(char *s,int n,int &t,char x);
char pop(char *s,int &t);
int stack(char *x,int &t);

// QUEUE
void InitQueue(char *q,int n,int &f,int &r);
char QIsEmpty(char *q,int f);
char QIsFull(char *q,int r);
char EnQueue(char *q,int n,int &r,char x);
char DeQueue(char *q,int n,int &f);
int queue(char *x,int &f,int &r);

int input_output(char *filename1,char *filename2);



//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__CDB7CAA3_C7CA_4766_9310_EC4CECD0108F__INCLUDED_)
