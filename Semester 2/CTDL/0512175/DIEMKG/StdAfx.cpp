// stdafx.cpp : source file that includes just the standard includes
//	DIEMKG.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <math.h>
#include <stdio.h>
// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// Bai 556
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
// Bai 557
void xuat(DIEMKG p)
{
	printf("(%8.3f,%8.3f,%8.3f)",p.x,p.y,p.z);
}
// Bai 558
float khoangcach(DIEMKG p1,DIEMKG p2)
{
	return sqrt(pow(p1.x-p2.x,2)+pow(p1.y-p2.y,2)+pow(p1.z-p2.z,2));
}
// Bai 559
float khoangcachx(DIEMKG p1,DIEMKG p2)
{
	return fabs(p1.x-p2.x);
}
// Bai 560
float khoangcachy(DIEMKG p1,DIEMKG p2)
{
	return fabs(p1.y-p2.y);
}
// Bai 561
float khoangcachz(DIEMKG p1,DIEMKG p2)
{
	return fabs(p1.z-p2.z);
}
// Bai 562
DIEMKG dxgoc(DIEMKG p)
{
	DIEMKG temp;
	temp.x=-p.x;
	temp.y=-p.y;
	temp.z=-p.z;
	return temp;
}
// Bai 563
DIEMKG dxoxy(DIEMKG p)
{
	DIEMKG temp;
	temp.x=p.x;
	temp.y=p.y;
	temp.z=-p.z;
	return temp;
}
// Bai 564
DIEMKG dxoxz(DIEMKG p)
{
	DIEMKG temp;
	temp.x=p.x;
	temp.y=-p.y;
	temp.z=p.z;
	return temp;
}
// Bai 565
DIEMKG dxoyz(DIEMKG p)
{
	DIEMKG temp;
	temp.x=-p.x;
	temp.y=p.y;
	temp.z=p.z;
	return temp;
}