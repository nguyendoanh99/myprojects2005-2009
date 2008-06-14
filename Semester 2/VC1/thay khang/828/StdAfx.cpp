// stdafx.cpp : source file that includes just the standard includes
//	828.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"


void init(LIST &l)
{
	l.phead=l.ptail=NULL;
}

NODE *getnode(SACH x)
{
	NODE *p= new NODE;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pnext=NULL;
	return p;
}

void addtail(LIST &l,NODE *p)
{
	if(l.phead==NULL)
		l.phead=l.ptail=p;
	else
	{
		l.ptail->pnext=p;
		l.ptail=p;
	}
}

void nhapsach(SACH &x)
{
	fflush(stdin);
	printf("\nNhap ten sach: ");
	gets(x.tensach);
	fflush(stdin);
	printf("\nNhap ten tac gia: ");
	gets(x.tentacgia);
	printf("\nNhap nam xuat ban: ");
	scanf("%d",&x.nam);
}

void xuatsach(SACH x)
{
	printf("\nTen sach : %s",x.tensach);
	printf("\nTen tac gia : %s",x.tentacgia);
	printf("\nNam xuat ban :%4d \n",x.nam);
}

void nhap_ds(LIST &l)
{
	init(l);
	int n;
	printf("Nhap so luong sach : ");
	scanf("%d",&n);
	for(int i=1;i<=n;i++)
	{
		SACH x;
		printf("\nNhap thong tin sach thu %d:",i);
		nhapsach(x);
		NODE *p=getnode(x);
		addtail(l,p);
	}
}

void xuat_ds(LIST l)
{
	int i=1;
	NODE *p=l.phead;
	while(p)
	{
		printf("\nThong tin sach thu %d:",i);
		xuatsach(p->info);
		p=p->pnext;
		i++;
	}
}

int input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;
	SACH temp;
	init(l);
	while(fread(&temp,sizeof(SACH),1,fp)==1)
	{
		NODE *p=getnode(temp);
		addtail(l,p);
		p=p->pnext;
	}
	fclose(fp);
	return 1;
}

int output(char *filename,LIST l)
{
	FILE *fp=fopen(filename,"wb");
	if(fp==NULL)
		return 0;
	NODE *p=l.phead;
	while(p)
	{
		if(fwrite(&p->info,sizeof(SACH),1,fp)==0)
			return 0;
		p=p->pnext;
	}
	fclose(fp);
	return 1;
}
SACH timsach(LIST l)
{
	NODE *p=l.phead;
	SACH lc=p->info;
	while(p)
	{
		if(p->info.nam>lc.nam)
			lc=p->info;
		p=p->pnext;
	}
	return lc;
}

int timnam(LIST );
void lietke(LIST ,int );
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
