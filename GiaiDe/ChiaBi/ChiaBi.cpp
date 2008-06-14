#include <iostream.h>
int m,n,k,l;
int a[10];
void t(int[]);
int Try(int);
void xuat(int[],int);
void main()
{
	m=7;
	n=33;
	k=3;
	l=5;
	Try(m);
}

int Try(int j)
{
	if (j==1)
	{
		if (n>=k && n<=l)
		{
			a[m-1]=n;
			xuat(a,m);
			return 1;
		}
		else		
			return 0;
	}
	if (n/j>=k && n/j<=l)
	{
		for (int i=n/j;i>=k;--i)
		{
			a[m-j]=i;
			n-=i;
			if (!Try(j-1))
			{
				n+=i;
				break;
			}			
			n+=i;
		}
		for (i=n/j+1;i<=l;++i)
		{
			a[m-j]=i;
			n-=i;
			if (!Try(j-1))
			{
				n+=i;

				return 0;
			}
			n+=i;
		}
		return 1;
	}
	else
	{

		return 0;
	}
}

void xuat(int a[],int n)
{
	for (int i=0;i<n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}