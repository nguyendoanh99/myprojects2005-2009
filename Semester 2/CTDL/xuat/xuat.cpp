// xuat.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int n, char* a[])
{
//	char a[40];
//	printf("nhap cau thong bao:");
//	scanf("%s",&a);
	for (int i=0;i<n;i++)
		printf("%s\n",a[i]);
	getch();
	return 0;
}
