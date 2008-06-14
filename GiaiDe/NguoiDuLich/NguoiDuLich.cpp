#include <iostream.h>
#include <stdio.h>
#include <limits.h>
#include <string.h>

const int maxn=10;

int n;
int Cmin=INT_MAX;
int a[maxn][maxn]={0};
int x[maxn+1];
int y[maxn+1];
int min=INT_MAX;
int DaTham[maxn]={0};
int t;
int xp;

void input();
void Try(int,int);
void xuat(int[],int);

void main()
{
	input();
	xp=1;
	x[1]=xp;
	DaTham[xp]=1;
	Try(2,0);
	xuat(y,n);
}

void xuat(int a[],int n)
{
	for (int i=1;i<=n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}
void Try(int i,int S)
{
	for (int j=0;j<n;++j)
		if (DaTham[j]==0)
		{
			t=S+a[x[i-1]][j];
			if (t+Cmin*(n-i+1)<min)
			{
				x[i]=j;
				DaTham[j]=1;
				if (i==n)
				{
					if (t+a[j][xp]<min)
					{
						min=t+a[j][xp];
						memcpy(y,x,sizeof(int)*(n+1));
					}
				}
				else
					Try(i+1,t);
				DaTham[i]=0;
			}
		}
}
void input()
{
	FILE *fp=fopen("NguoiDuLich.inp","rt");
	fscanf(fp,"%d",&n);
	for (int i=0;i<n-1;++i)
		for (int j=i+1;j<n;++j)
		{				
			fscanf(fp,"%d",&a[i][j]);
			a[j][i]=a[i][j];
			if (a[i][j]<Cmin)
				Cmin=a[i][j];
		}
	for (i=0;i<n;++i)
		a[i][i]=INT_MAX;
	fclose(fp);
}