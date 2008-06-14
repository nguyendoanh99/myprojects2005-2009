// stdafx.cpp : source file that includes just the standard includes
//	834.pch will be the pre-compiled header
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

NODE *getnode(NHANVIEN x)
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
	NHANVIEN x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(NHANVIEN),1,fp))
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
		if (!fwrite(&p->info,sizeof(NHANVIEN),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}


void xuat(NHANVIEN x)
{	
	printf("\nMa nhan vien: %s",x.manv);
	printf("Ten nhan vien: %s",x.tennv);
	printf("Luong nhan vien: %8.3f",x.luong);	
}

float tongluong(LIST l)
{
	float tong=0;
	for (NODE *p=l.pHead;p;p=p->pNext)		
		tong+=p->info.luong;
	FILE *fp=fopen(filename2,"wb");	
	fwrite(&tong,sizeof(float),1,fp);
	fclose(fp);
	return tong;
}

NHANVIEN timnhanvien(LIST l)
{
	NHANVIEN lc=l.pHead->info;
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)		
		if (lc.luong <p->info.luong)
			lc=p->info;
	FILE *fp=fopen(filename1,"wb");	
	fwrite(&lc,sizeof(NHANVIEN),1,fp);
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
			if (p->info.luong>q->info.luong)
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
		NHANVIEN x;		
		fgets(x.manv,6,fp);
		fgets(x.tennv,31,fp);
		float temp;
		fscanf(fp,"%f ",&temp);
		x.luong=temp;		
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}