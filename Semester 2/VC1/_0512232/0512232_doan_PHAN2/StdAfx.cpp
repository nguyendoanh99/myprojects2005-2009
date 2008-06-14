// stdafx.cpp : source file that includes just the standard includes
//	0512232_doan_PHAN1.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>
// TODO: reference any additional headers you need in STDAFX.H

void init(BigInt &l)
{
	l.pHead=NULL;
	l.pTail=NULL;
	l.sign=0;
}


DNODE *getdnode(unsigned char x)
{
	DNODE *p;

	p=new DNODE;
	if(p==NULL)
		return NULL;

	p->info=x;
	p->pNext=NULL;
	p->pPrev=NULL;
	return p;
}


void addhead(BigInt &l,DNODE *p)
{
	if(l.pHead==NULL)
		l.pHead=l.pTail=p;

	else
	{
		p->pNext=l.pHead;
		l.pHead->pPrev=p;
		l.pHead=p;
	}
}


void addtail(BigInt &l,DNODE *p)
{
	if(l.pTail==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		p->pPrev=l.pTail;
		l.pTail=p;
	}
}


void taoxautuchuoi(BigInt &l,char *a)
{
	init(l);
	int n=strlen(a);
	if(a[0]=='-')
	{	l.sign=1;
		for(int i=1;i<n;i++)
		{
			char s[2]={a[i],NULL};
			unsigned char x=atoi(s);
			DNODE *p=getdnode(x);
			addtail(l,p);
		}
	}
	else
		for(int i=0;i<n;i++)
		{
			char s[2]={a[i],NULL};
			unsigned char x=atoi(s);
			DNODE *p=getdnode(x);
			addtail(l,p);
		}
}

void output(BigInt l)
{
	if(l.sign==1)
		printf("-");
	for(DNODE *p=l.pHead ; p->info == 0 ; p=p->pNext);
	for(;p;p=p->pNext)
		printf("%d",p->info);
}


int sosanh2xau(BigInt l,BigInt h)
{
	if(l.sign == 0 && h.sign == 1)
		return 1;
	if(l.sign == 1 && h.sign == 0)
		return -1;

	DNODE *p=l.pTail;
	DNODE *q=h.pTail;

	while(p && q)
	{
	
		p=p->pPrev;
		q=q->pPrev;
	}

	if(p != NULL)
		return 1;

	if(q != NULL)
		return -1;
	for(p=l.pHead, q=h.pHead ; p && q ; p=p->pNext, q=q->pNext)
	{
		if(p->info > q->info)
			return 1;
		if(p->info < q->info)
			return -1;
	}

	return 0;
}


int sosanh(BigInt l,BigInt h)
{
	DNODE *p=l.pTail;
	DNODE *q=h.pTail;
	while(p && q)
	{
		p=p->pPrev;
		q=q->pPrev;
	}
	if(p != NULL)
		return 1;
	if(q != NULL)
		return -1;
	if(l.pHead->info > h.pHead->info)
		return 1;
	if(l.pHead->info < h.pHead->info)
		return -1;
	return 0;
}


BigInt nhanxauvoiso(BigInt l,unsigned char k)
{
	BigInt g;
	init(g);
	unsigned char x;
	unsigned char nho = 0 ;
	DNODE *t;

	for(DNODE *p=l.pTail;p;p=p->pPrev)
	{
		x =  k * p->info + nho;
		t=getdnode(x%10);
		addhead(g,t);
		nho = x/10;
	}

	if(nho != 0)
	{
		t=getdnode(nho);
		addhead(g,t);
	}

	return g;
}


BigInt nhanxauvoixau(BigInt l,BigInt h)
{
	BigInt tich;
	BigInt g;
	init(g);
	int dem=0;
	int temp=0;

	for(DNODE *q=h.pTail;q;q=q->pPrev)
	{
		tich=nhanxauvoiso(l,q->info);
		while(temp)
		{
			DNODE *k=getdnode(0);
			addtail(tich,k);
			temp--;
		}
		dem++;
		temp=dem;
		g=cong2xau(g,tich);
	}

	return g;
}


