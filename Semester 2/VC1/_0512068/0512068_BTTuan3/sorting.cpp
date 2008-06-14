#include"sorting.h"
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>

void hoanvi(int &a,int &b)
{
	int temp=a;
	a=b;
	b=temp;
}

void selection_sort(int *a,int n,int k)
{
	int min;
	if(k==0)
		for(int i=0;i<n-1;i++)
		{
			min=i;
			for(int j=i+1;j<n;j++)
				if(a[j]<a[min])
					min=j;
			hoanvi(a[min],a[i]);
		}
	else
		for(int i=0;i<n-1;i++)
		{
			min=i;
			for(int j=i+1;j<n;j++)
				if(a[j]>a[min])
					min=j;
			hoanvi(a[min],a[i]);
		}
}

void insertion_sort(int *a,int n,int k)
{
	int x,j;
	if(k==0)
		for(int i=1;i<n;i++)
		{
			x=a[i];
			j=i-1;
			while((j>=0)&&(a[j]>x))
			{
				a[j+1]=a[j];
				j--;
			}
			a[j+1]=x;
		}
	else
		for(int i=1;i<n;i++)
		{
			x=a[i];
			j=i-1;
			while((j>=0)&&(a[j]<x))
			{
				a[j+1]=a[j];
				j--;
			}
			a[j+1]=x;
		}
}


void interchang_sort(int *a,int n,int k)
{
	if(k==0)
	{
		for(int i=0;i<n-1;i++)
			for(int j=i+1;j<n;j++)
				if(a[i]>a[j])
					hoanvi(a[i],a[j]);
	}
	else
	{
		for(int i=0;i<n-1;i++)
			for(int j=i+1;j<n;j++)
				if(a[i]<a[j])
					hoanvi(a[i],a[j]);
	}
}


void bubble_sort(int *a,int n,int k)
{
	if(k==0)
	{
		for(int i=0;i<n-1;i++)
			for(int j=n-1;j>i;j--)
				if(a[j-1]>a[j])
					hoanvi(a[j],a[j-1]);
	}
	else
	{
		for(int i=0;i<n-1;i++)
			for(int j=n-1;j>i;j--)
				if(a[j-1]<a[j])
					hoanvi(a[j],a[j-1]);
	}
}


void shaker_sort(int *a,int n,int t)
{
	int l=1;
	int r=n-1;
	int k=0;
	if(t==0)
	{
		do
		{
			for(int j=r ; j>=l ; j--)
				if(a[j-1]>a[j])
				{
					hoanvi(a[j],a[j-1]);
					k=j;
				}
			l=k+1;
			for(j=l ; j<=r ; j++)
				if(a[j-1]>a[j])
				{
					hoanvi(a[j],a[j-1]);
					k=j;
				}
			r=k-1;
		}while(l<=r);
	}
	else
	{
		do
		{
			for(int j=r ; j>=l ; j--)
				if(a[j-1]<a[j])
				{
					hoanvi(a[j],a[j-1]);
					k=j;
				}
			l=k+1;
			for(j=l ; j<=r ; j++)
				if(a[j-1]<a[j])
				{
					hoanvi(a[j],a[j-1]);
					k=j;
				}
			r=k-1;
		}while(l<=r);
	}
}