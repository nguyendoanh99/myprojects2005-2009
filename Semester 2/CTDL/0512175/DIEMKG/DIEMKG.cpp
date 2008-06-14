// DIEMKG.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	DIEMKG p[2];
	printf("Nhap vao 2 diem trong mat phang Oxyz\n");
	for (int i=0;i<=1;i++)
	{
		printf("Nhap DIEM p%d:\n",i+1);
		nhap(p[i]);
	}
	printf("2 diem vua nhap vao la: \n");	
	xuat(p[0]);
	printf(" ; ");
	xuat(p[1]);
	// Tinh khoang cach
	printf("\n\nKhoang cach giua 2 diem:%8.3f",khoangcach(p[0],p[1]));
	printf("\nKhoang cach giua 2 diem theo phuong x:%8.3f",khoangcachx(p[0],p[1]));	
	printf("\nKhoang cach giua 2 diem theo phuong y:%8.3f",khoangcachy(p[0],p[1]));	
	printf("\nKhoang cach giua 2 diem theo phuong z:%8.3f\n",khoangcachz(p[0],p[1]));	
	// Tim diem doi xung
	for (i=0;i<=1;i++)
	{
		printf("\nToa do diem doi xung qua goc toa do cua diem p%d la:",i+1);	
		xuat(dxgoc(p[i]));
	}
	printf("\n");
	for (i=0;i<=1;i++)
	{
		printf("\nToa do diem doi xung qua (Oxy) cua diem p%d la:",i+1);	
		xuat(dxoxy(p[i]));
	}
	printf("\n");
	for (i=0;i<=1;i++)
	{
		printf("\nToa do diem doi xung qua (Oxz) cua diem p%d la:",i+1);	
		xuat(dxoxz(p[i]));
	}
	printf("\n");
	for (i=0;i<=1;i++)
	{
		printf("\nToa do diem doi xung qua (Oyz) cua diem p%d la:",i+1);	
		xuat(dxoyz(p[i]));
	}
	getch();
	return 0;
}
