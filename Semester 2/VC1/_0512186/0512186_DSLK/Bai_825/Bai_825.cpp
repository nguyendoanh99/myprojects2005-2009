// Bai_825.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>

int main(int argc, char* argv[])
{
	LIST lst;
	DIEM kq;

//	nhap_ds(lst);
//	input1("test.inp",lst);
//	output("data.inp",lst);
	input("data.inp",lst);
	printf("Toa do cac diem trong phan tu thu nhat cua mp Oxy la:\n");
	lietke(lst);
	printf("\n");

	printf("Diem co tung do lon nhat trong ds la:\n");
	kq=tunglonnhat(lst);
	xuatdiem(kq);
	printf("\n");

	printf("Toa do cac diem sau khi sap giam theo kc la:\n");
	sapgiam(lst);
	xuat_ds(lst);
	int k=output("data.out",lst);
	if(k==0)
		printf("Khong tao duoc file");
	return 0;
}
