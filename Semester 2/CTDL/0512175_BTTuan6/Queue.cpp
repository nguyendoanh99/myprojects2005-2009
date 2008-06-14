#include "stdafx.h"
#include "Queue.h"
#include <stdlib.h>

void init(QUEUE &q)
{
	q.pHead=q.pTail=NULL;
}

void addtail(QUEUE &l,NODEQUEUE *p)
{
	if (l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;		
		l.pTail=p;
	}
}

int isEmpty(QUEUE q)
{
	return q.pHead==NULL;
}
NODEQUEUE *_getnode(void *x)
{
	NODEQUEUE *p=new NODEQUEUE;
	if (!p)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void enQueue(QUEUE &q,NODEQUEUE *p)
{
	addtail(q,p);
}

void *deQueue(QUEUE &q)
{
	if (isEmpty(q))
		return NULL;
	NODEQUEUE *p=q.pHead;
	q.pHead=q.pHead->pNext;
	void *x=p->info;
	delete p;
	return x;
}