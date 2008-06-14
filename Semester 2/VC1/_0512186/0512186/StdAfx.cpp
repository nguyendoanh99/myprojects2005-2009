// stdafx.cpp : source file that includes just the standard includes
//	0512186.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
// TODO: reference any additional headers you need in STDAFX.H

void init(LIST &l)
{
	l.pHead=l.pTail=NULL;
}

NODE*getnode(int x)
{
	NODE*p=new NODE;
	if(p==NULL)
		return NULL;
	p->info=x;
	p->pNext=NULL;
	return p;
}

void addhead(LIST &l,NODE*p)
{
	if(l.pHead==NULL)
		l.pHead=l.pTail=p;
	else
	{
		p->pNext=l.pHead;
		l.pHead=p;
	}
}

// and not in this file
