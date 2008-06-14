#include "stdafx.h"
#include "sorting.h"

void SelectionSort(LIST &l)
{
	NODE *p,*q,*min;

	p=l.pHead;
	while(p!=l.pTail)
	{
		q=p->pNext;
		min=p;

		while(q)
		{
			if(q->info < min->info)
				min=q;
			q=q->pNext;
		}
		hoanvi(p->info,min->info);
		p=p->pNext;
	}
}

void InterchangeSort(LIST &l)
{
	for(NODE*p=l.pHead;p!=l.pTail;p=p->pNext)
		for(NODE*q=p->pNext;q;q=q->pNext)
			if(q->info < p->info)
				hoanvi(p->info,q->info);
}

void InsertionSort(LIST &l)
{
	for(NODE*t=l.pHead->pNext;t;t=t->pNext)
	{
		int x=t->info;
		NODE *p,*q=t;

		while(q!=l.pHead)
		{
			p=l.pHead;
			for(;p->pNext->info!=q->info;p=p->pNext);
			if(x<p->info)
				q->info=p->info;
			else
				break;
			q=p;
		}
		q->info=x;
	}
}

void hoanvi(int &a,int &b)
{
	int temp=a;
	a=b;
	b=temp;
}
