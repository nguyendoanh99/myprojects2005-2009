// bai2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
#include<string.h>

int main(int argc, char* argv[])
{
	int n,k;
	char x[40];
	DANHSACH a[200];
	FILE *f1;
	FILE *f2;
	f1=fopen(argv[1],"rt");
	if(f1==NULL)
		printf("Khong mo duoc file");
	fscanf(f1,"%d ",&n);
	fscanf(f1,"%d ",&k);
	fgets(x,40,f1);
	for(int i=0;i<n;i++)
	{
		float temp;
		fgets(a[i].MSSV,10,f1);
		fgets(a[i].hoten,40,f1);
		fgets(a[i].diachi,50,f1);
		fscanf(f1,"%f ",&temp);
		temp=a[i].dtb;
	}
	fclose(f1);
	if(k==1)
		k=timtuyentinh(a,n,x);
	else
		k=timnhiphan(a,n,x);
	f2=fopen(argv[2],"wt");
	fprintf(f2,"%d",k);
	fclose(f2);
}
