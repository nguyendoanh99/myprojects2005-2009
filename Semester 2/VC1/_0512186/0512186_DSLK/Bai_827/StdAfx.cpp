// stdafx.cpp : source file that includes just the standard includes
//	Bai_827.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
// TODO: reference any additional headers you need in STDAFX.H

void nhapphong(PHONG &P)
{
	fflush(stdin);
	printf("\nMa phong:");
	gets(P.maphong);

	fflush(stdin);
	printf("Ten phong:");
	gets(P.tenphong);

	float temp;
	printf("Gia thue:");
	scanf("%f",&temp);
	P.giathue=temp;

	printf("So luong giuong:" );
	scanf("%d",&P.sogiuong);

	printf("Tinh trang phong:");
	scanf("%d",&P.tinhtrang);
}

void xuatphong(PHONG P)
{
	printf("Ma phong:%s",P.maphong);
	printf("Ten phong:%s",P.tenphong);
	printf("Gia thue:%8.2f",&P.giathue);
	printf("So luong giuong:%3d",P.sogiuong);
	printf("Tinh trang phong:%8.2f",P.tinhtrang);
}

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getnode(PHONG x)
{
	NODE *p=new NODE ;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void addtail(LIST &l,NODE *p)
{
	if(l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}

void nhap_ds(LIST &l)
{
	int n;
	printf("Nhap so luong phong:");
	scanf("%d",&n);
	init(l);
	for(int i=1;i<=n;i++)
	{
		printf("\nNhap thong tin phong thu:%d",i);
		PHONG temp;
		nhapphong(temp);
		NODE *p=getnode(temp);
		addtail(l,p);
	}
}

void xuat_ds(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		xuatphong(p->info);
}

int input(char *filename,LIST &l)
{
	PHONG temp;
	FILE *fp;
	fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;
	init(l);
	while(fread(&temp,sizeof(PHONG),1,fp)==1)
	{
		NODE *p=getnode(temp);
		addtail(l,p);
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
	NODE *p=l.pHead;
	while(p)
	{
		if(fwrite(&p->info,sizeof(PHONG),1,fp)==0)
			return 0;
		p=p->pNext;
	}
	fclose(fp);
	return 1;
}

void lk_phongtrong(LIST l)
{
	NODE *p=l.pHead;
	FILE *fp;
	fp=fopen("data3.out","wb");
	while(p)
	{
		if(p->info.tinhtrang==0)
		{
			xuatphong(p->info);
			fwrite(&p->info,sizeof(PHONG),1,fp);
			printf("\n");
		}
		p=p->pNext;
	}
}

int tonggiuong(LIST l)
{
	FILE *fp;
	fp=fopen("data3.out","wb");
	int dem=0;
	NODE *p=l.pHead;
	while(p)
	{
		dem+=p->info.sogiuong;
		p=p->pNext;
	}
	FILE *fp;
	fp=fopen("data3.out","wb");
	fwrite(&dem,sizeof(int),1,fp);
	return dem;
}

void selection_sort(LIST &l)
{

}

void saptang(LIST l)
{
	for(NODE *p=l.pHead;p->pNext;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(p->info.giathue>q->info.giathue)
			{
				PHONG temp=p->info;
				p->info=q->info;
				q->info=temp;
			}
}

// and not in this file
