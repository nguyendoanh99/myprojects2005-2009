// stdafx.cpp : source file that includes just the standard includes
//	Bai_831.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<stdio.h>
// TODO: reference any additional headers you need in STDAFX.H

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getnode(MATHANG x)
{
	NODE *p=new NODE ;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void addtail(LIST &l,NODE *p)
{
	if(l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}

int input(char *filename,LIST &l)
{
	long temp1,temp2;
	int n;
	char temp3[21];
	FILE *fp=fopen(filename,"rt");
	if(fp==NULL)
		return 0;
	fscanf(fp,"%d",&n);
	for(int i=0;i<n;i++)
	{
		fgets(temp3,21,fp);
		fscanf(fp,"%ld",&temp1);
		fscanf(fp,"%ld",&temp2);
	}
	fclose(fp);
	return 1;
}

int output(char *filename,LIST &);
{
	FILE *fp=fopen(filename,"rt");
	if(fp==NULL)
		return 0;
}

// and not in this file
