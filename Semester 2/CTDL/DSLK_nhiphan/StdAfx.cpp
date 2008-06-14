// stdafx.cpp : source file that includes just the standard includes
//	DSLK_nhiphan.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE*getnode(VE x)
{
	NODE*p=new NODE;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void addhead(LIST &l,NODE*p)
{
	if(l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		p->pNext=l.pHead;
		l.pHead=p;
	}
}

void xuat(THOIGIAN x)
{
	printf("%d:%d:%d",x.gio,x.phut,x.giay);
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void xuat(VE x)
{
	printf("\nTen phim:%s",x.tenphim);
	printf("\nGia tien:%ld",x.giatien);
	printf("\nXuat chieu:");
	xuat(x.xuatchieu);
	printf("\nNgay xem:");
	xuat(x.ngayxem);
}

void output(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		xuat(p->info);
}

long tongtien(LIST l)
{
	long S=0;
	for(NODE *p=l.pHead;p;p=p->pNext)
		S+=p->info.giatien;
	return S;
}

int sosanh(THOIGIAN x,THOIGIAN y)
{
	if(x.gio>y.gio)
		return 1;
	if(x.gio<y.gio)
		return -1;
	if(x.phut>y.phut)
		return 1;
	if(x.phut<y.phut)
		return -1;
	if(x.giay>y.giay)
		return 1;
	if(x.giay<y.giay)
		return -1;
	return 0;
}

int sosanh(NGAY x,NGAY y)
{
	if(x.nm>y.nm)
		return 1;
	if(x.nm<y.nm)
		return -1;
	if(x.th>y.th)
		return 1;
	if(x.th<y.th)
		return -1;
	if(x.ng>y.ng)
		return 1;
	if(x.ng<y.ng)
		return -1;
	return 0;
}

int sosanh(VE x,VE y)
{
	if(sosanh(x.ngayxem,y.ngayxem)==1)
		return 1;
	if(sosanh(x.ngayxem,y.ngayxem)==0)
		return -1;
	if(sosanh(x.xuatchieu,y.xuatchieu)==1)
		return 1;
	if(sosanh(x.ngayxem,y.ngayxem)==0)
		return -1;
	return 0;
}

void saptang(LIST l)
{
	for(NODE*p=l.pHead;p;p=p->pNext)
		for(NODE*q=p->pNext;q;q=q->pNext)
			if(sosanh(p->info,q->info)==1)
			{
				VE temp;
				temp=p->info;
				p->info=q->info;
				q->info=temp;
			}
}

int input(char *filename,LIST &l)
{
	VE temp;
	FILE *fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;
	init(l);
	while(fread(&temp,sizeof(VE),1,fp)==1)
	{
		NODE*p=getnode(temp);
		addhead(l,p);
	}
	fclose(fp);
	return 1;
}

int output(char *filename,LIST l)
{
	FILE *fp=fopen(filename,"wb");
	if(fp==NULL)
		return 0;
	for(NODE *p=l.pHead;p;p=p->pNext)
	{
		if(fwrite(&p->info,sizeof(VE),1,fp)==0)
			return 0;
	}
	fclose(fp);
	return 1;
}

void nhap(THOIGIAN &x)
{
	printf("\nNhap gio:");
	scanf("%d",&x.gio);
	printf("\nNhap phut:");
	scanf("%d",&x.phut);
	printf("\nNhap giay:");
	scanf("%d",&x.giay);
}

void nhap(NGAY &x)
{
	printf("\nNhap ngay:");
	scanf("%d",&x.ng);
	printf("\nNhap thang:");
	scanf("%d",&x.th);
	printf("\nNhap nam:");
	scanf("%d",&x.nm);
}

void nhap(VE &x)
{
	fflush(stdin);
	printf("Nhap ten phim:");
	gets(x.tenphim);
	printf("Nhap gia tien:");
	scanf("%ld",&x.giatien);
	printf("Nhap xuat chieu:");
	nhap(x.xuatchieu);
	printf("Nhap ngay xem:");
	nhap(x.ngayxem);
}

void nhap(LIST &l)
{
	int n;
	printf ("Nhap so phan tu cua danh sach n=");
	scanf("%d",&n);
	init(l);
	for(int i=0;i<n;i++)
	{
		VE x;		
		nhap(x);
		NODE *p=getnode(x);
		addhead(l,p);
	}
}
