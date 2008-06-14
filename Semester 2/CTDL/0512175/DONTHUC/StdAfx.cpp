// stdafx.cpp : source file that includes just the standard includes
//	DONTHUC.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information
#include "stdafx.h"
#include <stdio.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

// Nhap don thuc
void nhap(DONTHUC &f)
{
	float temp;
	printf("Nhap he so:");
	scanf("%f",&temp);
	f.a=temp;
	printf("Nhap bac don thuc:");
	scanf("%d",&f.n);
}
// Xuat don thuc
void xuat(DONTHUC f)
{
	printf("%8.3fx^%d",f.a,f.n);
}
// Tinh x^n
float luythua(float x,int n)
{
	float t=1;
	for (int i=1;i<=n;i++)
		t=t*x;
	return t;
}
// Bai 486
DONTHUC tich(DONTHUC x,DONTHUC y)
{
	DONTHUC temp;
	temp.a=x.a*y.a;
	temp.n=x.n+y.n;
	return temp;
}
// Bai 487
DONTHUC daoham(DONTHUC x)
{
	DONTHUC temp;
	if (x.n==0)
	{
		temp.a=0;
		temp.n=0;
	}
	else
	{
		temp.a=x.n*x.a;
		temp.n=x.n-1;
	}
	return temp;
}
// Bai 488
DONTHUC thuong(DONTHUC x,DONTHUC y)
{
	DONTHUC temp;
	temp.a=x.a/y.a;
	temp.n=x.n-y.n;
	return temp;
}
// Bai 489 
DONTHUC daoham(DONTHUC x,int k)
{
	DONTHUC temp=x;
	for (int i=1;i<=k;i++)
		temp=daoham(temp);
	return temp;
}
// Bai 490
float tinhf(DONTHUC x,float x0)
{
	return x.a*luythua(x0,x.n);
}
// Bai 491
DONTHUC operator*(DONTHUC x,DONTHUC y)
{
	return tich(x,y);
}
// Bai 492
DONTHUC operator/(DONTHUC x,DONTHUC y)
{
	return thuong(x,y);
}