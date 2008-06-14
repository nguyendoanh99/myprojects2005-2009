// 830.cpp : Defines the entry point for the console application.
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
	int kq=tongtien(l);
	printf("\nTong gia tien cua tat ca cac ve la:%d",kq);
	sapxeptang(l);
	printf("\nDanh sach sau khi sap xep tang theo ngay xem va xuat chieu:\n");
	output(l);
	if (!output(filename2,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}

	return 0;
}
