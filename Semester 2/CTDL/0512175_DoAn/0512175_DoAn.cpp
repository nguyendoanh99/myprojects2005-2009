// 0512175_DoAn.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "bigint.h"
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char* argv[])
{
	char s[MAX]="bieuthuc.txt";
	fflush(stdin);
	printf("Nhap ten file muon thuc hien:");
	gets(s);
	Phan2(s);
	return 0;
}