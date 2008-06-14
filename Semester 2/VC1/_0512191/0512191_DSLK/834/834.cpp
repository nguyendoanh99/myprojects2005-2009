// 834.cpp : Defines the entry point for the console application.
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
	NHANVIEN kq=timnhanvien(l);
	printf("\n\nNhan vien co luong cao nhat la:\n");
	xuat(kq);
	float tong=tongluong(l);
	printf("\nTong luong cua cac nhan vien: %8.3f",tong);	
	sapxeptang(l);
	printf("\n\nDanh sach sau khi sap xep tang theo luong nhan vien:\n");
	output(l);
	if (!output(filename3,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	return 0;
}
