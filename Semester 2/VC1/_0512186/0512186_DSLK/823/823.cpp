// 823.cpp : Defines the entry point for the console application.
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
	printf("Cac nhan vien tren 40 tuoi:\n");
	lietke(l);
	int d=demluong(l);
	printf("So luong nhan vien co luong lon hon 1000000 dong trong danh sach la:%d",d);
	sapxepgiam(l);
	printf("\nDanh sach sau khi sap xep giam dan theo nam sinh:\n");
	output(l);
	if (!output(filename3,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	return 0;
}
