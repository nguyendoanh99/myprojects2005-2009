// 828.cpp : Defines the entry point for the console application.
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
	SACH kq=timsach(l);
	printf("\nQuyen sach cu nhat trong danh sach la:\n");
	xuat(kq);
	int nam=timnam(l);
	printf("\n\nNam co nhieu sach xuat ban nhat la nam:%d\n",nam);	
	lietke(l,nam);	
	return 0;
}
