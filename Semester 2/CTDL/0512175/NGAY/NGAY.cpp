// NGAY.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	NGAY x,y;
	int stt,nam,k;
	printf("Nhap vao 1 ngay:\n");
	nhap(x);
	printf("\nNgay vua nhap la:");
	xuat(x);
	if (ktnamnhuan(x.nm))
		printf("\n\nNam %d la nam nhuan.",x.nm);
	else
		printf("\n\nNam %d khong phai la nam nhuan.",x.nm);
	// Tinh so thu tu ngay
	printf("\n\nSo thu tu ngay trong nam cua ngay ");
	xuat(x);
	printf(" la: %d",thutungaynam(x));
	printf("\nSo thu tu ngay ke tu ngay 1/1/1 cua ngay ");
	xuat(x);
	printf(" la: %d",thutungay(x));
	// Tim ngay ke tiep
	printf("\n\nNgay ke tiep cua ngay ");
	xuat(x);
	printf(" la ngay ");
	xuat(ngayketiep(x));
	// Tim ngay hom qua
	printf("\nNgay qua cua ngay ");
	xuat(x);
	printf(" la ngay ");
	xuat(ngayhomqua(x));
	// Tim ngay ke do, ngay truoc do k ngay.
	printf("\n\nTim ngay ke do, ngay truoc do k ngay.");
	printf("\nNhap k: ");
	scanf("%d",&k);
	printf("Ngay ke do %d ngay cua ngay ",k);
	xuat(x);
	printf(" la ngay ");
	xuat(ngayke(x,k));
	printf("\nNgay truoc do %d ngay cua ngay ",k);
	xuat(x);
	printf(" la ngay ");
	xuat(ngaytruoc(x,k));
	// Tinh khoang cach giua hai ngay va so sanh hai ngay
	printf("\n\nTinh khoang cach giua hai ngay va so sanh hai ngay.");
	printf("\nNhap vao 1 ngay khac:\n");
	nhap(y);
	printf("Khoang cach giua ngay ");
	xuat(x);
	printf(" voi ngay ");
	xuat(y);
	printf(" la %d\n",khoangcach(x,y));
	xuat(x);
	switch (sosanh(x,y))
	{
	case -1:
		printf(" < ");
		break;
	case 0:
		printf(" = ");
		break;
	case 1:
		printf(" > ");
	}
	xuat(y);	
	// Tim ngay	
	printf("\n\nTim ngay khi biet nam va so thu tu ngay trong nam.");
	printf("\nNhap nam: ");
	scanf("%d",&nam);
	printf("Nhap so thu tu ngay trong nam: ");
	scanf("%d",&stt);
	printf("Ngay tuong ung la: ");
	xuat(timngay(nam,stt));
	printf("\n\nTim ngay khi biet so thu tu ngay ke tu ngay 1/1/1.");
	printf("\nNhap so thu tu ngay: ");
	scanf("%d",&stt);
	printf("Ngay tuong ung la: ");
	xuat(timngay(stt));
	getch();
	return 0;
}