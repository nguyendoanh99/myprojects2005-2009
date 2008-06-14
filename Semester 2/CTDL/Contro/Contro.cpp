// Contro.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <memory.h>

double sqr(double);
double fmax(double,double);
double (*f)(double,double);
void sort(void *,int,int,int(*)(void*,void*));
int tang(void*,void*);
int main(int argc, char* argv[])
{
	printf("%d %s\n",argc,argv[0]);
	for (int i=1;i<argc;i++)
		printf("\n %s",argv[i]);
	char *t;
	float x[]={20,25,10,5,15};
	int j;
	sort(x,4,5,tang);
	for (j=0;j<5;j++)
		printf("%10.2f",x[j]);
/*	VI DU 3
	int j;	
	double x=1.0;
	typedef double(*ham)(double);
	ham g[6];
	g[1]=sqr;
	g[2]=sin;
	g[3]=cos;
	g[4]=exp;
	g[5]=sqrt;
	while (x<=10.0)
	{
		printf("\n");
		for (j=1;j<=5;j++)
			printf("%10.2f",g[j](x));
			x+=0.5;
	}
*/

/*
	f=fmax;
	printf("%f",f(3,24));
*/

/*
	typedef int (*p)[max];
	int s[max][max];
	tao(s,max,max);
	int h[max];
	tao(h,max);
	p t1=(p) h;
	xuat(h,max);
	printf("\n");
//	xuat(t1[0],max);
	p t;
	t=(p) s;
	xuat(s,max,max);
	printf("\n");
//	xuat(t,max,max);
*/
	getch();
	return 0;
}

double fmax(double x,double y)
{
	return (x>y?x:y);
}

double sqr(double x)
{
	return x*x;
}

int tang(void *x,void *y)
{
	return (*(float*) x)<=(*(float*)y);
}

void sort(void *buf,int size,int n,int (*ss)(void*,void*))
{
	void *tg;
	char *p;
	int i,j;
	p=(char*)buf;
	tg=(char*)malloc(size);
	for (i=0;i<n-1;i++)
		for (j=i+1;j<n;j++)
			if (!ss(p+i*size,p+j*size))
			{
				memcpy(tg,p+i*size,size);
				memcpy(p+i*size,p+j*size,size);
				memcpy(p+j*size,tg,size);
			}
}