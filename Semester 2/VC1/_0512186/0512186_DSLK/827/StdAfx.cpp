// stdafx.cpp : source file that includes just the standard includes
//	827.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdlib.h>
#include <stdio.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void addtail(LIST & l,NODE *p)
{
	if (l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}

NODE *getnode(PHONG x)
{
	NODE *p=new NODE;
	if (p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

int input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rb");
	if (!fp)
		return 0;
	PHONG x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(PHONG),1,fp))
	{
		p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
	return 1;
}

void output(LIST l)
{
	for (NODE *p=l.pHead;p;p=p->pNext)		
	{
		xuat(p->info);			
		printf("\n");
	}
}

int output(char *filename,LIST l)
{
	FILE *fp=fopen(filename,"wb");
	if (!fp)
		return 0;
	for (NODE *p=l.pHead;p;p=p->pNext)
	{
		if (!fwrite(&p->info,sizeof(PHONG),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(PHONG x)
{
	printf("Ma phong: %s",x.maphong);
	printf("Ten phong: %s",x.tenphong);
	printf("Don gia: %8.3f",x.dongia);
	printf("\nSo luong giuong: %d",x.soluong);
	printf("\nTinh trang phong: ");
	if (x.tinhtrang)
		printf("ban\n");
	else
		printf("ranh\n");	
}

void lietkephong(LIST l)
{
	FILE *fp=fopen(filename1,"wb");	
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.tinhtrang==0)
		{
			xuat(p->info);
			fwrite(&p->info,sizeof(PHONG),1,fp);			
			printf("\n");
		}
	fclose(fp);
}

int tonggiuong(LIST l)
{
	int dem=0;
	FILE *fp=fopen(filename2,"wb");
	for (NODE *p=l.pHead;p;p=p->pNext)		
			dem+=p->info.soluong;
	fwrite(&dem,sizeof(dem),1,fp);
	fclose(fp);
	return dem;
}

void sapxeptang(LIST &l)
{	
	NODE *p=l.pHead;
	NODE *q;
	while (p->pNext)
	{
		q=p->pNext;
		while (q)
		{
			if (p->info.dongia>q->info.dongia)
			{
				hoanvi(l,p,q);
				NODE *temp=p;
				p=q;
				q=temp;
			}
			q=q->pNext;
		}
		p=p->pNext;
	}

}

void hoanvi(LIST &l,NODE *p,NODE *q)
{
	if (!p || !q || p==q)
		return ;
	int k=0;
	NODE *pPrev=NULL;
	NODE *qPrev=NULL;
	NODE *pNext=p->pNext;
	NODE *qNext=q->pNext;
	NODE *p1=l.pHead;
	if (p1==p || p1==q)
		k++;
	for (;k<2;p1=p1->pNext)
	{
		if (p1->pNext==p)
		{
			pPrev=p1;
			k++;
		}
		else
			if (p1->pNext==q)
			{
				qPrev=p1;
				k++;
			}	
	}
	l.pTail=qPrev;
	if (!l.pTail)
		l.pHead=NULL;
	addtail(l,p);
	// p, q xa nhau hay p < q
	if (qNext!=p)
	{
		addtail(l,qNext);
		l.pTail=pPrev;
	}
	if (!l.pTail)
		l.pHead=NULL;
	addtail(l,q);
	if (pNext!=q)	// p > q
		addtail(l,pNext);
	else			// p < q
		addtail(l,qPrev);
	for (l.pTail=q;l.pTail->pNext;l.pTail=l.pTail->pNext);
}

void _input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rt");
	int n;
	fscanf(fp,"%d ",&n);
	init(l);
	for (int i=0;i<n;i++)
	{
		PHONG x;
		fgets(x.maphong,6,fp);
		fgets(x.tenphong,31,fp);
		float temp;
		fscanf(fp,"%f ",&temp);
		x.dongia=temp;
		fscanf(fp,"%d ",&x.soluong);		
		fscanf(fp,"%d ",&x.tinhtrang);
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}