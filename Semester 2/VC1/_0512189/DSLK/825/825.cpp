// 825.cpp : Defines the entry point for the console application.
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
	printf("Danh sach toa do cac diem : ");
	output(l);

	printf("\nDanh sach cac diem trong phan tu thu I cau mat phang Oxy la : ");
	lietkephantuI(l);

	DIEM kq=tungdoln(l);
	printf("\nDiem co tung do lon nhat trong danh sach la : ");
	xuat(kq);

	printf("\nDanh sach cac diem sau khi sap giam dan theo khoang cach tu no den goc toa do:");
	sapxep(l); 
	output(l);
	getch();

	return 0;
}
