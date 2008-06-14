// stdafx.cpp : source file that includes just the standard includes
//	0512186_BTTuan3.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
// TODO: reference any additional headers you need in STDAFX.H

void hoanvi(int &a,int &b)
{
	int temp=a;
	a=b;
	b=temp;
}

void selection_sort(int a[],int n,int k)
{
	if(k==1)
	{
		for(int i=0;i<n-1;i++ )
		{
			int max=i;
			for(int j=i+1;j<n;j++)
				if(a[j]>a[max])
					max=j;
			hoanvi(a[max],a[i]);
		}		
	}
	else
	{
		for(int i=0;i<n-1;i++ )
		{
			int max=i;
			for(int j=i+1;j<n;j++)
				if(a[j]<a[max])
					max=j;
			hoanvi(a[max],a[i]);
		}		
	}
}

void insertion_sort(int a[],int n,int k)
{
	if(k==1)
		for(int i=1;i<n;i++)
		{
			int x=a[i];
			for(int j=i-1;j>=0 && a[j]<x;j--)				
					a[j+1]=a[j];
			a[j+1]=x;
		}
	else
		for(int i=1;i<n;i++)
		{
			int x=a[i];
			for(int j=i-1;j>=0 && a[j]>x;j--)					
				a[j+1]=a[j];
			a[j+1]=x;
		}
}

void interchange_sort(int a[],int n,int k)
{
	if(k==1)
	{
		for(int i=0;i<n-1;i++)
			for(int j=i+1;j<n;j++)
				if(a[i]<a[j])
					hoanvi(a[i],a[j]);
	}
	else
		for(int i=0;i<n-1;i++)
			for(int j=i+1;j<n;j++)
				if(a[i]>a[j])
					hoanvi(a[i],a[j]);

}

void bubble_sort(int a[],int n,int k)
{
	if(k==1)
	{
		for(int i=0;i<n-1;i++)
			for(int j=n-1;j>i;j--)
				if(a[j-1]<a[j])
					hoanvi(a[j-1],a[j]);
	}
	else
		for(int i=0;i<n-1;i++)
			for(int j=n-1;j>i;j--)
				if(a[j-1]>a[j])
					hoanvi(a[j-1],a[j]);

}

void shaker_sort(int a[],int n,int k)
{
	int l=1,r=n-1,t=n-1;
	do
	{
		if(k==0)
		{
			for(int i=r;i>=l;i--)
				if(a[i]<a[i-1])
					{
						hoanvi(a[i],a[i-1]);
						t=i;
					}
			l=t+1;
			for( i=l;i<=r;i++)
				if(a[i]<a[i-1])
					{
						hoanvi(a[i],a[i-1]);
						t=i;
					}
			r=t-1;
		}
		else
		{
			for(int i=r;i>=l;i--)
				if(a[i]>a[i-1])
					{
						hoanvi(a[i],a[i-1]);
						t=i;
					}
			l=t+1;
			for( i=l;i<=r;i++)
				if(a[i]>a[i-1])
					{
						hoanvi(a[i],a[i-1]);
						t=i;
					}
			r=t-1;
		}
	}while(l<=r);
}

int nhap(char filename[],int a[],int &n,int &x,int &k)
{
	FILE *f1;
	f1=fopen(filename,"rt");
	if(f1==NULL)
		return 0;
	fscanf(f1,"%d",&n);
	fscanf(f1,"%d",&x);
	fscanf(f1,"%d",&k);
	for(int i=0;i<n;i++)
		fscanf(f1,"%d",&a[i]);
	fclose(f1);
	return 1;
}

int xuat(char filename[], int a[],int n)
{
	FILE *f2;
	f2=fopen(filename,"wt");
	if(f2==NULL)
		return 0;
	fprintf(f2,"%4d\n",n);
	for(int i=0;i<n;i++)
		fprintf(f2,"%4d",a[i]);
	fclose(f2);
	return 1;
}

// and not in this file
