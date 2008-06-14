// HONSO.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	HONSO a[2];
	// Nhap 2 hon so
	printf("Nhap vao 2 hon so:\n");
	for (int i=1;i<=2;i++)
	{
		printf("HON SO %d :\n",i);
		nhap(a[i-1]);
	}
	// Xuat 2 hon so vua nhap
	printf("\n2 hon so vua nhap:");
	for (i=1;i<=2;i++)
	{
		printf("\nHon so %d:",i);
		xuat(a[i-1]);
	}
	// Kiem tra hon so toi gian
	printf("\n\nKiem tra 2 hon so vua nhap da toi gian hay chua?\n ");
	for (i=0;i<=1;i++)
	{		
		xuat(a[i]);
		if (kttoigian(a[i]))
			printf(" la hon so toi gian.\n ");
		else
			printf(" chua la hon so toi gian.\n ");	
		
	}
	// Rut gon 2 hon so
	rutgon(a[0]);
	rutgon(a[1]);
	printf("\n2 hon so sau khi da rut gon:");
	for (i=1;i<=2;i++)
	{
		printf("\nHon so %d:",i);
		xuat(a[i-1]);
	}	
	// Tinh tong, hieu, tich, thuong cua 2  hon so	
	printf("\n\nTinh tong, hieu, tich, thuong cua 2 hon so:\n ");
	HONSO kq;
	// Tich
	kq=tich(a[0],a[1]);
	xuat(a[0]);
	printf(" * ");
	xuat(a[1]);
	printf(" = ");
	xuat(kq);	
	printf("\n ");
	// Thuong
	kq=thuong(a[0],a[1]);
	xuat(a[0]);
	printf(" / ");
	xuat(a[1]);
	printf(" = ");
	xuat(kq);
	printf("\n ");
	// Qui dong 2 hon so
	quidong(a[0],a[1]);
	printf("\n2 hon so sau khi da qui dong:");
	for (i=1;i<=2;i++)
	{
		printf("\nHon so %d:",i);
		xuat(a[i-1]);
	}
	printf("\n ");
	// Tong
	kq=tong(a[0],a[1]);
	xuat(a[0]);
	printf(" + ");
	xuat(a[1]);
	printf(" = ");
	xuat(kq);
	printf("\n ");	
	// Hieu
	kq=hieu(a[0],a[1]);
	xuat(a[0]);
	printf(" - ");
	xuat(a[1]);
	printf(" = ");
	xuat(kq);
	printf("\n ");		
	getch();
	return 0;
}
