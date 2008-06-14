// 0512175_BTTuan3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

int main(int argc, char* argv[])
{
	int *a;
	int n,k,x;
	if (!input(argv[1],&a,&n,&x,&k))
	{
		printf("Khong mo duoc file");
		getch();
		exit(1);
	}
	switch (x)
	{
	case 1:
		SelectionSort(a,n,k);
		break;
	case 2:
		InsertionSort(a,n,k);
		break;
	case 3:
		InterchangeSort(a,n,k);
		break;
	case 4:
		BubbleSort(a,n,k);
		break;
	case 5:
		ShakerSort(a,n,k);
		break;
	}
	if(!output(argv[2],a,n))
	{
		printf("Khong tao duoc file");
		getch();
		exit(1);
	}
	return 0;
}
