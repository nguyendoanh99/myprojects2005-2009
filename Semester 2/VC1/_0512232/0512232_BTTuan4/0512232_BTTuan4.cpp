#include"sorting.h"
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include <math.h>

int main(int argc[], char* argv[])
{
	
	int *a;
	int n,x,k;
	
	FILE *fp;
	
	fp=fopen(argv[1],"rt");
	if(fp==NULL)
		return NULL;
	fscanf(fp,"%d ",&n);
	
	a=(int*) calloc((n+1),sizeof(int)); // fai cap phat bo nho cho a tai day (theo kinh nghiem) nhung khong chac
	
	input(argv[1],a,n,x,k);
	
	switch(x)
	{
	
	case 1:
	{

		if(k==0)
		{
			doimang(a,n,1);
			heapsort_tang(a,n);
			doimang(a,n,0);
			break;
		}

		else
		{
			doimang(a,n,1);
			heapsort_giam(a,n);
			doimang(a,n,0);
		}
		break;

	}

	case 2:
	{
		int m=(int)(log(n)/log(3));
		int *h=(int *)malloc(m*sizeof(int));
		h[m-1]=1;
		for (int i=m-1;i>0;i--)
			h[i-1]=3*h[i]+1;	

		if(k==0)
		{
			shellsort_tang(a,n,h,m);
			break;
		}
		else
			shellsort_giam(a,n,h,m);
		break;

	}

	case 3:
	{
		a=(int*) realloc(a,2*n*sizeof(int));
		if(k==0)
		{
			mergesort_tang(a,n);
			break;
		}
		else
			mergesort_giam(a,n);
		break;

	}

	case 4:
		{

			if(k==0)
			{
				quicksort_tang(a,0,n-1);
				break;
			}
			else
				quicksort_giam(a,0,n-1);
			break;

		}

	}
	
	output(argv[2],a,n);

	return 0;
}