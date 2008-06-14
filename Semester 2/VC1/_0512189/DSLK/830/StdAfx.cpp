// stdafx.cpp : source file that includes just the standard includes
//	830.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getNode(VE x)
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
	VE temp;
	FILE* fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;

	init(l);
	while(fread(&temp,sizeof(VE),1,fp)==1)
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
		if(fwrite(&p->info,sizeof(VE),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

void nhap(VE &x)
{
	fflush(stdin);
	printf("\nNhap ten phim : ");
	gets(x.tenphim);
	printf("Nhap gia tien : ");
	scanf("%ld",&x.giatien);
	printf("Nhap xuat chieu : ");
	nhap(x.xuatchieu);
	printf("Nhap ngay xem : ");
	nhap(x.ngayxem);

}

void nhap(NGAY &x)
{
	printf("\n	Nhap ngay : ");
	scanf("%d",&x.ng);
	printf("	Nhap thang : ");
	scanf("%d",&x.th);
	printf("	Nhap nam : ");
	scanf("%d",&x.nm);

}

void nhap(THOIGIAN &x)
{
	printf("\n	Nhap gio : ");
	scanf("%d",&x.gio);
	printf("	Nhap phut : ");
	scanf("%d",&x.phut);
	printf("	Nhap giay : ");
	scanf("%d",&x.giay);

}

void xuat(VE x)
{
	printf("\nPhim : %s",x.tenphim);
	printf("\n  Gia tien : %ld",x.giatien);
	printf("\n  Xuat chieu : ");
	xuat(x.xuatchieu);
	printf("\n  Ngay xem : ");
	xuat(x.ngayxem);

}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void xuat(THOIGIAN x)
{
	printf("%d:%d:%d",x.gio,x.phut,x.giay);
}

void output(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		xuat(p->info);
}

void input(LIST &l)
{
	int n;
	NODE*p;

	printf("Nhap vao n : ");
	scanf("%d",&n);
	init(l);
	
	for(int i=1;i<=n;i++)
	{
		VE x;
		nhap(x);
		p=getNode(x);
		addTail(l,p);
	}

}

long tonggiatien(LIST l)
{
	long s=0;
	for(NODE *p=l.pHead;p;p=p->pNext)
		s+=p->info.giatien;
	return s;

}

void sapxep(LIST&);

int sosanh(NGAY x,NGAY y)
{
	if(x.nm < y.nm)
		return -1;
	if(x.nm > y.nm)
		return 1;
	if(x.th < y.th)
		return -1;
	if(x.th < y.th)
		return 1;
	if(x.ng < y.ng)
		return -1;
	if(x.ng < y.ng)
		return 1;
	return 0;
}

int sosanh(THOIGIAN x,THOIGIAN y)
{
	if(x.gio < y.gio)
		return -1;
	if(x.gio > y.gio)
		return 1;
	if(x.phut < y.phut)
		return -1;
	if(x.phut < y.phut)
		return 1;
	if(x.giay < y.giay)
		return -1;
	if(x.giay < y.giay)
		return 1;
	return 0;
}

int sosanh(VE x,VE y)
{
	if(sosanh(x.ngayxem,y.ngayxem)==-1)
		return -1;
	if(sosanh(x.ngayxem,y.ngayxem)==1)
		return 1;
	if(sosanh(x.xuatchieu,y.xuatchieu)==-1)
		return -1;
	if(sosanh(x.xuatchieu,y.xuatchieu)==-1)
		return 1;
	return 0;
}
void sapxep(LIST &l)
{
	for(NODE *p=l.pHead;p!=l.pTail;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(sosanh(p->info,q->info)==1)
			{
				VE temp=p->info;
				p->info=q->info;
				q->info=temp;
			}
}
