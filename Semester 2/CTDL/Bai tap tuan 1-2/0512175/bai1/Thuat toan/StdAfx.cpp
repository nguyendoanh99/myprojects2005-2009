// stdafx.cpp : source file that includes just the standard includes
//	thuat toan.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
void hoanvi(int a,int b)
{
	int temp=a;
	a=b;
	b=temp;
}
void interchangesort(int a[],int n)
{
	int max=0;
	for(int i=0;i<n;i++)
		if(a[max]<a[i])
			max=i;
	hoanvi(a[max],a[n-1]);
	for( i=0;i<n-1;i++)
		if(a[i]>a[n-1])
			hoanvi(a[i],a[n-1]);
}