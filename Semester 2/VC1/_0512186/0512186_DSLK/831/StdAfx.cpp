// stdafx.cpp : source file that includes just the standard includes
//	831.pch will be the pre-compiled header
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

NODE *getnode(MATHANG x)
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
	MATHANG x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(MATHANG),1,fp))
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
		if (!fwrite(&p->info,sizeof(MATHANG),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(MATHANG x)
{	
	printf("\nTen mat hang: %s",x.tenhang);
	printf("Don gia: %d",x.dongia);
	printf("\nSo luong ton:%d",x.luongton);
}

int demmathang(LIST l)
{
	int dem=0;
	for (NODE *p=l.pHead;p;p=p->pNext)		
		if (p->info.luongton>1000)
			dem++;
	FILE *fp=fopen(filename2,"wb");	
	fwrite(&dem,sizeof(int),1,fp);
	fclose(fp);
	return dem;
}

MATHANG tim(LIST l)
{
	MATHANG lc=l.pHead->info;
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)		
		if (lc.dongia*lc.luongton<p->info.dongia*p->info.luongton)
			lc=p->info;
	FILE *fp=fopen(filename1,"wb");	
	fwrite(&lc,sizeof(MATHANG),1,fp);
	fclose(fp);
	return lc;
}

void _input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rt");
	int n;
	fscanf(fp,"%d ",&n);
	init(l);
	for (int i=0;i<n;i++)
	{
		MATHANG x;		
		fgets(x.tenhang,21,fp);
		fscanf(fp,"%d ",&x.dongia);
		fscanf(fp,"%d ",&x.luongton);		
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}