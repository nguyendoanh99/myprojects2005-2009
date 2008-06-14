// stdafx.cpp : source file that includes just the standard includes
//	838.pch will be the pre-compiled header
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

NODE *getnode(SOTIETKIEM x)
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
	SOTIETKIEM x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(SOTIETKIEM),1,fp))
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
		if (!fwrite(&p->info,sizeof(SOTIETKIEM),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}

void xuat(SOTIETKIEM x)
{	
	printf("\nMa so: %s",x.maso);
	printf("Loai tiet kiem: %s",x.loai);
	printf("Ho ten khach hang: %s",x.hoten);
	printf("Chung minh nhan dan: %d",x.cmnd);
	printf("Ngay mo so: ");
	xuat(x.ngaymoso);
	printf("\nSo tien goi: %8.3f",x.tiengoi);	
}

float tongtien(LIST l)
{
	float tong=0;
	for (NODE *p=l.pHead;p;p=p->pNext)		
		tong+=p->info.tiengoi;
	FILE *fp=fopen(filename1,"wb");	
	fwrite(&tong,sizeof(float),1,fp);
	fclose(fp);
	return tong;
}

NODE *timnode(LIST l,int cmnd)
{	
	for (NODE *p=l.pHead;p;p=p->pNext)		
		if (p->info.cmnd==cmnd)
		{
			FILE *fp=fopen(filename2,"wb");	
			fwrite(&p,sizeof(NODE*),1,fp);
			fclose(fp);
			return p;
		}	
	return p;
}

void _input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rt");
	int n;
	fscanf(fp,"%d ",&n);
	init(l);
	for (int i=0;i<n;i++)
	{
		SOTIETKIEM x;		
		fgets(x.maso,6,fp);
		fgets(x.loai,11,fp);
		fgets(x.hoten,31,fp);
		fscanf(fp,"%d ",&x.cmnd);
		fscanf(fp,"%d %d %d ",&x.ngaymoso.ng
			,&x.ngaymoso.th,&x.ngaymoso.nm);
		float temp;
		fscanf(fp,"%f ",&temp);
		x.tiengoi=temp;		
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}