// stdafx.cpp : source file that includes just the standard includes
//	824.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
void init(LIST &l)
{
	l.phead=l.ptail=NULL;
}

NODE *getnode(HOCSINH P)
{
	NODE *p=new NODE;
	if(p==NULL)
		return NULL;
	p->info=P;
	p->pnext=NULL;
	return p;
}

void addhead(LIST &l,NODE *p)
{
	if(l.phead=NULL)
		l.phead=l.ptail=NULL;
	else
	{
		p->pnext=l.phead;
		l.phead=p;
	}
}

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
