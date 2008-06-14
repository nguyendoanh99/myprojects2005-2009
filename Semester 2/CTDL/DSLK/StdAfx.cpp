// stdafx.cpp : source file that includes just the standard includes
//	DSLK.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdlib.h>
#include <stdio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

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
	p->count=1;
	p->pNext=NULL;
	return p;
}
// Chen p vao sau q
void addAfter(LIST &l,NODE *p,NODE *q)
{
	if (q==NULL)
		l.pHead=l.pTail=p;
	else
	{
		p->pNext=q->pNext;
		q->pNext=p;
		if (q==l.pTail)
			l.pTail=p;
	}
}

void xuat(LIST l)
{
	for (NODE *p=l.pHead;p!=l.pTail->pNext;p=p->pNext)
		printf("%4d ",p->info);
}

void nhapbaotoan(LIST &l)
{
	int x;
	NODE *sent=getnode(0);
	printf("Nhap x (x=0:dung): ");
	scanf("%d",&x);
	init(l);
	addAfter(l,getnode(0),NULL);
	l.pHead->pNext=sent;
	while (x)
	{
		sent->info=x;
		NODE *p=getnode(x);
		NODE *w2=l.pHead;
		NODE *w1=w2->pNext;
//		if (!w1)
//			addAfter(l,p,w2);
//		else
		{
			while (w1->info<x)	// Dung linh canh
//			while ((w1->pNext) && w1->info<x)
			{
				w2=w1;
				w1=w1->pNext;
			}
			if (w1->info==x && w1!=sent)	// Dung linh canh
//			if (w1->info==x)
				w1->count++;
			else
				if (w1->info>=x)	// Dung linh canh
//				if (w1->info>x)
					addAfter(l,p,w2);
				else
					addAfter(l,p,w1);
		}
		printf("Nhap x (x=0:dung): ");
		scanf("%d",&x);
	}
}