// stdafx.cpp : source file that includes just the standard includes
//	837.pch will be the pre-compiled header
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

NODE *getnode(LOPHOC x)
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
	LOPHOC x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(LOPHOC),1,fp))
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
		if (!fwrite(&p->info,sizeof(LOPHOC),1,fp))
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

void xuat(LOPHOC x)
{	
	printf("\nTen lop: %s",x.tenlop);	
	printf("Si so: %d",x.siso);	
	printf("\nDanh sach lop:\n");
	for (int i=0;i<x.siso;i++)
		xuat(x.dslop[i]);
}

LOPHOC timlop(LIST l)
{
	LOPHOC lc=l.pHead->info;
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)		
		if (lc.siso<p->info.siso)
			lc=p->info;
	FILE *fp=fopen(filename1,"wb");	
	fwrite(&lc,sizeof(LOPHOC),1,fp);
	fclose(fp);
	return lc;
}

HOCSINH timhocsinh(LIST l)
{
	HOCSINH lc=l.pHead->info.dslop[0];
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)	
	{
		for (int i=0;i<p->info.siso;i++)
			if (p->info.dslop[i].dtb>lc.dtb)
				lc=p->info.dslop[i];
	}		
	FILE *fp=fopen(filename2,"wb");	
	fwrite(&lc,sizeof(HOCSINH),1,fp);
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
		LOPHOC x;		
		fgets(x.tenlop,31,fp);
		fscanf(fp,"%d ",&x.siso);
		for (int i=0;i<x.siso;i++)
		{			
			fgets(x.dslop[i].hoten,31,fp);
			float temp;
			fscanf(fp,"%f ",&temp);
			x.dslop[i].toan=temp;
			fscanf(fp,"%f ",&temp);
			x.dslop[i].van=temp;
			x.dslop[i].dtb=(x.dslop[i].toan+x.dslop[i].van)/2;			
		}
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}