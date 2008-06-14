#include "stdafx.h"
#include <stdlib.h>

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getnode(int x)
{
	NODE *p=new NODE;
	if (!p)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void addtail(LIST &l,NODE *p)
{
	if (l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}

void delnode(LIST &l,NODE *p)
{
	if (p==l.pHead)
	{
		l.pHead=l.pHead->pNext;		
		if (l.pHead==NULL)
			l.pTail=NULL;
	}
	else
	{
		for (NODE *q=l.pHead;q->pNext!=p;q=q->pNext);
		q->pNext=p->pNext;
		if (p==l.pTail)
			l.pTail=q;
	}
	delete p;
}