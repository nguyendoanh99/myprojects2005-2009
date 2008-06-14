// stdafx.cpp : source file that includes just the standard includes
//	SapXep.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information
//#include "stack.h"
#include "stdafx.h"
#include <stdlib.h>
#include <time.h>
#include <stdio.h>
#include "stack_DSLk.h"
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void hoanvi(int &a,int &b)
{
	int temp=a;
	a=b;
	b=temp;
}
// Dung de qui
void QuickSort(int a[],int l,int r)
{
	int i=l,j=r;
	int x=a[(l+r)/2];
	do
	{		
		for (;a[i]<x;i++);
		for (;a[j]>x;j--);
		if (i<=j)
		{
			hoanvi(a[i],a[j]);
			i++;
			j--;
		}
	}while (i<j);
	if (l<j)
		QuickSort(a,l,j);
	if (i<r)
		QuickSort(a,i,r);	
}
// Khu de qui bang STACK
void _QuickSort(int a[],int l,int r)
{
	
	STACK t;
	KDL k={l,r};
	init(t);
	push(t,k);
	do
	{
		int l,r;
		k=pop(t);
		l=k.l;
		r=k.r;
		int i=l,j=r;
		int x=a[(l+r)/2];
		do
		{		
			for (;a[i]<x;i++);
			for (;a[j]>x;j--);
			if (i<=j)
			{
				hoanvi(a[i],a[j]);
				i++;
				j--;
			}
		}while (i<j);
		if (i<r)
		{
			k.l=i;
			k.r=r;
			push(t,k);
		}			
		if (l<j)
		{
			k.l=l;
			k.r=j;
			push(t,k);
		}			
	}while (!isEmpty(t));
}
void tao(int a[],int n)
{
	srand( (unsigned)time( NULL ) );
	int dau=1;
	for (int i=0;i<n;i++)
	{
		if (rand()%2==1)
			dau=1;
		else
			dau=-1;
		a[i]=dau*rand()%khoang;
	}
}

void tao(int a[][100],int m,int n)
{
	srand((unsigned) time(NULL));
	for (int i=0;i<m;i++)
		for (int j=0;j<n;j++)
			a[i][j]=rand()%100;
}
void xuat(int a[],int n)
{
	for (int i=0;i<n;i++)
		printf("%4d",a[i]);
	printf("\n");
}
void xuat(int a[][100],int m,int n)
{
	for (int i=0;i<m;i++)
	{
		for (int j=0;j<n;j++)
			printf("%4d",a[i][j]);
		printf("\n");
	}
}