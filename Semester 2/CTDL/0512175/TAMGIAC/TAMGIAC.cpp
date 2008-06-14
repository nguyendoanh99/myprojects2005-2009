// TAMGIAC.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	TAMGIAC t;
	printf("Nhap tam giac:\n");
	nhap(t);
	if (kiemtra(t))
	{
		printf("Toa do 3 dinh vua nhap lap thanh 3 dinh cua mot tam giac.\n");
		printf("\nTam giac vua nhap la:\n");
		xuat(t);
		printf("\nChu vi tam giac: %8.3f",chuvi(t));
		printf("\nDien tich tam giac: %8.3f",dientich(t));
		printf("\n\nToa do trong tam cua tam giac: ");
		xuat(trongtam(t));
		printf("\n\nDinh trong tam giac co hoanh do lon nhat la:");
		xuat(hoanhlonnhat(t));
		printf("\nDinh trong tam giac co tung do nho nhat la:");
		xuat(tungthapnhat(t));
		printf("\n\nTam giac vua nhap la tam giac ");
		switch (dangtamgiac(t))
		{
		case 0:
			printf("thuong.");
			break;
		case 1:
			printf("deu.");
			break;
		case 2:
			printf("vuong.");
			break;
		case 3:
			printf("vuong can.");
			break;
		case 4:
			printf("can.");
			break;
		}
		printf("\n\nKiem tra mot toa do diem co nam trong tam giac hay khong?");
		printf("\nNhap diem P:\n");
		DIEM P;
		nhap(P);
		printf("Diem P");
		xuat(P);
		if (ktthuoc(t,P))
			printf(" nam trong tam giac vua nhap.");
		else
			printf(" khong nam trong tam giac vua nhap.");
	}
	else
		printf("Toa do 3 dinh vua nhap khong lap thanh 3 dinh cua mot tam giac.");
	getch();
	return 0;
}
