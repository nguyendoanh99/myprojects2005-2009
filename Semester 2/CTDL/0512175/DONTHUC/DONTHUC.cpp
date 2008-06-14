// DONTHUC.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	DONTHUC a[2];
	// Nhap don thuc
	for (int i=1;i<=2;i++)
	{
		printf("Nhap don thuc %d:\n",i);
		nhap(a[i-1]);
	}
	// Xuat don thuc
	for (i=1;i<=2;i++)
	{
		printf("\nDon thuc %d:",i);
		xuat(a[i-1]);
	}
	// Tinh tich, thuong don thuc
	printf("\n\nTich 2 don thuc : ");
	xuat(a[0]*a[1]);
	printf("\nThuong 2 don thuc : ");
	xuat(a[0]/a[1]);
	// Tinh dao ham cap 1
	printf("\n");
	for (i=1;i<=2;i++)
	{
		printf("\nDao ham cap 1 cua don thuc %d: ",i);
		xuat(daoham(a[i-1]));
	}
	// Tinh dao ham cap k
	int k;
	printf("\n\nTinh dao ham cap k cua don thuc:");
	scanf("%d",&k);
	for (i=1;i<=2;i++)
	{
		printf("Dao ham cap %d cua don thuc %d: ",k,i);
		xuat(daoham(a[i-1],k));
		printf("\n");
	}
	// Tinh gia tri don thuc tai x0
	float x0;
	printf("\nTinh gia tri don thuc tai vi tri x=x0");
	printf("\nNhap x0=");
	scanf("%f",&x0);
	for (i=1;i<=2;i++)
		printf("Gia tri don thuc %d tai vi tri x0 = %8.3f\n",i,tinhf(a[i-1],x0));	
	getch();
	return 0;
}
