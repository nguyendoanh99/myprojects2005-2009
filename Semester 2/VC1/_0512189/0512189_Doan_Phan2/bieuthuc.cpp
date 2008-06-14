#include "stdafx.h"
#include "bigint.h"
#include "bieuthuc.h"

#include <stdio.h>
#include <string.h>

void init(BIEUTHUC &lst)
{
	lst.pHead=lst.pTail=NULL;
}

BT* getnode(char* x)
{
	BT* p=new BT;
	
	if(!p)
		return NULL;
	
	strcpy(p->s,x);
	p->pNext=NULL;
	p->pPre=NULL;
	return p;

}

void addhead(BIEUTHUC &lst,BT *p)
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

void addtail(BIEUTHUC &lst,BT* p)
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

int input(BIEUTHUC &A)
{
	FILE*fp=fopen("bieuthuc.txt","rt");
	if(fp==NULL)
		return 0;
	
	init(A);
	int i=feof(fp);
	while(!feof(fp))
	{
		BT*p=new BT;
		fgets(p->s,MAX,fp);
		addtail(A,p);
	}
	fclose(fp);
	return 1;

}

void process(BIEUTHUC &l )
{
	for(BT*p=l.pHead;p;p=p->pNext)
		tinhtoan(p);
}
void tinhtoan(BT *p)
{
	BIGINT a,b;
	char *v;
	init(a);
	init(b);

	while(v)
	{

	}
}