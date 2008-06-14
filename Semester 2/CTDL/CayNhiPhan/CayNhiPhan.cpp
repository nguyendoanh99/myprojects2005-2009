// CayNhiPhan.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


int main(int argc, char* argv[])
{
	TREE T;
	NODE **q;
	NODE *p=new NODE;
	input("input.txt",T);
	delnode(T,18);
	delnode(T,23);
	LNR(T);
	return 0;
}
