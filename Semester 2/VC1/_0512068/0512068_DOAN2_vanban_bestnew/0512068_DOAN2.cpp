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

	printf("\n Nhap hai so nguyen voi do dai tuy y :\n");
	do
	{
		printf("\n So thu 1 : ");
		if(Input(b1) == 0)
			printf("\n Ko hop le , moi nhap lai.");
		else
			break;
	}while(1);
	do
	{
		printf("\n So thu 2 : ");
		if(Input(b2) == 0)
			printf("\n Ko hop le , moi nhap lai.");
		else
			break;
	}while(1);
	printf("\n Cac toan tu : 1(cong) , 2(tru) , 3(nhan) , 4(sosanh) : ");
	do
	{
		printf("\n Chon toan tu so : ");
		scanf("%d",&tt);
		if(tt<1 || tt>4)
			printf("\n Ko hop le , moi chon lai.");
		else
			break;
	}while(1);

	printf("\n Ket qua la : ");
	switch(tt)
	{
	case 1:
			 b = b1+b2;
			 Output(b1) ; printf(" + ") ; Output(b2) ; printf(" = ") ; Output(b);
			 printf("\n");
			 break;
	case 2:
			 b = b1-b2;
			 Output(b1) ; printf(" - ") ; Output(b2) ; printf(" = ") ; Output(b);
			 printf("\n");
			 break;
	case 3:
		   	 b = b1*b2;
			 Output(b1) ; printf(" * ") ; Output(b2) ; printf(" = ") ; Output(b);
			 printf("\n");
			 break;
	case 4:
			 int kq = Sosanh(b1,b2);
			 switch(kq)
			 {
			 case -1:
				 Output(b1) ; printf(" < ") ; Output(b2);
				 printf("\n");
				 break;
			 case 0: 
				 Output(b1) ; printf(" = ") ; Output(b2);
				 printf("\n");
				 break;
			 case 1:
				 Output(b1); printf(" > "); Output(b2);
				 printf("\n");
				 break;
			 }
			 break;
	}

*/

// PHAN II VA III

	BIEUTHUC bt[100];
	int n;
	
	Read_file("input.txt",bt,n);
	
	printf("\n Tinh gia tri cua cac bieu thuc sau :\n\n");
	
	Xuat_ktra(bt,n);
	Tinh_cacbieuthuc(bt,n);
	printf("\n\n\n Gia tri cua cac bieu thuc theo thu tu la:\n\n");
	
	for(int i=0 ; i<n ; i++)
	{
		if(bt[i].kthl == 1)
			Output(bt[i].giatri);
		else
			printf("\n Bieu thuc thu %d ko hop le",i+1);
		printf("\n\n");
	}

//	getch();
	return 0;
}

