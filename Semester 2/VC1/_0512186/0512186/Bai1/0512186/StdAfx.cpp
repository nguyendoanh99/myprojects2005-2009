// stdafx.cpp : source file that includes just the standard includes
//	0512186.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include<stdio.h>
#include<stdlib.h>
// TODO: reference any additional headers you need in STDAFX.H
int timtuyentinh(int a[],int n,int x)
{
	a[n]=x;
	int i=0;
	while(a[i]!=x)
		i++;
	if(i==n)
		return -1;
	return i;
}
int timnhiphan(int a[],int n,int x)
{
	int left=0,right=n-1;
	do
	{
		int mid=(left+right)/2;
		if(a[mid]==x)
			return mid;
		else
			if(a[mid]<x)
				left=mid+1;
			else
				right=mid-1;
	}while(left<=right);
	return -1;
}
// and not in this file
