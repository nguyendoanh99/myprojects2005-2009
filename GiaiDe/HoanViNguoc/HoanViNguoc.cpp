#include <iostream.h>
#include <string.h>

const int maxn=10;

int n;
int b[maxn];
short chon[maxn];
int a[maxn];
int DuocChon[maxn];
void hv(int [],int);
void in();

void init(int[],int [],int);
int Generate(int [],int);
void xuat(int [],int);

void main()
{
	n=5;
	hv(a,1);
}

void init(int a[],int b[],int n)
{
	for (int i=1;i<=n;++i)
		DuocChon[i]=1;
	memcpy(a,b,sizeof(int)*(n+1));
}

int Generate(int a[],int n)
{
	int i=n;
	int k;
	while (i>0)
	{
		k=0;
		DuocChon[a[i]]=0;
		for (int j=a[i]-1;j>0;--j)
			if (DuocChon[j]==0)
			{
				DuocChon[j]=1;
				a[i]=j;
				k=1;
				break;
			}
		if (k)
		{
			int t=n;
			for (++i;i<=n;++i)
				for (int j=t;j>0;--j)
					if (DuocChon[j]==0)
					{
						DuocChon[j]=1;
						a[i]=j;
						t=j-1;
						break;
					}
			return 1;
		}
		else
			--i;
	}
	return 0;
}

void xuat(int a[],int n)
{
	for (int i=1;i<=n;++i)
		cout<<a[i]<<" ";	
}

void hv(int a[],int d)
{
	if (d>n)
	{
		xuat(a,n);
		cout<<"\t";
		init(b,a,n);
		if (Generate(b,n))
			xuat(b,n);
		cout<<endl;
		return;
	}
	for (int i=1;i<=n;++i)
		if (!chon[i])
		{
			chon[i]=1;
			a[d]=i;
			hv(a,d+1);
			chon[i]=0;
		}
}