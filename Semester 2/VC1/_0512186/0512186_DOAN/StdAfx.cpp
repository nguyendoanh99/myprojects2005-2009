// stdafx.cpp : source file that includes just the standard includes
//	0512186_DOAN.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>
#include <ctype.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

//Khoi tao BIGINT
void init(BIGINT & N)
{
	N.pHead=N.pTail=NULL;
}

//Tao mot node moi tu KDL char
NODE *getnode(char x)
{
	NODE *p=new NODE ;
	if(p==NULL)
		return NULL;
	p->digit=x;
	p->pNext=NULL;
	p->pPrev=NULL;
	return p;
}

//Tao mot node moi tu KDL int 
NODE *getnode(int  x)
{
	NODE *p=new NODE ;
	if(p==NULL)
		return NULL;
	p->digit=x;
	p->pNext=NULL;
	p->pPrev=NULL;
	return p;
}

//Them 1 node vao dau Bigint 
void addhead(BIGINT &N,NODE *p)
{
	if(N.pHead==NULL)
		N.pHead=N.pTail=p;
	else
	{
		p->pNext=N.pHead;
		N.pHead->pPrev=p;
		N.pHead=p;
	}
}

//Them 1 node vao cuoi Bigint 
void addtail(BIGINT &N,NODE *p)
{
	if(N.pHead==NULL)
		N.pHead=N.pTail=p;
	else
	{
		N.pTail->pNext=p;
		p->pPrev=N.pTail;
		N.pTail=p;
	}
}

//Xuat Bigint ra man hinh
void xuat(BIGINT N)
{
	if(N.dau==-1)
		printf("-");
	for(NODE *p=N.pHead;p;p=p->pNext)
	{
		printf("%d",p->digit);
	}
//	printf("\n");
}

//Dua 1 chuoi so vao Bigint 
void input(BIGINT &N,char a[])
{
	init(N);
	int i=0;
	if( a[0]=='-' )
	{
		if(a[1]!=0)
			N.dau=-1;
		i++;
	}
	else
		N.dau=1;
	
	while(i<strlen(a))
	{
		NODE *p=getnode(a[i]-'0');
		addtail(N,p);
		i++;
	}
}

BIGINT *CongBIGINT(BIGINT K,BIGINT N)
{
	
	BIGINT *kq=new BIGINT;
	if(kq==NULL)
		return NULL;
	//Khoi tao kq
	kq->pHead=NULL;
	kq->pTail=NULL;
	
	if(K.dau*N.dau==-1)
	{
		N.dau=-N.dau;
		return TruBIGINT(K,N);
	}

	//Cong 2 so cung dau
	NODE *p=K.pTail;
	NODE *q=N.pTail;
	NODE *p1;
	int nho=0;
	int temp,temp1,temp2;
	while(p&&q)
	{
		temp1= p->digit + q->digit + nho;
		temp2=temp1%10;
		nho=temp1/10;
		p1=getnode(temp2);
		addhead(*kq,p1);
		p=p->pPrev;
		q=q->pPrev;
	}
	if (q!=NULL)
		p=q;
	
	for(NODE *r=p;r;r=r->pPrev)
	{
		if(nho==1)
		{
			r->digit +=1;
			temp=r->digit%10;
			nho=r->digit/10;
			p1=getnode(temp);
			addhead(*kq,p1);
		}
		else
			addhead(*kq,r);
	}
	if(nho==1)
	{
		p1=getnode(nho);
		addhead(*kq,p1);
	}
	kq->dau=K.dau;

	return kq;
}

void tru_tam(int a,int b,int &kq,int &nho)
{
	if(a>=b)
	{
		kq=a-b;
		nho=0;
	}
	else
	{
		kq=a+10-b;
		nho=1;
	}
}

BIGINT *TruBIGINT(BIGINT K,BIGINT N)
{
	BIGINT *kq=new BIGINT;
	if(kq==NULL)
		return NULL;
	//Khoi tao kq
	kq->dau=1;
	kq->pHead=NULL;
	kq->pTail=NULL;

	if(K.dau*N.dau==-1)
	{
		N.dau=-N.dau;
		return CongBIGINT(K,N);
	}
	//Tru 2 so cung dau
	int ss1=sosanh1(K,N);
	if(ss1<0)
	{
		BIGINT tam=K;
		K=N;
		N=tam;
		kq->dau=-1;
	}

	NODE *p=K.pTail;
	NODE *q=N.pTail;
	NODE *p1;
	int nho,temp;
	while(q)
	{
		tru_tam(p->digit,q->digit,temp,nho);
		p1=getnode(temp);
		addhead(*kq,p1);
		if(q->pPrev!=NULL)
			q->pPrev->digit +=nho;
		p=p->pPrev;
		q=q->pPrev;
	}
	for(NODE *r=p;r;r=r->pPrev)
	{
		tru_tam(r->digit,nho,temp,nho);
		p1=getnode(temp);
		addhead(*kq,p1);
	}
	
	if(K.dau==-1&&N.dau==-1)
		kq->dau=-kq->dau;
	return kq;
}

