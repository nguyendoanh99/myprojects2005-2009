// stdafx.cpp : source file that includes just the standard includes
//	PHANSO.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <math.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

// Nhap phan so
void nhap(PHANSO &x)
{

	printf(" Nhap tu:");
	scanf("%d",&x.tu);
	printf(" Nhap mau:");
	scanf("%d",&x.mau);	
}
// Xuat phan so
void xuat(PHANSO x)
{
	printf("%d/%d",x.tu,x.mau);
}
// Tim Uoc chung lon nhat cua 2 so
int UCLN(int a,int b)
{		
	if (a*b==0) return a+b;
	while (a%b!=0)
	{
		int t=a%b;
		a=b;
		b=t;
	}
	return abs(b);
}
// Tim Boi chung lon nhat cua 2 so
int BCNN(int a,int b)
{
	return abs(a*b/UCLN(a,b));
}
// Bai 506
void rutgon(PHANSO &x)
{
	int t=UCLN(x.tu,x.mau);
	x.tu=x.tu/t;
	x.mau=x.mau/t;
}
// Bai 507
PHANSO tong(PHANSO a,PHANSO b)
{
	PHANSO t;
	quidong(a,b);	
	t.tu=a.tu+b.tu;
	t.mau=a.mau;	
	return t;
}
// Bai 508
PHANSO hieu(PHANSO a,PHANSO b)
{
	PHANSO t;
	quidong(a,b);
	t.tu=a.tu-b.tu;
	t.mau=a.mau;		
	return t;
}
// Bai 509
PHANSO tich(PHANSO a,PHANSO b)
{
	PHANSO t;
	t.tu=a.tu*b.tu;
	t.mau=a.mau*b.mau;		
	return t;
}
// Bai 510
PHANSO thuong(PHANSO a,PHANSO b)
{
	PHANSO t;
	t.tu=a.tu*b.mau;
	t.mau=a.mau*b.tu;			
	return t;
}
// Bai 511
int kttoigian(PHANSO x)
{
	return UCLN(x.tu,x.mau)==1;
}
// Bai 512
void quidong(PHANSO &a,PHANSO &b)
{
	if (a.mau!=b.mau)
	{
		int x=BCNN(a.mau,b.mau);
		a.tu=a.tu*x/a.mau;
		b.tu=b.tu*x/b.mau;
		a.mau=x;
		b.mau=x;
	}
}
// Bai 513
int ktduong(PHANSO x)
{	
	return x.tu*x.mau>0;
}
// Bai 514
int ktam(PHANSO x)
{	
	return (x.tu*x.mau<0);
}
// Bai 515
int sosanh(PHANSO a,PHANSO b)
{
	int t;
	quidong(a,b);
	if (a.tu>b.tu)
		t=1;		
	else
		if (a.tu<b.tu)
			t=-1;			
		else
			t=0;
	if (a.mau<0) 
		t=-t;
	return t;			
}
// Bai 516
PHANSO operator+(PHANSO a,PHANSO b)
{
	return tong(a,b);
}
// Bai 517
PHANSO operator-(PHANSO a,PHANSO b)
{
	return hieu(a,b);
}
// Bai 518
PHANSO operator*(PHANSO a,PHANSO b)
{
	return tich(a,b);
}
// Bai 519
PHANSO operator/(PHANSO a,PHANSO b)
{
	return thuong(a,b);
}
// Bai 520
PHANSO operator++(PHANSO &x)
{
	PHANSO t;
	t.tu=1;
	t.mau=1;
	x=x+t;
	return x;
}
// Bai 521
PHANSO operator--(PHANSO &x)
{
	PHANSO t;
	t.tu=1;
	t.mau=1;
	x=x-t;
	return x;
}