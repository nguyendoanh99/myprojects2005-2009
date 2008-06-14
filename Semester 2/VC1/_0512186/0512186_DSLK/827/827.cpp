// 827.cpp : Defines the entry point for the console application.
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
	printf("Cac phong con trong trong danh sach:\n");
	lietkephong(l);
	int d=tonggiuong(l);
	printf("\nTong so luong giuong co trong danh sach:%d\n",d);
	sapxeptang(l);
	printf("\nDanh sach sau khi sap xep tang theo don gia thue:\n");
	output(l);
	if (!output(filename3,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	return 0;
}
