//#include "stdafx.h"
#include <stdio.h>
#include "stack.h"

// Cac thao tac tren STACK dung theo danh sach lien ket
NODE *getnode(KDL x)
{
	NODE *p=new NODE;
	if (!p)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}
void push(STACK &t,KDL x)
{
	NODE *p=getnode(x);
	if (!t.pHead)
	{
		t.pHead=t.pTail=p;
		return;
	}
	t.pTail->pNext=p;
	t.pTail=p;
}
KDL pop(STACK &t)
{
	KDL x={t.pTail->info.l,t.pTail->info.r};
	if (t.pHead==t.pTail)
	{
		delete t.pHead;
		t.pHead=t.pTail=NULL;
	}
	else
	{
		NODE *p=t.pHead;	
		while (p->pNext!=t.pTail)
			p=p->pNext;
		delete t.pTail;
		p->pNext=NULL;
		t.pTail=p;
	}
	return x;
}
void init(STACK &t)
{
	t.pHead=t.pTail=NULL;
}
int isEmpty(STACK t)
{
	return t.pHead==NULL;
}
