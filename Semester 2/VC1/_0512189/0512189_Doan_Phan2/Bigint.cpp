#include "stdafx.h"
#include "bigint.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <math.h>

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


BIGINT CreateBigint(char *s)
{
	NODE *p;
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

BIGINT operator+(BIGINT a,BIGINT b)
{
	return cong(a,b);
}

BIGINT operator-(BIGINT a,BIGINT b)
{
	return tru(a,b);
}
void xuat(BIGINT N)
{
	if(N.sign==-1)
		printf("-");
	for(NODE *p=N.pHead;p;p=p->pNext)
	{
		printf("%d",p->info);
	}
//	printf("\n");
}
