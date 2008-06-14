// stdafx.cpp : source file that includes just the standard includes
//	827.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getNode(PHONG x)
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
	PHONG temp;
	FILE* fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;

	init(l);
	while(fread(&temp,sizeof(PHONG),1,fp)==1)
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
		if(fwrite(&p->info,sizeof(PHONG),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

void nhap(PHONG &x)
{
	float temp;
	fflush(stdin);
	printf("\nNhap ma phong : ");
	gets(x.maphong);
	printf("Nhap ten phong : ");
	fflush(stdin);
	gets(x.tenphong);
	printf("Nhap don gia thue : ");
	scanf("%f",&temp);
	x.giathue=temp;
	printf("Nhap so luong giuong : ");
	scanf("%d",&x.sogiuong);
	printf("Nhap tinh trang phong : ");
	scanf("%d",&x.tinhtrang);
}

void xuat(PHONG x)
{
	printf("\nMa phong : %s",x.maphong);
	printf("\n  Ten phong : %s",x.tenphong);
	printf("\n  Don gia thue : %0.2f",x.giathue);
	printf("\n  So luong giuong : %d",x.sogiuong);
	if(x.tinhtrang)
		printf("\n  Tinh trang phong : Ban");
	else
		printf("\n  Tinh trang phong : Ranh");

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
		PHONG x;
		nhap(x);
		p=getNode(x);
		addTail(l,p);
	}

}

void lietke(LIST l)
{
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(p->info.tinhtrang ==0)
			xuat(p->info);
}

int tonggiuong(LIST l)
{
	int dem=0;
	for(NODE*p=l.pHead;p;p=p->pNext)
		dem+=p->info.sogiuong;
	return dem;

}
void sapxep(LIST &l)
{
	for(NODE *p=l.pHead;p!=l.pTail;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(p->info.giathue > q->info.giathue)
			{
				PHONG temp=p->info;
				p->info=q->info;
				q->info=temp;
			}

}

