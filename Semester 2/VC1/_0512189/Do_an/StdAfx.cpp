// stdafx.cpp : source file that includes just the standard includes
//	Do_an.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <math.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void init(BIGINT &lst)
{
	lst.pHead=lst.pTail=NULL;
	lst.sign=1;
}

NODE* getnode(int x)
{
	NODE* p=new NODE;
	
	if(!p)
		return NULL;
	
	p->info=x;
	p->pNext=NULL;
	p->pPre=NULL;
	return p;

}

void addhead(BIGINT &lst,NODE *p)
{
	if(!lst.pHead)
		lst.pHead=lst.pTail=p;
	else
	{
		p->pNext=lst.pHead;
		lst.pHead->pPre=p;
		lst.pHead=p;
	}
}	

void addtail(BIGINT &lst,NODE* p)
{
	if(!lst.pTail)
		lst.pHead=lst.pTail=p;
	else
	{
		p->pPre=lst.pTail;
		lst.pTail->pNext=p;
		lst.pTail=p;
	}

}

/*
void input(BIGINT &lst)
{

	char c;
	
	init(lst);
	while((c=getche())!=13)
	{
		if(c=='-')
		{
			lst.sign=1;
			continue;
		}
		NODE *p=getnode(atoi(&c));
		addtail(lst,p);
	}
}
*/

void input(BIGINT &A)
{
	char s[MAX];

	fflush(stdin);
	gets(s);
	A=CreateBigint(s);

}

BIGINT CreateBigint(char *s)
{
	NODE*p;
	BIGINT A;
	init(A);
	if (*s=='-')
	{
		A.sign=-1;
		s++;
	}
	else
	{
		A.sign=1;
		if(*s=='+')
			s++;
	}

	for(;*s;s++)
	{
		p=getnode(*s-'0');
		addtail(A,p);
	}
	xoa0(A);
	return A;
}

void xoa0(BIGINT &A)
{
	NODE *p=A.pHead;
	while((p!=A.pTail)&& (p->info==0))
	{
			NODE *q=p;
			p=p->pNext;
			A.pHead=p;
			delete q;
	}
	A.pHead->pPre=NULL;
	if(kiemtra0(A))
		A.sign=1;

}

int kiemtra0(BIGINT A)
{
	if((A.pHead->info==A.pTail->info) && (A.pTail->info==0))
		return 1;
	return 0;
}


void output(BIGINT A)
{
	xoa0(A);

	if(A.sign==-1)
		printf("-");
	for(NODE*p=A.pHead;p;p=p->pNext)
		printf("%d",p->info);
}

BIGINT cong(BIGINT a,BIGINT b)
{
	BIGINT c;
	int du=0;
	int kq;
	NODE *t;

	init(c);
	c.sign=a.sign;

	if(a.sign!=b.sign)		//neu a,b trai dau 
	{	
		b.sign=-b.sign;		
		c=tru(a,b);
		return c;
	}

	NODE *p=a.pTail,*q=b.pTail;
	while(p && q)
	{
		kq=p->info + q->info + du;
		du=kq/10;
		kq=kq%10;

		t=getnode(kq);
		addhead(c,t);

		p=p->pPre;
		q=q->pPre;
	}
	while(p)
	{
		kq=p->info + du;
		du=kq/10;
		kq=kq%10;

		t=getnode(kq);
		addhead(c,t);
		p=p->pPre;
	}
	while(q)
	{
		kq=q->info + du;
		du=kq/10;
		kq=kq%10;

		t=getnode(kq);
		addhead(c,t);
		q=q->pPre;
	}
	if (du)
	{
		NODE *t=getnode(du);
		addhead(c,t);
	}
	return c;	
	
}

BIGINT tru(BIGINT a,BIGINT b)
{
	BIGINT c;
	NODE *t;
	int du=0;
	int kq;

	init(c);

	c.sign=a.sign;

	if(a.sign!=b.sign)
	{
		b.sign=-b.sign;
		c=cong(a,b);
		return c;
	}

	if(ss(a,b)==-1)
	{
		hoanvi(a,b);
		c.sign=-c.sign;
	}

	NODE *p=a.pTail,*q=b.pTail;

	while(p && q)
	{
		
		if((p->info + du) < q->info)
		{
			kq= (p->info + 10) - q->info + du ;
			du=-1;
		}
		else
		{
			kq= p->info - q->info + du;
			du=0;
		}

		t=getnode(kq);
		addhead(c,t);
		p=p->pPre;
		q=q->pPre;
	}
	while(p)
	{
		kq=p->info + du;
		if(kq<0)
		{
			kq+=10;
			du=-1;
		}
		else
			du=0;

		t=getnode(kq);
		addhead(c,t);
		p=p->pPre;
	}
	while(q)
	{
		kq=q->info + du;
		if(kq<0)
		{
			kq+=10;
			du=-1;
		}
		else
			du=0;

		t=getnode(kq);
		addhead(c,t);
		q=q->pPre;
	}

	return c;
}

