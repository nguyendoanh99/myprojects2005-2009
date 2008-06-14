// 0512189_Doan_Phan1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>

int main(int argc, char* argv[])
{
	BIGINT a,b,c;
	int tt;

	printf("Nhap so thu nhat : "); 
	input(a);
	printf("Nhap so thu hai : "); 
	input(b);

	printf("Cho biet toan tu (1 - cong, 2 - tru, 3 - nhan, 4 - so sanh) : ");
	scanf("%d",&tt);

	printf("Ket qua : ");

	switch(tt)
	{
	case 1:
		c=a+b;
		output(c);
		break;
	case 2:
		c=a-b;
		output(c);
		break;
	case 3:
		c=a*b;
		output(c);
		break;
	case 4:
		int kq=sosanh(a,b);
		output(a);
		switch(kq)
		{
		case 1:
			printf(">");
			break;
		case 0:
			printf("=");
			break;
		case -1:
			printf("<");
			break;
		}
		output(b);
		break;

	}

	DeleteBigint(a);
	DeleteBigint(b);
	DeleteBigint(c);

	getch();
	return 0;
}