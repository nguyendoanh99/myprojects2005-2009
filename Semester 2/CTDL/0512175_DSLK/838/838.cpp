// 838.cpp : Defines the entry point for the console application.
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
	float tong=tongtien(l);
	printf("\nTong so tien goi co trong danh sach: %8.3f",tong);
	int cmnd;
	printf("\n\nNhap so chung minh nhan dan muon tim:");
	scanf("%d",&cmnd);
	NODE *nodeSTK=timnode(l,cmnd);
	printf("\n\nDia chi cua node theo chung minh nhan dan %d la: %p",cmnd,nodeSTK);	
	return 0;
}
