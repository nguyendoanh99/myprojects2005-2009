// DUONGTRON.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	DUONGTRON c[2];
	printf("Nhap vao 2 duong tron:\n");
	for (int i=0;i<2;i++)
	{
		printf("Nhap duong tron C%d:\n",i+1);
		nhap(c[i]);
	}
	printf("\n2 duong tron vua nhap la:");
	for (i=0;i<2;i++)
	{
		printf("\nDuong tron C%d: ",i+1);
		xuat(c[i]);
	}
	// Chu vi
	printf("\n");
	for (i=0;i<2;i++)	
		printf("\nChu vi duong tron C%d = %8.3f",i+1,chuvi(c[i]));
	// Dien tich
	printf("\n");
	for (i=0;i<2;i++)	
		printf("\nDien tich duong tron C%d = %8.3f",i+1,dientich(c[i]));
	// Xet vi tri tuong doi
	int kq=tuongdoi(c[0],c[1]);
	printf("\n\nC1 ");
	xuat(c[0]);
	printf(" va C2");
	xuat(c[1]);
	switch (kq)
	{	
	case 0:

		printf(" trung nhau.");
		break;
	case 1:
		printf(" tiep xuc ngoai");
		break;
	case 2:
		printf(" tiep xuc trong");
		break;
	case 3:
		printf(" nam trong nhau");
		break;
	case 4:
		printf(" khong cat nhau");
		break;
	case 5:
		printf(" cat nhau");
		break;
	}	
	// Kiem tra diem co nam trong duong tron hay khong?
	DIEM P;
	printf("\n\nKiem tra diem co nam trong duong tron hay khong?");
	printf("\nNhap diem P:\n");
	nhap(P);
	for (i=0;i<2;i++)
	{
		printf("P");
		xuat(P);
		if (ktthuoc(c[i],P))			
			printf(" nam trong C%d",i+1);
		else
			printf(" khong nam trong C%d",i+1);
		xuat(c[i]);
		printf("\n");
	}
	printf("\nDien tich phan mat phang bi phu boi 2 duong tron do la: %8.3f",dientichphu(c[0],c[1]));
	getch();
	return 0;
}
