// 829.cpp : Defines the entry point for the console application.
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
	printf("Danh sach cac tinh la : \n");
	output(l);

	float kq=tongdt(l);
	printf("\n\nTong dien tich cac tinh la : %0.2f",kq);

	NODE* p=dientichln(l);
	printf("\n\nDia chi cua node chua tinh co dien tich lon nhat trong danh sach la : %p",p);

	TINH t=dansoln(l);
	printf("\n\nTinh co dan so lon nhat trong danh sach : ");
	xuat(t);
	printf("\n\nDanh sach cac tinh sau khi sap tang dan theo dien tich la : ");

	sapxep(l); 
	
	output(l);
	getch();

	return 0;
}
