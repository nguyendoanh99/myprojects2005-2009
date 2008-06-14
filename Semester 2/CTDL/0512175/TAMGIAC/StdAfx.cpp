// stdafx.cpp : source file that includes just the standard includes
//	TAMGIAC.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <math.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// Bai 582
void nhap(DIEM &p)
{
	float temp;
	printf("Nhap x: ");
	scanf("%f",&temp);
	p.x=temp;
	printf("Nhap y: ");
	scanf("%f",&temp);
	p.y=temp;
}
void nhap(TAMGIAC &t)
{
	printf("Nhap dinh A:\n");
	nhap(t.A);
	printf("Nhap dinh B:\n");
	nhap(t.B);
	printf("Nhap dinh C:\n");
	nhap(t.C);
}
// Bai 583
void xuat(DIEM p)
{
	printf("(%8.3f,%8.3f)",p.x,p.y);
}
void xuat(TAMGIAC t)
{
	printf("(");
	xuat(t.A);
	printf(";");
	xuat(t.B);
	printf(";");
	xuat(t.C);
	printf(")");
}
float khoangcach(DIEM p1,DIEM p2)
{
	return sqrt(khoangcachbinhphuong(p1,p2));
}
float khoangcachbinhphuong(DIEM p1,DIEM p2)
{
	return pow(p1.x-p2.x,2)+pow(p1.y-p2.y,2);
}
// Bai 584
int kiemtra(TAMGIAC t)
{
	float a=khoangcach(t.B,t.C);
	float b=khoangcach(t.A,t.C);
	float c=khoangcach(t.A,t.B);
	return (a+b>c && a+c>b && b+c>a);
}
// Bai 585
float chuvi(TAMGIAC t)
{
	return khoangcach(t.A,t.B)+khoangcach(t.A,t.C)+khoangcach(t.B,t.C);
}
// Bai 586
float dientich(TAMGIAC t)
{
	
	float a=khoangcach(t.B,t.C);
	float b=khoangcach(t.A,t.C);
	float c=khoangcach(t.A,t.B);
	float p=(a+b+c)/2;
	return sqrt(p*(p-a)*(p-b)*(p-c));
}
// Bai 587
DIEM trongtam(TAMGIAC t)
{
	DIEM temp;
	temp.x=(t.A.x+t.B.x+t.C.x)/3;
	temp.y=(t.A.y+t.B.y+t.C.y)/3;
	return temp;
}
// Bai 588
DIEM hoanhlonnhat(TAMGIAC t)
{
	DIEM max;
	max=t.A;	
	if (max.x<t.B.x)
		max=t.B;		
	if (max.x<t.C.x)
		max=t.C;
	return max;
}
// Bai 589
DIEM tungthapnhat(TAMGIAC t)
{
	DIEM min;
	min=t.A;	
	if (min.y>t.B.y)	
		min=t.B;
	if (min.y>t.C.y)	
		min=t.C;		
	return min;
}
// Bai 590
float tongkhoangcach(TAMGIAC t,DIEM p)
{
	return khoangcach(t.A,p)+khoangcach(t.B,p)+khoangcach(t.C,p);
}
// Bai 591
int ktthuoc(TAMGIAC t,DIEM p)
{
	float S=dientich(t);
	// Tinh dien tich 3 tam giac nho tao tu diem P 
	// voi 3 dinh cua tam giac lon
	TAMGIAC temp=t;
	temp.C=p;
	float S1=dientich(temp);
	temp=t;
	temp.B=p;
	S1=S1+dientich(temp);
	temp=t;
	temp.A=p;
	S1=S1+dientich(temp);
	return S-S1<=0.001 && S-S1>0;
}
// Bai 592
int dangtamgiac(TAMGIAC t)
{
	float a=khoangcachbinhphuong(t.B,t.C);
	float b=khoangcachbinhphuong(t.A,t.C);
	float c=khoangcachbinhphuong(t.A,t.B);
	if (a==b && b==c)
		return 1;	// deu
	if (a+b==c || a+c==b || b+c==a)
		if (a==b || b==c || a==c)
			return 3;	// vuong can
		else
			return 2;	// vuong
	else
		if (a==b || b==c || a==c)
			return 4;	// can
	return 0;	// thuong
}