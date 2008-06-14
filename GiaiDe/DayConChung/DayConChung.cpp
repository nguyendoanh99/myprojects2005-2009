#include <iostream.h>
#include <stdio.h>
#include <string.h>

const int max=15;
int *S1;
int *S2;
int L1,L2;
int *A[max]={NULL};
int B[max];
int kq[max];
int temp[max];
int lkq,ltemp=0;
int t;

void input();
void LapBang();
void xuat(int [],int);
void Try(int,int);
int tim(int[],int,int);

void main()
{
	input();
	xuat(S1,L1);
	xuat(S2,L2);
	LapBang();
/*	for (int i=0;i<L2;++i)
	{
		for (int j=0;j<B[i];++j)
			cout<<A[i][j]<<" ";
		cout<<endl;
	}
*/	Try(0,-1);
	cout<<endl;
	for (int i=0;i<lkq;++i)
		cout<<kq[i]<<" ";
	
	delete []S1;
	delete []S2;	
	for (i=L2-1;i>=0;--i)		
			delete []A[i];
}

int tim(int a[],int n,int d)
{
	for (int i=0;i<n;++i)
		if (a[i]>d)
			return a[i];
	return d;
}
void Try(int d,int n)
{
	for (int i=d;i<L2;++i)
	{
		if (L2-i+ltemp>lkq)
		{
			t=tim(A[i],B[i],n);
			if (t>n)
			{
				temp[ltemp++]=S2[i];
				Try(i+1,t);
				--ltemp;
			}
		}
		else
			return;
	}
	if (lkq<ltemp)
	{
		memcpy(kq,temp,sizeof(temp[0])*ltemp);
		lkq=ltemp;		
	}
}
void xuat(int a[],int n)
{
	for (int i=0;i<n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}

void LapBang()
{
	int *temp=new int[L1];
	int d;
	for (int i=0;i<L2;++i)
	{
		for (int j=i-1;j>=0;--j)
			if (S2[i]==S2[j])
			{
				if (B[j]<=1)
				{
					B[i]=0;
					break;
				}
				else
				{
					B[i]=B[j]-1;
					A[i]=new int[B[i]];
					memcpy(A[i],A[j]+1,sizeof(A[j][0])*B[i]);
					break;
				}
			}
		if (j<0)
		{
			d=0;
			for (int k=0;k<L1;++k)
				if (S1[k]==S2[i])
					temp[d++]=k;
			if (d>0)
			{
				A[i]=new int[d];
				memcpy(A[i],temp,sizeof(temp[0])*d);			
				B[i]=d;
			}
		}
	}
	delete temp;
}

void input()
{
	FILE *fp=fopen("DayConChung.inp","rt");
	fscanf(fp,"%d",&L1);
	S1=new int[L1];
	for (int i=0;i<L1;++i)
		fscanf(fp,"%d",&S1[i]);
	fscanf(fp,"%d",&L2);
	S2=new int[L2];
	for (i=0;i<L2;++i)
		fscanf(fp,"%d",&S2[i]);
	if (L1<L2)
	{
		int *temp=S1;
		S1=S2;
		S2=temp;
		int t=L1;
		L1=L2;
		L2=t;
	}
	fclose(fp);
}