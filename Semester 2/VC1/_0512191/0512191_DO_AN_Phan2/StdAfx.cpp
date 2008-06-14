// stdafx.cpp : source file that includes just the standard includes
//	0512191_DO_AN.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
#include "string.h"
#include <ctype.h>
void init(BIGINT &A)
{
	A.phead=A.ptail=NULL;
}

NODE *getnode(char x)
{
	NODE *p=new NODE;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pnext=NULL;
	p->pprev=NULL;
	return p;	
}

void addhead(BIGINT &A,NODE *p)
{
	if(A.phead==NULL)
		A.phead=A.ptail=p;
	else
	{
		p->pnext=A.phead;
		A.phead->pprev=p;
		A.phead=p;
	}
}

void addtail(BIGINT &A,NODE *p)
{
	if(A.phead==NULL)
		A.phead=A.ptail=p;
	else
	{
		p->pprev=A.ptail;
		A.ptail->pnext=p;
		A.ptail=p;
	}
	
}

void input(BIGINT &A,char s[])
{	
	init(A);
	int i=0;
	if(s[0]=='-')
		{
			A.dau=-1;
			i++;
		}
	else
		A.dau=1;
	for (;i<strlen(s);i++)
	{
		
		NODE *q=getnode(s[i]-'0');
		addtail(A,q);
	}	
}
void output(BIGINT A)
{
	if(A.dau==-1)
		printf("-");
	for(NODE *p=A.phead;p!=NULL;p=p->pnext)
		printf("%d",p->info);
}
void cong(BIGINT A,BIGINT B,BIGINT &C)
{
	if(A.dau!=B.dau)
	{
		B.dau=A.dau;
		tru(A,B,C);
		B.dau=-B.dau;
		return;
	}
	C.dau=A.dau;
	init(C);
	int du=0;
	int k;
	NODE *p1,*p2,*p;
	for(p1=A.ptail,p2=B.ptail;p1&&p2;p1=p1->pprev,p2=p2->pprev)
	{
		k=p1->info+p2->info+du;
		du=k/10;
		k=k%10;
		p=getnode(k);
		addhead(C,p);
	}
	if(p2)
		p1=p2;
	for(;p1;p1=p1->pprev)
	{
		k=p1->info+du;
		du=k/10;
		k=k%10;
		p=getnode(k);
		addhead(C,p);
	}
	if(du)
	{
		p=getnode(du);
		addhead(C,p);
	}
	huykhong(C);
}

//Ham ss xuat ra 
//  1:la A dai hon;
// -1:la B dai hon;
//  0:la dai ban nhau.

int ss(BIGINT A ,BIGINT B)
{
	int flag=0;
	NODE *p1,*p2;
	for(p1=A.ptail,p2=B.ptail;p1&&p2;p1=p1->pprev,p2=p2->pprev)
	{
		if(p1->info>p2->info)
			flag=1;
		if(p1->info<p2->info)
			flag=-1;
	}
	if(p1==p2)
		return flag;
	if(p1)
		return 1;
	else
		return -1;
}  
void tru(BIGINT A,BIGINT B,BIGINT &C)
{
	if(A.dau!=B.dau)
	{
		B.dau=A.dau;
		cong(A,B,C);
		B.dau=-B.dau;
		return;
	}
	init(C);
	NODE *p1,*p2,*p;
	int du=0;int k;
	k=ss(A,B);
	if(k==-1)
	{
		C.dau=-B.dau;
		BIGINT tam=A;
		A=B;
		B=tam;
	}
	else
		C.dau=A.dau;
	for(p1=A.ptail,p2=B.ptail;p2;p1=p1->pprev,p2=p2->pprev)
	{
		k=p1->info+10-p2->info-du;
		du=1-k/10;
		k=k%10;
		p=getnode(k);
		addhead(C,p);
	}
	for(;p1;p1=p1->pprev)
	{
		k=p1->info+10-du;
		du=1-k/10;
		k=k%10;
		p=getnode(k);
		addhead(C,p);
	}
	huykhong(C);
}

//Ham sosanh xuat ra 
//  1:la A lon hon;
// -1:la B lon hon;
//  0:la bang nhau.

