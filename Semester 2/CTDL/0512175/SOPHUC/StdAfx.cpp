// stdafx.cpp : source file that includes just the standard includes
//	SOPHUC.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <math.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// Bai 533
void nhap(SOPHUC &x)
{
	float temp;
	printf("Nhap thuc: ");
	scanf("%f",&temp);
	x.thuc=temp;
	printf("Nhap ao: ");
	scanf("%f",&temp);
	x.ao=temp;
}
// Bai 534
void xuat(SOPHUC x)
{
	printf("%8.3f + i*%8.3f",x.thuc,x.ao);
}
// Bai 535
SOPHUC tong(SOPHUC x,SOPHUC y)
{
	SOPHUC temp;
	temp.thuc=x.thuc+y.thuc;
	temp.ao=x.ao+y.ao;
	return temp;
}
// Bai 536
SOPHUC hieu(SOPHUC x,SOPHUC y)
{
	SOPHUC temp;
	temp.thuc=x.thuc-y.thuc;
	temp.ao=x.ao-y.ao;
	return temp;
}
// Bai 537
SOPHUC tich(SOPHUC x,SOPHUC y)
{
	SOPHUC temp;
	temp.thuc=x.thuc*y.thuc-x.ao*y.ao;
	temp.ao=x.thuc*y.ao+y.thuc*x.ao;
	return temp;
}
// Bai 538
SOPHUC thuong(SOPHUC x,SOPHUC y)
{
	SOPHUC temp;
	temp.thuc=(x.thuc*y.thuc+x.ao*y.ao)/(pow(y.thuc,2)+pow(y.ao,2));
	temp.ao=(y.thuc*x.ao+x.thuc*y.ao)/(pow(y.thuc,2)+pow(y.ao,2));
	return temp;
}
// Bai 539
SOPHUC luythua(SOPHUC x,int n)
{
	SOPHUC temp;
	temp.thuc=1;
	temp.ao=0;
	for (int i=1;i<=abs(n);i++)
		temp=tich(temp,x);
	if (n<0)
	{
		SOPHUC t;
		t.thuc=1;
		t.ao=0;
		temp=thuong(t,temp);
	}
	return temp;
}