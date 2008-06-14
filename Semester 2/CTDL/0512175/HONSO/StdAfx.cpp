// stdafx.cpp : source file that includes just the standard includes
//	HONSO.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <math.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

// Bai 523
void nhap(HONSO &x)
{
	printf(" Nhap nguyen: ");
	scanf("%d",&x.nguyen);
	printf(" Nhap tu:");
	scanf("%d",&x.tu);
	printf(" Nhap mau:");
	scanf("%d",&x.mau);		
}
// Bai 524
void xuat(HONSO x)
{
	printf("%d(%d/%d)",x.nguyen,x.tu,x.mau);
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
// Tim boi chung nho nhat cua 2 so
int BCNN(int a,int b)
{
	return abs(a*b/UCLN(a,b));
}
// Bai 525
void rutgon(HONSO &x)
{	
	x.nguyen=x.nguyen+x.tu/x.mau;
	x.tu=x.tu%x.mau;
	int t=UCLN(x.tu,x.mau);
	x.tu=x.tu/t;
	x.mau=x.mau/t;
}
// Bai 526
HONSO tong(HONSO a,HONSO b)
{
	HONSO t;
	quidong(a,b);	
	t.nguyen=a.nguyen+b.nguyen;
	t.tu=a.tu+b.tu;
	t.mau=a.mau;	
	return t;
}
// Bai 527
HONSO hieu(HONSO a,HONSO b)
{
	HONSO t;
	quidong(a,b);
	t.nguyen=a.nguyen-b.nguyen;
	t.tu=a.tu-b.tu;
	t.mau=a.mau;
	if (t.tu<0)
	{
		t.tu=t.nguyen*t.mau+t.tu;		
		t.nguyen=t.tu/t.mau;
		t.tu=t.tu%t.mau;
	}
	return t;
}
// Bai 528
HONSO tich(HONSO a,HONSO b)
{
	HONSO t;
	t.nguyen=0;
	t.tu=(a.nguyen*a.mau+a.tu)*(b.nguyen*b.mau+b.tu);
	t.mau=a.mau*b.mau;				
	rutgon(t);
	return t;
}
// Bai 529
HONSO thuong(HONSO a,HONSO b)
{
	HONSO t;
	t.nguyen=0;
	t.tu=(a.nguyen*a.mau+a.tu)*b.mau;
	t.mau=a.mau*(b.nguyen*b.mau+b.tu);	
	rutgon(t);
	return t;
}
// Bai 530
int kttoigian(HONSO x)
{
	return (UCLN(x.tu,x.mau)==1)&&(x.tu/x.mau<1);
}
// Bai 531
void quidong(HONSO &a,HONSO &b)
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