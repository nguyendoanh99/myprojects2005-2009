// 835.cpp : Defines the entry point for the console application.
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
	printf("Cac thi sinh thi dau trong danh sach la:\n");
	lietke(l);	
	sapxepgiam(l);	
	printf("\nDanh sach sau khi sap xep giam dan theo diem tong cong:\n");
	output(l);
	if (!output(filename2,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	return 0;
}
