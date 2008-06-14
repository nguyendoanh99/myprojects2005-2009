// DATHUC.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	DATHUC f[2];
	printf("NHAP VAO 2 DA THUC:\n");
	for (int i=1;i<=2;i++)
	{
		printf("Da thuc %d:\n",i);
		nhap(f[i-1]);
	}
	printf("\n2 da thuc vua nhap la:");
	for (i=1;i<=2;i++)
	{	
		printf("\nDa thuc %d:",i);
		xuat(f[i-1]);
	}
	// Tinh tong, hieu, tich, thuong 2 da thuc
	printf("\n\nTong 2 da thuc:");
	xuat(f[0]+f[1]);
	printf("\nHieu 2 da thuc:");
	xuat(f[0]-f[1]);
	printf("\nTich 2 da thuc:");
	xuat(f[0]*f[1]);
	printf("\nThuong 2 da thuc:");
	xuat(f[0]/f[1]);
	printf("\nPhan du :");
	xuat(phandu(f[0],f[1]));
	printf("\n");
	// Tinh dao ham
	for (i=1;i<=2;i++)
	{
		printf("\nDao ham cap 1 cua da thuc %d:",i);
		xuat(daoham(f[i-1]));
	}
	int k;
	float x0;	
	printf("\n\nTinh dao ham cap k cua 2 da thuc vua nhap:");
	printf("\nNhap k:");
	scanf("%d",&k);
	for (i=1;i<=2;i++)
	{
		printf("Dao ham cap %d cua da thuc %d:",k,i);
		xuat(daoham(f[i-1],k));
		printf("\n");
	}
	// Tinh da thuc tai x0
	printf("\n\nTinh gia tri cua 2 da thuc tai vi tri x0:");
	printf("\nNhap x0:");
	scanf("%f",&x0);	
	for (i=1;i<=2;i++)
		printf("Gia tri da thuc %d tai x0 = %0.3f\n",i,tinhf(f[i-1],x0));
	// Tim nghiem da thuc 
	float a,b;
	printf("\n\nTim nghiem cua da thuc trong doan [a,b]:");
	printf("\nNhap a:");
	scanf("%f",&a);
	printf("Nhap b:");
	scanf("%f",&b);
	printf("Nghiem cua da thuc 1 trong doan [%0.3f,%0.3f] la: %f",a,b,timnghiem(f[0],a,b));
	printf("\nNghiem cua da thuc 2 trong doan [%0.3f,%0.3f] la: %f",a,b,timnghiem(f[1],a,b));
	getch();
	return 0;
}
