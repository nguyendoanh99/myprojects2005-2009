// 0512191_DO_AN.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdio.h"
#include "conio.h"
#include "string.h"
#include <time.h>

int main(int argc, char* argv[])
{
	//BIGINT A,B,C;
	char s[100];
	time_t ltime[4];
    _tzset();    	
	char a[100][100];
	BIGINT *A;
	printf("Nhap so thu nhat:");
	gets(s);
	A=TinhToan(s);
	output(*A);






/*	input(A,s);
	printf("\n");
	printf("Nhap so thu hai:");
	gets(s);
	input(B,s);
	printf("\n");
	output(A);
	printf("\n");
	output(B);
	printf("\n");
	printf("so sanh ");
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
//	getch();
*/	return 0;
}
