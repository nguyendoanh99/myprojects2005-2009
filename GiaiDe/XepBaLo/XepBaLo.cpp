#include <iostream.h>
#include <stdio.h>

int a[100];
int x[100]={0};
int n;
int S;
int Smin=0,Smax=0;

void input();
void Try(int,int,int);
void xuat(int [],int[],int);

void main()
{
	input();
	Try(0,Smin,Smax);
}

void Try(int i,int Smin,int Smax)
{	
	int S1,S2;
	for (int j=0;j<=1;++j)
	{
		S1=Smin;
		S2=Smax;
		if (j==0)
		{
			if (a[i]<0)
				S1-=a[i];
			else
				S2-=a[i];
		}
		else
		{
			if (a[i]<0)
				S2+=a[i];
			else
				S1+=a[i];
		}
		if (S1<=S && S<=S2)
		{
			x[i]=j;
			if (i<n-1)
				Try(i+1,S1,S2);
			else
				xuat(a,x,n);
		}
	}
}

void xuat(int a[],int x[],int n)
{
	for (int i=0;i<n;++i)
		if (x[i])
			cout<<a[i]<<" ";
	cout<<endl;

}
void input()
{
	FILE *fp=fopen("XepBaLo.inp","rt");
	fscanf(fp,"%d %d",&n,&S);
	for (int i=0;i<n;++i)
	{
		fscanf(fp,"%d", &a[i]);
		if (a[i]>0)
			Smax+=a[i];
		else
			Smin+=a[i];
	}
	fclose(fp);
}