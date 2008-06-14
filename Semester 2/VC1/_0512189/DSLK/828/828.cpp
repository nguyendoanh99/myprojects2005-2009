// 828.cpp : Defines the entry point for the console application.
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
	printf("Danh sach cac quyen sach : \n");
	output(l);

	printf("\n\nQuyen sach cu nhat trong danh sach la : ");
	SACH kq=tim(l);
	xuat(kq);

	int nam=timnam(l);
	printf("\n\nNam co nhieu sach xuat ban nhat la: %d",nam);
	lietke(l,nam);

	//output(l);
	getch();

	return 0;
}
