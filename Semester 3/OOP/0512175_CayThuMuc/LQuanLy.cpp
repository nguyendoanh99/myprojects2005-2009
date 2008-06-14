#include "LQuanLy.h"
#include "LTapTin.h"

#include <iostream>
using namespace std;

LQuanLy::LQuanLy() //: m_NoiDung(string("\"), string("20/12/2006"))
{
}
LQuanLy::~LQuanLy()
{
}
void LQuanLy::Nhap()
{
}
void LQuanLy::Xuat()
{
	cout << m_NoiDung.Xuat(0);
}

void LQuanLy::ThemTapTin()
{
//	cout << "Nhap thong tin cua tap tin can them:" << endl;
	LThongTin * t = new LTapTin;
	t->Nhap(0);
	m_NoiDung.Them(t);	
}

void LQuanLy::ThemThuMuc()
{
//	cout << "Nhap thong tin cua thu muc can them:" << endl;
	LThongTin * t = new LThuMuc;
	t->Nhap(0);
	m_NoiDung.Them(t);	
}

int LQuanLy::LuaChon()
{
	int iChon;
	cout << "1. Them thu muc tai vi tri goc " << endl;
	cout << "2. Them tap tin tai vi tri goc " << endl;
	cout << "3. Xuat cay thu muc: " << endl;
	cout << "4. Thong ke: " << endl;
	cout << "0. Thoat. " <<endl;
	cout << "------> Chon: ";
	cin >> iChon;
	
	switch (iChon)
	{
	case 2:
		ThemTapTin();
		break;
	case 1:
		ThemThuMuc();
		break;
	case 3:
		Xuat();
		break;
	case 4:
//		ThongKe();
		break;
	}
	return iChon;
}
/*
LThongTin* TimKiem(string strTenThuMuc, const LThuMuc &ThuMuc)
{
	// Tim kiem thu muc trong thu muc chi dinh
	for (int i = 0; i < ThuMuc.size(); ++i)
	{
		if (ThuMuc[i]->LayLoai() == THUMUC && ThuMuc[i]->DocTen() == strTenThuMuc)
		{
			return ThuMuc[i];
		}
	}
	// Tim kiem thu muc trong cac thu muc con trong thu muc chi dinh 
	for (i = 0; i < ThuMuc.size(); ++i)
		if (ThuMuc[i]->LayLoai() == THUMUC)
		
		
}

void LQuanLy::ThongKe(string strTenThuMuc, int &iSoThuMuc, int &iSoTapTin)
{
	for (int i = 0; i <	
}
*/