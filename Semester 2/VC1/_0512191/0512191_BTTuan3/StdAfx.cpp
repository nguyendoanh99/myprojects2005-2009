// stdafx.cpp : source file that includes just the standard includes
//	0512191_BTTuan3.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <time.h>
#include <stdlib.h>
#include <stdio.h>

int nhap(char filename[],int a[],int &n,int &x,int &k)
{
	FILE *fp;
	fp=fopen(filename,"rt");
	if(fp==NULL)
		return 0;
	fscanf(fp,"%d",&n);
	fscanf(fp,"%d",&x);
	fscanf(fp,"%d",&k);
	for(int i=0;i<n;i++)
		fscanf(fp,"%d",&a[i]);
	fclose(fp);
	return 1;
}

int xuat(char filename[],int a[],int n)
{
	FILE *fp;
	fp=fopen(filename,"wt");
	if(fp==NULL)
		return 0;
	fprintf(fp,"%d\n",n);
	for(int i=0;i<n;i++)
		fprintf(fp,"%4d",a[i]);
	fclose(fp);
	return 1;
}

void hoanvi(int &a,int &b)
{
	int tam=a;
	a=b;
	b=tam;
}

void SelectionSort(int a[],int n)
{
	for(int i=0;i<n-1;i++)
	{
		int min=i;
		for(int j=i+1;j<n;j++)
			if(a[min]>a[j])
				min=j;
		hoanvi(a[min],a[i]);
	}
}

void InsertionSort(int a[],int n)
{
	for(int i=1;i<n;i++)
	{
		int x=a[i];
		for(int j=i-1;j>=0&&a[j]>x;j--)
			a[j+1]=a[j];
		a[j+1]=x;	
	}
}

void BubbleSort(int a[],int n)
{
	for(int i=0;i<n-1;i++)
		for(int j=n-1;j>i;j--)
			if(a[j]<a[j-1])
				hoanvi(a[j],a[j-1]);
}

void ShakerSort(int a[],int n)
{
 	int l=1;int r=n-1;
	int k=n-1;
	do
	{
		for(int j=r;j>=l;j--)
			if(a[j]<a[j-1])
			{
				hoanvi(a[j],a[j-1]);
				k=j;
			}
		l=k+1;
		for(j=l;j<=r;j++)
			if(a[j]<a[j-1])
			{
				hoanvi(a[j],a[j-1]);
				k=j;
			}
		r=k-1;	
	}while(l<=r);
}

void InterchangeSort(int a[],int n)
{
	for(int i=0;i<n-1;i++)
	{
		for(int j=i+1;j<n;j++)
			if(a[i]>a[j])
				hoanvi(a[i],a[j]);
	}
}

void daomang(int a[],int n)
{
	for(int i=0;i<n/2;i++)
		hoanvi(a[i],a[n-1-i]);
}

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
