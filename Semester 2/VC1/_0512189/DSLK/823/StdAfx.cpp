// stdafx.cpp : source file that includes just the standard includes
//	823.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <time.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getNode(NHANVIEN x)
{
	NODE *p=new NODE;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void addTail(LIST &l,NODE *p)
{
	if(l.pTail==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}

int input(char*filename,LIST &l)
{
	NHANVIEN temp;
	FILE* fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;

	init(l);
	while(fread(&temp,sizeof(NHANVIEN),1,fp)==1)
	{
		NODE *p=getNode(temp);
		addTail(l,p);
	}
	fclose(fp);
	return 1;
	
}


int output(char*filename,LIST l)
{
	FILE* fp=fopen(filename,"wb");
	if(fp==NULL)
		return 0;
	
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(fwrite(&p->info,sizeof(NHANVIEN),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

void lietke(LIST l)
{
	for(NODE*p=l.pHead;p;p=p->pNext)
		if((2006 - p->info.ngaysinh.nm)>40)
			xuat(p->info);
}


int dem(LIST l)
{
	int d=0;
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(p->info.luong > 1000000)
			d++;
	return d;
}

void sapxep(LIST &l)
{
	for(NODE*p=l.pHead;p!=l.pTail;p=p->pNext)
		for(NODE*q=p->pNext;q;q=q->pNext)
			if(p->info.ngaysinh.nm < q->info.ngaysinh.nm)
			{
				NHANVIEN t=p->info;
				p->info=q->info;
				q->info=t;
			}
}

void xuat(NHANVIEN x)
{
	printf("\nTen : %s",x.hoten);
	printf("\nNgay sinh : ");
	xuat(x.ngaysinh);
	printf("\nLuong : %.2f",x.luong);
	printf("\nGioi tinh : ");
	if(x.gioitinh==0)
		printf("Nu");
	else
		printf("Nam");

}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void nhap(LIST &l)
{
	int n;
	printf("Nhap vap n : ");
	scanf("%d",&n);
	init(l);
	for(int i=1;i<=n;i++)
	{
		NHANVIEN x;
		nhap(x);
		NODE*p=getNode(x);
		addTail(l,p);
	}
}

void nhap(NGAY &x)
{
	printf("Ngay : ");
	scanf("%d",&x.ng);
	printf("\nThang : ");
	scanf("%d",&x.th);
	printf("\nNam : ");
	scanf("%d",&x.nm);

}


void nhap(NHANVIEN &x)
{
	float temp;
	fflush(stdin);
	printf("\nNhap ho ten : ");
	gets(x.hoten);
	printf("\nNgay sinh : ");
	nhap(x.ngaysinh);
	printf("\nLuong : ");
	scanf("%d",&temp);
	x.luong=temp;
	printf("\nGioi tinh : ");
	scanf("%d",&x.gioitinh);
}
