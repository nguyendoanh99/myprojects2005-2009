// 832.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
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
	printf("Xuat danh sach:\n");
	output(l);
	NGAY kq=timngay(l);
	printf("\Ngay co nhieu chuyen bay nhat:\n");
	xuat(kq);
	printf("\nNhap ma chuyen bay muon tim kiem:");
	fflush(stdin);
	char s[6];
	gets(s);
	CHUYENBAY temp;
	int kq1=timchuyenbay(l,s,temp);
	if (kq1)
	{
		printf("Chuyen bay co ma:%s",s);
		xuat(temp);
	}
	else
		printf("Khong tim thay chuyen bay co ma la %s",s);	
	return 0;
}
