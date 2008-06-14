// 0512191_DO_AN.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
#include "string.h"
#include <time.h>

int main(int argc, char* argv[])
{
	Phan2();
/*
	BIGINT A,B,C;
	char s[1000];
	int x,k;
	time_t ltime[4];
    _tzset();
	do
	{
		fflush(stdin);
		printf("Nhap so thu nhat:");
		gets(s);
		input(A,s);
		fflush(stdin);
		printf("\n");
		printf("Nhap so thu hai :");
		gets(s);
		input(B,s);
		printf("\nNhap mot so:( 1:Cong ; 2:Tru ; 3:Nhan ; 4:So sanh ) ");
		scanf("%d",&x);
		switch(x)
		{
			case 1:
				cong(A,B,C);
				printf("\nKet qua phep cong:  ");
				output(C);
				break;
			case 2:
				tru(A,B,C);
				printf("\nKet qua phep tru:  ");
				output(C);
				break;
			case 3:
				nhan(A,B,C);
				printf("\nKet qua phep nhan:  ");
				output(C);
				break;
			case 4:
				int kq=sosanh(A,B);
				printf("\nKet qua so sanh:  ");
					output(A);
				if(kq==1)
					printf(" > ");
				else
					if(kq==-1)
						printf(" < ");
					else
						printf(" = ");
				output(B);
				break;
		}
		printf("\n");
		printf("\nNhap mot so :( 1 : Tiep tuc ; 0 : Ngung )  ");
		scanf("%d",&k);
		printf("\n");
	}while(k);
/*	printf("\n");
	output(A);
	printf("\n");
	output(B);
	printf("\n");
	/*printf("so sanh ");
	int kq=ss(A,B);
	printf("%d",kq);
	cong(A,B,C);
	printf("Phep cong :");
	output(C);
	
	printf("\n");
	tru(A,B,C);
	printf("Phep tru :");
	output(C);
	printf("\nPhep nhan :");
	nhan(A,B,C);
	output(C);
	printf("\nPhep nhan luy thua:\n");
	time( &ltime[0]);
	
	phepnhanluythua(A,C);
	for(int i=1;i<=10;i++)
	{
		A=C;		
		phepnhanluythua(A,C);
	}
	time( &ltime[1]);
	output(C);
	printf("%\nlen=%d",length(C));
	printf("\ntime1=%ld\n",ltime[1]-ltime[0]);
*/	
	return 0;
}
