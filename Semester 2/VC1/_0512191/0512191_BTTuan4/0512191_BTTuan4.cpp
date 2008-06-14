// 0512191_BTTuan4.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
#include "stdlib.h"

int main(int argc, char* argv[])
{
	int a[30000];int n,x,k;
	int kq=nhap(argv[1],a,n,x,k);
	if(!kq)
	{
		printf("Nhap khong thanh cong !");
		return 0;
	}
	switch(x)
	{
	case 1:
		HeapSort(a,n);
		break;
	case 2:
		ShellSort(a,n);
		break;
	case 3:
		MergeSort(a,n);		
		break;
	case 4:
		QuickSort(a,1,n);
		break;
	}
	kq=xuat(argv[2],a,n,k);
	if(!kq)
	{
		printf("Xuat khong thanh cong !");
		return 0;
	}
	return 0;
}