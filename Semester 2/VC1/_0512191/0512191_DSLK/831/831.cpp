// 831.cpp : Defines the entry point for the console application.
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
	MATHANG kq=tim(l);
	printf("\nMat hang co tong gia tri ton la lon nhat la:");
	xuat(kq);
	int dem=demmathang(l);	
	printf("\n\nSo luong mat hang co so luong ton lon hon 1000 la:%d",dem);
	return 0;
}
