// stdafx.cpp : source file that includes just the standard includes
//	832.pch will be the pre-compiled header
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

NODE *getnode(CHUYENBAY x)
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
	CHUYENBAY x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(CHUYENBAY),1,fp))
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
		if (!fwrite(&p->info,sizeof(CHUYENBAY),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(CHUYENBAY x)
{	
	printf("Ma chuyen bay: %s",x.machuyenbay);
	printf("Ngay bay:");
	xuat(x.ngaybay);
	printf("\nGio bay:");
	xuat(x.giobay);
	printf("\nNoi di: %s",x.noidi);
	printf("Noi den: %s",x.noiden);	
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void xuat(THOIGIAN x)
{
	printf("%d:%d:%d",x.gio,x.phut,x.giay);
} 

int tansuat(LIST l,NGAY x)
{
	int dem=0;
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (sosanh(x,p->info.ngaybay)==0)
			dem++;
	return dem;
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

NGAY timngay(LIST l)
{
	NGAY lc=l.pHead->info.ngaybay;
	int _lc=tansuat(l,lc);	
	for (NODE *p=l.pHead;p;p=p->pNext)		
		if (_lc<tansuat(l,p->info.ngaybay))
		{
			lc=p->info.ngaybay;
			_lc=tansuat(l,lc);
		}
	FILE *fp=fopen(filename1,"wb");	
	fwrite(&lc,sizeof(NGAY),1,fp);
	fclose(fp);
	return lc;
}

int timchuyenbay(LIST l,char *ma,CHUYENBAY &kq)
{	
	int len=strlen(ma);
	ma[len]=10;
	ma[len+1]=0;
	for (NODE *p=l.pHead;p;p=p->pNext)			
		if (strcmpi(p->info.machuyenbay,ma)==0)
		{
			kq=p->info;
			FILE *fp=fopen(filename2,"wb");	
			fwrite(&kq,sizeof(CHUYENBAY),1,fp);
			fclose(fp);	
			return 1;
		}
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
		CHUYENBAY x;		
		fgets(x.machuyenbay,6,fp);
		fscanf(fp,"%d %d %d ",&x.ngaybay.ng,
			&x.ngaybay.th,&x.ngaybay.nm);
		fscanf(fp,"%d %d %d ",&x.giobay.gio,
			&x.giobay.phut,&x.giobay.giay); 
		fgets(x.noidi,21,fp);
		fgets(x.noiden,21,fp);
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}