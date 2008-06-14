#include "stdafx.h"

void SelectionSort(LIST l)
{
	for (NODE *p=l.pHead;p->pNext;p=p->pNext)
	{
		NODE *min=p;
		for (NODE *q=p->pNext;q;q=q->pNext)
			if (min->info>q->info)
				min=q;
		hoanvi(min->info,p->info);			
	}
}

void InterchangeSort(LIST l)
{
	for (NODE *p=l.pHead;p->pNext;p=p->pNext)
		for (NODE *q=p->pNext;q;q=q->pNext)
			if (p->info>q->info)
				hoanvi(q->info,p->info);
}

void InsertionSort(LIST l)
{
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)
	{
		int x=p->info;
		NODE *q,*p1=p;
		while (p1!=l.pHead)
		{
			q=l.pHead;
			for (;q->pNext!=p1;q=q->pNext);
			if (q->info>x)
				p1->info=q->info;
			else
				break;
			p1=q;
		}
		p1->info=x;
	}
}