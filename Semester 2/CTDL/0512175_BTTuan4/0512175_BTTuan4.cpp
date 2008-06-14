// 0512175_BTTuan4.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "sorting.h"
#include <stdlib.h>
#include <stdio.h>

int main(int argc, char* argv[])
{
	int *a;
	int n,k,x;
	if (!input(argv[1],&a,n,x,k))	
	{
		printf("Khong mo duoc file.");
		return 01;
	}
	switch (x)
	{
	case 1:
		heapsort(a,n,k);
		break;
	case 2:
		shellsort(a,n,k);
		break;
	case 3:
		a=(int *) realloc(a,(2*n+1)*sizeof(int));
		mergesort(a,n,k);
		break;
	case 4:
		quicksort(a,1,n,k);
		break;
	}
	if (!output(argv[2],a,n))
	{
		printf("Khong tao duoc file ");
		return 1;
	}
	free(a);
	return 0;
}
