 // CTDL.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <process.h>
#include <math.h>
int main(int argc, char* argv[])
{

	FILE *f1;
	int *a;
	int n;
	int x;
	int k;
	int *h;
	int nh;
	int i;
	k = 5;

	f1 = fopen(argv[1],"rt");
	if(f1 == NULL)
	{
		printf("\n Khong mo file nay duoc.");
		exit(0);
	}
	fscanf(f1,"%d",&n);

	a = new int[n+1];
	docfile(f1,n,a,x,k);
	fclose(f1);

//	in_ktra(n,a,x,k);

// CAC PHUONG PHAP SAP XEP
	switch(x)
	{
		case 1:
				Heapsort(a,n,k);
				break;
		case 2:
				nh=(int) (log(n)/log(3));
				h=(int*)malloc(nh*sizeof(int));
				h[nh-1]=1;
				for (i=nh-1;i>0;i--)
					h[i-1]=3*h[i]+1;
				if(k == 0)
					ShellSort_tang(a,n,h,nh);
				else
					ShellSort_giam(a,n,h,nh);
				break;
		case 3:
				a=(int*)realloc(a,(2*n+1)*sizeof(int));
				if(k == 0)
					MergeSort_tang(a,n);
				else
					MergeSort_giam(a,n);
				break;

		case 4:
			if(k == 0)
				Quicksort_tang(a,1,n);
			else
				Quicksort_giam(a,1,n);
			break;

	}


//	printf("\n");
//	Insau_sapxep(a,n);
	ghifile(a,n,argv[2]);

	return 0;
}
