// stdafx.cpp : source file that includes just the standard includes
//	828.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getNode(SACH x)
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
	SACH temp;
	FILE* fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;

	init(l);
	while(fread(&temp,sizeof(SACH),1,fp)==1)
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
		if(fwrite(&p->info,sizeof(SACH),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

void nhap(SACH &x)
{
	fflush(stdin);
	printf("\nNhap ten sach : ");
	gets(x.tensach);

	printf("Nhap ten tac gia : ");
	fflush(stdin);
	gets(x.tacgia);

	printf("Nhap nam xuat ban : ");
	scanf("%d",&x.namxb);
}

void xuat(SACH x)
{
	printf("\nSach : %s",x.tensach);
	printf("\n  Tac gia : %s",x.tacgia);
	printf("\n  Nam xuat ban : %d",x.namxb);

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
		SACH x;
		nhap(x);
		p=getNode(x);
		addTail(l,p);
	}

}

SACH tim(LIST l)
{
	SACH lc=l.pHead->info;
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(lc.namxb > p->info.namxb)
			lc=p->info;
	return lc;
		
}

int timnam(LIST l)
{
	int lc=l.pHead->info.namxb;
	int dem1=1;
	for(NODE*p=l.pHead;p;p=p->pNext)
	{
		int flag=1;
		int dem2=0;
		for(NODE*q=l.pHead;q!=p && flag;q=q->pNext)
			if(q->info.namxb == p->info.namxb)
				flag=0;
		if (flag)
		{
			for(NODE*q=l.pHead;q!=p && flag;q=q->pNext)
				if(q->info.namxb == p->info.namxb)
					dem2++;
			if(dem2>dem1)
			{
				dem1=dem2;
				lc=p->info.namxb;
			}
		}	

	}
	return lc;
}

void lietke(LIST l,int x)
{
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(p->info.namxb==x)
			xuat(p->info);
}