int cmp_length(BIGINT K,BIGINT N)
{
	NODE *p=K.pTail;
	NODE *q=N.pTail;
	while(p&&q)
	{
		p=p->pPrev;
		q=q->pPrev;
	}
	if(p!=NULL)
		return 1;
	if(q!=NULL)
		return -1;
	return 0;
}

int sosanh1(BIGINT K,BIGINT N)
{
	int kq=cmp_length(K,N);
	if(kq==1)
		return 1;
	if(kq==-1)
		return -1;
	NODE *p=K.pHead;
	NODE *q=N.pHead;
	while(p)
	{
		if(p->digit>q->digit)
			return 1;
		if(p->digit<q->digit)
			return -1;
		p=p->pNext;
		q=q->pNext;
	}
	return 0;
}

int sosanh(BIGINT K,BIGINT N)
{
	if(K.dau==1&&N.dau==-1)
		return 1;
	if(K.dau==-1&&N.dau==1)
		return -1;
	
	if(K.dau==1&&N.dau==1)
		return sosanh1(K,N);
	if(K.dau==-1&&N.dau==-1)
		return sosanh1(N,K);
	return 0;
}

void xoadau(BIGINT b)
{
	NODE *p=b.pHead;
	b.pHead=b.pHead->pNext;
	b.pHead->pPrev=NULL;
	p->pNext=NULL;
	delete(p);
}

//Xoa cac so 0 vo nghia cua BIGINT
void xoa0(BIGINT b)
{
	NODE *p=b.pHead;
	while(p->digit==0&&p->pNext!=NULL)
	{
		xoadau(b);
		p=p->pNext;
	}
}

//Nhan 1 so voi 1 BIGINT 
BIGINT *nhan_tam(BIGINT K,int n)
{
	BIGINT *b=new BIGINT ;
	if(b==NULL)
		return NULL;
	b->pHead=b->pTail=NULL;
	int nho=0;
	int temp,kq;
	NODE *p1;
	NODE *p=K.pTail;
	while(p)
	{
		temp= n* p->digit +nho;
		kq=temp%10;
		nho=temp/10;
		p1=getnode(kq);
		addhead(*b,p1);
		p=p->pPrev;
	}
	p1=getnode(nho);
	addhead(*b,p1);
	return b;
}

BIGINT *NhanBIGINT(BIGINT K,BIGINT N)
{
	BIGINT *kq;
	kq=new BIGINT ;
	if(kq==NULL)
		return NULL;
	kq->pHead=kq->pTail=NULL;

	BIGINT *b1,*b2;
	NODE *p=N.pTail->pPrev;
	//NODE *q=p->pPrev;
	NODE *p_tam;
	b1=nhan_tam(K,N.pTail->digit);
	while(p)
	{
		//Tach node cuoi khoi b1
		p_tam=b1->pTail;
		p_tam->pPrev->pNext=NULL;
		b1->pTail=p_tam->pPrev;
		p_tam->pPrev=NULL;

		addhead(*kq,p_tam);

		b2=nhan_tam(K,p->digit);
		b1=CongBIGINT(*b1,*b2);
		p=p->pPrev;
	}
	for(NODE *q=b1->pTail;q;q=q->pPrev)
		addhead(*kq,q);
	if(K.dau*N.dau==-1)
		kq->dau=-1;
	else
		kq->dau=1;
	return kq;
}
BIGINT tinhbieuthuc(char *s)
{
	BIGINT *temp=new BIGINT;
	BIGINT so[2];
	char dau='+';	
	input(so[0],"0");
	init(*temp);
	char *c;
	while (*s!=0 &&*s!=10)
	{
		if (isdigit(*s))
		{
			NODE *p=getnode(*s-'0');
			addtail(*temp,p);
		}
		else
		{			
			if (temp->pHead)
			{
				temp->dau=1;
				so[1]=*temp;				
				temp=new BIGINT;
				init(*temp);
			}
			if (*s==' ')
			{
				s++;
				continue;
			}
			switch (dau)
			{			
			case '+':
				temp=CongBIGINT(so[0],so[1]);				
				break;
			case '-':
				temp=TruBIGINT(so[0],so[1]);				
				break;			
			}
			so[0]=*temp;
			temp=new BIGINT;
			init(*temp);
			dau=*s;
		}
		s++;
	}
	// So nam o cuoi chuoi
	if (temp->pHead)
	{
		temp->dau=1;
		so[1]=*temp;				
		temp=new BIGINT;
		init(*temp);
	}
	switch (dau)
	{			
	case '+':
		temp=CongBIGINT(so[0],so[1]);				
		break;
	case '-':
		temp=TruBIGINT(so[0],so[1]);				
		break;			
	}
	return *temp;
}
void Phan2()
{
	char filename[256];	
	fflush(stdin);
	printf("Nhap ten file muon thuc hien:");
	gets(filename);
	FILE *fp=fopen(filename,"rt");
	if (!fp)
	{
		printf("Khong mo duoc file");
		return;
	}
	char s[2001];
	while (1)
	{
		fgets(s,2001,fp);
		int t=strlen(s)-1;
		if (s[t]==10)
			s[t]=0;
		printf("%s = ",s);
		BIGINT c=tinhbieuthuc(s);
		xuat(c);
		printf("\n");		
		if (feof(fp))
			break;
	}
	fclose(fp);
}