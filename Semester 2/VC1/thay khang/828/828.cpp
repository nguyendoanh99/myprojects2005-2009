// 828.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"

int main(int argc, char* argv[])
{
	SACH x;
	LIST l;
//	nhap_ds(l);
//	xuat_ds(l);
//	output("data.inp",l);
	input("data.inp",l);
	output("data.out",l);
	x=timsach(l);
	xuatsach(x);
	return 0;
}
