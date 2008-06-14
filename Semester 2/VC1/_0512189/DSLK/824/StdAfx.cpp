// stdafx.cpp : source file that includes just the standard includes
//	824.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getNode(HOCSINH x)
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
	HOCSINH temp;
	FILE* fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;

	init(l);
	while(fread(&temp,sizeof(HOCSINH),1,fp)==1)
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
		if(fwrite(&p->info,sizeof(HOCSINH),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

void xuat(HOCSINH x)
{
	printf("\nHo ten : %s",x.hoten);
	printf("\n  Diem toan : %0.2f",x.toan);
	printf("\n  Diem van : %0.2f",x.van);
	printf("\n  Diem trung binh : %0.2f",x.dtb);
}

void nhap(HOCSINH &x)
{
	float temp;
	fflush(stdin);
	printf("\nNhap ho ten : ");
	gets(x.hoten);
	printf("Nhap diem toan : ");
	scanf("%f",&temp);
	x.toan=temp;
	printf("Nhap diem van : ");
	scanf("%f",&temp);
	x.van=temp;
	x.dtb=(x.toan+x.van)/2;
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
		HOCSINH x;
		nhap(x);
		p=getNode(x);
		addTail(l,p);
	}

}

void lietke(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(p->info.toan<5)
			xuat(p->info);
}

int demhs(LIST l)
{
	int dem=0;
	for(NODE*p=l.pHead;p;p=p->pNext)
		if(p->info.toan > 8 && p->info.van > 8)
			dem++;
	return dem;
}

void sapxep(LIST &l)
{
	for(NODE *p=l.pHead;p!=l.pTail;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(p->info.dtb < q->info.dtb)
			{
				HOCSINH temp=p->info;
				p->info=q->info;
				q->info=temp;
			}

}

