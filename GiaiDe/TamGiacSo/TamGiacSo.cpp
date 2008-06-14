#include <iostream.h>
#include <stdio.h>
#include <limits.h>

const int max=10;
int n;
int A[max][max];
int B[max][max];
int C[max];
int d;
void input();
void LapBang();
int min(int[],int );
void duongdi();

void main()
{
	input();
	LapBang();
	d=n;
	duongdi();
	for (int i=1;i<=n;++i)
		cout<<C[i]<<" ";
}

void duongdi()
{
	int temp;
	int t=min(B[n],n);
	C[d--]=A[n][t];
	temp=B[n][t]-A[n][t];
	for (int i=n-1;i>0;--i)
	{
		if (temp==B[i][t-1])		
			--t;		
		temp-=A[i][t];
		C[d--]=A[i][t];
	}
}

int min(int a[],int n)
{
	int m=1;
	for (int i=2;i<=n;++i)
		if (a[m]>a[i])
			m=i;
	return m;
}
void LapBang()
{	
	B[1][1]=A[1][1];
	for (int i=2;i<=n;++i)
		for (int j=1;j<=i;++j)
			if (B[i-1][j]>B[i-1][j-1])			
				B[i][j]=A[i][j]+B[i-1][j-1];
			else
				B[i][j]=A[i][j]+B[i-1][j];
}

void input()
{
	FILE *fp=fopen("TamGiacSo.inp","rt");
	fscanf(fp,"%d",&n);
	for (int i=1;i<=n;++i)
	{
		for (int j=1;j<=i;++j)
			fscanf(fp,"%d",&A[i][j]);		
		B[i][0]=B[i][i+1]=INT_MAX;
	}
	fclose(fp);
}