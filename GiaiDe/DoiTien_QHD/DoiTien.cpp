#include <iostream.h>
const int n=4;
const int L=42;
int A[n]={1,2,3,5};
int F[100];
short Luu[100];
int Loai[n]={0};

void ThucHien();
void Xuat();

void main()
{
	ThucHien();
	cout<<F[L]<<endl;
	Xuat();
	for (int i=1;i<=L;++i)
		cout<<"F["<<i<<"] = "<<F[i]<<endl;
}

void ThucHien()
{
	for (int i=01;i<=L;++i)
		F[i]=L+1;
	for (i=0;i<n;++i)
	{
		F[A[i]]=1;
		Luu[A[i]]=i;
	}

	for (i=01;i<=L;++i)
		if (F[i]!=1)
		{
			for (int j=0;j<n;++j)
				if (i>A[j])				
					if (F[i]>F[i-A[j]])
					{
						F[i]=F[i-A[j]]+1;
						Luu[i]=j;
					}
		}
}

void Xuat()
{
	int temp=L;
	while (temp)
	{
		++Loai[Luu[temp]];
		temp-=A[Luu[temp]];
	}
	for (int i=0;i<n;++i)
		cout<<"Loai "<<A[i]<<"d co "<<Loai[i]<<endl;
}