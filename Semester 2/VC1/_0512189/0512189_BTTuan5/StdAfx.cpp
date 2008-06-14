// stdafx.cpp : source file that includes just the standard includes
//	0512189_BTTuan5.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE* getnode(int x)
{
	NODE* p=new NODE;
	
	if(p==NULL)
		return NULL;

	p->info=x;
	p->pNext=NULL;
	return p;
}

void addHead(LIST &l,NODE*p)
{
	if(l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		p->pNext=l.pHead;
		l.pHead=p;
	}
}

void addTail(LIST &l,NODE*p)
{
	if(l.pTail==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}

int input(char*filename,LIST &l,int &x)
{
	int temp,m,n;
	NODE*p;

	FILE *fp=fopen(filename,"rt");
	if(fp==NULL)
		return 0;

	fscanf(fp,"%d ",&n);
	init(l);
	for(int i=01;i<=n;i++)
	{
		fscanf(fp,"%d ",&temp);
		p=getnode(temp);
		addTail(l,p);
	}

	xoaphantutrung(l);

	fscanf(fp,"%d ",&m);
	for( i=01;i<=m;i++)
	{
		fscanf(fp,"%d ",&temp);
		if(!timtrung(l,temp))
		{
			p=getnode(temp);
			addTail(l,p);
		}
	}
	
	fscanf(fp,"%d",&x);

	fclose(fp);
	return 1;
}

int output(char*filename, LIST &l)
{
	int n=0;

	FILE *fp=fopen(filename,"wt");
	if(fp==NULL)
		return 0;

	for(NODE*p=l.pHead;p;p=p->pNext)
		n++;
	fprintf(fp,"%d\n",n);

	for(p=l.pHead;p;p=p->pNext)
		fprintf(fp,"%d ",p->info);

	fclose(fp);
	return 1;
}

void RemoveAfter(LIST &l,NODE *q)
{
	NODE *p;
	
	if(q!=NULL)
	{
		p=q->pNext;
		if(p!=NULL)
		{
			if(p==l.pTail)
				l.pTail=q;
			q->pNext=p->pNext;
			delete p;
		}
	}
}

void xoaphantutrung(LIST &l)
{
	for(NODE*p=l.pHead;p;p=p->pNext)
	{
		NODE *q=p;
		while(q->pNext)
		{
			if(q->pNext->info==p->info)
				RemoveAfter(l,q);
			else
				q=q->pNext;
		}
	}
}

int timtrung(LIST l,int x)
{
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(p->info==x)
			return 1;
	return 0;
}

int ktnt(int k)
{
	int dem=0;
	for(int i=1;i<=k;i++)
		if(k%i==0)
			dem++;
	return dem==2;
}

void nguyento(LIST &l)
{
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(ktnt(p->info))
		{
			do
			{
				(p->info)++;
			}while(!ktnt(p->info));
		}
}

