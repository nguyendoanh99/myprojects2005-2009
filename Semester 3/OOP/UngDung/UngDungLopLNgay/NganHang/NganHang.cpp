#include "LNgay.h"
#include <iostream.h>

#define LAI_SUAT 0.02

LNgay NgayRutTien(LNgay&, double, double);
double TinhTienLai(LNgay&, double, LNgay&);

void main()
{
	LNgay NG, NR;
	double dST, dX;

	cout<<"Nhap ngay goi tien:"<<endl;
	NG.Nhap();
	cout<<"\nNhap so tien goi: ";
	cin>>dST;
	cout<<"\nNhap so tien muon lai: ";
	cin>>dX;
	cout<<"\nNgay can rut tien la ngay:";

	LNgay kq = NgayRutTien(NG,dST,dX);
	kq.In();

	cout<<"\n\nNhap ngay rut tien:"<<endl;
	NR.Nhap();
	cout<<"\nSo tien lai la: "<<TinhTienLai(NG,dST,NR);
}

LNgay NgayRutTien(LNgay &NG, double dST, double dX)
{
	double dTongTien = dST;
	int iNgay = 0;

	while (dTongTien - dST < dX)
	{
		++iNgay;
		dTongTien += dTongTien*LAI_SUAT;
	}
	
	return NG.NgayTL(iNgay);	
}

double TinhTienLai(LNgay &NG, double dST, LNgay &NR)
{
	int iKhoangCach = NG.KhoangCach(NR);
	double dTongTien = dST;

	while (iKhoangCach > 0)
	{
		dTongTien += dTongTien*LAI_SUAT;
		--iKhoangCach;
	}

	return dTongTien-dST;
}