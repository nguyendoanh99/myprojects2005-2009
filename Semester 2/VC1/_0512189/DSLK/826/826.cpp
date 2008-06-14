// 826.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	LIST l;

	//input(l);
	//output("data.inp",l);

	input("data.inp",l);
	printf("Danh sach cac hop sua : ");
	output(l);

	int kq=dem(l);
	printf("\nSo luong hop sua san xuat truoc nam 2003 trong danh sach la : %d",kq);

	HOPSUA hs=moinhat(l);
	printf("\nHop sua moi nhat trong danh sach : ");
	xuat(hs);

	printf("\nDanh sach hop sua sau khi sap tang dan theo han su dung : ");
	sapxep(l); 
	output(l);
	getch();
	return 0;
}
