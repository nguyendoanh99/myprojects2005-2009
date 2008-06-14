// Do_an.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <time.h>

int main(int argc, char* argv[])
{
	BIGINT a,b,c;
	time_t ltime; 
	int ltime1,ltime2;
//	int n;
	printf("Nhap so thu nhat : "); 
	input(a);
	printf("\nNhap so thu hai : "); 
	input(b);
	printf("\n\nSo thu nhat la : ");
	output(a);
	printf("\nSo thu hai la : ");
	output(b);

	printf("\nSo sanh : %d",sosanh(a,b));
	printf("\nSo sanh tri tuyet doi : %d",ss(a,b));

	c=cong(a,b);
	printf("\na+b = ");
	output(c);


	c=tru(a,b);
	printf("\na-b = ");
	output(c);
	
	ltime1=time(&ltime);

	c=pow(a,10);
	printf("\nC1 :a^10 = ");
	output(c);
	ltime2=time(&ltime);
	printf("\nThoi gian chay : %d",(ltime2-ltime1));


	c=pow2(a,10);
	printf("\nC2 :a^10 = ");
	output(c);

	
	printf("\nGiai thua cua a la : ");
	ltime1=time(&ltime);

	c=giaithua(a);
	output(c);
	ltime2=time(&ltime);
	printf("\nThoi gian chay : %d",(ltime2-ltime1));


	/*

	c=nhan(a,b);
	printf("\na*b ket qua la : ");
	output(c);

	c=nhan2(a,b);
	printf("\na*b ket qua la : ");
	output(c);

	//printf("\nNhap vao so mu n : ");
	//scanf("%d",&n);
	//c=luythua(a,n);
	//printf("\na^%d ket qua la : ",n);
	//output(c);

	//printf("\nGiai thua cua a la : ");
	//c=giaithua(a);
	//output(c);
*/
	getch();
	return 0;
}
