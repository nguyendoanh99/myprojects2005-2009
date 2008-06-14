// 826.cpp : Defines the entry point for the console application.
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
	int kq=demhopsua(l);
	printf("So luong hop sua san xuat truoc nam 2003 la:%d\n",kq);
	HOPSUA k=timhopmoi(l);
	printf("Hop sua moi nhat trong danh sach la:\n");
	xuat(k);
	sapxeptang(l);
	printf("\n\nDanh sach sau khi sap xep tang theo han su dung:\n");
	output(l);
	if (!output(filename3,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}

	return 0;
}
