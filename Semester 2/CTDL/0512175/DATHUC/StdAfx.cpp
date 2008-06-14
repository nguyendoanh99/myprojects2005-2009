// stdafx.cpp : source file that includes just the standard includes
//	DATHUC.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information
#include "stdafx.h"
#include <stdio.h>
#include <math.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

// Nhap da thuc
void nhap(DATHUC &f)
{
	printf("Nhap bac da thuc:");
	scanf("%d",&f.n);
	for (int i=f.n;i>=0;i--)
	{
		float temp;
		printf("Nhap he so x^%d: ",i);
		scanf("%f",&temp);
		f.a[i]=temp;
	}
}
// Xuat da thuc
void xuat(DATHUC f)
{
	for (int i=f.n;i>0;i--)
		printf("%8.3fx^%d + ",f.a[i],i);
	printf("%8.3f",f.a[i]);
}
// Bai 493
DATHUC hieu(DATHUC x,DATHUC y)
{
	DATHUC z;
	if (x.n>y.n)
	{
		z.n=x.n;	
		for (int i=x.n;i>y.n;i--)
			y.a[i]=0;
		y.n=x.n;
	}
	else
	{
		z.n=y.n;	
		for (int i=y.n;i>x.n;i--)
			x.a[i]=0;
		x.n=y.n;
	}
	for (int i=x.n;i>=0;i--)
		z.a[i]=x.a[i]-y.a[i];	
	while (z.a[z.n]==0 && z.n>0)
		z.n--;	
	return z;
}
// Bai 494
DATHUC tong(DATHUC x,DATHUC y)
{
	DATHUC z;
	if (x.n>y.n)
	{
		z.n=x.n;	
		for (int i=x.n;i>y.n;i--)
			y.a[i]=0;
		y.n=x.n;
	}
	else
	{
		z.n=y.n;	
		for (int i=y.n;i>x.n;i--)
			x.a[i]=0;
		x.n=y.n;
	}
	for (int i=z.n;i>=0;i--)
		z.a[i]=x.a[i]+y.a[i];	
	while (z.a[z.n]==0 && z.n>0)
		z.n--;
	return z;
}
// Bai 495
DATHUC tich(DATHUC x,DATHUC y)
{
	DATHUC z;
	z.n=x.n+y.n;
	for (int i=0;i<=z.n;i++)
		z.a[i]=0;
	for (i=x.n;i>=0;i--)
		for (int j=y.n;j>=0;j--)
			z.a[i+j]=z.a[i+j]+x.a[i]*y.a[j];
	while (z.a[z.n]==0 && z.n>0)
		z.n--;
	return z;
}
// Bai 496
DATHUC thuong(DATHUC x,DATHUC y)
{
	DATHUC z,temp;
	z.n=0;
	z.a[0]=0;
	while (y.a[y.n]==0 && y.n>0)
		y.n--;	
	while (x.n>=y.n && !(x.n==0 && x.a[0]==0))
	{		
		temp.n=x.n-y.n;
		temp.a[temp.n]=x.a[x.n]/y.a[y.n];
		for (int i=temp.n-1;i>=0;i--)
			temp.a[i]=0;
		z=z+temp;
		x=x-temp*y;
	}
	return z;
}
// Bai 497
DATHUC phandu(DATHUC x,DATHUC y)
{
	DATHUC temp;
	while (y.a[y.n]==0 && y.n>0)
		y.n--;
	while (x.n>=y.n && !(x.n==0 && x.a[0]==0))
	{		
		temp.n=x.n-y.n;
		temp.a[temp.n]=x.a[x.n]/y.a[y.n];	
		for (int i=temp.n-1;i>=0;i--)
			temp.a[i]=0;
		x=x-temp*y;
	}
	return x;
}
// Bai 498
DATHUC daoham(DATHUC f)
{
	DATHUC z;
	z.n=0;
	z.a[0]=0;
	if (f.n>0)
	{
		z.n=f.n-1;
		for (int i=f.n;i>0;i--)
			z.a[i-1]=i*f.a[i];
	}
	while (z.a[z.n]==0 && z.n>0)
		z.n--;
	return z;
}
// Bai 499
DATHUC daoham(DATHUC f,int k)
{
	for (int i=1;i<=k;i++)
		f=daoham(f);
	return f;
}
// Bai 500
float tinhf(DATHUC f,float x0)
{
	float s=f.a[0],t=1;
	for (int i=1;i<=f.n;i++)
	{
		t=t*x0;
		s=s+f.a[i]*t;
	}
	return s;
}
// Bai 501
DATHUC operator+(DATHUC x,DATHUC y)
{
	return tong(x,y);
}
// Bai 502
DATHUC operator-(DATHUC x,DATHUC y)
{
	return hieu(x,y);
}
// Bai 503
DATHUC operator*(DATHUC x,DATHUC y)
{
	return tich(x,y);
}
// Bai 504
DATHUC operator/(DATHUC x,DATHUC y)
{
	return thuong(x,y);
}
// Bai 505
float timnghiem(DATHUC f,float a,float b)
{
	float mid=(a+b)/2;
	while (fabs(a-b)>0.00001)
	{
		mid=(a+b)/2;
		if (tinhf(f,a)*tinhf(f,mid)<0)
			b=mid;
		else
			a=mid;
	}
	return mid;
}