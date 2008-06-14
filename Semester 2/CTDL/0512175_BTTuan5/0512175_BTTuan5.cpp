// 0512175_BTTuan5.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include "sorting.h"

int main(int argc, char* argv[])
{
	LIST l;
	int x;
	if (!input(argv[1],l,x))
	{
		printf("Khong mo duoc file ");
		return 1;	
	}
	tim_thaythe(l);
	switch (x)
	{
	case 1:
		SelectionSort(l);
		break;
	case 2:
		InsertionSort(l);
		break;
	case 3:
		InterchangeSort(l);
		break;
	}
	if (!output(argv[2],l))
	{
		printf("Khong tao duoc file");
		return 1;
	}
	return 0;
}
