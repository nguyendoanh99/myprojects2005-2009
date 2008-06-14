// 824.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <stdio.h>

int main(int argc, char* argv[])
{
	LIST l;
	_input("data.txt",l);
	output("data.inp",l);
	if (!input("data.inp",l))
	{
		printf("Khong mo duoc file");
		return 1;
	}
	printf("cac hoc sinh co diem toan nho hon 5:\n");
	lietke(l);
	int d=demdiem(l);
	printf("So luong hoc sinh co diem toan va diem van lon hon 8 la:%d\n",d);
	sapxepgiam(l);	
	printf("\nDanh sach sau khi sap xep giam dan theo diem trung binh:\n");
	output(l);
	if (!output(filename3,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	return 0;
}
