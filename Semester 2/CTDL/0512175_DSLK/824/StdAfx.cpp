// stdafx.cpp : source file that includes just the standard includes
//	824.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
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

NODE *getnode(HOCSINH x)
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
	FILE *fp=fopen(filename,"rb+");
	if (!fp)
		return 0;
	int len;
	fseek(fp,0,SEEK_END);
	len=ftell(fp);	
	printf("%d	sizeof() %d	\t",len,sizeof(HOCSINH));
	fseek(fp,-sizeof(HOCSINH),SEEK_END);
	len=ftell(fp);
	printf("%d	",len);
	fseek(fp,0,SEEK_SET);
	len=ftell(fp);	
	printf("%d	",len);
	HOCSINH x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(HOCSINH),1,fp))
	{
		p=getnode(x);
		addtail(l,p);
		printf("len %d	\n",ftell(fp));
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
		if (!fwrite(&p->info,sizeof(HOCSINH),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(HOCSINH x)
{
	printf("Ho ten: %s",x.hoten);
	printf("Diem toan: %8.3f",x.toan);
	printf("\nDiem van: %8.3f",x.van);
	printf("\nDiem trung binh: %8.3f\n",x.dtb);	
}

void output(LIST l)
{
	for (NODE *p=l.pHead;p;p=p->pNext)
	{
		xuat(p->info);		
		printf("\n");
	}
}

void lietke(LIST l)
{
	FILE *fp=fopen(filename1,"wb");	
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.toan<5)
		{
			xuat(p->info);
			fwrite(&p->info,sizeof(HOCSINH),1,fp);			
			printf("\n");
		}
	fclose(fp);
}

int demdiem(LIST l)
{
	int dem=0;
	FILE *fp=fopen(filename2,"wb");
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.toan>8 && p->info.van>8)
			dem++;
	fwrite(&dem,sizeof(dem),1,fp);
	fclose(fp);
	return dem;
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
			if (p->info.dtb <q->info.dtb)
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
		HOCSINH x;
		fgets(x.hoten,31,fp);
		float temp;
		fscanf(fp,"%f ",&temp);
		x.toan=temp;
		fscanf(fp,"%f ",&temp);
		x.van=temp;
		x.dtb=(x.toan+x.van)/2;
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}