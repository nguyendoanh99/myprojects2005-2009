// stdafx.cpp : source file that includes just the standard includes
//	0512068_BTTuan6.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H

// CAC THAO TAC TREN DSLK DON (STACK)
void Push(STACK &S,NODE_ST *p)
{
	if (S.pHead == NULL)
		S.pHead = S.pTail = p;
	else
	{
		p->pNext = S.pHead;
		S.pHead = p;
	}
	S.so_node++;
}

char Pop(STACK &S)
{
	NODE_ST *p;
	char x;
	if (S.pHead == NULL)
		return -1;
	else
	{
		p = S.pHead;
		x = S.pHead->info;
		S.pHead = S.pHead->pNext;
		delete p;
		S.so_node--;
		if(S.pHead == NULL)
			S.pTail = NULL;
		return x;
	}
}

char Top(STACK S)
{
	if(S.pHead == NULL)
		return -1;
	return S.pHead->info;
}

NODE_ST *Getnode_stack(char x)
{
	NODE_ST *p = new NODE_ST;
	if (p == NULL)
		return NULL;
	p->info = x;
	p->pNext = NULL;
	return p;
}

void Init_stack(STACK &S)
{
	S.pHead = S.pTail = NULL;
	S.so_node = 0;
}

bool Is_empty(STACK S)
{
	if(S.pHead == NULL)
		return 1;
	return 0;
		
}

// and not in this file
