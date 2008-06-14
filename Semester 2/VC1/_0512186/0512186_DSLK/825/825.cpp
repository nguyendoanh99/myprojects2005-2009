// 825.cpp : Defines the entry point for the console application.
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
	printf("Cac diem trong phan tu thu I cua mat phang Oxy:\n");
	lietke(l);
	printf("Diem co tung do lon nhat:");
	xuat(timdiem(l));
	printf("\nDanh sach sau khi sap xep giam dan theo khoang cach tu no den goc toa do:\n");
	sapxepgiam(l);
	output(l);
	if (!output(filename3,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	return 0;
}
