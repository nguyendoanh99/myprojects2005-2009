#include <iostream.h>

int a[100];
int m,n;
short DuocChon[100]={0};

void ChinhHop(int,const int&);
void xuat(int);
int Generate();
void ChinhHop1();
void init();

void main()
{
	m=4;
	n=4;
//	ChinhHop(0,m);
	ChinhHop1();
}

void init()
{
	for (int i=0;i<m;i++)
	{
		a[i]=i;
		DuocChon[i]=1;
	}
}

void ChinhHop1()
{
	init();
	xuat(m);
	int k=1;
	while (k)
	{
		if (k=Generate())
			xuat(m);
	}
}

int Generate()
{
	int i=m-1;
	int k=0;
	while (i>=0)
	{
		k=0;
		DuocChon[a[i]]=0;		
		for (int j=a[i]+1;j<n;++j)
			if (DuocChon[j]==0)
			{			
				a[i]=j;
				DuocChon[j]=1;
				k=1;
				break;
			}
		if (k)
		{
			if (i<m-1)				
			{
				int t=0;				
				for (++i;i<m;++i)
					for (int j=t;j<n;++j)
						if (DuocChon[j]==0)
						{
							DuocChon[j]=1;
							a[i]=j;
							t=j+1;
							break;
						}
			}
			return 1;
		}
		else
			--i;
	}
	return 0;
}
void ChinhHop(int j,const int &m)
{
	if (j==m)
	{
		xuat(m);
		return;
	}
	for (int i=0;i<n;++i)
		if (DuocChon[i]==0)
		{
			DuocChon[i]=1;
			a[j]=i;
			ChinhHop(j+1,m);
			DuocChon[i]=0;
		}
}

void xuat(int n)
{
	for (int i=0;i<n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}