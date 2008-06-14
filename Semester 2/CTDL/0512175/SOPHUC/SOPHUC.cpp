// SOPHUC.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	SOPHUC x[2];
	int n;
	printf("Nhap vao 2 so phuc: \n");
	for (int i=0;i<2;i++)
	{
		printf("Nhap so phuc %d: \n",i+1);
		nhap(x[i]);
	}
	printf("2 so phuc vua nhap la:");
	for (i=0;i<2;i++)
	{
		printf("\nSo phuc %d:",i+1);
		xuat(x[i]);
	}
	printf("\n\nTinh tong, hieu, tich, thuong cua 2 so phuc:\n");
	// Tong
	printf("(");
	xuat(x[0]);
	printf(") + (");
	xuat(x[1]);
	printf(") = (");
	xuat(tong(x[0],x[1]));
	printf(")\n(");
	// Hieu
	xuat(x[0]);
	printf(") + (");
	xuat(x[1]);
	printf(") = (");
	xuat(hieu(x[0],x[1]));
	printf(")\n(");
	// Tich
	xuat(x[0]);
	printf(") * (");
	xuat(x[1]);
	printf(") = (");
	xuat(tich(x[0],x[1]));
	printf(")\n(");
	// Thuong
	xuat(x[0]);
	printf(") / (");
	xuat(x[1]);
	printf(") = (");
	xuat(thuong(x[0],x[1]));
	// Luy thua
	printf(")\n\nTinh luy thua bac n cua so phuc 1:");
	printf("\nNhap n: ");
	scanf("%d",&n);
	printf("(");
	xuat(x[0]);
	printf(")^%d = ",n);
	xuat(luythua(x[0],n));
	getch();
	return 0;
}