// stdafx.cpp : source file that includes just the standard includes
//	HINHCAU.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <stdio.h>
#include <math.h>
#define PI 3.1415926535
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// Bai 575
void nhap(DIEMKG &p)
{
	float temp;
	printf("Nhap x: ");
	scanf("%f",&temp);
	p.x=temp;
	printf("Nhap y: ");
	scanf("%f",&temp);
	p.y=temp;
	printf("Nhap z: ");
	scanf("%f",&temp);
	p.z=temp;
}
void nhap(HINHCAU &S)
{
	nhap(S.I);
	float temp;
	printf("Nhap ban kinh: ");
	scanf("%f",&temp);
	S.R=temp;
}
void xuat(DIEMKG p)
{
	printf("(%6.3f,%6.3f,%6.3f)",p.x,p.y,p.z);
}
// Bai 576
void xuat(HINHCAU S)
{
	printf("((%6.3f,%6.3f,%6.3f),%6.3f)",S.I.x,S.I.y,S.I.z,S.R);
}
// Bai 577
float dientichxungquanh(HINHCAU S)
{
	return 4*PI*pow(S.R,2);
}
// Bai 578
float thetich(HINHCAU S)
{
	return 4/3*PI*pow(S.R,3);
}
float khoangcach(DIEMKG p1,DIEMKG p2)
{
	return sqrt(pow(p1.x-p2.x,2)+pow(p1.y-p2.y,2)+pow(p1.z-p2.z,2));
}
// Bai 579
int tuongdoi(HINHCAU S1,HINHCAU S2)
{
	float kc=khoangcach(S1.I,S2.I);
	if (S1.R==S2.R && kc==0)
		return 0; // trung nhau
	if (kc==S1.R+S2.R)
		return 1; // tiep xuc ngoai
	if (kc==fabs(S1.R-S2.R))
		return 2; // tiep xuc trong	
	if (fabs(S1.R-S2.R)>kc)
		return 3; // nam trong nhau
	if (kc>S1.R+S2.R)
		return 4; // khong cat nhau	
	return 5; // cat nhau
}
// Bai 580
int ktthuoc(HINHCAU S,DIEMKG p)
{
	return khoangcach(S.I,p)<S.R;
}