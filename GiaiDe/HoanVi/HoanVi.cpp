#include <iostream.h>
int a[10];
short chon[10];
int n;
void hv(int);
void in();
void init(int );
void main()
{
	n=4;
	hv(0);
}

void init(int n)
{
	for (int i=0;i<n;++i)
		chon[i]=0;
}
void in()
{
	for (int i=0;i<n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}

void hv(int d)
{
	if (d==n)
	{
		in();
		return;
	}
	for (int i=0;i<n;++i)
		if (!chon[i])
		{
			chon[i]=1;
			a[d]=i;
			hv(d+1);
			chon[i]=0;
		}
}