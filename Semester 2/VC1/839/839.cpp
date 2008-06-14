// 839.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>

int main(int argc, char* argv[])
{
	LIST l;
	_input("data.txt",l);
	output("data.inp",l);
	if (!input("data.inp",l)==0)
	{
		printf("Khong mo duoc file");
		return 1;
	}
	printf("Xuat danh sach:\n");
	output(l);	
	printf("\nNhap ten dai ly muon tim kiem:");
	fflush(stdin);
	char s[31];
	gets(s);
	DAILY temp;
	int kq1=timten(l,s,temp);
	if (kq1)
	{		
		xuat(temp);
	}
	else
		printf("Khong tim thay dai ly co ten la %s",s);
	DAILY k=timtiepnhan(l);	
	printf("\n\nDai ly duoc tiep nhan gan day nhat la:\n");
	xuat(k);	
	output("data.out",l);	
	return 0;
}
