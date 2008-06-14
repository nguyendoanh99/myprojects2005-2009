// stdafx.cpp : source file that includes just the standard includes
//	823.pch will be the pre-compiled header
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

NODE *getnode(NHANVIEN x)
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
	init(l);
	FILE *fp=fopen(filename,"rb");
	if (!fp)
		return 0;
	NHANVIEN x;	
	NODE *p;
	while (fread(&x,sizeof(NHANVIEN),1,fp))
	{
		p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
	return 1;
}

int output(char *filename,LIST l)
{
	FILE *fp=fopen(filename,"wb");
	if (!fp)
		return 0;
	NODE *p=l.pHead;
	while (p)	
	{
		if (!fwrite(&p->info,sizeof(NHANVIEN),1,fp))
			return 0;
		p=p->pNext;

	}
	fclose(fp);
	return 1;
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void xuat(NHANVIEN x)
{
	printf("Ho ten: %s",x.hoten);
	printf("Ngay sinh :");
	xuat(x.ngaysinh);
	printf("\nLuong :%8.3f",x.luong);
	printf("\nGioi tinh: ");
	if (x.gioitinh)
		printf("Nam\n");
	else
		printf("Nu\n");	
}

void output(LIST l)
{
	for (NODE *p=l.pHead;p;p=p->pNext)
		xuat(p->info);
		printf("\n");
}

void lietke(LIST l)
{
	FILE *fp=fopen(filename1,"wb");	
	for (NODE *p=l.pHead;p;)
	{
		if (2006-p->info.ngaysinh.nm>40)
		{
			xuat(p->info);
			fwrite(&p->info,sizeof(NHANVIEN),1,fp);			
			printf("\n");
		}
		p=p->pNext;
	}
	fclose(fp);
}

int demluong(LIST l)
{
	int dem=0;
	FILE *fp=fopen(filename2,"wb");
	for (NODE *p=l.pHead;p;p=p->pNext)
		if (p->info.luong>1000000)
			 dem++;		
	fwrite(&dem,sizeof(dem),1,fp);
	fclose(fp);
	return dem;
}

void sapxepgiam(LIST &l)
{	

	for (NODE *p=l.pHead;p;)
	{
		int flag =0;
		for (NODE *q=p->pNext;q;q=q->pNext)		
			if (p->info.ngaysinh.nm<q->info.ngaysinh.nm)
			{
				hoanvi(l,p,q);
				NODE *t=p;
				p=q;
				q=t;
				flag=1;
			}
		
		if(flag)
			p=l.pHead;
		else
			p=p->pNext;
	}
}
// Ham hoanvi dung, khong can kiem tra
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
	for (int i=1;i<=n;i++)
	{
		//init(l);
		NHANVIEN x;
		fgets(x.hoten,31,fp);
		fscanf(fp,"%d %d %d",&x.ngaysinh.ng,&x.ngaysinh.th,
			&x.ngaysinh.nm);		
		fscanf(fp,"%f ",&x.luong);		
		fscanf(fp,"%d ",&x.gioitinh);
		NODE *p=getnode(x);
		addtail(l,p);
	}	
}