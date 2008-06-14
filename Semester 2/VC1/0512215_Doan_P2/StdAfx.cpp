// stdafx.cpp : source file that includes just the standard includes
//	0512215_Doan_P2.pch will be the pre-compiled header
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

void init(LIST &l)
{
	l.head=NULL;
	l.tail=NULL;
}

NODE *getnode(unsigned char x)
{
	NODE *p;

	p=new NODE;
	if(p==NULL)
		return NULL;

	p->info=x;
	p->pNext=NULL;
	p->pPrev=NULL;
	return p;
}


void addhead(BigInt &l,NODE *p)
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


void addtail(BigInt &l,NODE *p)
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
	for(int i=0;i<n;i++)
	{
		char s[2]={a[i],NULL};
		unsigned char x=atoi(s);
		NODE *p=getnode(x);
		addtail(l,p);
	}
}

void output(BigInt l)
{
	for(NODE *p=l.pHead ; p->info == 0 && p->pNext != NULL; p=p->pNext);
	if(l.sign == 1 && p->info != 0)
		printf("-");
	
	for(;p;p=p->pNext)
		printf("%d",p->info);
}





BigInt operator + (BigInt &l,BigInt h)
{

	unsigned char nho = 0;
	unsigned char x;
	NODE *p=l.pTail;
	NODE *q=h.pTail;
	while(p && q)
	{
		x=p->info + q->info + nho;
		if(x>=10)
			nho=1;
		else
			nho=0;
		p->info = x%10;
		p=p->pPrev;
		q=q->pPrev;
	}
	while(p != NULL)
	{
		
		
		if(p->info == 9 && nho == 1)
		{
			p->info = 0;
			nho=1;
		}
		else
		{
			x=p->info + nho;
			p->info = x;
			nho=0;
		}
		p=p->pPrev;
	}
	while(q != NULL)
	{
		NODE *k;
		if(q->info == 9 && nho == 1)
		{
			k=getnode(0);
			addhead(l,k);
			nho=1;
		}
		else
		{
			x= q->info + nho;
			k=getnode(x);
			addhead(l,k);
			nho=0;
		}
		q=q->pPrev;
	}
	if(nho == 1)
	{
		NODE *k=getnode(nho);
		addhead(l,k);
	}
	return l;
}


BigInt operator - (BigInt &l,BigInt h)
{
	
	char nho=0;
	unsigned char x;
	NODE *p=l.pTail;
	NODE *q=h.pTail;

	while(p && q)
	{
		if(p->info >= (q->info + nho) )
		{
			x=p->info - q->info - nho;
			nho=0;
		}
		else
		{
			x= 10 + p->info - q->info - nho;
			nho=1;
		}

		p->info=x;
		p=p->pPrev;
		q=q->pPrev;
	}

	while(p != NULL)
	{
		if( p->info < nho)
		{
			x= 10 - nho;
			nho = 1;
			p->info = x;
		}
		else
		{
			x= p->info - nho;
			nho = 0;
			p->info = x;
		}

		p=p->pPrev;
	}
	return l;

}


int ktlatoantu(char *a)
{
	if(a[0] == '+' || a[0] == '-')
		return 1;
	return 0;
}

char* file_to_mang(FILE *fp,char *a[],int &n,char *temp)
{
	
	int i=0;
	n=1;
	if(temp == NULL)
	{
		a[i]=new char[100];
		if(fscanf(fp,"%s",a[i]) == -1)
			return "0";
	}
	else
		a[i]=temp;
	
	a[n]=new char[2];
	fscanf(fp,"%s",a[n]);

	while(ktlatoantu(a[n]) == 1)
	{
		i=n+1;
		n=n+2;
		a[i]=new char [100];
		a[n]=new char [2];
		fscanf(fp,"%s",a[i]);
		if(fscanf(fp,"%s",a[n]) == -1)
			return NULL;
		
	}

	return a[n];
	

}

void xuatmang(char *a[],int n)
{
	for(int i=0;i<n;i++)
	{
		printf("% s ",a[i]);
	}
}

BigInt tinhmotbieuthuc(char *a[],int n)
{
	BigInt l;
	BigInt h;
	init(l);
	init(h);
	taoxautuchuoi(l,a[0]);
	int i=1;
	while(i<n)
	{
		char toantu=a[i][0];
		i++;
		taoxautuchuoi(h,a[i]);
		i++;
		if(toantu == '+')
		{
			if(l.sign == 1)
			{
				if(sosanh2soduong(l,h) == -1)
				{
					l = h - l;
					l.sign = 0;
				}
				else if(sosanh2soduong(l,h) == 1)       ///// !!!!!!! chu y
				{
					l = l - h;
				}
				else
				{
					l = l - h;
					l.sign = 0;
				}
			}
			else
				l = l + h;
		}
		if(toantu == '-')
		{
			if(l.sign == 1)
			{
				l = l + h;
				l.sign = 1;
			}
			else
			{
				if(sosanh2soduong(l,h) == -1)
				{
					l = h - l;
					l.sign = 1;
				}
				else
				{
					l = l - h;
				}
			
			}
		}
	}
	return l;
}


int operation(char *filename)
{
	
	FILE *fp;
	fp=fopen(filename,"rt");
	if(fp == NULL)
		return 0;
	char *temp;
	temp = NULL;
	char *a[100];
	int n;
	int i=0;
	do
	{
	
		BigInt kq;
		temp = file_to_mang(fp,a,n,temp);
		if(temp == "0")
		{
			printf("Khong ton tai bieu thuc\n");
			return 0;
		}
		kq = tinhmotbieuthuc(a,n);
		xuatmang(a,n);
		printf("  = ");
		output(kq);
		printf("\n");
	}while(temp != NULL);
	fclose (fp);
	return 1;




}

int sosanh2soduong(BigInt l,BigInt h)
{
	NODE *p=l.pTail;
	NODE *q=h.pTail;
	while(p && q)
	{
		p=p->pPrev;
		q=q->pPrev;
	}
	if(p != NULL)
		return 1;
	if(q != NULL)
		return -1;
	for(p=l.pHead, q=h.pHead; p && q; p=p->pNext, q=q->pNext)
	{
		if(p->info > q->info)
			return 1;
		if(p->info < q->info)
			return -1;
	}
	return 0;
}
