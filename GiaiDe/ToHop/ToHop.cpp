#include <iostream.h>

int n;
int k;
int a[100];

void xuat(int[],int);
void Try(int);
int Generate();
void ToHop();
void init();

void main()
{
	a[0]=0;
	n=3;
	k=6;
//	Try(1);
	ToHop();
}

void init()
{
	for (int i=1;i<=n;++i)
		a[i]=i;
}

int Generate()
{	
	int i=n;
	while (i>0)
	{
		if (k-a[i]>n-i)
		{
			++a[i];
			if (i<n)
			{
				for (++i;i<=n;++i)
					a[i]=a[i-1]+1;
			}
			return 1;
		}
		else
			i--;		
	}
	return 0;
}

void ToHop()
{
	init();
	xuat(a,n);
	int t=1;
	while (t)
	{
		if (t=Generate())
			xuat(a,n);
	}
}

void Try(int t)
{
	for (int i=a[t-1]+1;i<=k-n+t;++i)
	{
		a[t]=i;
		if (t<n)
			Try(t+1);
		else
			xuat(a,n);
	}
}

void xuat(int a[],int n)
{
	for (int i=1;i<=n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}