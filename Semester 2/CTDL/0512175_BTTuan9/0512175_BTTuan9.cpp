// 0512175_BTTuan9.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


int main(int argc, char* argv[])
{
	int x;
	AVLTREE T;
	if (!input(argv[1],T,x))
	{
		printf("Khong tim thay file nay.");
		return 1;
	}
	int viti=tim(T,x);
	XoaChinhPhuong(T);
	output(argv[2],T,viti);
	return 0;
}
