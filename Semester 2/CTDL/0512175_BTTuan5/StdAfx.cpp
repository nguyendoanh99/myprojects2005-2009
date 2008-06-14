// stdafx.cpp : source file that includes just the standard includes
//	0512175_BTTuan5.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "list.h"
#include <stdlib.h>
#include <stdio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

int input(char *filename,LIST &l,int &x)
{
	FILE *fp=fopen(filename,"rt");
	if (!fp)
		return 0;
	int n,m,temp;
	NODE *p;
	fscanf(fp,"%d ",&n);
	init(l);
	for (int i=1;i<=n;i++)
	{
		fscanf(fp,"%d ",&temp);
		p=getnode(temp);
		addtail(l,p);
	}
	xoatrung(l);
	fscanf(fp,"%d ",&m);
	for (i=1;i<=m;i++)
	{
		fscanf(fp,"%d ",&temp);
		if (!timtrung(l.pHead,temp))
		{
			p=getnode(temp);
			addtail(l,p);
		}
	}
	fscanf(fp,"%d ",&x);
	fclose(fp);
	return 1;
}

void xoatrung(LIST &l)
{
	NODE *p=l.pHead;
	NODE *q;
	while (p)
	{
		q=timtrung(p->pNext,p->info);
		while (q)
		{
			delnode(l,q);
			q=timtrung(p->pNext,p->info);
		}
		p=p->pNext;
	}
}

int ktnt(int n)
{
	for (int i=1,dem=0;i<=n;i++)
		if (n%i==0)
			dem++;
	return dem==2;
}

NODE *timtrung(NODE *p,int x)
{
	NODE *q=p;
	while (q && q->info!=x)		
		q=q->pNext;
	return q;

}

void tim_thaythe(LIST l)
{
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (ktnt(p->info))
		{
			p->info++;
			for (;!ktnt(p->info);p->info++);
		}
}

int output(char *filename,LIST l)
{
	FILE *fp=fopen(filename,"wt");
	if (!fp)
		return 0;
	int n=0;
	for (NODE *p=l.pHead;p;p=p->pNext,n++);
	fprintf(fp,"%d\n",n);
	for (p=l.pHead;p;p=p->pNext)
	{
		fprintf(fp,"%4d ",p->info);
	}
	fclose(fp);
	return 1;
}

void hoanvi(int &a,int &b)
{
	int temp=a;
	a=b;
	b=temp;
}