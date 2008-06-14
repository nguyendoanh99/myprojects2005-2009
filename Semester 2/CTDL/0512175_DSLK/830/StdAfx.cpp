// stdafx.cpp : source file that includes just the standard includes
//	830.pch will be the pre-compiled header
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

NODE *getnode(VE x)
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
	VE x;
	init(l);
	NODE *p;
	while (fread(&x,sizeof(VE),1,fp))
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
		if (!fwrite(&p->info,sizeof(VE),1,fp))
			return 0;
	}
	fclose(fp);
	return 1;
}


void xuat(VE x)
{	
	printf("\nTen phim: %s",x.tenphim);
	printf("Gia tien: %d",x.giatien);
	printf("\nXuat chieu:");
	xuat(x.xuatchieu);
	printf("\nNgay xem:");
	xuat(x.ngayxem);	
}

void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}
void xuat(THOIGIAN x)
{
	printf("%d:%d:%d",x.gio,x.phut,x.giay);
}

int tongtien(LIST l)
{
	int tong=0;
	for (NODE *p=l.pHead;p;p=p->pNext)		
		tong+=p->info.giatien;
	FILE *fp=fopen(filename1,"wb");	
	fwrite(&tong,sizeof(int),1,fp);
	fclose(fp);
	return tong;
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
			if (sosanh(p->info,q->info)==1)
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

int sosanh(THOIGIAN x,THOIGIAN y)
{
	if (x.gio>y.gio)
		return 1;
	if (x.gio<y.gio)
		return -1;
	if (x.phut>y.phut)
		return 1;
	if (x.phut<y.phut)
		return -1;
	if (x.giay>y.giay)
		return 1;
	if (x.giay<y.giay)
		return -1;
	return 0;
}

int sosanh(NGAY x,NGAY y)
{
	if (x.nm>y.nm)
		return 1;
	if (x.nm<y.nm)
		return -1;
	if (x.th>y.th)
		return 1;
	if (x.th<y.th)
		return -1;
	if (x.ng>y.ng)
		return 1;
	if (x.ng<y.ng)
		return -1;
	return 0;
}

int sosanh(VE x,VE y)
{
	if (sosanh(x.ngayxem,y.ngayxem)!=0)
		return sosanh(x.ngayxem,y.ngayxem);
	return sosanh(x.xuatchieu,y.xuatchieu);		
}

void _input(char *filename,LIST &l)
{
	FILE *fp=fopen(filename,"rt");
	int n;
	fscanf(fp,"%d ",&n);
	init(l);
	for (int i=0;i<n;i++)
	{
		VE x;		
		fgets(x.tenphim,21,fp);
		fscanf(fp,"%d ",&x.giatien);
		fscanf(fp,"%d %d %d ",&x.xuatchieu.gio,
			&x.xuatchieu.phut,&x.xuatchieu.giay);
		fscanf(fp,"%d %d %d ",&x.ngayxem.ng,
			&x.ngayxem.th,&x.ngayxem.nm);
		NODE *p=getnode(x);
		addtail(l,p);
	}
	fclose(fp);
}