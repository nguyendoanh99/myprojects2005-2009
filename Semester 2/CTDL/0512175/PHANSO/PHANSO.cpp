// PHANSO.cpp : Defines the entry point for the console application.
// Chu de ve phan so

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	PHANSO a[2];
	// Nhap 2 phan so
	printf("Nhap vao 2 phan so:\n");
	for (int i=1;i<=2;i++)
	{
		printf("PHAN SO %d :\n",i);
		nhap(a[i-1]);
	}
	// Xuat 2 phan so vua nhap
	printf("\n2 phan so vua nhap:");
	for (i=1;i<=2;i++)
	{
		printf("\nPhan so %d:",i);
		xuat(a[i-1]);
	}
	// Kiem tra phan so toi gian
	printf("\n\nKiem tra 2 phan so vua nhap da toi gian hay chua?\n ");
	for (i=0;i<=1;i++)
	{		
		xuat(a[i]);
		if (kttoigian(a[i]))
			printf(" la phan so toi gian.\n ");
		else
			printf(" chua la phan so toi gian.\n ");
	}
	// Rut gon 2 phan so
	rutgon(a[0]);
	rutgon(a[1]);
	printf("\n2 phan so sau khi da rut gon:");
	for (i=1;i<=2;i++)
	{
		printf("\nPhan so %d:",i);
		xuat(a[i-1]);
	}
	// Kiem tra Phan so 1 co phai la phan so duong hay khong
	printf("\n\nKiem tra PHAN SO 1 co phai la phan so duong hay khong?\n ");
	xuat(a[0]);
	if (ktduong(a[0]))
		printf(" la phan so duong.");
	else
		printf(" khong la phan so duong.");
	// Kiem tra Phan so 2 co phai la phan so am hay khong
	printf("\n\nKiem tra PHAN SO 2 co phai la phan so am hay khong?\n ");
	xuat(a[1]);
	if (ktam(a[1]))
		printf(" la phan so am.");
	else
		printf(" khong la phan so am.");
	// So sanh 2 phan so
	printf("\n\nSo sanh 2 phan so: ");
	xuat(a[0]);
	switch (sosanh(a[0],a[1]))
	{
	case -1:
		printf(" < ");
		break;
	case 1:
		printf(" > ");
		break;
	case 0:
		printf(" = ");
		break;
	}
	xuat(a[1]);
	// Tinh tong, hieu, tich, thuong cua 2  phan so	
	printf("\n\nTinh tong, hieu, tich, thuong cua 2 phan so:\n ");	
	// Tich
	xuat(a[0]);
	printf(" * ");
	xuat(a[1]);
	printf(" = ");
	xuat(a[0]*a[1]);
	printf("\n ");	
	// Thuong
	xuat(a[0]);
	printf(" / ");
	xuat(a[1]);
	printf(" = ");
	xuat(a[0]/a[1]);
	quidong(a[0],a[1]);
	printf("\n\n2 phan so sau khi da qui dong:");
	for (i=1;i<=2;i++)
	{
		printf("\nPhan so %d:",i);
		xuat(a[i-1]);
	}
	printf("\n ");
	// Tong
	xuat(a[0]);
	printf(" + ");
	xuat(a[1]);
	printf(" = ");
	xuat(a[0]+a[1]);
	printf("\n ");	
	// Hieu
	xuat(a[0]);
	printf(" - ");
	xuat(a[1]);
	printf(" = ");
	xuat(a[0]-a[1]);
	printf("\n ");	
	// Tang Phan so 1 them 1 don vi	
	printf("\n\nPhan so 1 sau khi tang 1 don vi = ");
	a[0]++;
	xuat(a[0]);
	// Giam Phan so 2 xuong 1 don vi	
	printf("\nPhan so 2 sau khi giam 1 don vi = ");
	a[1]--;
	xuat(a[1]);		
	getch();
	return 0;
}