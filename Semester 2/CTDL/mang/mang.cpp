// mang.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>

void chantangamgiam(int [],int);

void tronmang(int [],int,int [],int,int [],int &);
void tangdan(int [],int);
void chantang(int [],int);
void thembaotoan(int [],int &,int );
void taomangchanle(int [],int,int [],int &);
void ziczac(int [][100],int,int);
void tronoc(int [][100],int,int);
int oketiep(int [][100],int ,int ,int ,int &,int &);
void lkc(int [],int ,int, int, int);
void lkc(int [],int ,int, int);
void lietkecontang(int [],int );
void lietkecon(int [],int);
int dem(int [], int, int, int);
int demcontang(int [],int);
void tim(int [],int,int,int,int&,int&);
void duongdainhat(int [],int,int&,int&);
void daonguocchanle(int [],int);
void daonguoc(int [],int ,int ,int);
int duongnhonhat(int[],int);
int main(int argc, char* argv[])
{	
	FILE *f=fopen(argv[1],"wt");
	int n=atoi(argv[2]);
//	extern int khoang;
//	khoang=n;
//#undef khoang
#define khoang n
	int *a=(int *)malloc(n*sizeof(int));
	int x=atoi(argv[3]);
	int k=atoi(argv[4]);
	tao(a,n,n);
	fprintf(f,"%d %d %d\n",n,x,k);
	for (int i=0;i<n;i++)
		fprintf(f,"%4d ",a[i]);
//	xuat(a,n);
//	printf("\n");
//	printf("%d",duongnhonhat(a,n));
	fclose(f);
/*	int n=10,m=5,k;
	int a[100],c[100],b[100];
	srand((unsigned) time(NULL));
	tao(a,n);
//	tao(b,m);
//	tangdan(a,n);
//	tangdan(b,m);
	xuat(a,n);
//	xuat(b,m);
//	chantangamgiam(a,n);
//	tronmang(a,n,b,m,c,k);
//	xuat(c,k);
//	chantang(c,k);
//	thembaotoan(c,k,-10);
//	textcolor(3);
	taomangchanle(a,n,c,k);
	xuat(c,k);
//	cout.adjustfield*/
//	int a[100][100],m=4,n=+6;
//	float c[100][100];
//	tao(a,m,n);
//	xuat(a,m,n);
//	printf("\n");
//	ziczac(a,m,n);
//	xuat(a,m,n);
//	tronoc(a,m,n);
//	printf("\n");
//	xuat(a,m,n);
//	int s=4;
//	s+=(s==78);
	
//	s=s/t;
//	printf("%d",s);
//	int i=0;
	
//	daonguocchanle(a,n);
//	xuat(a,n);
//	lietkecon(a,n);
//	lietkecontang(a,n);
//	printf("%4d",demcontang(a,n));
//	duongdainhat(a,n,d,c);
//	printf("\n%4d %4d",d,c);
//	getch();
	return 0;
}
int duongnhonhat(int a[],int n)
{
	if (n==0)
		return -1;
	int lc=0;
	lc=duongnhonhat(a,n-1);
	if (a[n-1]<=0)
		return lc;
	if (lc==-1)
		return a[n-1];
	if (lc>a[n-1])
		lc=a[n-1];
	return lc;
}
void daonguoc(int a[],int i,int k,int l)
{
//	if (i>=k && i>=l)
//		return;
	int h;
	if (a[i]%2==0)
	{
		if (k<i)
			return;
		if (a[k]%2==0)
		{
			h=k;
			k--;			
		}
		else
		{
			daonguoc(a,i,k-1,l);
			return;
		}
	}
	else
	{
		if (l<i)
			return;
		if (a[l]%2!=0)
		{
			h=l;
			l--;
		}
		else
		{
			daonguoc(a,i,k,l-1);
			return;
		}
	}
	daonguoc(a,i+1,k,l);
	int temp=a[h];
	a[h]=a[i];
	a[i]=temp;
}
void daonguocchanle(int a[],int n)
{
/*
	for (int i=0,k=n,l=n,h;i<k || i<l;i++)
	{
		if (a[i]%2==0)
		{
			for (k--;a[k]%2!=0 && k>i;k--);
			if (k<i)
				continue;
			h=k;
		}
		else
		{
			for (l--;a[l]%2==0 && l>i;l--);
			if (l<i)
				continue;
			h=l;
		}
		int temp=a[h];
		a[h]=a[i];
		a[i]=temp;
	}
*/
	daonguoc(a,0,n-1,n-1);
}
void tim(int a[],int n,int l,int i,int &d,int &c)
{
	if (l<n && i==n-l)
	{
		tim(a,n,l+1,n-l-1,d,c);
		if (d!=-1)
			return;
	}
	if (i>0)
	{
		tim(a,n,l,i-1,d,c);
		if (d!=-1)
			return;
	}
	for (int flag=1,j=0;j<l;j++)
		if (a[i+j]<=0)
		{
			flag=0;
			break;
		}
	if (flag)
	{
		d=i;
		c=i+l-1;
		return;
	}
}
void duongdainhat(int a[],int n,int &d,int &c)
{
	d=c=-1;
	tim(a,n,1,n-1,d,c);
}
int dem(int a[],int n, int l, int i)
{
	for (int flag=1,j=0;j<l-1;j++)
		if (a[i+j]>a[i+j+1])
		{
			flag=0;
			break;
		}
	int kq=0;
	if (l>2 && i==n-l)
		kq=dem(a,n,l-1,n-l+1);
	if (i>0)
		kq=kq+dem(a,n,l,i-1);
	return kq+flag;
}
int demcontang(int a[],int n)
{
	int d=0;
	for (int l=2;l<=n;l++)
		for (int i=0;i<=n-l;i++)
		{
			for (int flag=01,j=0;j<l-1;j++)
				if (a[i+j]>a[i+j+1])
					flag=0;
			d+=flag;
		}
	printf("%4d",d);
	return dem(a,n,n,0);
}
void lkc(int a[],int n,int l,int i)
{
	if (l>2 && i==n-l)
		lkc(a,n,l-1,n-l+1);
	if (i>0)
		lkc(a,n,l,i-1);
	for (int j=0,flag=1;j<l-1;j++)
		if (a[i+j]>a[i+j+1])
			flag=0;
	if (flag)
	{
		for (j=0;j<l;j++)
			printf("%4d",a[i+j]);
		printf("\n");
	}	
}
void lietkecontang(int a[],int n)
{
	lkc(a,n,n,0);
/*	for (int l=1;l<=n;l++)
		for (int i=0;i<=n-l;i++)
		{
			for (int j=0,flag=1;j<l-1;j++)
				if (a[i+j]>a[i+j+1])
					flag=0;
			if (flag)
			{
				for (j=0;j<l;j++)
					printf("%4d",a[i+j]);
				printf("\n");
			}
		}
*/
}
void lkc(int a[],int n,int l, int i, int j)
{
	if (l>3 && i==n-l && j==l-1)
	{
		lkc(a,n,l-1,n-l+1,l-2);
		printf("\n");
	}
	if (i>0 && j==l-1)
	{
		lkc(a,n,l,i-1,j);
		printf("\n");
	}
	if (j>0)
		lkc(a,n,l,i,j-1);
	printf("%4d",a[i+j]);
}
void lietkecon(int a[],int n)
{
	lkc(a,n,n,0,n-1);
}
int oketiep(int a[][100],int m,int n,int i,int &flag,int &t)
{
	if (i/n==0 || i/n==m-1 || i%n==0 || i%n==n-1)
	{
		flag=!flag;
		if (flag)
		{
			int j;
			if (i/n==0 || i/n==m-1)
				j=(i%n==n-1)?i+n:i+1;
			if (i%n==0 || i%n==n-1)
				j=(i/n==m-1)?i+1:i+n;				
			return j;
		}
		else
			t=-t;
	}
	return i+t*(n-1);		
}
void tronoc(int a[][100],int m,int n)
{		
	for (int t=1,i=0,n1=0,n2=n,m1=0,m2=m;m1<m2 && n1<n2;i=i+t)
	{		
/*
		if (i/n==m1 && i%n==n2-1)
		{
			if (i/n) n1++;
			t=n;
		}
*/
		(i/n==m1 && i%n==n2-1)?t=n,(i/n)?n1++:n1:t;
		(i%n==n2-1 && i/n==m2-1)?m1++,t=-1:t;
		(i/n==m2-1 && i%n==n1)?n2--,t=-n:t;
		(i%n==n1 && i/n==m1 && i!=0)?m2--,t=1:t;
/*
		if (i%n==n2-1 && i/n==m2-1)
		{
			m1++;
			t=-1;
		}
		if (i/n==m2-1 && i%n==n1)
		{
			n2--;
			t=-n;
		}
		if (i%n==n1 && i/n==m1 && i!=0)
		{    
			m2--;
			t=1;
		}
*/
		for (int t1=t,j=i+t,n3=n1,n4=n2,m3=m1,m4=m2;m3<m4 && n3<n4;j+=t1)
		{
/*
			if (j/n==m3 && j%n==n4-1)
			{
				if (j/n) n3++;
				t1=n;
			}
*/
			(j/n==m3 && j%n==n4-1)?t1=n,(j/n)?n3++:n3:t1;
			(j%n==n4-1 && j/n==m4-1)?t1=-1,m3++:t1;
			(j/n==m4-1 && j%n==n3)?n4--,t1=-n:t1;
			(j%n==n3 && j/n==m3 && j!=0)?m4--,t1=1:t1  ;
/*			
			if (j%n==n4-1 && j/n==m4-1)
			{
				m3++;
				t1=-1;
			}
			if (j/n==m4-1 && j%n==n3)
			{
				n4--;
				t1=-n;
			}
			if (j%n==n3 && j/n==m3 && j!=0)
			{
				m4--;
				t1=1;
			}
*/
			if (a[i/n][i%n]>a[j/n][j%n])
			{
				int temp=a[i/n][i%n];
				a[i/n][i%n]=a[j/n][j%n];
				a[j/n][j%n]=temp;
			}
		}
					
	}
}


