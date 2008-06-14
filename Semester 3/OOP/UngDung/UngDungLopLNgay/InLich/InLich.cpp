#include "LNgay.h"
#include <iostream.h>

void InLich(int ,int);

void main()
{
	int th, nm;

	cout<<"Nhap thang: ";
	cin>>th;
	cout<<"Nhap nam: ";
	cin>>nm;

	InLich(th, nm);
}

void InLich(int th, int nm)
{
	static int SoNgay[]={0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
	LNgay ngay;
	ngay.KhoiDong(1, th, nm);
	if (ngay.LaNamNhuan())
		SoNgay[2] = 29;	
	
	cout<<"\t\t\tLich thang: "<<th<<"/"<<nm<<endl;
	cout<<"\tHai"<<"\t"<<"Ba"<<"\t"<<"Tu"<<"\t"
		<<"Nam"<<"\t"<<"Sau"<<"\t"<<"Bay"<<"\t"<<"Chu Nhat";
	cout<<endl<<"\t";

	int d = ngay.LaThu() - 2;
	
	for (int j = 0; j < d; ++j)
		cout<<"\t";

	for (int i = 1; i <= SoNgay[th]; ++i)
	{		
		cout<<i<<"\t";

		++d;
		if (d % 7 == 0)
		{
			d = 0;
			cout<<endl<<"\t";
		}
	}

	SoNgay[2] = 28;
}
