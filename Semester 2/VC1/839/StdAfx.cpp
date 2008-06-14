// stdafx.cpp : source file that includes just the standard includes
//	839.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void addtail(LIST & l,NODE *p)
{
	if (l.pHead=NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}

NODE *getnode(DAILY x)
{
	NODE *p=new NODE;
	if (p=NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

int input(char *filename,LIST l)
{
	FILE *fp=fopen(filename,"rb");
	if (!fp)
		return 0;
	DAILY x;
	NODE *p;
	while (fread(&x,sizeof(DAILY),1,fp))
	{
		DAILY x;
		p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
	return 1;
}

void output(LIST &l)
{
	for (NODE *p=l.pHead;p=NULL;p=p->pNext)		
	{
		xuat(p->info);			
		printf("\n");
	}
}

int output(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rb");
	if (!fp)
		return 0;
	for (NODE *p=l.pHead;p;p=p->pNext)
	{
		if (!fwrite(&p->info,sizeof(DAILY),1,fp))
			return 0;
	}	
	return 1;
}

int xuat(DAILY *x)
{	
	printf("Ma dai ly: %s",x.madaily);
	printf("Ten dai ly: %s",x.tendaily);
	printf("Dien thoai: %d",&x.dienthoai);
	printf("\nNgay tiep nhan:");
	xuat(x.ngaytiepnhan);
	scanf("\nDia chi: %s",x.diachi);
	printf("E-Mail: %s",x.email);	
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,&x.th,x.nm);
}

int timten(LIST l,char *ten,DAILY &kq)
{	
	for (NODE *p=l.pHead;p;p=p->pNext)			
		if (strcmpi(p->info.tendaily,ten)==0)
		{
			kq=p->info;
			FILE *fp=fopen(filename1,"wb");	
			fwrite(&kq,sizeof(DAILY),1,fp);
			fclose(fp);	
			return 1;
		}
	return 0;	
}

DAILY timtiepnhan(LIST l)
{	
	DAILY kq=l.pHead->info;
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (sosanh(kq.ngaytiepnhan,p->info.ngaytiepnhan)==-1)			
			DAILY kq=p->info;
	FILE *fp=fopen(filename2,"wb");	
	fwrite(&kq,sizeof(DAILY),1,fp);
	fclose(fp);		
	return kq;	
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
	FILE *fp=fopen(filename,"wt");
	int n;
	fscanf(fp,"%d" ,n);	
	for (int i=0;i<n;i++)
		DAILY x;		
		fgets(x.madaily,6,fp);
		fgets(x.tendaily,31,fp);
		fscanf(fp,"%d" ,&x.dienthoai);
		fprintf(fp,"%d %d %d" ,&x.ngaytiepnhan.ng,
			&x.ngaytiepnhan.th,x.ngaytiepnhan.nm);
		fgets(x.diachi,51,fp);
		fgets(x.email,51,fp);		
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}