// stdafx.cpp : source file that includes just the standard includes
//	833.pch will be the pre-compiled header
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

NODE *getnode(CAUTHU x)
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
	CAUTHU x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(CAUTHU),1,fp))
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
		if (!fwrite(&p->info,sizeof(CAUTHU),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void xuat(CAUTHU x)
{	
	printf("\nMa cau thu: %s",x.macauthu);
	printf("Ten cau thu: %s",x.tencauthu);
	printf("Ngay sinh:");
	xuat(x.ngaysinh);
}

NGAY tim(LIST l)
{
	NGAY lc=l.pHead->info.ngaysinh;
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)		
		if (sosanh(lc,p->info.ngaysinh)==-1)
			lc=p->info.ngaysinh;	
	return lc;
}

void lietke(LIST l,NGAY ng)
{	
	FILE *fp=fopen(filename1,"wb");	
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)		
		if (sosanh(ng,p->info.ngaysinh)==0)
		{
			xuat(p->info);	
			fwrite(&p->info,sizeof(CAUTHU),1,fp);
		}
	fclose(fp);	
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
			if (sosanh(p->info.ngaysinh,q->info.ngaysinh)==-1)
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

int sosanh(NGAY x,NGAY y)
{
	if (x.nm>y.nm)
		return 1;
	if (x.nm<y.nm)
		return -1;
	if (x.th>y.th)
		return 1;
	if (x.th<y.th)
		return -1;
	if (x.ng>y.ng)
		return 1;
	if (x.ng<y.ng)
		return -1;
	return 0;
}

void _input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rt");
	int n;
	fscanf(fp,"%d ",&n);
	init(l);
	for (int i=0;i<n;i++)
	{
		CAUTHU x;		
		fgets(x.macauthu,11,fp);
		fgets(x.tencauthu,31,fp);		
		fscanf(fp,"%d %d %d ",&x.ngaysinh.ng,
			&x.ngaysinh.th,&x.ngaysinh.nm);
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}