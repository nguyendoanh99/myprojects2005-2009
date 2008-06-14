// 0512186_BTTuan3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>

int main(int argc, char* argv[])
{
	int a[30];
	int n,x,k;
	int kq=nhap(argv[1],a,n,x,k);
	if(kq==0)
	{
		printf("Khong mo duoc file");
		return 0;
	}
	switch(x)
	{
	case 1:
		selection_sort(a,n,k);
		break;
	case 2:
		insertion_sort(a,n,k);
		break;
	case 3:
		interchange_sort(a,n,k);
		break;
	case 4:
		bubble_sort(a,n,k);
		break;
	case 5:
		shaker_sort(a,n,k);
		break;
	}
	kq=xuat(argv[2],a,n);
	if(kq==0)
	{
		printf("Khong tao duoc file");
		return 0;
	}
	return 0;
}
