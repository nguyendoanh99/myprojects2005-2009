// stdafx.cpp : source file that includes just the standard includes
//	NGAY.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <math.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// Bai 594
void nhap(NGAY &x)
{
	printf("Nhap ngay: ");
	scanf("%d",&x.ng);
	printf("Nhap thang: ");
	scanf("%d",&x.th);
	printf("Nhap nam: ");
	scanf("%d",&x.nm);
}
// Bai 595
void xuat(NGAY x)
{
	printf("%d/%d/%d",x.ng,x.th,x.nm);
}
// Bai 596
int ktnamnhuan(int nam)
{
	return (nam%4==0 && nam%100!=0)||(nam%400==0);
}
// Bai 597
int thutungaynam(NGAY x)
{	
	int thutu=0;
	int kq=ktnamnhuan(x.nm);
	if (kq)
		thangngay[1]=29;
	for (int i=x.th-1;i>=1;i--)		
		thutu+=thangngay[i-1];
	thangngay[1]=28;
	return thutu+x.ng;
}
// Bai 598
int thutungay(NGAY x)
{
	int thutu=0;
	for (int i=1;i<x.nm;i++)
		if (ktnamnhuan(i))
			thutu+=366;
		else
			thutu+=365;
	return thutu+thutungaynam(x);
}
// Bai 599
NGAY timngay(int nam,int stt)
{
	NGAY temp;	
	int t=0;
	temp.nm=nam;	
	temp.th=1;
	if (ktnamnhuan(temp.nm))
		thangngay[1]=29;
	while (stt-t>thangngay[temp.th-1])
	{		
		t+=thangngay[temp.th-1];
		temp.th++;
	}
	thangngay[1]=28;
	temp.ng=stt-t;
	return temp;	
}
// Bai 600
NGAY timngay(int stt)
{
	NGAY temp;	
	int t=0;
	temp.nm=1;	
	int songay=(ktnamnhuan(temp.nm))?366:365;
	while (stt-t>songay)
	{		
		t+=songay;
		temp.nm++;		
		songay=(ktnamnhuan(temp.nm))?366:365;
	}
	stt-=t;
	t=0;
	temp.th=1;
	if (songay==366)
		thangngay[1]=29;
	while (stt-t>thangngay[temp.th-1])
	{		
		t+=thangngay[temp.th-1];
		temp.th++;
	}
	thangngay[1]=28;
	temp.ng=stt-t;
	return temp;
}
// Bai 601
NGAY ngayketiep(NGAY x)
{
	if (ktnamnhuan(x.nm))
		thangngay[1]=29;
	x.ng++;
	if (x.ng>thangngay[x.th-1])
	{
		x.th++;
		if (x.th==13)
		{
			x.nm++;
			x.th=1;
		}
		x.ng=1;
	}

	thangngay[1]=28;
	return x;
}
// Bai 602
NGAY ngayhomqua(NGAY x)
{
	if (ktnamnhuan(x.nm))
		thangngay[1]=29;
	x.ng--;
	if (x.ng==0)
	{
		x.th--;
		if (x.th==0)
		{
			x.nm--;
			x.th=12;
		}
		x.ng=thangngay[x.th-1];
	}
	thangngay[1]=28;
	return x;
}
// Bai 603
NGAY ngayke(NGAY x,int k)
{
	for (int i=1;i<=k;i++)
		x=ngayketiep(x);
	return x;
}
// Bai 604
NGAY ngaytruoc(NGAY x,int k)
{
	for (int i=1;i<=k;i++)
		x=ngayhomqua(x);
	return x;
}
// Bai 605
int khoangcach(NGAY x,NGAY y)
{
	return abs(thutungay(x)-thutungay(y));
}
// Bai 606
int sosanh(NGAY x,NGAY y)
{
	if (x.nm>y.nm)
		return 1;
	if (x.nm<y.nm)
		return -1;
	if (x.th>y.th)
		return 1;
	if (x.th<y.th)
		return -1;
	if (x.ng>y.ng)
		return 1;
	if (x.ng<y.ng)
		return -1;
	return 0;	
}