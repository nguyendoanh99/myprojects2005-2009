// DSLK_nhiphan.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>

int main(int argc, char* argv[])
{
	LIST lst;
//	nhap(lst);
//	output("data.inp",lst);
	input("data.inp",lst);
	output(lst);
	long S=tongtien(lst);
	printf("\nTong tien la:%ld",S);
	saptang(lst);
	output("data.out",lst);
	getch();
	return 0;
}
