// 0512068_doan_p1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <iostream.h>
#include <string.h>
#include <ctype.h>

int main(int argc, char* argv[])
{

/* 
// PHAN I

	BIGINT b,b1,b2;
	int tt;

	do
	{
		printf("\n Nhap hai so nguyen voi do dai tuy y :\n");
		Input(b1);
		Input(b2);
		printf("\n Chon toan tu (1:+,2:-,3:*,4:sosanh):");
		scanf("%d",&tt);
		switch(tt)
		{
		case 1:
				 b = Cong(b1,b2);
				 Output(b1) ; printf("+") ; Output(b2) ; printf("=") ; Output(b);
				 break;
		case 2:
				 b = Tru(b1,b2);
				 Output(b1) ; printf("-") ; Output(b2) ; printf("=") ; Output(b);
				 break;
		case 3:
				 b = Nhan(b1,b2);
				 Output(b1) ; printf("*") ; Output(b2) ; printf("=") ; Output(b);
				 break;
		case 4:
				 int kq = Sosanh(b1,b2);
				 switch(kq)
				 {
				 case -1:
					 Output(b1) ; printf("<") ; Output(b2);
					 break;
				 case 0: 
					 Output(b1) ; printf("=") ; Output(b2);
					 break;
				 case 1:
					 Output(b1); printf(">"); Output(b2);
					 break;
				 }
				 break;
		}

	}while(1);
*/

// PHAN II VA III

	BIEUTHUC bt[100];
	int n;
	Read_file("input.txt",bt,n);
	printf("\n Tinh gia tri cua cac bieu thuc sau :\n");
	Xuat_ktra(bt,n);
	Tinh_cacbieuthuc(bt,n);
	printf("\n Gia tri cua cac bieu thuc la:\n");
	for(int i=0 ; i<n ; i++)
	{
		Output(bt[i].giatri);
		printf("\n");
	}

  
	return 0;
}

