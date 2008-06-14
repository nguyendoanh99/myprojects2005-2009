#include <iostream.h>
#include <stdio.h>

const int maxm=5;
const int maxn=4;
int A[maxm][maxn]={0};
short B[maxm][maxn]={0};
int m,n;
int F[maxm];
int Fi[maxm];
int Fj[maxm];

int max(int [],short[]);
void input();
void ThucHien();
void Try(int,const int&);
void Xuat(int);

void main()
{
	input();
	ThucHien();
	cout<<F[m]<<endl;
	Xuat(m);
}

void Xuat(int m)
{
	if (m<=0)
		return;
	cout<<"Dau tu "<<Fi[m]<<" trieu cho linh vuc "<<Fj[m]<<" lai la "<<A[Fi[m]][Fj[m]]<<endl;
	Xuat(m-Fi[m]);
}

void Try(int m,const int &t)
{
	if (m<t)
		return;
	if (Fi[m]==t)
		B[t][Fj[m]]=1;
	Try(m-Fi[m],t);
}
void ThucHien()
{	
	for (int i=1;i<=m;++i)
	{		
		for (int j=1;j<i;++j)		
		{
			for (int k=01;k<=n;++k)
				B[i][k]=0;
			Try(j,i-j);
			int t=max(A[i-j],B[i-j]);
			if (t!=0 && F[i]<F[j]+A[i-j][t])
			{
				F[i]=F[j]+A[i-j][t];
				Fi[i]=i-j;
				Fj[i]=t;
			}
		}		
	}
}

void input()
{
	FILE *fp=fopen("DAUTU.INP","rt");
	fscanf(fp,"%d %d",&m,&n);
	for (int i=1;i<=m;++i)
	{
		A[i][0]=-1;
		int k=0;
		for (int j=1;j<=n;++j)
		{
			fscanf(fp,"%d",&A[i][j]);
			if (A[i][k]<A[i][j])
				k=j;
		}
		F[i]=A[i][k];
		Fi[i]=i;
		Fj[i]=k;
	}
}

int max(int a[],short b[])
{
	int k=0;
	for (int i=1;i<=n;++i)
		if (!b[i])
			if (a[k]<a[i])
				k=i;
	return k;
}