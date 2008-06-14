#include "stdafx.h"
#include <stdlib.h>
#include "stack.h"

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

void push(STACK &s,NODESTACK *p)
{
	addhead(s,p);
}

void *pop(STACK &s)
{
	if (isEmpty(s))
		return NULL;
	else
	{
		NODESTACK *p=s.pHead;
		void *x=s.pHead->info;
		s.pHead=s.pHead->pNext;
		delete p;
		return x;
	}
}

NODESTACK *getnode(void *x)
{
	NODESTACK *p=new NODESTACK;
	if (p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void init(STACK &l)
{
	l.pHead=l.pTail=NULL;
}

int isEmpty(STACK l)
{
	return l.pHead==NULL;
}
