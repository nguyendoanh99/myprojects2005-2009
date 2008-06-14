// 830.cpp : Defines the entry point for the console application.
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
	printf("Danh sach cac ve xem phim la : ");
	output(l);

	long kq=tonggiatien(l);
	printf("\nTong gia tien cac ve trong danh sach la : %ld",kq);

	printf("\nDanh sach cac ve sau khi sap tang dan theo ngay xem va xuat chieu : ");
	sapxep(l); 
	output(l);

	getch();
	return 0;
}
