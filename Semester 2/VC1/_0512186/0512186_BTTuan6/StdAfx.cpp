// stdafx.cpp : source file that includes just the standard includes
//	0512186_BTTuan6.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdlib.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void addhead(LIST &s,NODE *p)
{
	if (s.pHead==NULL)
		s.pHead=s.pTail=p;
	else
	{
		p->pNext=s.pHead;
		s.pHead=p;
	}
}

void push(LIST &s,NODE *p)
{
	addhead(s,p);
}

char pop(LIST &s)
{
	if (isEmpty(s))
		return 0;
	else
	{
		NODE *p=s.pHead;
		char x=s.pHead->info;
		s.pHead=s.pHead->pNext;
		delete p;
		return x;
	}
}

NODE *getnode(char x)
{
	NODE *p=new NODE;
	if (p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

int isEmpty(LIST l)
{
	return l.pHead==NULL;
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

void enQueue(LIST &q,NODE *p)
{
	addtail(q,p);
}

char deQueue(LIST &q)
{
	if (isEmpty(q))
		return NULL;
	NODE *p=q.pHead;
	q.pHead=q.pHead->pNext;
	char x=p->info;
	delete p;
	return x;
}