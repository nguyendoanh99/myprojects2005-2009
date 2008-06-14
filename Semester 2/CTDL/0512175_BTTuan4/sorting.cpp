#include "stdafx.h"
#include <math.h>
#include <stdlib.h>
// HeapSort
void shift(int *a,int l,int r,FUNC ss)
{
	int i=l;
	int j=2*i;
	int x=a[i];
	while (j<=r)
	{
		if (j<r)
			if (ss(a[j],a[j+1])) 
				j++;
		if (!ss(x,a[j]))
			break;
		a[i]=a[j];
		i=j;
		j=i*2;
	}
	a[i]=x;
}

void tao_heap(int *a,int n,FUNC ss)
{
	int l=n/2;
	while (l)
	{
		shift(a,l,n,ss);
		l--;
	}
}

void heapsort(int *a,int n,int k)
{
	FUNC ss=(k)?lonhon:nhohon;
	tao_heap(a,n,ss);
	int r=n;
	while (r>0)
	{
		hv(a[r],a[1]);
		r--;
		shift(a,1,r,ss);		
	}
}
// ShellSort
void shellsort(int *a,int n,int t)
{
	FUNC ss=(t)?nhohon:lonhon;
	int k=(int)(log(n)/log(3));
	int *h=(int *) malloc(k*sizeof(int));
	h[k-1]=1;
	for (int i=k-1;i>0;i--)
		h[i-1]=3*h[i]+1;
	for (i=0;i<k;i++)
	{
		int len=h[i];		
		for (int j=len;j<=n;j++)
		{
			int x=a[j];
			int t=j-len;			
			while (t>=1 && ss(a[t],x))
			{
				a[t+len]=a[t];
				t-=len;
			}
			a[t+len]=x;
		}
	}
}
// MergeSort
void mergesort(int *a,int n,int t)
{
	FUNC ss=(t)?lonhon:nhohon;
	int p=1;
	int up=1;
	int i,j,k,l;
	do
	{
		if (up)
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

			int q;
			int r;
			if (m>=p) 
				q=p;
			else
				q=m;
			m-=q;
			if (m>=p)
				r=p;
			else
				r=m;
			m-=r;
			while (q && r)
			{
				if (ss(a[i],a[j]))
				{
					a[k]=a[i];
					i++;
					q--;					
				}
				else
				{
					a[k]=a[j];
					j--;
					r--;					
				}
				k+=h;
			}
			while (q)
			{
				a[k]=a[i];
				i++;
				k+=h;
				q--;
			}
			while (r)
			{
				a[k]=a[j];
				j--;
				k+=h;
				r--;
			}
			h=-h;
			hv(k,l);
		} while (m);
		p*=2;
		up=!up;
	} while (p<n);
	if (!up)
		for (int i=1;i<=n;i++)
			a[i]=a[i+n];
}
// QuickSort
void quicksort(int *a,int l,int r,int k)
{
	int i=l,j=r;
	int x=a[(l+r)/2];
	FUNC ss=(k)?lonhon:nhohon;
	do
	{
		while (ss(a[i],x)) i++;
		while (ss(x,a[j])) j--;
		if (i<=j)
		{
			hv(a[i],a[j]);
			i++;
			j--;
		}
	}
	while (i<j);
	if (l<j)
		quicksort(a,l,j,k);
	if (i<r)
		quicksort(a,i,r,k);
}