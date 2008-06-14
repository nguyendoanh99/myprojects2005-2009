// 829.cpp : Defines the entry point for the console application.
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
	float tongDT=tongdientich(l);
	printf("Tong dien tich cua tat ca cac tinh: %8.3f",tongDT);
	NODE *nodetinh=diachinode(l);
	printf("\n\nDia chi cua node chua tinh co dien tich lon nhat: %p",nodetinh);
	TINH kq=timtinh(l);
	printf("\n\nTinh co dan so lon nhat la:\n");
	xuat(kq);
	sapxeptang(l);
	printf("\n\nDanh sach sau khi sap xep tang theo dien tich:\n");
	output(l);
	if (!output(filename4,l))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	return 0;
}
