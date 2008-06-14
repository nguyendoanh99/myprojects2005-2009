#include <iostream.h>

short nt[32676]={0};
void ptich(int );
void taobang(int );

void main()
{
	int n=29;
	taobang(n);
	ptich(n);
}

void ptich(int n)
{
	int ni=n;
	int t=1;
	for (int i=2;i<ni;i+=t)
	{
		if (i==3)
			t=2;
		if (nt[i]==0)
			for (int j=i+t;j<ni-i;j+=2)
				if  (nt[j]==0 && nt[n-i-j]==0 && n-i-j>j)
				{
					cout<<i<<" "<<j<<" "<<(n-i-j);										
					ni=n-i-j;					
					cout<<endl;
				}		
	}
}

void taobang(int n)
{
	nt[0]=nt[1]=1;
	for (int j=4;j<=n;j+=2)
		nt[j]=1;
	for (int i=3;i<=n;i+=2)
		if (nt[i]==0)
			for (int j=i*i;j<=n;j*=i)
				nt[j]=1;
}