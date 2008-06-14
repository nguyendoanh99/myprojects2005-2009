// stdafx.cpp : source file that includes just the standard includes
//	825.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
#include "math.h"
const DIEM goc={0,0};

NODE *getnode(DIEM P)
{
	NODE *p=new NODE;
	if(p==NULL)
		return NULL;
	p->info=P;
	p->pnext=NULL;
	return p;
}

void init(LIST &l)
{
	l.phead=l.ptail=NULL;
}

void addhead(LIST &l,NODE *p)
{
	if(l.phead=NULL)
		l.phead=l.ptail=p;
	else
	{
		p->pnext=l.phead;
		l.phead=p;
	}
}

int input(char filename[],LIST &l)
{
	DIEM tam;
	FILE *fp;
	fp=fopen(filename,"rb");
	if(fp==NULL)
		return 0;
	init(l);
	while(fread(&tam,sizeof(DIEM),1,fp)==1)
	{
		NODE *p=getnode(tam);
		addhead(l,p);
	}
	fclose(fp);
	return 1;
}
void lietke(LIST l )
{
	for(NODE *p=l.phead;p!=NULL;p=p->pnext)
		if(p->info.x>0&&p->info.y>0)
			xuat(p->info);
}
DIEM tunglonnhat(LIST l)
{
	NODE *max;
	for(NODE *p=l.phead;p!=NULL;p=p->pnext)
		if(max->info.y>p->info.y)
			max=p;
	return max->info;
}

void xuat(DIEM P)
{
	printf("(%8.3,%8.3f)",P.x,P.y);
}

void sapxepgiam(LIST &l)
{
	for(NODE *p1=l.phead;p1!=l.ptail;p1=p1->pnext)
	{
		float tam=khoangcach(goc,p1->info);
		for(NODE *p2=p1->pnext;p2!=NULL;p2=p2->pnext)
			if(khoangcach(goc,p2->info)<tam)
	}
	
}
float khoangcach(DIEM P,DIEM Q)
{
	return sqrt(pow(P.x-Q.x,2)+pow(P.y-Q.y,2));
}


// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
