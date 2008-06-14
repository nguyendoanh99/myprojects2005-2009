#include <iostream.h>

int A[100];
int *B[2];
int n=5;

void Nhap(int[],int);
void Xuat(int[],int);
void Tim(int &,int &,int);

void main()
{
	int ct,cd,M;
	Nhap(A,n);
	Xuat(A,n);
	cout<<"Nhap M:";
	cin>>M;
	Tim(cd,ct,M);
	cout<<cd<<" "<<ct;
}

void Tim(int &canduoi,int &cantren,int M)
{
	canduoi=0;
	cantren=-1;
	B[0]=new int[n+1];
	B[1]=new int[n+1];
	int *temp;
	for (int i=0;i<=n;++i)
		B[0][i]=0;
	for (i=0;i<=n;++i)
	{
		for (int j=i+1;j<=n;++j)
		{
			B[1][j]=B[0][j-1]+A[j];
			if (B[1][j]==M)
			{
				canduoi=j-i;
				cantren=j;
				return;
			}
		}		
		temp=B[0];
		B[0]=B[1];
		B[1]=temp;
	}
	delete B[0];
	delete B[1];
}

void Nhap(int a[],int n)
{
	for (int i=1;i<=n;++i)
	{
		cout<<"Nhap A["<<i<<"]=";
		cin>>a[i];
	}
}

void Xuat(int a[],int n)
{
	for (int i=1;i<=n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}
/*
#include <iostream.h>
#include <stdio.h>

int a[100];
int x[100]={0};
int n;
int S,tong=0;
int Smin=0,Smax=0;

void input();
void Try(int,int,int);
void xuat(int [],int[],int);

void main()
{
	input();
	Try(1,Smin,Smax);
}

void Try(int i,int Smin,int Smax)
{	
	int S1,S2;
	int j;
	if (x[i-1]==1)
		j=1;
	else
		j=0;
	for (;j<=1;++j)
	{
		S1=Smin;
		S2=Smax;
		tong+=a[i]*j;
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
			if (tong==S || i==n)
				xuat(a,x,n);				
			else
				if (i<n)
					Try(i+1,S1,S2);				
			x[i]=0;
		}
		tong-=a[i]*j;
	}
}

void xuat(int a[],int x[],int n)
{
	for (int i=1;i<=n;++i)
		if (x[i])
			cout<<a[i]<<" ";
	cout<<endl;

}
void input()
{
	FILE *fp=fopen("DayCon.inp","rt");
	fscanf(fp,"%d %d",&n,&S);
	for (int i=1;i<=n;++i)
	{
		fscanf(fp,"%d", &a[i]);
		if (a[i]>0)
			Smax+=a[i];
		else
			Smin+=a[i];
	}
	fclose(fp);
}
*/


