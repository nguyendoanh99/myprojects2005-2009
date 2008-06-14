#include <iostream.h>
#include <string.h>
#include <stdio.h>

const int maxn=10;

int *x;
int *y;
int nx,ny;

int *a[maxn];
int b[maxn];
int *kq;
int *temp;
int nkq=0,ntemp=0;
int k;

void LapBang();
void Input();
void Try(int ,int);
int tim(int [],int,int);
void xuat(int [],int);

void main()
{
	Input();
	LapBang();
	xuat(x,nx);
	xuat(y,ny);
	cout<<endl;
	for (int j=0;j<ny;++j)
	{
		xuat(a[j],b[j]);
	}
	kq=new int[ny+1];
	temp=new int[ny+1];
	Try(0,nx+1);
	xuat(kq,nkq);
	delete []kq;
	delete []temp;
	delete []x;
	delete []y;
	for (int i=0;i<ny;++i)
		delete []a[i];
}

void xuat(int a[],int n)
{
	for (int i=0;i<n;++i)
		cout<<a[i]<<" ";
	cout<<endl;
}

int tim(int a[],int n,int t)
{
	for (int i=0;i<n;++i)
		if (a[i]>t)
			return a[i];
	return t;
}

void Try(int i,int t)
{	
	for (int j=i;j<=ny;++j)
	{		
		if (i==0)
		{
			temp[ntemp++]=y[j];
			for (int p=0;p<b[j];++p)
				Try(j+1,a[j][p]);
			--ntemp;
		}
		else
		{
			if (ntemp+(ny-j)<nkq)
				break;
			k=tim(a[j],b[j],t);
			if (k-t==1)
			{
				temp[ntemp++]=y[j];
				Try(i+1,k);
				--ntemp;
			}
			else
			{
				if (ntemp>nkq)
				{
					nkq=ntemp;
					memcpy(kq,temp,sizeof(temp[0])*ntemp);
				}
			}		
			break;
		}
	}
}

void Input()
{
	FILE *fp=fopen("DayConChung.inp","rt");
	fscanf(fp,"%d",&nx);
	x=new int[nx];
	for (int i=0;i<nx;++i)
		fscanf(fp,"%d",&x[i]);
	fscanf(fp,"%d",&ny);
	y=new int[ny];
	for (i=0;i<ny;++i)
		fscanf(fp,"%d",&y[i]);
	if (ny>nx)
	{
		int temp=ny;
		ny=nx;
		nx=temp;
		int *t=x;
		x=y;
		y=t;
	}
}

void LapBang()
{
	int *temp=new int[ny+1];	
	for (int i=0;i<ny;++i)
	{
		int k=0;
		for (int j=i-1;j>=0;--j)
			if (y[i]==y[j])
			{
				b[i]=b[j]-1;
				if (b[i]>0)		
				{							
					a[i]=new int[b[i]];
					memcpy(a[i],a[j]+1,sizeof(a[j][0])*(b[i]));
				}
				k=1;
				break;
			}
		if (k==0)
		{
			b[i]=0;
			for (int j=0;j<nx;++j)
				if(y[i]==x[j])			
					temp[b[i]++]=j;			
			if (b[i]>0)
			{
				a[i]=new int[b[i]];				
				memcpy(a[i],temp,sizeof(temp[0])*b[i]);
			}
		}
	}
	delete []temp;
}