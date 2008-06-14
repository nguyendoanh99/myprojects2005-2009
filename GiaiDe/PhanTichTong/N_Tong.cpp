#include <iostream.h>

int a[100];
int n=10;
int d=0;
int tong=0;

void Try(int);
void main()
{
	Try(1);
}

void Try(int k)
{
	if (tong==n)
	{
		for (int i=0;i<d;++i)
			cout<<a[i]<<" + ";
		cout<<endl;
		return ;
	}
	for (int i=k;i<=n-tong;++i)
	{
		a[d++]=i;
		tong+=i;
		Try(i);
		tong-=i;
		--d;
	}
}