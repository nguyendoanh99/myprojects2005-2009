#include "LNgay.h"
#include "stdlib.h"
#include "iostream.h"
void LNgay::KhoiDong(const LNgay& a)
{
	mNgay=a.mNgay;
	mThang=a.mThang;
	mNam=a.mNam;
}

void LNgay::KhoiDong(int ngay,int thang,int nam)
{
	static int SoNgay[]={0,31,28,31,30,31,30,31,31,30,31,30,31};
	mNam=__max(1,nam);
	mThang=__max(1,thang);
	mThang=__min(mThang,12);
	if (this->LaNamNhuan())
		SoNgay[2]=29;
	mNgay=__max(1,ngay);
	mNgay=__min(mNgay,SoNgay[mThang]);
	SoNgay[2]=28;
}

int LNgay::TuDauNam()
{
	static int SoNgay[]={0,31,28,31,30,31,30,31,31,30,31,30,31};
	if (this->LaNamNhuan())
		SoNgay[2]=29;
	int TongNgay=mNgay;
	for (int i=1;i<mThang;++i)
		TongNgay+=SoNgay[i];	
	SoNgay[2]=28;
	return TongNgay;
}

long LNgay::TuDauCN()
{
	long TongNgay=TuDauNam()-1;
	LNgay tam;
	for (int i=1;i<mNam;++i)
	{
		tam.GanNam(i);
		if (tam.LaNamNhuan())
			TongNgay+=366;
		else
			TongNgay+=365;
	}
	return TongNgay;
}

long LNgay::KhoangCach(LNgay& a)
{
	LNgay x,y;
	if (this->SoSanh(a)<0)
	{
		x.KhoiDong(*this);
		y.KhoiDong(a);
	}
	else
	{
		x.KhoiDong(a);
		y.KhoiDong(*this);
	}
	int d1=x.TuDauNam();
	int d2=y.TuDauNam();
	long d3=0;
	LNgay tam;
	for (int i=x.mNam;i<y.mNam;++i)
	{
		tam.GanNam(i);
		if (tam.LaNamNhuan())
			d3+=366;
		else
			d3+=365;
	}
	return d3-d1+d2;
}

int LNgay::LaThu()
{
	LNgay x;
	x.KhoiDong(1,1,1900);
	long kc=KhoangCach(x);
	int t=(kc%7)+2;
	return t;
}

LNgay LNgay::NgayTL(unsigned x)
{
	LNgay kq;
	static int SoNgay[]={0,31,28,31,30,31,30,31,31,30,31,30,31};
	kq.KhoiDong(*this);
	if (this->LaNamNhuan())
		SoNgay[2]=29;
	kq.mNgay+=x;
	while (kq.mNgay>SoNgay[kq.mThang])
	{
		kq.mNgay-=SoNgay[kq.mThang];
		++kq.mThang;
		if (kq.mThang>12)
		{
			++kq.mNam;
			if (kq.LaNamNhuan())
				SoNgay[2]=29;
			else 
				SoNgay[2]=28;
			kq.mThang=1;
		}		
	}
	SoNgay[2]=28;
	return kq;
}

LNgay LNgay::NgayQK(unsigned x)
{
	LNgay kq;
	static int SoNgay[]={0,31,28,31,30,31,30,31,31,30,31,30,31};
	kq.KhoiDong(*this);
	if (this->LaNamNhuan())
		SoNgay[2]=29;
	kq.mNgay-=x;
	while (kq.mNgay<=0)
	{
		--kq.mThang; 		
		if (kq.mThang<1)
		{
			--kq.mNam;
			if (kq.LaNamNhuan())
				SoNgay[2]=29;
			else 
				SoNgay[2]=28;
			kq.mThang=12;
		}		
		kq.mNgay+=SoNgay[kq.mThang];		
	}
	SoNgay[2]=28;
	return kq;
}

void LNgay::In()
{
	cout<<"Ngay "<<mNgay<<" thang "<<mThang<<" nam "<<mNam;
}

int LNgay::DocNgay()
{
	return mNgay;
}

int LNgay::DocThang()
{
	return mThang;
}

int LNgay::DocNam()
{
	return mNam;
}

void LNgay::GanNgay(int x)
{
	static int SoNgay[]={0,31,28,31,30,31,30,31,31,30,31,30,31};	
	if (this->LaNamNhuan())
		SoNgay[2]=29;
	if (x>=1 && x<=SoNgay[mThang])
		mNgay=x;
	SoNgay[2]=28;
}

void LNgay::GanThang(int x)
{
	if (x>=1 && x<=12)
		mThang=x;
}

void LNgay::GanNam(int x)
{
	if (x>=1)
		mNam=x;
}

int LNgay::LaNamNhuan()
{
	return (mNam%400==0)||((mNam%4==0)&&(mNam%100!=0));
}

void LNgay::Nhap()
{
	int iNgay, iThang, iNam;

	cout<<"Nhap ngay: ";
	cin>>iNgay;
	cout<<"Nhap thang: ";
	cin>>iThang;
	cout<<"Nhap nam: ";
	cin>>iNam;
	KhoiDong(iNgay, iThang, iNam);
}

int LNgay::SoSanh(const LNgay& a)
{
		if (mNam>a.mNam)
			return 1;
		if (mNam<a.mNam)
			return -1;
		if (mThang>a.mThang)
			return 1;
		if (mThang<a.mThang)
			return -1;
		if (mNgay>a.mNgay)
			return 1;
		if (mNgay<a.mNgay)
			return -1;
		return 0;
	}