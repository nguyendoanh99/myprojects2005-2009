// 833.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>

int main(int argc, char* argv[])
{
	LIST l;
//	_input("data.txt",l);
//	output("data.inp",l);
	if (!input("data.inp",l))
	{
		printf("Khong mo duoc file");
		return 1;
	}
	printf("Xuat danh sach:\n");
	output(l);
	printf("\nDanh sach cac cau thu nho tuoi nhat trong danh sach:\n");
	lietke(l,tim(l));	
	sapxepgiam(l);
	printf("\n\nDanh sach sau khi sap xep giam theo ngay sinh:\n");
	output(l);
	if (!output(filename2,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	return 0;
}
