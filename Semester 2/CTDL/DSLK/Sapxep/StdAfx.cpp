// stdafx.cpp : source file that includes just the standard includes
//	Sapxep.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
int demchuso(int n)
{
	int dem=0;
	do
	{
		n/=10;
		dem++;
	} while (n!=0);
	return dem;
}
int laychuso(int n,int d)
{
	for (;d>1;d--)
		n/=10;
	return n%10;
}

void input(char *filename,LIST *l)
{
	FILE *fp=fopen(filename,"rt");
	int n,x;
	fscanf(fp,"%d",&n);
	init(l);
	for (;n;n--)
	{
		fscanf(fp,"%d",&x);
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}
void init(LIST *l)
{
	(*l).pHead=(*l).pTail=NULL;
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

void addtail(LIST *l,NODE *p)
{
	if (l->pHead==NULL)
		l->pHead=l->pTail=p;
	else
	{
		(*l).pTail->pNext=p;
		(*l).pTail=p;		
	}
}

void xuat(LIST l)
{
	for (NODE *p=l.pHead;p;p=p->pNext)
		printf("%4d ",p->info);
}
// Sap xep giam dan
void QuickSort(LIST *l)
{
	if (l->pHead==l->pTail)
		return ;
	NODE *x=l->pHead;
	l->pHead=l->pHead->pNext;
	x->pNext=NULL;
	LIST l1;
	LIST l2;
	init(&l1);
	init(&l2);
	while (l->pHead)
	{
		NODE *p=l->pHead;
		l->pHead=l->pHead->pNext;
		p->pNext=NULL;		
		if (p->info>x->info)
			addtail(&l1,p);
		else
			addtail(&l2,p);
	}
	QuickSort(&l1);
	QuickSort(&l2);
	if (l1.pHead==NULL)
		l->pHead=x;
	else
	{
		*l=l1;
		l1.pTail->pNext=x;
	}
	x->pNext=l2.pHead;
	if (l2.pHead)
		l->pTail=l2.pTail;
	else
		l->pTail=x;
}
// Sap xep tang dan
void SelectionSort(LIST *l)
{
	LIST lst;
	init(&lst);
	while (l->pHead!=NULL)
	{		
		NODE *qPrev=NULL;
		NODE *q=l->pHead;
		NODE *pPrev=l->pHead;
		NODE *p=pPrev->pNext;
		while (p)
		{
			if (p->info<q->info)
			{
				q=p;
				qPrev=pPrev;
			}
			pPrev=p;
			p=p->pNext;
		}
		if (qPrev)
			qPrev->pNext=q->pNext;
		else
			l->pHead=l->pHead->pNext;
		q->pNext=NULL;
		addtail(&lst,q);
	}
	*l=lst;
}

void RadixSort(LIST *l)
{
	int k=0;
	for (NODE *p=l->pHead;p;p=p->pNext)
	{
		int dem=demchuso(p->info);
		if (dem>k)
			k=dem;
	}
	LIST lst[10];
	for (int j=0;j<10;j++)
		init(&lst[j]);
	for (int i=1;i<=k;i++)
	{		
		while (l->pHead)
		{
			NODE *p=l->pHead;
			l->pHead=l->pHead->pNext;
			p->pNext=NULL;
			addtail(&lst[laychuso(p->info,i)],p);
		}
		init(l);
		for (j=0;j<10;j++)
		{
			if (lst[j].pHead)
			{
				addtail(l,lst[j].pHead);			
				l->pTail=lst[j].pTail;
			}
			init(&lst[j]);
		}
	}
}

void RadixSort(int a[],int n)
{
	int k=0;
	for (int i=0;i<n;i++)
	{
		int dem=demchuso(a[i]);
		if (dem>k)
			k=dem;
	}
	for (i=1;i<=k;i++)
	{
		LIST l[10];
		for (int j=0;j<10;j++)
			init(&l[j]);
		for (j=0;j<n;j++)		
			addtail(&l[laychuso(a[j],i)],getnode(a[j]));
		int m=0;
		for (j=0;j<10;j++)
		{
			while (l[j].pHead)
			{
				NODE *p=l[j].pHead;
				l[j].pHead=l[j].pHead->pNext;
				a[m++]=p->info;
				delete p;
			}
		}
		
	}
}
void MergeSort(LIST *l)
{
	int n=0;
	for (NODE *p=l->pHead;p;p=p->pNext,n++);
	LIST lst[2];	
	int k=1;
	do
	{
		init(&lst[0]);
		init(&lst[1]);
		// Tach
		int d=0;
		int t=0;				
		while (l->pHead)
		{
			NODE *p=l->pHead;			
			l->pHead=l->pHead->pNext;
			p->pNext=NULL;
			addtail(&lst[t],p);
			d++;
			if (d==k)
			{							
				d=0;
				t=1-t;				
			}				
		}
		// Tron
		NODE *p[2];
		init(l);
		while (lst[0].pHead && lst[1].pHead)
		{
			int d0=k,d1=k;
			while (lst[0].pHead && lst[1].pHead && d0 && d1)
			{
				if (lst[0].pHead->info<lst[1].pHead->info)
				{
					NODE *q=lst[0].pHead;
					lst[0].pHead=q->pNext;
					q->pNext=NULL;
					addtail(l,q);
					d0--;
				}
				else
				{
					NODE *q=lst[1].pHead;
					lst[1].pHead=q->pNext;
					q->pNext=NULL;
					addtail(l,q);
					d1--;
				}
			}
			while (d0 && lst[0].pHead)
			{
				NODE *q=lst[0].pHead;
				lst[0].pHead=q->pNext;
				q->pNext=NULL;
				addtail(l,q);
				d0--;
			}
			while (d1 && lst[1].pHead)
			{
				NODE *q=lst[1].pHead;
				lst[1].pHead=q->pNext;
				q->pNext=NULL;
				addtail(l,q);
				d1--;
			}
		}
		if (lst[0].pHead)
		{
			addtail(l,lst[0].pHead);
			l->pTail=lst[0].pTail;
		}		
		k*=2;
	} while (k<n);
}