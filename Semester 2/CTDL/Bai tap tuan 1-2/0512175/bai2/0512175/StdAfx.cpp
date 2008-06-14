// stdafx.cpp : source file that includes just the standard includes
//	0512175.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
int tuantu(SV *a,int n,char *x)
{
	strcpy(a[n].hoten,x);
	int i=0;	
	while (strcmpi(a[i].hoten,x)) 
		i++;
	if (i==n)
		return -1;
	return i;
}

int nhiphan(SV *a,int n,char *x)
{
	int l=0;
	int r=n-1;
	int mid,t;
	do 
	{
		mid=(l+r)/2;
		t=strcmpi(a[mid].hoten,x);
		if (t>0)
			r=mid-1;
		else
			if (t<0)
				l=mid+1;
			else
				return mid;
	}
	while (l<=r);
	return -1;
}

void input(char *fi,SV **a,int &n,int &k,char *x)
{
	FILE *f=fopen(fi,"rt");
	float temp;
	if (!f)
	{
		printf("khong mo file duoc");
		getch();
		exit(1);
	}	
	fscanf(f,"%d %d ",&n,&k);
	*a=(SV*) calloc(n+1,sizeof(SV));
	fgets(x,40,f);
	fscanf(f," ");
	for (int i=0;i<n;i++)
	{
		fgets((*a+i)->mssv,10,f);
		fgets((*a+i)->hoten,40,f);
		fgets((*a+i)->diachi,50,f);
		fscanf(f,"%f ",&temp);
		(*(*a+i)).dtb=temp;		
	}
	fclose(f);
}

void output(char *fo,int k)
{
	FILE *f=fopen(fo,"wt");
	if (!f)
	{
		printf("khong tao duoc file");
		getch();
		exit(1);
	}
	fprintf(f,"%d",k);
	fclose(f);
}