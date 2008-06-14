
#include <iostream.h>

int n;
int k;
int a[100]={0};

void xuat(int[],int);
void Try(int);
void ChinhHopLap(int);
int Generate(int[],int);
void main()
{
	n=3;
	k=3;
	Try(0);
	ChinhHopLap(n);
}

int Generate(int a[],int n)
{
	int i=n-1;
	while (i>0 && a[i]==k-1)
	{
		a[i]=0;
		--i;
	}
	if (i>0)
	{
		++a[i];
		return 1;
	}
	else
		return 0;
}
void ChinhHopLap(int n)
{
	xuat(a,n);
	int t=1;
	while (t)
	{
		if (t=Generate(a,n))
			xuat(a,n);
	}
}

void Try(int t)
{
	for (int i=0;i<k;++i)
	{
		a[t]=i;
		if (t+1<n)
			Try(t+1);
		else
			xuat(a,n);
	}
}

void xuat(int a[],int n)
{
	for (int i=0;i<n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}
