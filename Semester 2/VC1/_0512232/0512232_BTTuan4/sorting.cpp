#include"sorting.h"
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<math.h>


void hoanvi(int &a,int &b)
{
	int temp=a;
	a=b;
	b=temp;
}


int input(char *filename,int *a,int n,int &x,int &k)
{
	FILE *fp;
	int t;
	fp=fopen(filename,"rt");

	if(fp == NULL)
		return 0;

	fscanf(fp,"%d",&t);
	fscanf(fp,"%d ",&x);
	fscanf(fp,"%d ",&k);

	for(int i=0;i<n;i++)
		fscanf(fp,"%d ",a+i);

	fclose(fp);
	return 1;
}


int output(char *filename,int *a,int n)
{
	FILE *fp;
	fp=fopen(filename,"wt");

	if(fp==NULL)
		return 0;
	fprintf(fp,"%d\n",n);
	for(int i=0;i<n;i++)
		fprintf(fp,"%4d ",*(a+i));

	fclose(fp);
	return 1;
}


void quicksort_tang(int *a,int l,int r)
{
	int x=a[(l+r)/2];
	int i=l;
	int j=r;

	do
	{

		while(a[i]<x)
			i++;
		while(a[j]>x)
			j--;

		if(i <= j)              // i < j tuy truong hop khong chay dung
		{
			hoanvi(a[i],a[j]);
			i++;
			j--;
		}

	}while(i<j);

	if(l<j)
		quicksort_tang(a,l,j);
	if(i<r)
		quicksort_tang(a,i,r);
}

void quicksort_giam(int *a,int l,int r)
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
		quicksort_giam(a,l,j);    // loi : khong chay tiep duoc --> soluted
	if(i<r)
		quicksort_giam(a,i,r);
}



void mergesort_tang(int *a,int n)
{
	int up=1;    // Dung up = true hong duoc , hong biet tai sao??? --> dung dai up = 1 --> cung dung !!
	int p=1;
	int i,j,k,l;
	
	do
	{
		
		if(up == 1)
		{
			i=0;
			j=n-1;
			k=n;
			l=2*n-1;
		}
		else
		{
			i=n;
			j=2*n-1;
			k=0;
			l=n-1;
		}
		
		int h=1;
		int m=n;
		
		do
		{
			
			int q;
			int r;
			
			if(m >= p)
				q=p;
			else
				q=m;
			
			m -= q;
			
			if(m > p)
				r=p;
			else
				r=m;
			
			m -= r;
			
			while((q) && (r))
			{

				if(a[i] < a[j])     // loi ---> soluted do da cap phat cho a o ham main
				{
					a[k] = a[i];
					i++;
					q--;
					k += h;
				}

				else
				{
					a[k]=a[j];
					j--;
					r--;
					k += h;
				}

			}

			while(q)
			{
				a[k]=a[i];
				i++;
				q--;
				k += h;
			}

			while(r)
			{
				a[k]=a[j];
				j--;
				r--;
				k += h;
			}

			h=-h;
			int temp=k;
			k=l;
			l=temp;

		}while(m);

		up=-up;
		p *= 2;

	}while(p<n);

	if(up != 1)
		for(i=0;i<n;i++)
			a[i]=a[i+n];
}


void mergesort_giam(int *a,int n)
{
	int up=1;
	int p=1;
	int i,j,k,l;
	
	do
	{
		
		if(up == 1)
		{
			i=0;
			j=n-1;
			k=n;
			l=2*n-1;
		}
		else
		{
			i=n;
			j=2*n-1;
			k=0;
			l=n-1;
		}
		
		int h=1;
		int m=n;
		
		do
		{
			
			int q;
			int r;
			
			if(m >= p)
				q=p;
			else
				q=m;
			
			m -= q;
			
			if(m > p)
				r=p;
			else
				r=m;
			
			m -= r;
			
			while((q) && (r))
			{

				if(a[i] > a[j])     // loi  ---> da giai quyet
				{
					a[k] = a[i];
					i++;
					q--;
					k += h;
				}
				else
				{
					a[k]=a[j];
					j--;
					r--;
					k += h;
				}

			}

			while(q)
			{
				a[k]=a[i];
				i++;
				q--;
				k += h;
			}

			while(r)
			{
				a[k]=a[j];
				j--;
				r--;
				k += h;
			}

			h=-h;
			int temp=k;
			k=l;
			l=temp;

		}while(m);

		up=-up;
		p *= 2;

	}while(p<n);

	if(up != 1)
		for(i=0;i<n;i++)
			a[i]=a[i+n];
}

void shellsort_tang(int *a,int n,int h[],int k)
{
	int len;

	for(int i=0;i<k;i++)
	{
		len=h[i];

		for(int j=len;j<n;j++)
		{
			int x=a[j];
			int t=j-len;

			while((t>=0) && (a[t]>x))
			{
				a[t+len]=a[t];
				t -= len;
			}

			a[t+len]=x;
		}
	}
}

void shellsort_giam(int *a,int n,int h[],int k)
{
	int len;

	for(int i=0;i<k;i++)
	{
		len=h[i];

		for(int j=len;j<n;j++)
		{
			int x=a[j];
			int t=j-len;

			while((t>=0) && (a[t]<x))
			{
				a[t+len]=a[t];
				t -= len;
			}

			a[t+len]=x;
		}
	}
}


void shift_tang(int *a,int l,int r)
{
	int i=l;
	int j=i*2;
	int x=a[i];

	while(j <= r)
	{
		
		if(j < r)  // neu co du 2 phan tu lien doi
			if(a[j]<a[j+1])
				j++;

		if(x >= a[j])
			break;

		a[i]=a[j];
		i=j;
		j=2*i;
	}

	a[i]=x;
}

void createheap_tang(int *a,int n)
{
	int l=n/2;

	while(l>=1)
	{
		shift_tang(a,l,n); // n hay n-1 ??? --> dich thi la n-1
		l--;
	}
}

void heapsort_tang(int *a,int n)
{
	createheap_tang(a,n);
	int r=n;

	while(r>0)
	{
		hoanvi(a[1],a[r]);
		r--;
		shift_tang(a,1,r);
	}
}

void shift_giam(int *a,int l,int r)
{
	int i=l;
	int j=i*2;
	int x=a[i];

	while(j <= r)
	{
		
		if(j < r)  // neu co du 2 phan tu lien doi
			if(a[j]>a[j+1])
				j++;

		if(x <= a[j])
			break;

		a[i]=a[j];
		i=j;
		j=2*i;
	}

	a[i]=x;
}

void createheap_giam(int *a,int n)
{
	int l=n/2;

	while(l>=1)
	{
		shift_giam(a,l,n); // n hay n-1 ??? --> dich thi la n-1
		l--;
	}
}

void heapsort_giam(int *a,int n)
{
	createheap_giam(a,n);
	int r=n;

	while(r>0)
	{
		hoanvi(a[1],a[r]);
		r--;
		shift_giam(a,1,r);
	}
}



void doimang(int *a,int n,int k)
{
	if(k==1)
		for(int i=n-1;i>=0;i--)
			a[i+1]=a[i];
	else
		for(int i=0;i<n;i++)
			a[i]=a[i+1];
}