// 837.cpp : Defines the entry point for the console application.
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
	LOPHOC kq=timlop(l);
	printf("\nLop co si so dong nhat:\n");
	xuat(kq);
	HOCSINH kq1=timhocsinh(l);
	printf("\nHoc sinh co diem trung binh lon nhat:\n");
	xuat(kq1);
	
	return 0;
}