void tinhtoan(BigInt l,BigInt h,unsigned char x)
{

	BigInt kq;
	if(x == '1')
	{
		if(l.sign == 0 && h.sign == 0)
			kq=cong2xau(l,h);

		if(l.sign == 1 && h.sign == 0)
		{
			if(sosanh(l,h) == 1)
			{
				kq=tru2xau(l,h);
				kq.sign=1;
			}
			if(sosanh(l,h) == -1)
			{
				kq=tru2xau(h,l);
				kq.sign=0;
			}
			if(sosanh(l,h) == 0)
			{
				init(kq);
				DNODE *p=getdnode(0);
				addtail(kq,p);
			}
		}

		if(l.sign == 0 && h.sign == 1)
		{
			if(sosanh(l,h) == 1)
				kq=tru2xau(l,h);
			if(sosanh(l,h) == -1)
			{
				kq=tru2xau(h,l);
				kq.sign=1;
			}
			if(sosanh(l,h) == 0)
			{
				init(kq);
				DNODE *p=getdnode(0);
				addtail(kq,p);
			}
		}

		if(l.sign == 1 && h.sign == 1)
		{
			kq=cong2xau(l,h);
			kq.sign=1;
		}

		output(l);
		printf(" + ");
		output(h);
		printf(" = ");
		output(kq);
	}

	else if(x == '2')
	{
		if(l.sign == 0 && h.sign == 0)
		{
			if(sosanh(l,h) == 1)
				kq=tru2xau(l,h);
			if(sosanh(l,h) == -1)
			{
				kq=tru2xau(h,l);
				kq.sign=1;
			}
			if(sosanh(l,h) == 0)
			{
				init(kq);
				DNODE *p=getdnode(0);
				addtail(kq,p);
			}
		}

		if(l.sign == 1 && h.sign == 0)
		{
			kq=cong2xau(l,h);
			kq.sign=1;
		}

		if(l.sign == 0 && h.sign == 1)
		{
			kq=cong2xau(l,h);
		}

		if(l.sign == 1 && h.sign == 1)
		{
			if(sosanh(l,h) == 1)
			{
				kq=tru2xau(l,h);
				kq.sign=1;
			}
			if(sosanh(l,h) == -1)
			{
				kq=tru2xau(h,l);
				kq.sign=0;
			}
			if(sosanh(l,h) == 0)
			{
				init(kq);
				DNODE *p=getdnode(0);
				addtail(kq,p);
			}

		}

		output(l);
		printf(" - ");
		output(h);
		printf(" = ");
		output(kq);

		}


	else if(x == '3')
	{
		if((l.sign == 1 && h.sign == 1) || (l.sign == 0 && h.sign == 0))
			kq=nhanxauvoixau(l,h);
		else
		{
			kq=nhanxauvoixau(l,h);
			kq.sign=1;
		}
		output(l);
		printf(" * ");
		output(h);
		printf(" = ");
		output(kq);
	}

	else if(x == '4')
	{
		int dau=sosanh2xau(l,h);
		output(l);
		if(dau == 1)
			printf("  > ");
		else if(dau == -1)
			printf("  <  ");
		else
			printf("  =  ");
		output(h);
	}

	else if(x == '5')
		return;
}


BigInt operator + (BigInt l,BigInt h)
{
	BigInt g;
	init(g);
	unsigned char nho = 0;
	unsigned char x;
	DNODE *p=l.pTail;
	DNODE *q=h.pTail;
	while(p && q)
	{
		x=p->info + q->info + nho;
		if(x>=10)
			nho=1;
		else
			nho=0;
		DNODE *k=getdnode(x%10);
		addhead(g,k);
		p=p->pPrev;
		q=q->pPrev;
	}
	while(p != NULL)
	{
		
		DNODE *k;
		if(p->info == 9 && nho == 1)
		{
			k=getdnode(0);
			addhead(g,k);
			nho=1;
		}
		else
		{
			x=p->info + nho;
			k=getdnode(x);
			addhead(g,k);
			nho=0;
		}
		p=p->pPrev;
	}
	while(q != NULL)
	{
		DNODE *k;
		if(q->info == 9 && nho == 1)
		{
			k=getdnode(0);
			addhead(g,k);
			nho=1;
		}
		else
		{
			x= q->info + nho;
			k=getdnode(x);
			addhead(g,k);
			nho=0;
		}
		q=q->pPrev;
	}
	if(nho == 1)
	{
		DNODE *k=getdnode(nho);
		addhead(g,k);
	}
	return g;
}


BigInt operator - (BigInt l,BigInt h)
{
	BigInt g;
	init(g);		// nho nho nho nho nho....nho !!!!!!!!!
	char nho=0;
	unsigned char x;
	DNODE *k;
	DNODE *p=l.pTail;
	DNODE *q=h.pTail;

	while(p && q)
	{
		if(p->info >= (q->info + 1) )
		{
			x=p->info - q->info - nho;
			nho=0;
		}
		else
		{
			x= 10 + p->info - q->info - nho;
			nho=1;
		}

		k=getdnode(x);
		addhead(g,k);
		p=p->pPrev;
		q=q->pPrev;
	}

	while(p != NULL)
	{
		if( p->info < nho)
		{
			x= 10 - nho;
			nho = 1;
			k=getdnode(x);
			addhead(g,k);
		}
		else
		{
			x= p->info - nho;
			nho = 0;
			k=getdnode(x);
			addhead(g,k);
		}

		p=p->pPrev;
	}

	return g;
}


int file_to_mang(char *filename,char *a,int &n)
{
	n=0;
	char temp[100];
	FILE *fp;
	fp=fopen(filename,"rt");
	if(fp == NULL)
		return 0;
	int i=0;
	while(1)
	{
		fscanf(kq,"%s",&temp);
		if(temp == '+' || temp == '-')

		
	}
	
}
// and not in this file
