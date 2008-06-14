// SapXep.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
//#define _STACK 1
int main(int argc, char* argv[])
{
	int a[100];
	int n=100;
	tao(a,n);
	xuat(a,n);
//	printf("\n");

//#if _STACK==1
//#include "stack_dslk.h"
//#else
//#include "stack.h"
//#endif
	_QuickSort(a,0,n-1);
	xuat(a,n);
	getch();
	return 0;
}
