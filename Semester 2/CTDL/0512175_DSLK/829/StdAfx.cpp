// stdafx.cpp : source file that includes just the standard includes
//	829.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdlib.h>
#include <stdio.h>

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

NODE *getnode(TINH x)
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
	TINH x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(TINH),1,fp))
	{
		p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
	return 1;
}

void output(LIST l)
{
	for (NODE *p=l.pHead;p;p=p->pNext)		
	{
		xuat(p->info);			
		printf("\n");
	}
}

int output(char *filename,LIST l)
{
	FILE *fp=fopen(filename,"wb");
	if (!fp)
		return 0;
	for (NODE *p=l.pHead;p;p=p->pNext)
	{
		if (!fwrite(&p->info,sizeof(TINH),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}


void xuat(TINH x)
{	
	printf("Ten tinh: %s",x.tentinh);
	printf("Dien tich: %8.3f",x.dientich);
	printf("\nDan so:%d",x.danso);	
}

float tongdientich(LIST l)
{
	float tong=0;
	for (NODE *p=l.pHead;p;p=p->pNext)		
		tong+=p->info.dientich;
	FILE *fp=fopen(filename1,"wb");	
	fwrite(&tong,sizeof(float),1,fp);
	fclose(fp);
	return tong;
}

NODE *diachinode(LIST l)
{
	NODE *lc=l.pHead;
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)		
		if (lc->info.dientich<p->info.dientich)
			lc=p;
	FILE *fp=fopen(filename2,"wb");	
	fwrite(&lc,sizeof(NODE*),1,fp);
	fclose(fp);
	return lc;
}

TINH timtinh(LIST l)
{
	TINH lc=l.pHead->info;
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)		
		if (lc.danso <p->info.danso)
			lc=p->info;
	FILE *fp=fopen(filename3,"wb");	
	fwrite(&lc,sizeof(TINH),1,fp);
	fclose(fp);
	return lc;
}

void sapxeptang(LIST &l)
{	
	NODE *p=l.pHead;
	NODE *q;
	while (p->pNext)
	{
		q=p->pNext;
		while (q)
		{
			if (p->info.dientich>q->info.dientich)
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
		TINH x;		
		fgets(x.tentinh,31,fp);
		float temp;
		fscanf(fp,"%f ",&temp);
		x.dientich=temp;
		fscanf(fp,"%d ",&x.danso);		
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}