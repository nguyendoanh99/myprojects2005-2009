// stdafx.cpp : source file that includes just the standard includes
//	0512175.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void input(char *fi,int *&a,int &n,int &k,int &x)
{
	FILE *f;
	f=fopen(fi,"rt");
	if (!f)
	{
		printf("khong mo file duoc");
		getch();
		exit(1);
	}
	fscanf(f,"%d %d %d",&n,&k,&x);
	a=(int *) malloc((n+1)*sizeof(int));
	for (int i=0;i<n;i++)
		fscanf(f,"%d",a+i);
	fclose(f);	
}

void output(char *fo,int k)
{
	FILE *f;
	f=fopen(fo,"wt");
	if (!f)
	{
		printf("khong tao duoc file");
		getch();
		exit(1);
	}
	fprintf(f,"%d",k);
	fclose(f);
}

int tuantu(int *a,int n,int x)
{
	a[n]=x;
	for (int i=0;a[i]!=x;i++);
	if (i==n)
		return -1;
	return i;
}

int nhiphan(int *a,int n,int x)
{
	int l=0;
	int r=n-1;
	int mid;
	do
	{
		mid=(l+r)/2;
		if (x<a[mid])
			r=mid-1;
		else
			if (x>a[mid])
				l=mid+1;
			else
				return mid;
	}
	while (l<=r);
	return -1;
}