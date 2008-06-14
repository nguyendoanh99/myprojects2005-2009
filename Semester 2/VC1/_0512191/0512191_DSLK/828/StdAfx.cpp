// stdafx.cpp : source file that includes just the standard includes
//	828.pch will be the pre-compiled header
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

NODE *getnode(SACH x)
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
	SACH x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(SACH),1,fp))
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
		if (!fwrite(&p->info,sizeof(SACH),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void xuat(SACH x)
{	
	printf("Ten sach: %s",x.tensach);
	printf("Ten tac gia: %s",x.tacgia);
	printf("Nam xuat ban:");
	xuat(x.xuatban);
}

void lietke(LIST l,int nam)
{
	FILE *fp=fopen(filename2,"wb");	
	fwrite(&nam,sizeof(int),1,fp);
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.xuatban.nm==nam)
		{
			xuat(p->info);
			fwrite(&p->info,sizeof(SACH),1,fp);			
			printf("\n");
		}
	fclose(fp);
}

SACH timsach(LIST l)
{
	FILE *fp=fopen(filename1,"wb");
	SACH lc=l.pHead->info;
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)
		if (sosanh(lc.xuatban,p->info.xuatban)==1)
			lc=p->info;
	fwrite(&lc,sizeof(SACH),1,fp);
	return lc;
	fclose(fp);
}

int tansuat(LIST l,int nam)
{
	int dem=0;
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.xuatban.nm==nam)
			dem++;
	return dem;
}

int timnam(LIST l)
{
	int nam=l.pHead->info.xuatban.nm;
	int max=tansuat(l,nam);
	
	for (NODE *p=l.pHead->pNext;p;p=p->pNext)
		if (max<tansuat(l,p->info.xuatban.nm))
		{
			max=tansuat(l,p->info.xuatban.nm);
			nam=p->info.xuatban.nm;
		}
	return nam;
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
		SACH x;		
		fgets(x.tensach,51,fp);
		fgets(x.tacgia,31,fp);
		fscanf(fp,"%d %d %d ",&x.xuatban.ng,&x.xuatban.th,&x.xuatban.nm);		
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}