void ziczac(int a[][100],int m,int n)
{
/*
	int k,l;
	for (int i=0;i<m*n;i++)
	{		
		k=(i/n%2)?n-1-i%n:i%n;
		for (int j=i+1;j<m*n;j++)
		{
			l=(j/n%2)?n-1-j%n:j%n;
			if (a[i/n][k]>a[j/n][l])
			{
				int temp=a[i/n][k];
				a[i/n][k]=a[j/n][l];
				a[j/n][l]=temp;
			}
		}
	}
*/
	for (int i=0,flag=0,t=1,d=0;d<m*n;d++,i=oketiep(a,m,n,i,flag,t))
		for (int flag1=flag,t1=t,j=oketiep(a,m,n,i,flag1,t1),d1=d+1;d1<m*n;j=oketiep(a,m,n,j,flag1,t1),d1++)
			if (a[i/n][i%n]>a[j/n][j%n])
			{
				int temp=a[i/n][i%n];
				a[i/n][i%n]=a[j/n][j%n];
				a[j/n][j%n]=temp;
			}		
}
void taomangchanle(int a[],int n,int b[],int &m)
{
	if (n<=0)
	{
		b[0]=0;
		b[1]=1;
		m=2;
	}
	else
		if (n==1)
		{
			b[0]=a[0];
			b[1]=1-abs(b[0]%2);
			m=2;
		}
		else
		{
			m=0;
			for (int i=0;i<n-1;i++)
			{
				b[m]=a[i];
				m++;
				if ((a[i]+a[i+1])%2==0)
				{
					b[m]=1-abs(a[i]%2);
					m++;
				}
			}
			b[m]=a[n-1];
			m++;
		}
}
void thembaotoan(int a[],int &n,int x)
{
	for (int i=n-1;a[i]>x && i>=0;i--)
		a[i+1]=a[i];
	a[i+1]=x;
	n++;
}
void chantang(int a[],int n)
{
	for (int i=0;i<n;i++)
		for (int j=i+1;j<n;j++)
			if ((a[i]-a[j])%2==0 && a[i]>a[j])
			{
				int temp=a[i];
				a[i]=a[j];
				a[j]=temp;
			}
}
void tangdan(int a[],int n)
{
	for (int i=0;i<n;i++)
		for (int j=i+1;j<n;j++)
			if (a[i]>a[j])
			{
				int temp=a[i];
				a[i]=a[j];
				a[j]=temp;
			}
}
void tronmang(int a[],int n,int b[],int m,int c[],int &k)
{
	k=m+n;
/*	int i=n-1,j=m-1;
	while (i>=0 && j>=0)
		if (a[i]<b[j])
		{
			c[k-i-j-2]=b[j];
			j--;
		}
		else
		{
			c[k-i-j-2]=a[i];
			i--;
		}
	for (;i>=0;i--)
		c[k-i-j-2]=a[i];
	for (;j>=0;j--)
		c[k-i-j-2]=b[j];
*/
	int i=0,j=0;
	while (i<n && j<m)
		if (a[i]>b[j])
		{
			c[i+j]=b[j];
			j++;
		}
		else
		{
			c[i+j]=a[i];
			i++;
		}
	for (;i<n;i++)
		c[i+j]=a[i];
	for (;j<m;j++)
		c[i+j]=b[j];
	
}

void chantangamgiam(int a[],int n)
{
	for (int i=0;i<n;i++)
		for (int j=1+i;j<n;j++)
			if (a[i]*a[j]>0 && abs(a[i])>abs(a[j]))
			{
				int temp=a[i];
				a[i]=a[j];
				a[j]=temp;
			}
}

