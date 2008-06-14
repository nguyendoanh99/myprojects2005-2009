// stdafx.cpp : source file that includes just the standard includes
//	0512186_BTTuan5.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
// TODO: reference any additional headers you need in STDAFX.H

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE *getnode(int x)
{
	NODE *p=new NODE;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void addtail(LIST &l,NODE *p)
{
	if(l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		l.pTail->pNext=p;
		l.pTail=p;
	}
}
int input(char *filename,LIST &l,int &n,int &m,int &x,int &dem)
{
	init(l);
	FILE *fp;
	fp=fopen(filename,"rt");
	if(fp==NULL)
		return 0;
	fscanf(fp,"%d",&n);
	for(int i=0;i<n;i++)
	{
		int temp;
		fscanf(fp,"%d",&temp);
		NODE *p=getnode(temp);
		addtail(l,p);
	}
	dem=n;
	xoatrung(l,dem);
	fscanf(fp,"%d",&m);
	for( i=0;i<m;i++)
	{
		int temp;
		fscanf(fp,"%d",&temp);
		NODE *sent=getnode(temp);
		addtail(l,sent);
		NODE *t=l.pHead;
		while( t->info!=sent->info )
			t=t->pNext;
		if(t!=l.pTail)
			removenode(l,sent);
		else
			dem++;
	}
	fscanf(fp,"%d",&x);
	fclose(fp);
	return 1;
}

void removenode(LIST &l,NODE *p)
{
	if(p==l.pHead&&p==l.pTail)
	{
		l.pHead=l.pTail=NULL;
		delete(p);
		return ;
	}
	
	if(p==l.pHead)
	{
		l.pHead=l.pHead->pNext;
		delete(p);
		return ;
	}

	if(p==l.pTail)
	{
		NODE *q=l.pHead;
		while(q->pNext!=p)
			q=q->pNext;
		q->pNext=NULL;
		//q->pNext=l.pTail;
		//q=NULL;
		//l.pTail=q->pNext;
		l.pTail=q;

		delete(p);
		return ;
	}
	NODE *q=l.pHead;
	while(q->pNext!=p)
		q=q->pNext;
	q->pNext=p->pNext;
	p->pNext=NULL;
	delete(p);
}

void xoatrung(LIST &l,int &n)
{
	NODE *p=l.pHead;
	while(p)
	{
		NODE *q=p->pNext;
		while(q)
		{
			if(p->info==q->info)
			{
				removenode(l,q);
				n--;
				q=p->pNext;
			}
			else
				q=q->pNext;
		}
		p=p->pNext;
	}
	/*for(NODE *p=l.pHead;p->pNext;p=p->pNext)
		for(NODE *q=p->pNext;q;q=q->pNext)
			if(p->info==q->info)
				removenode(l,p);*/
}

/*void themnode(LIST &l,int a[],int m)
{
	for(int i=0;i<m;i++)
	{
		NODE *p=getnode(a[0]);
		addtail(l,p);
	}
}*/

int ktnt(int n)
{
	for(int dem=0,i=1;i<=n;i++)
		dem+=(n%i==0)?1:0;
	return dem==2;
}

void hoanvi(int &a,int &b)
{
	int temp=a;
	a=b;
	b=temp;
}

int ntliensau(int n)
{
	for(int i=n+1;!ktnt(i);i++);
	return i;
}

void thaynt(LIST l)
{
	for(NODE *p=l.pHead;p;p=p->pNext)
		if(ktnt(p->info))
			p->info=ntliensau(p->info);
}

void selection_sort(LIST l)
{
	NODE *p,*q;
	NODE * min;
	p=l.pHead;
	while(p->pNext)
	{
		min=p;
		q=p->pNext;
		while(q)
		{
			if(min->info>q->info)
				min=q;//Luu lai dia chi chua gia tri nho nhat
			q=q->pNext;
		}
		hoanvi(p->info,min->info);
		p=p->pNext;
	}
}

void addbefore(LIST &l,NODE *p,NODE *q)
{
	if(q==l.pHead)
	{
	
		p->pNext=q;
		l.pHead=p;
		return ;
	}
	/*if(p==l.pTail)
	{
		for(NODE *temp=l.pHead;temp->pNext!=q;temp=temp->pNext)
		{
			temp->pNext=p;
			p->pNext=q;
			for(NODE *temp=l.pHead;p;temp=temp->pNext);
			l.pTail=temp;
			return ;
		}
	}*/
	NODE *temp=l.pHead;
	while(temp->pNext!=q)
		temp=temp->pNext;
	//for(NODE *temp=l.pHead;temp->pNext!=q;temp=temp->pNext);
	//temp->pNext=p;
	p->pNext=temp->pNext;
	temp->pNext=p;
}

void insertion_sort(LIST &l)
{
	NODE *prev_p=l.pHead;
	NODE *p=l.pHead->pNext;
	NODE *Next;
	

	while(p->pNext)
	{
		NODE *q=l.pHead;
		while(q!=p)
		{
			//prev_p=q;
			if(p->info>=q->info)
			{
				q=q->pNext;
				prev_p=q;
			}
			else
			{
				prev_p=q;
				Next=p->pNext;
				prev_p->pNext=p->pNext;
				p->pNext=NULL;
				addbefore(l,p,q);
				break;
			}
			
		}
		//prev_p=p;
		p=Next;
		if(p==l.pTail)
		{
			prev_p->pNext=NULL;	
			addbefore(l,p,q);
		}
	}

}

/*void insertion_sort(LIST l)
{
	NODE *p=l.pHead->pNext;
	while(p)
	{
		NODE *q=l.pHead;
		while(q!=p)
		{
			if(p->info<q->info)
				hoanvi(p->info,q->info);
			q=q->pNext;
		}
		p=p->pNext;
	}
}*/

void interchange_sort(LIST l)
{
	NODE *p=l.pHead;
	while(p->pNext)
	{
		NODE *q=p->pNext;
		while(q)
		{
			if(p->info>q->info)
				hoanvi(p->info,q->info);
			q=q->pNext;
		}
		p=p->pNext;
	}
}

int output(char *filename,LIST l,int k)
{
	FILE *fp;
	fp=fopen(filename,"wt");
	if(fp==NULL)
		return 0;
	fprintf(fp,"%4d\n",k);
	for(NODE *p=l.pHead;p;p=p->pNext)
	{
		fprintf(fp,"%4d",p->info);
	}
	fclose(fp);
	return 1;
}

// and not in this file
