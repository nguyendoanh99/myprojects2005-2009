// 827.cpp : Defines the entry point for the console application.
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
	printf("Danh sach cac phong trong khach san : \n");
	output(l);

	printf("\n\nCac phong trong trong danh sach : ");
	lietke(l);

	int kq=tonggiuong(l);
	printf("\n\nTong so luong giuong co trong danh sach la : %d",kq);

	printf("\n\nDanh sach phong sau khi sap tang dan theo don gia thue : ");
	sapxep(l); 
	output(l);
	getch();

	return 0;
}
