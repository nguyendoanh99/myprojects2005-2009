// stdafx.cpp : source file that includes just the standard includes
//	0512191.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
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
	int l,r,mid;
	l=0;
	r=n-1;
	do
	{
		mid=(l+r)/2;
		if(a[mid]==x)
			return mid;
		else
			if(a[mid]>x)
				r=mid-1;
			else
				l=mid+1;
	}while(l<=r);
	return-1;
}