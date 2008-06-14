#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <iostream.h>
#include "stack.h"
#include "bigint.h"

void xuat(I_NODE *x)
{
	if (x==NULL)
	{
		printf("NULL");
		return ;
	}
	bool k;
	char *s;
	switch (x->loai)
	{
	case _BIGINT: 
		xuat(*((BIGINT *) x->pInfo));
		break;
	case _CHAR:
		s=(char*) x->pInfo;
		printf("%s",s);
		break;
	case _BOOL:
		if (x->pInfo)
		{
			k=*((bool*) x->pInfo);
			if (k==true)
				printf("Dung");
			else
				printf("Sai");
		}
		else 
			printf("NULL");
		break;
	case _NULL:
		printf("NULL");
		break;
	}
}
void xuat(STACK st)
{
	I_NODE x;
	for (NODESTACK *p=st.pHead;p;p=p->pNext)
	{
		x=p->info;
		xuat(&x);		
		printf(" ");		
	}
}
// Chen p vao sau q
void addafter(STACK &st,NODESTACK *q,NODESTACK *p)
{
	if (q==NULL)	
		addhead(st,p);
	else
	{
		p->pNext=q->pNext;
		q->pNext=p;
		if (p->pNext==NULL)
			st.pTail=p;
	}	
}
// Them vao dau 
void addhead(STACK &s,NODESTACK *p)
{
	if (s.pHead==NULL)
		s.pHead=s.pTail=p;
	else
	{
		p->pNext=s.pHead;
		s.pHead=p;
	}
}
// Lay noi dung cua phan tu o dinh Stack
I_NODE top(STACK st)
{
	return st.pHead->info;
}
// Them p vao STACK
void push(STACK &s,NODESTACK *p)
{
	addhead(s,p);
}
// Lay phan tu ra khoi STACK
I_NODE pop(STACK &s)
{
	I_NODE x;
	if (isEmpty(s))
	{
		x.loai=_NULL;
		x.pInfo=NULL;
		return x;
	}
	else
	{
		NODESTACK *p=s.pHead;
		x=s.pHead->info;
		s.pHead=s.pHead->pNext;
		if (s.pHead==NULL)
			s.pTail=NULL;
		delete p;
		return x;
	}
}

NODESTACK *getnode(I_NODE x)
{
	NODESTACK *p=new NODESTACK;
	if (p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}
// Khoi tao STACK
void init(STACK &l)
{
	l.pHead=l.pTail=NULL;
}
// Kiem tra STACK co rong khong
int isEmpty(STACK l)
{
	return l.pHead==NULL;
}
// Them p vao cuoi STACK
void addtail(STACK &l,NODESTACK *p)
{
	if (l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;		
		l.pTail=p;
	}
}
// Xoa phan tu dung sau p
void delafter(STACK &l,NODESTACK *p)
{
	if (p==NULL)
	{
		p=l.pHead;
		l.pHead=l.pHead->pNext;
		if (l.pHead==NULL)
			l.pTail=NULL;
		if (p->info.pInfo!=NULL)		
			delete p->info.pInfo;		
		delete p;
	}
	else
	{
		NODESTACK *q=p->pNext;
		if (!q)
			return;
		p->pNext=q->pNext;
		if (q==l.pTail)
			l.pTail=p;
		delete q->info.pInfo;
		delete q;
	}
}
// Xoa tat ca cac phan tu trong STACK
void Empty(STACK &st)
{
	while (st.pHead)
		delafter(st,NULL);	
	init(st);
}