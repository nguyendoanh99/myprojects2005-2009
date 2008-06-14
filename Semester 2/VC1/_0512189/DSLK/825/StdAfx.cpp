// stdafx.cpp : source file that includes just the standard includes
//	825.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <math.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getNode(DIEM x)
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
	DIEM temp;
	FILE* fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;

	init(l);
	while(fread(&temp,sizeof(DIEM),1,fp)==1)
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
		if(fwrite(&p->info,sizeof(DIEM),1,fp)==0)
			return 0;
	fclose(fp);
	return 1;
}

void xuat(DIEM P)
{
	printf("\n(%0.2f,%0.2f)",P.x,P.y);
}

void nhap(DIEM &P)
{
	float temp;
	printf("\nNhap x : ");
	scanf("%f",&temp);
	P.x=temp;
	printf("Nhap y : ");
	scanf("%f",&temp);
	P.y=temp;
}

void output(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
	{
		xuat(p->info);
	}
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
		DIEM x;
		nhap(x);
		p=getNode(x);
		addTail(l,p);
	}

}

void lietkephantuI(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(p->info.x >0 && p->info.y >0)
			xuat(p->info);
}

DIEM tungdoln(LIST l)
{
	DIEM lc=l.pHead->info;
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(lc.y < p->info.y)
			lc=p->info;

	return lc;
}

float kctoigoc(DIEM P)
{
	return (float)sqrt(P.x*P.x+P.y*P.y);
}


void sapxep(LIST &l)
{
	for(NODE *p=l.pHead;p!=l.pTail;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(kctoigoc(p->info) < kctoigoc(q->info))
			{
				DIEM temp=p->info;
				p->info=q->info;
				q->info=temp;
			}

}