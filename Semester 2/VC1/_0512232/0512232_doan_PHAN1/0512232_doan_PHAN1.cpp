// 0512232_doan_PHAN1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>
#include<ctype.h>

int main(int argc, char* argv[])
{
	
	char *a;
	char *b;
	BigInt l;
	BigInt h;
	
	a=new char[1000];
	b=new char[1000];
	
	
	fflush(stdin);
	printf("Nhap so thu nhat : ");
	//strcpy(a, "365");
	gets(a);

	printf("\nNhap so thu hai : ");
	//strcpy(b, "27");
	gets(b);

	taoxautuchuoi(l,a);
	output(l);
	taoxautuchuoi(h,b);
	printf("\n");
	output(h);

	printf("\nHay chon toan tu : \n");
	printf("	1.Cong\n");
	printf("	2.Tru\n");
	printf("	3.Nhan\n");
	printf("	4.So sanh\n");
	printf("	5.Thoat\n");
	printf("Ban chon : ");
	
	unsigned char x=getchar();
	printf("  KET QUA : " );
	tinhtoan(l,h,x);
	
	
	return 1;
}



