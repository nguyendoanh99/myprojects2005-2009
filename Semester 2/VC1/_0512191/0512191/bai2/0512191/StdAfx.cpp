// stdafx.cpp : source file that includes just the standard includes
//	0512191.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <string.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
int timtuyentinh(DANHSACH a[],int n,char x[])
{
	int i=0;
	strcpy(a[n].hoten,x);
	while(strcmpi(a[i].hoten,x)!=0)
		i++;
	if(i==n)
		return -1;
	return i;
}


int timnhiphan(DANHSACH a[],int n,char x[])
{
	int left=0;
	int right=n-1;
	int mid;
	do
	{
		mid=(left+right)/2;
		if(strcmpi(a[mid].hoten,x)==0)
			return mid;
		else
			if(strcmpi(a[mid].hoten,x)<0)
				left=mid+1;
			else
				right=mid-1;
	}while(left<=right);
	return -1;
}