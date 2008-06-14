// stdafx.cpp : source file that includes just the standard includes
//	0512191_DO_AN.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
#include "string.h"

void init(BIGINT &A)
{
	A.phead=A.ptail=NULL;
}

NODE *getnode(int x)
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

void init(STACK &st)
{
	st.phead=st.ptail=NULL;
}

NODESTACK *getnode(void *x)
{
	char *k=(char *)x;
	NODESTACK *p=new NODESTACK;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pnext=NULL;
	return p;
}

void Push(STACK &st,NODESTACK *p)
{
	if(st.phead==NULL)
		st.phead=st.ptail=p;
	else
	{
		p->pnext=st.phead;
		st.phead=p;
	}
}
void *Pop(STACK &st)
{
	NODESTACK *temp=st.phead;
	void *x=st.phead->info;
	st.phead=st.phead->pnext;
	delete(temp);
	return x;
}
int IsEmty(STACK st)
{
	return (st.phead==NULL);
}

int input(char *filename,char a[][])
{
	FILE *fp=fopen(filename,"rt");
	if(fp==NULL)
		return 0;
	int i=0;int j=0;
	while(i<)
	fgets(
}

BIGINT *TinhToan(char *s)
{
	STACK STBIG,STDAU;
	init(STBIG);
	init(STDAU);
	NODESTACK *p;
	NODESTACK *q;
	int i=0;
	while(i<strlen(s))
	{
		BIGINT *SO=new BIGINT;
		init(*SO);		
		while(s[i]>='0'&&s[i]<='9'||s[i]==' ')
		{
			if(s[i]==' ')
			{
				i++;
				continue;
			}
			NODE *p=getnode(s[i]-'0');
			addtail(*SO,p);
			SO->dau=1;
			i++;
		}
		if(SO->phead)
		{
			xoa0dau(*SO);
			p=getnode(SO);
			Push(STBIG,p);
		}
	/*	if(s[i]==' ')
		{
			i++;
			continue;
		}  */
		if(s[i]==0)
			break;
		char *DAU=new char;
		*DAU=s[i];
		q=getnode(DAU);
		if(*DAU=='(')
		{
			Push(STDAU,q);
			i++;
			continue;
		}
		xuly(STBIG,STDAU,q);
		i++;
	}
	BIGINT *kq=new BIGINT;
	while(IsEmty(STDAU)==0)
	{
		char *dau2=(char *)Pop(STDAU);
		BIGINT *B=(BIGINT *)Pop(STBIG);
		BIGINT *A=(BIGINT *)Pop(STBIG);
		if(*dau2=='*')
			nhan(*A,*B,*kq);
		else
			if(*dau2=='+')
				cong(*A,*B,*kq);
			else
				tru(*A,*B,*kq);
		p=getnode(kq);
		Push(STBIG,p);
	}
	kq=(BIGINT *)STBIG.phead->info;
	return kq;
}

void xuly(STACK &STBIG,STACK &STDAU,NODESTACK *dau1)
{
	BIGINT *C=new BIGINT;
	init(*C);
	C->dau=1;	
	char *dau2;
	if(*(char *)dau1->info==')')
	{
		while(*(char *)STDAU.phead->info!='(')
		{
			dau2=(char *)Pop(STDAU);
			BIGINT *B=(BIGINT *)Pop(STBIG);
			BIGINT *A=(BIGINT *)Pop(STBIG);
			if(*dau2=='*')   // = if(*(char *)Pop(STDAU)=='*') 
				nhan(*A,*B,*C);
			else
				if(*dau2=='+')    // = if(*(char *)Pop(STDAU)=='+')
					cong(*A,*B,*C);
				else
					tru(*A,*B,*C);
			NODESTACK *p=getnode(C);
			Push(STBIG,p);
		}
		dau2=(char *)Pop(STDAU);
		return;
	}
	else
		if(*(char *)dau1->info!='*')
			while(IsEmty(STDAU)==0&&*(char *)STDAU.phead->info!='(')
			{
				dau2=(char *)Pop(STDAU);
				BIGINT *B=(BIGINT *)Pop(STBIG);
				BIGINT *A=(BIGINT *)Pop(STBIG);
				if(*dau2=='*')   // = if(*(char *)Pop(STDAU)=='*') 
					nhan(*A,*B,*C);
				else
					if(*dau2=='+')    // = if(*(char *)Pop(STDAU)=='+')
						cong(*A,*B,*C);
					else
						tru(*A,*B,*C);
				NODESTACK *p=getnode(C);
				Push(STBIG,p);
			}
		else
			if(IsEmty(STDAU))
			{
				STDAU.phead=STDAU.ptail=dau1;
				return;
			}
			else
				if(*(char *)STDAU.phead->info=='*')
				{
					dau2=(char *)Pop(STDAU);
					BIGINT *A=(BIGINT *)Pop(STBIG);
					BIGINT *B=(BIGINT *)Pop(STBIG);
					nhan(*A,*B,*C);
					NODESTACK *p=getnode(C);
					Push(STBIG,p);
				}
	Push(STDAU,dau1);		 		
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
	xoa0dau(A);
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
	xoa0dau(C);
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

void nhan(BIGINT A,BIGINT B,BIGINT &C)
{
	init(C);
	NODE *p=getnode((char)0);
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
	xoa0dau(C);
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
	xoa0dau(C);
}

int length(BIGINT x)
{
	int len=0;
	for (NODE *p=x.phead ;p!=x.ptail ->pnext;p=p->pnext,len++);
	return len;
}

void xoa0dau(BIGINT &A)
{
	while(A.phead->pnext)
		if(A.phead->info==0)
		{
			NODE *temp=A.phead;
			A.phead=A.phead->pnext;
			A.phead->pprev=NULL;
			delete(temp);
		}
		else
			break;
}




// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
