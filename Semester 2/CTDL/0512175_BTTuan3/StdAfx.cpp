// stdafx.cpp : source file that includes just the standard includes
//	0512175_BTTuan3.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
int input(char *filename,int **a,int *n,int *x,int *k)
{
	FILE *f=fopen(filename,"rt");
	if (!f)
		return 0;
	fscanf(f,"%d %d %d ",n,x,k);
	*a=(int*) malloc((*n)*sizeof(int));
	for (int i=0;i<*n;i++)
		fscanf(f,"%d ",*a+i);
	fclose(f);
	return 1;
}

int output(char *filename,int a[],int n)
{
	FILE *f=fopen(filename,"wt");
	if (!f)
		return 0;
	
	fprintf(f,"%d\n",n);
	for (int i=0;i<n;i++)
		fprintf(f,"%4d ",a[i]);
	fclose(f);
	return 1;
}
// Hoan vi
void hv(int *a,int *b)
{
	int t=*a;
	*a=*b;
	*b=t;
}

int lonhon(int a,int b)
{
	return a>b;
}

int nhohon(int a,int b)
{
	return a<b;
}
// Selection Sort
void SelectionSort(int a[],int n,int k)
{
	pf ss=(k)?nhohon:lonhon;
	for (int i=0;i<n-1;i++)
	{
		int lc=i;
		for (int j=i+1;j<n;j++)
			if (ss(a[lc],a[j]))
				lc=j;
		hv(&a[i],&a[lc]);
	}
}
// Insertion Sort
void InsertionSort(int a[],int n,int k)
{
	pf ss=(k)?nhohon:lonhon;
	for (int i=1;i<n;i++)
	{
		int x=a[i];
		int j=i-1;
		while (ss(a[j],x) && j>=0)
		{
			a[j+1]=a[j];
			j--;
		}
		a[j+1]=x;	
	}
}
//Interchange Sort
void InterchangeSort(int a[],int n,int k)
{
	pf ss=(k)?nhohon:lonhon;
	for (int i=0;i<n-1;i++)
		for (int j=i+1;j<n;j++)
			if (ss(a[i],a[j]))
				hv(&a[i],&a[j]);
}
//Bubble Sort
void BubbleSort(int a[],int n,int k)
{
	pf ss=(k)?nhohon:lonhon;
	for (int i=0;i<n-1;i++)
		for (int j=n-1;j>i;j--)
			if (ss(a[j-1],a[j]))
				hv(&a[j-1],&a[j]);
}
//Shaker Sort
void ShakerSort(int a[],int n,int k)
{
	pf ss=(k)?nhohon:lonhon;
	int l=1,r=n-1,t=n-1;
	do
	{
		for (int j=r;j>=l;j--)
			if (ss(a[j-1],a[j]))
			{
				hv(&a[j-1],&a[j]);
				t=j;
			}
		l=t+1;
		for (j=l;j<=r;j++)
			if (ss(a[j-1],a[j]))
			{
				hv(&a[j-1],&a[j]);
				t=j;
			}
		r=t-1;
	}
	while (l<=r);
}