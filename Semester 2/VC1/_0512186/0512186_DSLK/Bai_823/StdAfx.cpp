// stdafx.cpp : source file that includes just the standard includes
//	Bai_823.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include<conio.h>
// TODO: reference any additional headers you need in STDAFX.H

void init(LIST l)
{
	l.pHead=NULL;
	l.pTail=NULL;
}

NODE *getnode(NHANVIEN x)
{
	NODE *p=new NODE;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void addhead(LIST &l,NODE *p)
{
	if(l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		p->pNext=l.pHead;
		l.pHead=p;
	}
}

void nhapngay(NGAY &x)
{
	printf("\nNhap ngay:");
	scanf("%d",&x.ng);
	printf("Nhap thang:");
	scanf("%d",&x.th);
	printf("Nhap nam:");
	scanf("%d",&x.nm);
}

void nhapnv(NHANVIEN &x)
{
	float temp;
	fflush(stdin);
	printf("\nHo ten nhan vien:");
	gets(x.hoten);
	printf("Ngay sinh:");
	nhapngay(x.ngaysinh);
	printf("Luong:");
	scanf("%f",&temp);
	x.luong=temp;
	printf("Gioi tinh:");
	scanf("%d",&x.gioitinh);
}

void xuatngay(NGAY x)
{
	printf("%d:%d:%d",x.ng,x.th,x.nm);
}

void xuatnv(NHANVIEN x)
{
	printf("Ho ten nhan vien la:%s",x.hoten);
	printf("Ngay sinh la:");
	xuatngay(x.ngaysinh);
	printf("Luong nhan vien la:%8.3f",x.luong);
	printf("Gioi tinh:");
	if(x.gioitinh==0)
		printf("Nu\n");
	else
		printf("Nam\n");
}

void input(LIST &l)
{
	int n;
	printf("Nhap so luong nhan vien n=");
	scanf("%d",&n);
	init(l);
	for(int i=1;i<=n;i++)
	{
		NHANVIEN x;
		printf("\nNhap thong tin nhan vien %d",i);
		nhapnv(x);
		NODE *p=getnode(x);
		addhead(l,p);
	}
}

void output(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		xuatnv(p->info);
}

void lietke(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(2006-(p->info.ngaysinh.nm))
			xuatnv(p->info);
}

int demluong(LIST l)
{
	int dem=0;
	for(NODE *p=l.pHead;p;p=p->pNext)
		if((p->info.luong)>1000000)
			dem++;
	return dem;
}

void sapgiam(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(p->info.ngaysinh.nm<q->info.ngaysinh.nm)
			{
				NHANVIEN temp;
				temp=p->info;
				p->info=q->info;
				q->info=temp;
			}
}

int input(char *filename,LIST &l)
{
	NHANVIEN temp;
	FILE *fp;
	fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;
	init(l);
	while(fread(&temp,sizeof(NHANVIEN),1,fp)==1)
	{
		NODE *p=getnode(temp);
		addhead(l,p);
	}
	fclose(fp);
	return 1;
}

int output(char *filename,LIST l)
{
	FILE *fp;
	fp=fopen(filename,"wb");
	if(fp==NULL)
		return 0;
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(fwrite(&p->info,sizeof(NHANVIEN),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

// and not in this file
