#include <iostream.h>

int F(int);
int f(int);

void main()
{
	int n=255000;
	cout<<F(n)<<endl;
	cout<<f(n)<<endl;
}

int F(int n)
{
	if (n==0)
		return 0;
	if (n==1)
		return 1;
	if (n%2==0)
		return F(n/2);
	return F(n/2)+F(n/2+1);
}

int f(int n)
{
	int *a=new int[n+1];
	a[0]=0;
	a[1]=1;
	for (int i=2;i<=n;++i)
		if (i%2==0)
			a[i]=a[i/2];
		else
			a[i]=a[i/2]+a[i/2+1];
	int t=a[n];
	delete a;
	return t;	
}