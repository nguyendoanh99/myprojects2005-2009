//#include "stdafx.h"
#include <stdio.h>
#include "stack.h"
// Cac thao tac tren STACK dung theo mang
KDL pop(STACK &t)
{
	KDL x;
	x=t.a[--t.n];
	return x;
}
void push(STACK &t,KDL x)
{
	t.a[t.n++]=x;
}
void init(STACK &t)
{
	t.n=0;
}

int isEmpty(STACK t)
{
	return t.n==0;
}
