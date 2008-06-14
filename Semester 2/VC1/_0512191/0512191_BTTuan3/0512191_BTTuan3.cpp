// 0512191_BTTuan3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
int main(int argc, char* argv[])
{
	int a[30000];int n,x,k;
	int kq=nhap(argv[1],a,n,x,k);
	if(kq==0)
	{
		printf("Nhap khong duoc!");
		return 0;
	}
	switch(x)
	{
	case 1:
		SelectionSort(a,n);
		break;
	case 2:
		InsertionSort(a,n);
		break;
	case 3:
		InterchangeSort(a,n);	
		break;
	case 4:
		BubbleSort(a,n);
		break;
	case 5:
		ShakerSort(a,n);
		break;
	}
	if(k==1)
		daomang(a,n);
	kq=xuat(argv[2],a,n);
	if(kq==0)
	{
		printf("Xuat khong duoc!");
		return 0;
	}
	return 0;
}