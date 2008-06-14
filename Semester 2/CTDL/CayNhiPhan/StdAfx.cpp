// stdafx.cpp : source file that includes just the standard includes
//	CayNhiPhan.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
int input(char *filename,TREE &T)
{
	FILE *fp=fopen(filename,"rt");
	if (!fp)
		return 0;
	int n;
	fscanf(fp,"%d ",&n);
	init(T);
	for (int i=0;i<n;i++)
	{
		int x;
		fscanf(fp,"%d ",&x);
		insert(T,x);
	}
	fclose(fp);
	return 1;
}
void init(TREE &T)
{
	T=NULL;
}
int insert(TREE &T,int x)
{
	if (T)
	{
		if (T->info==x)
			return 0;
		if (T->info>x)
			return insert(T->pLeft,x);
		return insert(T->pRight,x);
	}
	T=new NODE;
	if (T==NULL)
		return -1;
	T->info=x;
	T->pLeft=T->pRight=NULL;
	return 1;
}
int delnode(TREE &T,int x)
{
	if (T==NULL)
		return 0;
	if (T->info>x)
		return delnode(T->pLeft,x);
	if (T->info<x)
		return delnode(T->pRight,x);
	NODE *p;
	p=T;
	if (T->pLeft==NULL)
		T=T->pRight;
	else
		if (T->pRight==NULL)
			T=T->pLeft;
		else
		{
//			NODE *q=T->pRight;
			searchStandFor(p,T->pRight);
		}
	delete p;
}
void searchStandFor(TREE &p,TREE &q)
{
	if (q->pLeft)
		searchStandFor(p,q->pLeft);
	else
	{
		p->info=q->info;
		p=q;
		q=q->pRight;
	}
}
void NLR(TREE T)
{
	if (T)
	{
		printf("%d ",T->info);
		NLR(T->pLeft);
		NLR(T->pRight);
	}
}
void LNR(TREE T)
{
	if (T)
	{
		LNR(T->pLeft);
		printf("%d ",T->info);
		LNR(T->pRight);
	}
}
void LRN(TREE T)
{
	if (T)
	{
		LRN(T->pLeft);		
		LRN(T->pRight);
		printf("%d ",T->info);
	}	
}