// stdafx.cpp : source file that includes just the standard includes
//	0512175_BTTuan4.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

int input(char *filename,int **a,int &n,int &x,int &k)
{
	FILE *fp=fopen(filename,"rt");
	if (!fp)
		return 0;
	fscanf(fp,"%d%d%d ",&n,&x,&k);
	*a=(int*)malloc((n+1)*sizeof(int));
	for (int i=1;i<=n;i++)	
		fscanf(fp,"%d ",*a+i);
	fclose(fp);
	return 1;
}

int output(char *filename,int *a,int n)
{
	FILE *fp=fopen(filename,"wt");
	if (!fp)
		return 0;
	fprintf(fp,"%d\n",n);
	for (int i=1;i<=n;i++)	
		fprintf(fp,"%4d ",a[i]);
	fclose(fp);
	return 1;
}

int lonhon(int a,int b)
{
	return a>b;
}

int nhohon(int a,int b)
{
	return a<b;
}

void hv(int &a,int &b)
{
	int temp=a;
	a=b;
	b=temp;
}
