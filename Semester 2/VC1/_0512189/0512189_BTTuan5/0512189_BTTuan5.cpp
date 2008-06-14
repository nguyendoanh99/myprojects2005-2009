// 0512189_BTTuan5.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "sorting.h"
#include <stdio.h>

int main(int argc, char* argv[])
{
	LIST a;
	int x;

	if(!input(argv[1],a,x))
		printf("Khong mo duoc file!!!");
	
	nguyento(a);

	switch(x)
	{
	case 1:
		SelectionSort(a);
		break;
	case 2:
		InsertionSort(a);
		break;
	case 3:
		InterchangeSort(a);
		break;
	}

	if(!output(argv[2],a))
		printf("Khong tao duoc file!!!");

	return 0;
}
