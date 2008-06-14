// stdafx.cpp : source file that includes just the standard includes
//	826.pch will be the pre-compiled header
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

NODE *getnode(HOPSUA x)
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
	HOPSUA x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(HOPSUA),1,fp))
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
		if (!fwrite(&p->info,sizeof(HOPSUA),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void xuat(HOPSUA x)
{
	printf("\nNhan hieu: %s",x.nhanhieu);
	printf("Trong luong:%8.3f",x.trongluong);
	printf("\nHan su dung:");
	xuat(x.hsd);	
}

void output(LIST l)
{
	for (NODE *p=l.pHead;p;p=p->pNext)		
	{
		xuat(p->info);			
		printf("\n");
	}
}
HOPSUA timhopmoi(LIST l)
{
	FILE *fp=fopen(filename2,"wb");	
	HOPSUA moinhat=l.pHead->info;
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (sosanh(moinhat.hsd,p->info.hsd)==-1)
			moinhat=p->info;	
	fwrite(&moinhat,sizeof(HOPSUA),1,fp);			
	fclose(fp);
	return moinhat;
}

int demhopsua(LIST l)
{
	int dem=0;
	FILE *fp=fopen(filename1,"wb");
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.hsd.nm<2003)
			dem++;
	fwrite(&dem,sizeof(dem),1,fp);
	fclose(fp);
	return dem;
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
			if (sosanh(p->info.hsd,q->info.hsd)==1)
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
		HOPSUA x;
		fgets(x.nhanhieu,21,fp);
		float temp;
		fscanf(fp,"%f ",&temp);
		x.trongluong=temp;
		fscanf(fp,"%d %d %d ",&x.hsd.ng,&x.hsd.th,
			&x.hsd.nm);		
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}