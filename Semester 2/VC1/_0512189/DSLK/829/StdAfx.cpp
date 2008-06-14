// stdafx.cpp : source file that includes just the standard includes
//	829.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getNode(TINH x)
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
	TINH temp;
	FILE* fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;

	init(l);
	while(fread(&temp,sizeof(TINH),1,fp)==1)
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
		if(fwrite(&p->info,sizeof(TINH),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

void nhap(TINH &x)
{
	float temp;
	fflush(stdin);
	printf("\nNhap ten tinh : ");
	gets(x.ten);

	printf("Nhap dien tich : ");
	scanf("%f",&temp);
	x.dientich=temp;
	printf("Nhap dan so : ");
	scanf("%d",&x.danso);
}

void xuat(TINH x)
{
	printf("\nTinh : %s",x.ten);
	printf("\n  Dien tich : %0.2f",x.dientich);
	printf("\n  Dan so : %ld",x.danso);
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
		TINH x;
		nhap(x);
		p=getNode(x);
		addTail(l,p);
	}

}

float tongdt(LIST l)
{
	float s=0;
	for(NODE*p=l.pHead;p;p=p->pNext)
		s+=p->info.dientich;
	return s;
}

NODE* dientichln(LIST l)
{
	NODE* q=l.pHead;
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(p->info.dientich > q->info.dientich)
			q=p;
	return q;
}

TINH dansoln(LIST l)
{
	TINH lc=l.pHead->info;
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(p->info.danso > lc.danso)
			lc=p->info;
	return lc;

}

void sapxep(LIST &l)
{
	for(NODE *p=l.pHead;p!=l.pTail;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(p->info.dientich > q->info.dientich)
			{
				TINH temp=p->info;
				p->info=q->info;
				q->info=temp;
			}

}
