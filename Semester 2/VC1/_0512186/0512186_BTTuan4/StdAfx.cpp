// stdafx.cpp : source file that includes just the standard includes
//	0512186_BTTuan4.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
#include "stdlib.h"
#include "math.h"


int nhap(char filename [],int a[],int &n,int &x,int &k)
{
	FILE *fp;
	fp=fopen(filename,"rt");
	if(fp ==NULL)
		return 0;
	fscanf(fp,"%d",&n);
	fscanf(fp,"%d",&x);
	fscanf(fp,"%d",&k);
	for(int i=1;i<=n;i++)
		fscanf(fp,"%d",&a[i]);
	fclose(fp);
	return 1;
}

int xuat(char filename[],int a[],int n,int k)
{
	FILE *fp;
	fp=fopen(filename,"wt");
	if(fp ==NULL)
		return 0;
	fprintf(fp,"%d\n",n);
	if(k==0)
	{
		for(int i=n;i>=1;i--)
		fprintf(fp,"%4d ",a[i]);
	}
	else
	{
		for(int i=1;i<=n;i++)
		fprintf(fp,"%4d ",a[i]);
	}
	fclose(fp);
	return 1;
}

void hoanvi(int &c,int &d)
{
	int tam=c;
	c=d;
	d=tam;
}

void Shift(int a[],int l,int r)
{
	int i=l;
	int j=2*i;
	int x=a[i];
	while(j<=r)
	{
		if(j<r)
			if(a[j]>a[j+1])
				j++;
		if(x<=a[j])
			break;
		a[i]=a[j];
		i=j;
		j=2*i;
	}
	a[i]=x;
}

void CreatHeap(int a[],int n)
{
	int l=n/2;
	while(l>0)
	{
		Shift(a,l,n);
		l--;
	}
}

void HeapSort(int a[],int n)

{
	CreatHeap(a,n);
	int r=n;
	while(r>1)
	{
		hoanvi(a[r],a[1]);
		r--;
		Shift(a,1,r);
	}
}

void ShellSort(int a[],int n)
{
	int k,i,j;
	int x,kc;
	int m=(int)(log(n)/log(3));
	int *h;
	h=(int *) malloc(m*sizeof(int));
	h[m-1]=1;
	for(i=m-1;i>0;i--)
		h[i-1]=3*h[i]+1;
	for(k=0;k<m;k++)
	{
		kc=h[k];
		for(i=kc;i<=n;i++)
		{
			x=a[i];
			j=i-kc;
			while((x>a[j])&&(j>0))
			{
				a[j+kc]=a[j];
				j=j-kc;
			}
			a[j+kc]=x;
		}
	}
}

void QuickSort(int a[],int l,int r)
{
	int x=a[(l+r)/2];
	int i=l;
	int j=r;
	do
	{
		while(a[i]>x)
			i++;
		while(a[j]<x)
			j--;
		if(i<=j)
		{
			hoanvi(a[i],a[j]);
			i++;
			j--;
		}
	}while(i<j);
	if(l<j)
		QuickSort(a,l,j);
	if(i<r)
		QuickSort(a,i,r);
}

void MergeSort(int a[],int n)
{
	int i,j,k,l,q,r,up;
	up=1;
	int p=1;
	do
	{
		if(up)
		{
			i=1;
			j=n;
			k=n+1;
			l=2*n;
		}
		else
		{
			i=n+1;
			j=2*n;
			k=1;
			l=n;
		}
		int h=1;
		int m=n;
		do
		{
			if(m>=p)
				q=p;
			else
				q=m;
			m-=q;
			if(m>=p)
				r=p;
			else
				r=m;
			m-=r;
			while((q)&&(r))
				if(a[i]>a[j])
				{
					a[k]=a[i];
					i++;q--;k+=h;
				}
				else
				{
					a[k]=a[j];
					j--;r--;k+=h;
				}
			while(q)
			{
				a[k]=a[i];
				i++;q--;k+=h;	
			}
			while(r)
			{
				a[k]=a[j];
				j--;r--;k+=h;	
			}
			h=-h;
			hoanvi(k,l);
		}while(m);
		up=!up;
		p*=2;
	}while(p<n);
	if (!up)
		for (int i=1;i<=n;i++)
			a[i]=a[i+n];
}
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
