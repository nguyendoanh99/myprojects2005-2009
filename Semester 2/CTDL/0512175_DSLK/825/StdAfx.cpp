// stdafx.cpp : source file that includes just the standard includes
//	825.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void addtail(LIST & l,NODE *p)
{
	if (l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}

NODE *getnode(DIEM x)
{
	NODE *p=new NODE;
	if (p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

int input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rb");
	if (!fp)
		return 0;
	DIEM x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(DIEM),1,fp))
	{
		p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
	return 1;
}

int output(char *filename,LIST l)
{
	FILE *fp=fopen(filename,"wb");
	if (!fp)
		return 0;
	for (NODE *p=l.pHead;p;p=p->pNext)
	{
		if (!fwrite(&p->info,sizeof(DIEM),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(DIEM x)
{
	printf("(%8.3f,%8.3f)",x.x,x.y);
}

void lietke(LIST l)
{
	FILE *fp=fopen(filename1,"wb");	
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.x>0 && p->info.y>0)
		{
			xuat(p->info);
			fwrite(&p->info,sizeof(DIEM),1,fp);			
			printf("\n");
		}
	fclose(fp);
}

float khoangcach0(DIEM a)
{
	return sqrt(a.x*a.x+a.y*a.y);
}

void output(LIST l)
{
	for (NODE *p=l.pHead;p;p=p->pNext)
	{
		xuat(p->info);		
		printf("\n");
	}
}
DIEM timdiem(LIST l)
{
	FILE *fp=fopen(filename2,"wb");
	DIEM max=l.pHead->info;
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.x>max.x)
			max=p->info;	
	fwrite(&max,sizeof(DIEM),1,fp);
	fclose(fp);
	return max;
}

void sapxepgiam(LIST &l)
{	
	NODE *p=l.pHead;
	NODE *q;
	while (p->pNext)
	{
		q=p->pNext;
		while (q)
		{
			if (khoangcach0(p->info) <khoangcach0(q->info))
			{
				hoanvi(l,p,q);
				NODE *temp=p;
				p=q;
				q=temp;
			}
			q=q->pNext;
		}
		p=p->pNext;
	}
}

void hoanvi(LIST &l,NODE *p,NODE *q)
{
	if (!p || !q || p==q)
		return ;
	int k=0;
	NODE *pPrev=NULL;
	NODE *qPrev=NULL;
	NODE *pNext=p->pNext;
	NODE *qNext=q->pNext;
	NODE *p1=l.pHead;
	if (p1==p || p1==q)
		k++;
	for (;k<2;p1=p1->pNext)
	{
		if (p1->pNext==p)
		{
			pPrev=p1;
			k++;
		}
		else
			if (p1->pNext==q)
			{
				qPrev=p1;
				k++;
			}	
	}
	l.pTail=qPrev;
	if (!l.pTail)
		l.pHead=NULL;
	addtail(l,p);
	// p, q xa nhau hay p < q
	if (qNext!=p)
	{
		addtail(l,qNext);
		l.pTail=pPrev;
	}
	if (!l.pTail)
		l.pHead=NULL;
	addtail(l,q);
	if (pNext!=q)	// p > q
		addtail(l,pNext);
	else			// p < q
		addtail(l,qPrev);
	for (l.pTail=q;l.pTail->pNext;l.pTail=l.pTail->pNext); 
}

void _input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rt");
	int n;
	fscanf(fp,"%d ",&n);
	init(l);
	for (int i=0;i<n;i++)
	{
		DIEM x;
		float temp;
		fscanf(fp,"%f",&temp);
		x.x=temp;
		fscanf(fp,"%f",&temp);
		x.y=temp;
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}