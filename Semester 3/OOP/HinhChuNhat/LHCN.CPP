#include "LHCN.h"
#include <stdlib.h>
#include <iostream.h>

LHCN::LHCN(int iX, int iY, int iRong, int iDai, int iMau)
{
	// Ep iX ve gia tri co nghia
	iX = __max(iX, 0);
	if (iRong >= 1 && iRong <= 79)
		iX = __min(iX, 79 - iRong);
	else
		iX = __min(iX, 79);
	// Ep iX ve gia tri co nghia
	iY = __max(iY, 0);
	if (iDai >= 1 && iDai <=24)
		iY = __min(iY, 25 - iDai);
	else
		iY = __min(iY, 24);

	mGoc.GanXY(iX,  iY);
	mGoc.GanMau(iMau);
	
	GanRong(iRong);
	GanDai(iDai);	
}

LHCN::LHCN(const LDiem& Goc, int iRong, int iDai) : mGoc(Goc)
{	
	GanRong(iRong);
	GanDai(iDai);	
}

LHCN::LHCN(const LDiem& Diem1, const LDiem& Diem2) : mGoc(Diem1)
{
	// Lay diem tren trai
	if (!(Diem1.DocX() >= Diem2.DocY() && Diem1.DocY() >= Diem2.DocY()))
	{
		mGoc.GanXY(Diem2.DocX(), Diem2.DocY());
		mGoc.GanMau(Diem2.DocMau());
	}

	GanRong(abs(Diem1.DocX() - Diem2.DocX()));
	GanDai(abs(Diem1.DocY() - Diem2.DocY()));	
}

LHCN::LHCN(const LHCN& P) : mGoc(P.mGoc)
{	
	mRong = P.mRong;
	mDai = P.mDai;	
}

int LHCN::DocX() const
{
	return mGoc.DocX();
}

int LHCN::DocY() const
{
	return mGoc.DocY();
}

int LHCN::DocRong() const
{
	return mRong;
}

int LHCN::DocDai() const 
{
	return mDai;
}

int LHCN::DocMau() const
{
	return mGoc.DocMau();
}

LDiem LHCN::DocGoc() const
{
	return mGoc;
}
void LHCN::GanX(int iX)
{
	// Ep iX ve gia tri co nghia
	iX = __max(iX, 0);
	iX = __min(iX, 80 - mRong);
	mGoc.GanX(iX);
}

void LHCN::GanY(int iY)
{
	// Ep iX ve gia tri co nghia
	iY = __max(iY, 0);
	iY = __min(iY, 24 - mDai);
	mGoc.GanY(iY);
}

void LHCN::GanXY(int iX, int iY)
{
	GanX(iX);
	GanY(iY);
}

void LHCN::GanGoc(const LDiem &P)
{
	GanX(P.DocX());
	GanY(P.DocY());
}

void LHCN::GanMau(int iMau)
{
	mGoc.GanMau(iMau);
}

void LHCN::GanRong(int iRong)
{
	mRong = __max(iRong, 1);
	mRong = __min(mRong, 79 - mGoc.DocX());
}

void LHCN::GanDai(int iDai)
{
	mDai = __max(iDai, 1);
	mDai = __min(mDai, 24 - mGoc.DocY());
}

void LHCN::In() const
{
	LDiem Ve1(mGoc);
	LDiem Ve2(' ', mGoc.DocX() + mRong, mGoc.DocY() + mDai, mGoc.DocMau());

	// Ve diem tren trai
	Ve1.GanKyTu(218);
	Ve1.In();
	// Ve diem duoi phai
	Ve2.GanKyTu(217);	
	Ve2.In();	
	
	Ve1.GanKyTu(196);
	Ve2.GanKyTu(196);	
	for (int i = 1; i < mRong; ++i)
	{
		// Ve duong ngang nam tren
		Ve1.DichPhai();
		Ve1.In();
		// Ve duong ngang nam duoi
		Ve2.DichTrai();
		Ve2.In();
	}

	// Ve diem tren phai
	Ve1.GanKyTu(191);
	Ve1.DichPhai();
	Ve1.In();
	// Ve diem duoi trai
	Ve2.GanKyTu(192);
	Ve2.DichTrai();
	Ve2.In();

	Ve1.GanKyTu(179);
	Ve2.GanKyTu(179);
	for (i = 1; i < mDai; ++i)
	{
		// Ve duong doc ben phai
		Ve1.DichXuong();
		Ve1.In();
		// Ve duong doc ben trai
		Ve2.DichLen();
		Ve2.In();
	}	
}

void LHCN::Xoa() const
{ 
	LDiem Ve1(mGoc);
	LDiem Ve2(' ', mGoc.DocX() + mRong, mGoc.DocY() + mDai, mGoc.DocMau());
	
	// Xoa diem tren trai	
	Ve1.Xoa();
	// Xoa diem duoi phai	
	Ve2.Xoa();		
	
	for (int i = 0; i < mRong; ++i)
	{
		// Xoa duong ngang nam tren
		Ve1.DichPhai();
		Ve1.Xoa();
		// Ve duong ngang nam duoi
		Ve2.DichTrai();
		Ve2.Xoa();
	}	
	
	for (i = 1; i < mDai; ++i)
	{
		// Xoa duong doc ben phai
		Ve1.DichXuong();
		Ve1.Xoa();
		// Xoa duong doc ben trai
		Ve2.DichLen();
		Ve2.Xoa();
	}
}

void LHCN::DichLen(int d)
{
	mGoc.DichLen(d);	
}

void LHCN::DichXuong(int d)
{
	if (mGoc.DocY() + mDai + d < 25)
		mGoc.DichXuong(d);
}

void LHCN::DichTrai(int d)
{
	mGoc.DichTrai(d);
}

void LHCN::DichPhai(int d)
{
	if (mGoc.DocX() + mRong + d < 80)
		mGoc.DichPhai(d);
}