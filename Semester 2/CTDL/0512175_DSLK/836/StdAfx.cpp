// stdafx.cpp : source file that includes just the standard includes
//	836.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
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

NODE *getnode(LUANVAN x)
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
	LUANVAN x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(LUANVAN),1,fp))
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
		if (!fwrite(&p->info,sizeof(LUANVAN),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(LUANVAN x)
{	
	printf("\nMa luan van: %s",x.maLV);
	printf("Ten luan van: %s",x.tenLV);	
	printf("Sinh vien thuc hien: %s",x.hotenSV);
	printf("Giao vien huong dan: %s",x.hotenGV);
	printf("Nam thuc hien: %d",x.nam);
}

int tansuat(LIST l,int nam)
{
	int dem=0;
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (nam==p->info.nam)
			dem++;
	return dem;
}

int timnam(LIST l)
{
	int lc=l.pHead->info.nam;
	int _lc=tansuat(l,lc);	
	for (NODE *p=l.pHead;p;p=p->pNext)		
		if (_lc<tansuat(l,p->info.nam))
		{
			lc=p->info.nam;
			_lc=tansuat(l,lc);
		}
	FILE *fp=fopen(filename1,"wb");	
	fwrite(&lc,sizeof(LUANVAN),1,fp);
	fclose(fp);
	return lc;
}

int timnamgannhat(LIST l)
{		
	int max=l.pHead->info.nam;
	for (NODE *p=l.pHead;p;p=p->pNext)			
		if (max<p->info.nam)
			max=p->info.nam;
	return max;
}

void lietke(LIST l,int nam)
{	
	FILE *fp=fopen(filename2,"wb");	
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)		
		if (p->info.nam==nam)
		{
			xuat(p->info);	
			fwrite(&p->info,sizeof(LUANVAN),1,fp);
		}
	fclose(fp);	
}

void _input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rt");
	int n;
	fscanf(fp,"%d ",&n);
	init(l);
	for (int i=0;i<n;i++)
	{
		LUANVAN x;		
		fgets(x.maLV,11,fp);
		fgets(x.tenLV,101,fp);
		fgets(x.hotenSV,31,fp);
		fgets(x.hotenGV,31,fp);
		fscanf(fp,"%d ",&x.nam);		
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}
