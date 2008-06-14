// stdafx.cpp : source file that includes just the standard includes
//	0512068_BTTuan4.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H


void docfile(FILE *f,int n,int *a,int &x,int &k)
{

	fscanf(f,"%d\n",&x);
	fscanf(f,"%d\n",&k);

	for(int i=1 ; i<=n ; i++)
		fscanf(f,"%d",&a[i]);

}

void ghifile(int *a,int n,char *ten)
{

	FILE *f;
	f = fopen(ten,"wt");
	if(f == NULL)
	{
		printf("\n Khong mo duoc file nay.");
		exit(0);
	}

	fprintf(f,"%d\n",n);

	for(int i=1 ; i<=n ; i++)
		fprintf(f,"%d ",a[i]);

}


void in_ktra(int n,int *a,int x,int k)
{

	printf("%d\n",n);
	printf("%d\n",x);
	printf("%d\n",k);

	for(int i=1 ; i<=n ; i++)
		printf("%d ",a[i]);

}


void Insau_sapxep(int *a,int n)
{

	for(int i=1 ; i<=n ; i++)
		printf("%d ",a[i]);
}


void hoanvi(int &a,int &b)
{
	int temp = a;
	a = b;
	b = temp;
}



// CAC PHUONG PHAP SAP XEP

// 1. PP heapsort cai tien tu chen truc tiep

void Shift_giam(int *a,int l,int r)
{
	int i = l;
	int j = 2*i;
	int x = a[i];

	while(j <= r)
	{

		if(j < r)
			if(a[j] > a[j+1])
				j++;

		if(x <= a[j])
			break;

		a[i] = a[j];
		i = j;
		j = 2*i;

	}

	a[i] = x;
}


void Shift_tang(int *a,int l,int r)
{

	int i = l;
	int j = 2*i;
	int x = a[i];

	while(j <= r)
	{

		if(j < r)
			if(a[j] < a[j+1])
				j++;

		if(x >= a[j])
			break;

		a[i] = a[j];
		i = j;
		j = 2*i;

	}

	a[i] = x;
}


void Createheap(int *a,int n,int k)
{

	int i = n/2;
	while(i >= 1)
	{
		if(k == 0)
			Shift_tang(a,i,n);
		else 
			Shift_giam(a,i,n);
		i--;
	}

}


void Heapsort(int *a,int n,int k)
{

	Createheap(a,n,k);
	
	int i = n;
	while(i>=2)
	{
		hoanvi(a[i],a[1]);
		i--;
		if(k == 1)
			Shift_giam(a,1,i);
		else
			Shift_tang(a,1,i);
	}

}



// 2. PP shellsort cai tien tu chen truc tiep

void ShellSort_tang(int *a,int n,int h[],int k)
{

	int step,i,j;
	int x,len;

	for(step=0 ; step<k ; step++)
	{

		len = h[step]; 
		for(i=len ; i<=n ; i++)
		{
			x = a[i];
			j = i-len;  

			while((j>=1)&&(x<a[j]))  
			{
				a[j+len] = a[j];
				j = j-len;
			}

			a[j+len] = x;
		}

	}

}


void ShellSort_giam(int *a,int n,int h[],int k)
{

	int step,i,j;
	int x,len;

	for(step=0 ; step<k ; step++)
	{

		len = h[step]; 
		for(i=len ; i<=n ; i++)
		{
			x = a[i];
			j = i-len;  

			while((j>=1)&&(x>a[j]))  
			{
				a[j+len] = a[j];
				j = j-len;
			}

			a[j+len] = x;
		}

	}

}



// 3. PP mergesort

void MergeSort_tang(int *a,int n)
{

	int up = 1;
	int p = 1;

	do {

		int i,j,k,l;
		if(up == 1)
		{
			i=1 , j=n , k=n+1 , l=2*n;
		}
		else
		{
			i=n+1 , j=2*n , k=1 , l=n;
		}

		int h=1;
		int m=n;
		do {

			int q,r;
			if(m >= p)
				q = p;
			else
				q = m;
			m -= q;
			if(m >= p)
				r = p;
			else
				r = m;
			m -= r;
			while((q) && (r))
				if(a[i] < a[j])
				{
					a[k] = a[i];
					i++ , q-- , k+=h;
				}
				else
				{
					a[k] = a[j];
					j-- , r-- , k+=h;
				}
			while(q)
				{
					a[k] = a[i];
					i++ , q-- , k+=h;
				}
			while(r)
				{
					a[k] = a[j];
					j-- , r-- , k+=h;
				}
			hoanvi(k,l);
			h=-h;
		} while(m);
		up = !up;
		p *= 2;
	} while(p < n);

	if(!up)
		for(int i=1 ; i<=n ; i++)
			a[i] = a[i+n];

}

void MergeSort_giam(int *a,int n)
{

	int up = 1;
	int p = 1;

	do {

		int i,j,k,l;
		if(up == 1)
		{
			i=1 , j=n , k=n+1 , l=2*n;
		}
		else
		{
			i=n+1 , j=2*n , k=1 , l=n;
		}


		int h=1;
		int m=n;
		do {
			int q,r;
			if(m >= p)
				q = p;
			else
				q = m;
			m -= q;
			if(m >= p)
				r = p;
			else
				r = m;
			m -= r;
			while((q) && (r))
				if(a[i] > a[j])
				{
					a[k] = a[i];
					i++ , q-- , k+=h;
				}
				else
				{
					a[k] = a[j];
					j-- , r-- , k+=h;
				}
			while(q)
				{
					a[k] = a[i];
					i++ , q-- , k+=h;
				}
			while(r)
				{
					a[k] = a[j];
					j-- , r-- , k+=h;
				}
			hoanvi(k,l);
			h=-h;
		} while(m);

		up = !up;
		p *= 2;

	} while(p < n);

	if(!up )
		for(int i=1 ; i<=n ; i++)
			a[i] = a[i+n];
}

// 4. PP quicksort 

void Quicksort_tang(int *a,int l,int r)
{

	int i,j;
	int x;

	x = a[(l+r)/2];	
	i = l; j = r;

	do{
		while (a[i]<x)
			i++;

		while(a[j]>x)
			j--;
			
		if(i<=j)
		{
			hoanvi(a[i],a[j]);
			i++;
			j--;
		}

	}while(i<j);

	if(l<j)
		Quicksort_tang(a,l,j);

	if(i<r)
		Quicksort_tang(a,i,r);

}


void Quicksort_giam(int *a,int l,int r)
{

	int i,j;
	int x;

	x = a[(l+r)/2];	
	i = l; j =r;

	do{
		while (a[i]>x)
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
		Quicksort_giam(a,l,j);

	if(i<r)
		Quicksort_giam(a,i,r);

}

// and not in this file
