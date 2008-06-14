// stdafx.cpp : source file that includes just the standard includes
//	DIEM.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <math.h>
#include <stdio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// Bai 541
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
// Bai 542
void xuat(DIEM p)
{
	printf("(%8.3f,%8.3f)",p.x,p.y);
}
// Bai 543
float khoangcach(DIEM p1,DIEM p2)
{
	return sqrt(pow(p1.x-p2.x,2)+pow(p1.y-p2.y,2));
}
// Bai 544
float khoangcachx(DIEM p1,DIEM p2)
{
	return fabs(p1.x-p2.x);
}
// Bai 545
float khoangcachy(DIEM p1,DIEM p2)
{
	return fabs(p1.y-p2.y);
}
// Bai 546
DIEM dxgoc(DIEM p)
{
	DIEM temp;
	temp.x=-p.x;
	temp.y=-p.y;
	return temp;
}
// Bai 547
DIEM dxox(DIEM p)
{
	DIEM temp;
	temp.x=p.x;
	temp.y=-p.y;
	return temp;
}
// Bai 548
DIEM dxoy(DIEM p)
{
	DIEM temp;
	temp.x=-p.x;
	temp.y=p.y;
	return temp;
}
// Bai 549
DIEM dxpg1(DIEM p)
{
	DIEM temp;
	temp.x=p.y;
	temp.y=p.x;
	return temp;
}
// Bai 550
DIEM dxpg2(DIEM p)
{
	DIEM temp;
	temp.x=-p.y;
	temp.y=-p.x;
	return temp;
}
// Bai 551
int ktphantu1(DIEM p)
{
	return (p.x>0 && p.y>0);
}
// Bai 552
int ktphantu2(DIEM p)
{
	return (p.x<0 && p.y>0);
}
// Bai 553
int ktphantu3(DIEM p)
{
	return (p.x<0 && p.y<0);
}
// Bai 554
int ktphantu4(DIEM p)
{
	return (p.x>0 && p.y<0);
}