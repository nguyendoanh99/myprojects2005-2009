// HINHCAU.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	HINHCAU S[2];
	printf("Nhap vao 2 hinh cau:\n");
	for (int i=0;i<2;i++)
	{
		printf("Nhap hinh cau S%d:\n",i+1);
		nhap(S[i]);
	}
	printf("\n2 hinh cau vua nhap la:");
	for (i=0;i<2;i++)
	{
		printf("\nHinh cau S%d: ",i+1);
		xuat(S[i]);
	}
	// Dien tich xung quanh
	printf("\n");
	for (i=0;i<2;i++)	
		printf("\nDien tich xung quanh hinh cau S%d = %8.3f",i+1,dientichxungquanh(S[i]));
	// The tich
	printf("\n");
	for (i=0;i<2;i++)	
		printf("\nThe tich duong tron S%d = %8.3f",i+1,thetich(S[i]));
	// Xet vi tri tuong doi
	int kq=tuongdoi(S[0],S[1]);
	printf("\n\nS1 ");
	xuat(S[0]);
	printf(" va S2");
	xuat(S[1]);
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
	// Kiem tra diem co nam trong hinh cau hay khong?
	DIEMKG P;
	printf("\n\nKiem tra diem co nam trong hinh cau hay khong?");
	printf("\nNhap diem P:\n");
	nhap(P);
	for (i=0;i<2;i++)
	{
		printf("P");
		xuat(P);
		if (ktthuoc(S[i],P))			
			printf(" nam trong S%d",i+1);
		else
			printf(" khong nam trong S%d",i+1);
		xuat(S[i]);
		printf("\n");
	}
	getch();
	return 0;
}
