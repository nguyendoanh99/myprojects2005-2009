// stdafx.cpp : source file that includes just the standard includes
//	DUONGTRON.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <time.h>
#define PI 3.1415926535

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// Bai 567
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
void nhap(DUONGTRON &C)
{

	float temp;
	nhap(C.I);
	printf("Nhap ban kinh: ");
	scanf("%f",&temp);
	C.R=temp;
}

void xuat(DIEM p)
{
	printf("(%6.3f,%6.3f)",p.x,p.y);
}
// Bai 568
void xuat(DUONGTRON c)
{
	printf("((%6.3f,%6.3f),%6.3f)",c.I.x,c.I.y,c.R);
}
// Bai 569
float chuvi(DUONGTRON c)
{
	return 2*c.R*PI;
}
// Bai 570
float dientich(DUONGTRON c)
{
	return pow(c.R,2)*PI;
}
float khoangcach(DIEM p1,DIEM p2)
{
	return sqrt(pow(p1.x-p2.x,2)+pow(p1.y-p2.y,2));
}
// Bai 571
int tuongdoi(DUONGTRON c1,DUONGTRON c2)
{
	float kc=khoangcach(c1.I,c2.I);	
	if (c1.R==c2.R && kc==0)
		return 0; // trung nhau
	if (kc==c1.R+c2.R)
		return 1; // tiep xuc ngoai
	if (kc==fabs(c1.R-c2.R))
		return 2; // tiep xuc trong	
	if (fabs(c1.R-c2.R)>kc)
		return 3; // nam trong nhau
	if (kc>c1.R+c2.R)
		return 4; // khong cat nhau	
	return 5; // cat nhau	
}
// Bai 572
int ktthuoc(DUONGTRON c,DIEM p)
{
	return khoangcach(c.I,p)<c.R;
}
// Bai 573
float dientichphu(DUONGTRON p1,DUONGTRON p2)
{
	srand( (unsigned)time( NULL ) );
	DIEM td,t;
	td.x=(p1.I.x+p2.I.x)/2;
	td.y=(p1.I.y+p2.I.y)/2;
	float temp=khoangcach(p1.I,p2.I)/2;
	if (p1.R>p2.R)
		temp+=p1.R;
	else
		temp+=p2.R;
	float x=floor(td.x-temp);
	float y=floor(td.y-temp);
	// Chieu dai canh hinh vuong
	int chieudai=ceil(td.x+temp)-floor(td.x-temp);
	float Shv=pow(chieudai,2);
	int n=0; // So lan diem thuoc duong tron
	for (int i=1;i<=1000000;i++)
	{	
		t.x=x+(rand()%chieudai)+((rand()%1000)/1000.0);
		t.y=y+(rand()%chieudai)+((rand()%1000)/1000.0);
		if (ktthuoc(p1,t) && ktthuoc(p2,t))
			n++;
	}
	return Shv*n/1000000;
}
