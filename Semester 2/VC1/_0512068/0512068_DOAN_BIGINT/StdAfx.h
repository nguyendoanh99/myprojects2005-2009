// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__756D145A_C718_4B08_85CE_BE035BA8F21F__INCLUDED_)
#define AFX_STDAFX_H__756D145A_C718_4B08_85CE_BE035BA8F21F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <iostream.h>
#include <string.h>
#include <ctype.h>



// KHAI BAO CAC KIEU CAU TRUC CAN SU DUNG
// 1
struct node
{
	int info;
	struct node *pNext;
	struct node *pPrev;
};
typedef struct node NODE;
// 2
struct bigint
{
	bool dau;
	NODE *pHead;
	NODE *pTail;
};
typedef struct bigint BIGINT;
// 3
struct node_st
{
	char info;
	struct node_st *pNext;
};
typedef struct node_st NODE_ST;
// 4
struct stack
{
	NODE_ST *pHead;
	NODE_ST *pTail;
	int so_node;
};
typedef struct stack STACK;
// 5
struct unit
{
	int type; 
	union
	{
		BIGINT data;
		char op;
	}ptu;
};
typedef struct unit UNIT;
// 6
struct bieuthuc
{
	BIGINT giatri;
	UNIT un[100];
	int so_unit;
};
typedef struct bieuthuc BIEUTHUC;




// CAC THAO TAC TREN DSLK KEP (BIGINT)
void Init(BIGINT &b);
NODE *Get_node(int n);
void Add_head(BIGINT &b,NODE *p);
void Add_tail(BIGINT &b,NODE *p);


// CAC THAO TAC TREN DSLK DON (STACK)
void Push(STACK &S,NODE_ST *p);
char Pop(STACK &S);
char Top(STACK S);
NODE_ST *Getnode_stack(char x);
void Init_stack(STACK &S);
bool Is_empty(STACK S);


// CAC HAM NHAP XUAT , DOC GHI FILE
void Input(BIGINT &b);
void Output(BIGINT b);
void Read_file(char *filename,BIEUTHUC bt[],int &n);
void Xuat_ktra(BIEUTHUC bt[],int t);


// CAC THAO TAC PHU
int Count_chuso(BIGINT b);
int Do_uutien(char a,char b);
int Compare_khongdau(BIGINT b1,BIGINT b2);
void Dichtrai_2nac(BIEUTHUC &bt,int vtri);
void Create_dodai_bangnhau(BIGINT &b1,BIGINT &b2);
void Add_tail_0_nlan(BIGINT &temp,int n);
BIGINT Nhan_khongdau(BIGINT b,int n);;
BIGINT Create_bigint(int *a,int n);
BIGINT Tinh(BIGINT b1,BIGINT b2,char x);
BIGINT operator+(BIGINT b1,BIGINT b2);
BIGINT operator-(BIGINT b1,BIGINT b2);
BIGINT operator*(BIGINT b1,BIGINT b2);


// CAC THAO TAC CHINH
// Phan 1
BIGINT Cong(BIGINT b1,BIGINT b2);
BIGINT Tru(BIGINT b1,BIGINT b2);
BIGINT Nhan(BIGINT b1,BIGINT b2);
int Sosanh(BIGINT b1,BIGINT b2);
// Phan 2 va 3
BIEUTHUC Chuyenve_postfix(BIEUTHUC &bt);
BIGINT Tinh_postfix(BIEUTHUC bt);
BIGINT Tinh_bieuthuc(BIEUTHUC bt);
void Tinh_cacbieuthuc(BIEUTHUC bt[],int n);



//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__756D145A_C718_4B08_85CE_BE035BA8F21F__INCLUDED_)
