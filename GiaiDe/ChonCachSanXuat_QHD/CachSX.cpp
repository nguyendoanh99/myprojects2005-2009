#include <iostream.h>
#include <limits.h>
int A[4][5]={
	{0},
	{10,12,15,20,1000},
	{10,14,16,19,23},
	{10,12,17,19,1000}};
int R[5][4];
short B[5][4];

void chon();
int Min(int,int,int &);
void xuat();

void main()
{
	chon();
	cout<<R[4][3]<<endl;
	xuat();
}

int Min(int a,int b,int &m)
{
	if (a>b)
	{
		m=1;
		return b;
	}
	else
	{
		m=0;
		return a;
	}
}

void chon()
{
	for (int j=0;j<=4;++j)	
	{
		R[j][1]=A[1][j];
		B[j][1]=j;
	}
	
	int i=2;
	int min;
	int temp,m;
	for (j=0;j<=4;++j)
	{			
		min=INT_MAX;
		for (int k=0;k<=j;++k)
		{
			min=Min(min,R[k][i-1]+A[i][j-k],m);
			if (m==1)
				temp=j-k;
		}
		R[j][i]=min;
		B[j][i]=temp;
	}
	i=3;
	j=4;
	min=INT_MAX;
	for (int k=0;k<=4;++k)
	{
		min=Min(min,R[k][i-1]+A[i][j-k],m);
		if (m==1)
			temp=j-k;
	}
	B[j][i]=temp;
	R[j][i]=min;
}

void xuat()
{
	int temp=R[4][3]-A[3][B[4][3]];
	cout<<"x3="<<B[4][3]<<endl;
	for (int j=2;j>=1;--j)
	{
		for (int i=0;i<=4;++i)
			if (R[i][j]==temp)
				break;
		cout<<"x"<<j<<"="<<B[i][j]<<endl;
		temp-=A[j][B[i][j]];
	}
}