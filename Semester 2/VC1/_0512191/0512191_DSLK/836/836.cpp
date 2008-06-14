// 836.cpp : Defines the entry point for the console application.
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
	int kq=timnam(l);
	printf("\nNam co nhieu luan van nhat: %d\n",kq);	
	printf("\nCac luan van thuc hien gan day nhat la:\n");
	lietke(l,timnamgannhat(l));	
	return 0;
}
