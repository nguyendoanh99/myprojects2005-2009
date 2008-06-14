// 0512191.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char* argv[])
{
		int n,x,k;
	int a[30000];
	FILE *f1;
	FILE *f2;
	f1=fopen(argv[1],"rt");
	if (f1==NULL)
	{
		printf("Khong mo file duoc");
		getch();
		exit(1);
	}
	fscanf(f1,"%d",&n);
	fscanf(f1,"%d",&k);
	fscanf(f1,"%d",&x);
	for(int i=0;i<n;i++)
		fscanf(f1,"%d",&a[i]);
	fclose(f1);
	if(k==1)
		k=timtuyentinh(a,n,x);
	else
		k=timnhiphan(a,n,x);
	f2=fopen(argv[2],"wt");
	fprintf(f2,"%d",k);
	fclose(f2);
	return 1;
	return 0;
}
