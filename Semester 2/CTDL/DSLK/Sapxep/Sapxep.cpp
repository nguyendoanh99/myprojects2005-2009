// Sapxep.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>

int main(int argc, char* argv[])
{
	LIST *l=new LIST;
	input("data.txt",l);
	xuat(*l);
//	QuickSort(l);
//	SelectionSort(l);
/*
	int a[100];
	int n=0;
	for (NODE *p=l->pHead;p;p=p->pNext)
		a[n++]=p->info;
	printf("\n");
	RadixSort(a,n);
*/
//	RadixSort(l);
	MergeSort(l);
	printf("\nSau khi sap xep:\n");
/*	for (int i=0;i<n;i++)
		printf("%4d ",a[i]);
*/
	xuat(*l);
	return 0;
}
