// stdafx.cpp : source file that includes just the standard includes
//	Bai_825.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
#include<math.h>
// TODO: reference any additional headers you need in STDAFX.H

void nhapdiem(DIEM &P)
{
	float temp;
	printf("\nNhap hoanh do:");
	scanf("%f",&temp);
	P.x=temp;
	printf("Nhap tung do:");
	scanf("%f",&temp);
	temp=P.y;
}

void xuatdiem(DIEM P)
{
	printf("(%8.3f,%8.3f)",P.x,P.y);
	printf("\n");
}

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
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

NODE *getnode(DIEM P)
{
	NODE *p=new NODE ;
	if(p==NULL)
		return NULL;
	p->info=P;
	p->pNext=NULL;
	return p;
}

void nhap_ds(LIST &l)
{
	int n;
	printf("Nhap so phan tu n=");
	scanf("%d",&n);
	init(l);
	for(int i=1;i<=n;i++)
	{
		DIEM temp;
		printf("\nNhap diem thu %d",i);
		nhapdiem(temp);
		NODE *p=getnode(temp);
		addtail(l,p);
	}
}

void xuat_ds(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		xuatdiem(p->info);
}

int ktthuoc(DIEM P)
{
	if(P.x>0&&P.y>0)
		return 1;
	else
		return 0;
}

void lietke(LIST l)
{
	FILE *fp;
	fp=fopen("data1.out","wb");
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(ktthuoc(p->info))
		{
			xuatdiem(p->info);
			fwrite(&p->info,sizeof(DIEM),1,fp);
			//printf("\n");
		}
}

DIEM tunglonnhat(LIST l)
{
	FILE *fp;
	fp=fopen("data2.out","wb");
	DIEM lc;
	lc.y=l.pHead->info.y;
	lc.x=l.pHead->info.x;
	for(NODE *p=l.pHead->pNext;p;p=p->pNext)
		if(p->info.y>lc.y)
		{
			DIEM temp;
			temp=p->info;
			p->info=lc;
			lc=temp;
		}

	fwrite(&lc,sizeof(DIEM),1,fp);
	return lc;
}

float kc(DIEM P)
{
	return sqrt((P.x*P.x)+(P.y*P.y));
}

void sapgiam(LIST l)
{
	for(NODE *p=l.pHead;p->pNext;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(kc(p->info)<kc(q->info))
			{
				DIEM temp=p->info;
				p->info=q->info;
				q->info=temp;
			}
}

int input1(char *filename,LIST &l)
{
	int n;
	FILE *fp;
	fp=fopen(filename,"rt");
	if(fp==NULL)
		return 0;
	init(l);
	fscanf(fp,"%d",&n);
	for(int i=1;i<=n;i++)
	{
		DIEM P;
		float temp1,temp2;
		fscanf(fp,"%f",&temp1);
		P.x=temp1;
		fscanf(fp,"%f",&temp2);
		P.y=temp2;
		NODE *p=getnode(P);
		addtail(l,p);
	}
	fclose(fp);
	return 1;
}

int input(char *filename,LIST &l)
{
	DIEM temp;
	FILE *fp;
	fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;
	init(l);
	while(fread(&temp,sizeof(DIEM),1,fp)==1)
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
		if(fwrite(&p->info,sizeof(DIEM),1,fp)==0)
			return 0;
		p=p->pNext;
	}
	fclose(fp);
	return 1;
}

// and not in this file
