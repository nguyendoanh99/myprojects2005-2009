// Bai_827.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include<conio.h>

int main(int argc, char* argv[])
{
	LIST lst;
//	nhap_ds(lst );
//	output("data.inp",lst);
	
	printf("Cac phong trong la:");
	lk_phongtrong(lst);
	output("data1.out",lst);
	
	printf("Tong so luong giuong la:");
	int kq=tonggiuong(lst);
	printf("%4d",kq);

	printf("Danh sach sau khi sap la:");
	saptang(lst);
	output("data2.out",lst);

	return 0;
}
