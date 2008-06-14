// stdafx.cpp : source file that includes just the standard includes
//	826.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getNode(HOPSUA x)
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
	HOPSUA temp;
	FILE* fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;

	init(l);
	while(fread(&temp,sizeof(HOPSUA),1,fp)==1)
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
		if(fwrite(&p->info,sizeof(HOPSUA),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

void nhap(HOPSUA &x)
{
	float temp;
	fflush(stdin);
	printf("\nNhap nhan hieu : ");
	gets(x.nhanhieu);
	printf("Nhap trong luong : ");
	scanf("%f",&temp);
	x.trongluong=temp;
	printf("Nhap han su dung : ");
	nhap(x.hsd);
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

void xuat(HOPSUA x)
{
	printf("\nNhan hieu : %s",x.nhanhieu);
	printf("\n  Trong luong : %0.2f",x.trongluong);
	printf("\n  Han su dung : ");
	xuat(x.hsd);
}


void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
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
		HOPSUA x;
		nhap(x);
		p=getNode(x);
		addTail(l,p);
	}

}

int dem(LIST l)
{
	int d=0;
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(p->info.hsd.nm < 2003)
			d++;
	return d;

}

HOPSUA moinhat(LIST l)
{
	HOPSUA lc=l.pHead->info;
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(sosanh(lc.hsd,p->info.hsd)==-1)
			lc=p->info;
	return lc;

}

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

void sapxep(LIST &l)
{
	for(NODE *p=l.pHead;p!=l.pTail;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(sosanh(p->info.hsd,q->info.hsd)==1)
			{
				HOPSUA temp=p->info;
				p->info=q->info;
				q->info=temp;
			}
}