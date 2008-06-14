// 0512232_BTTuan3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include"sorting.h"

int main(int argc, char* argv[])
{
	int *a;
	int n,x,k;
	FILE *f1;
	FILE *f2;
	
	f1=fopen(argv[1],"rt");
	if(f1==NULL)
	{
		printf("Khong mo duoc file");
		exit(1);
	}
	fscanf(f1,"%d ",&n);
	fscanf(f1,"%d ",&x);
	fscanf(f1,"%d ",&k);
	
	a=(int*) malloc((n+1)*sizeof(int));
	for(int i=0;i<n;i++)
		fscanf(f1,"%d",a+i);
	
	fclose(f1);
	
	switch(x)
	{
	case 1:
		selection_sort(a,n,k);
		break;
	case 2:
		insertion_sort(a,n,k);
		break;
	case 3:
		interchang_sort(a,n,k);
		break;
	case 4:
		bubble_sort(a,n,k);
		break;
	case 5:
		shaker_sort(a,n,k);
		break;
	}
	
	f2=fopen(argv[2],"wt");
	if(f2==NULL)
	{
		printf("Khong mo duoc file");
		exit(1);
	}
	fprintf(f2,"%d\n",n);
	for(i=0;i<n;i++)
		fprintf(f2,"%4d",*(a+i));
	
	fclose(f2);
	return 0;

}
