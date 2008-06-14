// stdafx.cpp : source file that includes just the standard includes
//	mang.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdlib.h>
#include <time.h>
#include <stdio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

void tao(int a[],int n,int khoang)
{
	srand( (unsigned)time( NULL ) );
	int dau=1;
	for (int i=0;i<n;i++)
	{
//		if (rand()%2==1)
//			dau=1;
//		else
//			dau=-1;
		a[i]=dau*rand()%khoang;
	}
}

void tao(int a[][100],int m,int n,int khoang)
{
	srand((unsigned) time(NULL));
	for (int i=0;i<m;i++)
		for (int j=0;j<n;j++)
			a[i][j]=rand()%khoang;
}
void xuat(int a[],int n)
{
	for (int i=0;i<n;i++)
		printf("%4d",a[i]);
	printf("\n");
}
void xuat(int a[][100],int m,int n)
{
	for (int i=0;i<m;i++)
	{
		for (int j=0;j<n;j++)
			printf("%4d",a[i][j]);
		printf("\n");
	}
}