// 824.cpp : Defines the entry point for the console application.
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
	printf("Danh sach hoc sinh : ");
	output(l);

	printf("\nDanh sach hoc sinh co diem toan nho hon 5 la : ");
	lietke(l);

	int kq=demhs(l);
	printf("\nSo luong hoc sinh co diem toan va diem van lon hon 8 : %d",kq);

	printf("\nDanh sach hoc sinh sau khi sap giam dan theo diem trung binh : ");
	sapxep(l); 
	output(l);
	getch();
	return 0;
}