int ss(BIGINT a,BIGINT b)
{
	NODE *p;
	NODE *q;
	int kq=0;

	a.sign=1;
	b.sign=1;
	p=a.pTail;
	q=b.pTail;

	while(p&&q)
	{
		if(p->info > q->info)
			kq= 1;
		if(p->info < q->info)
			kq= -1;
		p=p->pPre;
		q=q->pPre;
	}

	if(p==NULL && q != NULL)
		kq= -1;
	if(q==NULL && p !=NULL)
		kq= 1;

	return kq;

}
int sosanh (BIGINT a,BIGINT b)
{
	int kq=0;

	if (a.sign < b.sign)
		return -1;
	if (a.sign > b.sign)
		return 1;
	kq=ss(a,b);
	kq=(a.sign==-1)?-kq:kq;
	return kq;

}

void hoanvi(BIGINT &a,BIGINT &b)
{
	BIGINT t;
	t=a;
	a=b;
	b=t;
}

BIGINT tich(BIGINT a,BIGINT b)
{
	BIGINT kq;
	int d=0;
	init(kq);
	
	for(NODE* q=b.pTail;q;q=q->pPre)
	{
		BIGINT c;
		NODE *r;
		int du=0;
		init(c);

		for(int i=1;i<=d;i++)
		{
			r=getnode(0);
			addhead(c,r);
		}
		for(NODE* p=a.pTail;p;p=p->pPre)
		{
			int t=p->info * q->info + du;
			du=t/10;
			t=t%10;

			r=getnode(t);
			addhead(c,r);
		}
		if (du)
		{
			r=getnode(du);
			addhead(c,r);
		}

		kq=cong(kq,c);
		d++;
	}

	if(a.sign!=b.sign)
		kq.sign=1;

	return kq;
}

BIGINT tich2(BIGINT a,BIGINT b)
{
	BIGINT kq;
	int d=0;
	init(kq);
	
	for(NODE* q=b.pTail;q;q=q->pPre)
	{
		NODE *r=kq.pTail;
		int du=0;

		for(int i=1;i<=d;i++)
			r=r->pPre;

		for(NODE* p=a.pTail;p;p=p->pPre)
		{
			int t=p->info * q->info + du;

			if(r==NULL)
			{
				du=t/10;
				t=t%10;
				NODE*s=getnode(t);
				addhead(kq,s);
			}
			else
			{
				t+=r->info;
				du=t/10;
				t=t%10;

				r->info = t;
			}
			r=(r==NULL)?r:r->pPre;
		}
		if (du)
		{
			NODE*s=getnode(du);
			addhead(kq,s);
		}

		d++;
	}

	if(a.sign!=b.sign)
		kq.sign=1;

	return kq;
}

BIGINT pow(BIGINT a,int n)
{
	BIGINT kq;
	
	NODE*p=getnode(1);
	
	init(kq);
	addhead(kq,p);

	for(int i=1;i<=n;i++)
		kq=tich(kq,a);
	if(n%2)
		kq.sign=a.sign;

	return kq;
}

BIGINT pow2(BIGINT a,int n)
{
	BIGINT b;
	if(n==0)
	{
		b=CreateBigint("1");
		return b;
	}
	if(n==1)
	{
		b=CreateBigint(a);
		return b;
	}
	b=pow2(a,n/2);
	if(n%2)
		return (b*b)*a;
	return b*b;
}
BIGINT CreateBigint(BIGINT A)
{
	BIGINT B;
	NODE*q;
	init(B);
	for(NODE*p=A.pHead;p;p=p->pNext)
	{
		q=getnode(p->info);
		addtail(B,q);
	}
	return B;
}

BIGINT giaithua(BIGINT a)
{
	BIGINT  kq;
	BIGINT b,c;
	init(kq);
	init(b);
	init(c);
	NODE *p=getnode(1);
	addhead(b,p);
	addhead(c,p);
	addhead(kq,p);

	while(sosanh(a,b)!=0)
	{
		b=cong(b,c);
		kq=tich(kq,b);
	}
	return kq;
}

BIGINT operator*(BIGINT a,BIGINT b)
{
	return tich(a,b);
}
