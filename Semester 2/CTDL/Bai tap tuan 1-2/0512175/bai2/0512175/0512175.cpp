// 0512175.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>


int main(int argc, char* argv[])
{
	SV *a;
	int n,k,t;
	char x[41];
	input(argv[1],&a,n,k,x);
	switch (k)
	{
	case 1:
		t=tuantu(a,n,x);
		break;
	case 2:
		t=nhiphan(a,n,x);
		break;
	}
	output(argv[2],t);
	return 0;
}

