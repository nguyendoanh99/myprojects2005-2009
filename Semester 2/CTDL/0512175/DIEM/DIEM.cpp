// DIEM.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	DIEM p[2];
	printf("Nhap vao 2 diem trong mat phang Oxy\n");
	for (int i=0;i<=1;i++)
	{
		printf("Nhap DIEM p%d:\n",i+1);
		nhap(p[i]);
	}
	printf("2 diem vua nhap vao la: ");	
	xuat(p[0]);
	printf(" ; ");
	xuat(p[1]);
	// Tinh khoang cach
	printf("\n\nKhoang cach giua 2 diem:%8.3f",khoangcach(p[0],p[1]));
	printf("\nKhoang cach giua 2 diem theo phuong Ox:%8.3f",khoangcachx(p[0],p[1]));	
	printf("\nKhoang cach giua 2 diem theo phuong Oy:%8.3f\n",khoangcachy(p[0],p[1]));	
	printf("\nToa do diem doi xung qua goc toa do cua");	
	// Tim diem doi xung
	for (i=0;i<=1;i++)
	{
		printf("\nDiem p%d la:",i+1);	
		xuat(dxgoc(p[i]));
	}
	printf("\n\nToa do diem doi xung qua truc hoanh cua");	
	for (i=0;i<=1;i++)
	{
		printf("\nDiem p%d la:",i+1);	
		xuat(dxox(p[i]));
	}
	printf("\n\nToa do diem doi xung qua truc tung cua");	
	for (i=0;i<=1;i++)
	{
		printf("\nDiem p%d la:",i+1);	
		xuat(dxoy(p[i]));
	}
	printf("\n\nToa do diem doi xung qua duong phan giac thu nhat cua");	
	for (i=0;i<=1;i++)
	{
		printf("\nDiem p%d la: ",i+1);	
		xuat(dxpg1(p[i]));
	}
	printf("\n\nToa do diem doi xung qua duong phan giac thu hai cua");	
	for (i=0;i<=1;i++)
	{
		printf("\nDiem p%d la:",i+1);	
		xuat(dxpg2(p[i]));
	}
	// Xem diem co thuoc cac phan tu hay khong?
	printf("\n\nXem diem p1, p2 thuoc phan tu thu may?\n");
	for (i=0;i<=1;i++)
	{
		xuat(p[i]);
		if (ktphantu1(p[i]))
			printf(" thuoc phan tu thu I.\n");
		else
			if (ktphantu2(p[i]))
				printf(" thuoc phan tu thu II.\n");
			else
				if (ktphantu3(p[i]))
					printf(" thuoc phan tu thu III.\n");
				else
					if (ktphantu4(p[i]))
						printf(" thuoc phan tu thu IV.\n");
					else
						printf(" khong thuoc phan tu nao het.\n");
	}
	getch();
	return 0;
}
