// stdafx.cpp : source file that includes just the standard includes
//	bai1.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<conio.h>
// TODO: reference any additional headers you need in STDAFX.H
int timtuyentinh (int a[],int n,int x)
{
	int i=0;
	a[n]=x;
	while((a[i])!=x)
		i++;
	if(i==n)
		return -1;
	else
		return i;
}
int timnhiphan(int a[],int n,int x)
{
	int left,right,mid;
	left=0;
	right=n-1;
	do
	{
		mid=(left+right)/2;
		if(a[mid]==x)
			return mid;
		else
			if(a[mid]>x)
				right=mid-1;
			else
				left=mid+1;
	}while(left<=right);
	return-1;
}
// and not in this file
// stdafx.cpp : source file that includes just the standard includes
//	0512232.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