int sosanh(BIGINT A,BIGINT B)
{
	if(A.dau==-1)
	{
		if(B.dau==-1)
		{	
			int kq=ss(A,B);				//Ham ss xuat ra 
			if(kq)						//  1:la A dai hon;
				return -kq;				// -1:la B dai hon;
			else						//  0:la dai ban nhau.
				return 0;							
										
		}
		else
			return -1;
	}
	else
	{
		if(B.dau==1)
			return ss(A,B);
		else
			return 1;
	}
}
/*
void nhan(BIGINT A,BIGINT B,BIGINT &C)
{
	init(C);
	NODE *p=getnode(0);
	addtail(C,p);
	NODE *p1=A.ptail;
	NODE *p2=B.ptail;
	int nho=0;
	while(p1)
	{
		while(p2)
		{
			NODE *q1=p1;
			NODE *q2=p2;
			int kq=0;
			while(q1&&q2)
			{
				kq=kq+q1->info*q2->info;
				q1=q1->pprev;
				q2=q2->pnext;
			}
			kq=kq+nho;
			p->info=kq%10;
			nho=kq/10;			
			if(p->pprev==NULL)
			{
				NODE *temp;
				temp=getnode(0);
				addhead(C,temp); 
			}		
			p2=p2->pprev;
			p=p->pprev;		
			
		}
		p2=B.phead;
		p1=p1->pprev;
	}
	C.phead=p->pnext;
	C.phead->pprev=NULL;
	delete(p);
	while(nho)
	{
		NODE *temp=getnode(nho%10);
		addhead(C,temp);
		nho=nho/10;
	}
	if(A.dau!=B.dau)
		C.dau=-1;
	else
		C.dau=1;
}
*/
 
void nhan(BIGINT A,BIGINT B,BIGINT &C)
{
	init(C);
	NODE *p=getnode(0);
	addtail(C,p);
	NODE *p2=B.ptail;
	while(p2)
	{
		NODE *p1=A.ptail;NODE *p3=p;int nho=0;
		while(p1)
		{
			p3->info=p3->info+p1->info*p2->info+nho;
			nho=p3->info/10;
			p3->info=p3->info%10;
			p1=p1->pprev;
			if(p3->pprev==NULL)
			{
				NODE *temp=getnode(nho);
				addhead(C,temp);
				nho=nho/10;
			}
			p3=p3->pprev;
		}
		p=p->pprev;
		p2=p2->pprev;
	}
	if(A.dau!=B.dau)
		C.dau=-1;
	else
		C.dau=1;
	huykhong(C);
}

void huykhong(BIGINT &A)
{
	NODE *p=A.phead;
	while(p->info==0&&p->pnext)
	{
		A.phead=p->pnext;
		A.phead->pprev=NULL;
		delete(p);
		p=A.phead;
	}
}
void phepnhanluythua(BIGINT A,BIGINT &C)
{
	init(C);
	NODE *p=getnode(0);
	addtail(C,p);
	p=C.ptail;
	NODE *p1=A.ptail;
	NODE *p2=A.ptail;
	int nho=0;
	while(p1)
	{
		while(p2)
		{
			NODE *q1=p1;
			NODE *q2=p2;
			int kq=0;
			while(q1!=q2)
			{
				kq=kq+q1->info*q2->info;
				q1=q1->pprev;
				if(q1==q2)
				{
					q2=q2->pnext;
					break;
				}
				q2=q2->pnext;
			}

			kq=kq*2;
			if(q1==q2)
				kq=kq+q1->info*q2->info;
			kq=kq+nho;
			p->info=kq%10;
			nho=kq/10;			
			if(p->pprev==NULL)
			{
				NODE *temp;
				temp=getnode(0);
				addhead(C,temp); 
			}		
			p2=p2->pprev;
			p=p->pprev;			
		}
		p2=A.phead;
		p1=p1->pprev;
	}
	C.phead=p->pnext;
	C.phead->pprev=NULL;
	delete(p);
	while(nho)
	{
		NODE *temp=getnode(nho%10);
		addhead(C,temp);
		nho=nho/10;
	}
	C.dau=1;
}

int length(BIGINT x)
{
	int len=0;
	for (NODE *p=x.phead ;p!=x.ptail ->pnext;p=p->pnext,len++);
	return len;
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
			if (temp->phead)
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
				cong(so[0],so[1],*temp);				
				break;
			case '-':
				tru(so[0],so[1],*temp);								
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
	if (temp->phead)
	{
		temp->dau=1;
		so[1]=*temp;				
		temp=new BIGINT;
		init(*temp);
	}
	switch (dau)
	{			
	case '+':
		cong(so[0],so[1],*temp);				
		break;
	case '-':
		tru(so[0],so[1],*temp);				
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
		output(c);
		printf("\n");		
		if (feof(fp))
			break;
	}
	fclose(fp);
}
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
