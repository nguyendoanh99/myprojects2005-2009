// bai1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
#include<string.h>

int main(int argc, char* argv[])
{
	int n,x,k;
	int a[30000];
	FILE *f1;
	FILE *f2;
	f1=fopen("text.inp","rt");
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
	f2=fopen("text.out","wt");
	fprintf(f2,"%d",k);
	fclose(f2);
}
