// 0512186_BTTuan5.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>

int main(int argc, char* argv[])
{
	LIST lst;
	int n,m,x,dem;
	input(argv[1],lst,n,m,x,dem);
	thaynt(lst);
	switch(x)
	{
	case 1:
		selection_sort(lst);
		break;
	case 2:
		insertion_sort(lst);
		break;
	case 3:
		interchange_sort(lst);
		break;
	}
	output(argv[2],lst,dem);
	return 0;
}
