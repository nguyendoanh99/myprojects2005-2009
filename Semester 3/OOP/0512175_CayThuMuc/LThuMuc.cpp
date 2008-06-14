#include <iostream>
#include "LThuMuc.h"
#include "LTapTin.h"
using namespace std;
LThuMuc::LThuMuc(const std::string &strTen, const std::string &strNgayTao) : LThongTin(strTen, strNgayTao)
{
}
int LThuMuc::DocKichThuoc()
{
	int kq = 0;
	for (int i = 0; i < m_arrNoiDung.size(); ++i)
		kq += m_arrNoiDung[i]->DocKichThuoc();
	return kq;
}

LThuMuc::~LThuMuc()
{	
	for (int i = 0; i < m_arrNoiDung.size(); ++i)
	{
		cout << "~ " << m_arrNoiDung[i]->DocTen() << endl;
		delete m_arrNoiDung[i];
	}
}

void LThuMuc::Them(LThongTin* t)
{
	m_arrNoiDung.push_back(t);
}
/*
LThongTin* LThuMuc::TimKiem(std::string strTen,int iLoai)
{
	// Tim kiem thu muc (hoac tap tin) trong thu muc hien hanh
	for (int i = 0; i < m_arrNoiDung.size(); ++i)
	{
		if (ThuMuc[i]->LayLoai() == Loai && m_arrNoiDung[i]->DocTen() == strTen)
		{
			return m_arrNoiDung[i];
		}
	}
	// Tim kiem thu muc (hoac tap tin) trong cac thu muc con cua thu muc hien hanh
	for (i = 0; i < m_arrNoiDung.size(); ++i)
		if (ThuMuc[i]->LayLoai() == THUMUC)
		
	
}
*/
void LThuMuc::Nhap(int iCap)
{
	int iChon;
	LThongTin *t;
	LThongTin::Nhap(iCap);
	string str;

	for (int i = 0; i < iCap; ++i)
		str += "\t";
	
	do
	{
		cout << endl << str << "Thu muc hien hanh \"" << DocTen() << "\"" << endl;
		cout << str << "1. Them thu muc " << endl;
		cout << str << "2. Them tap tin " << endl;
		cout << str << "0. Thoat" << endl;
		cout << str << "-------------> Chon: ";
		cin >> iChon;
		switch (iChon)
		{
		case 1:			
			t = new LThuMuc();
			break;
		case 2:			
			t = new LTapTin();				
			break;
		default:
			continue;			
		}

		t->Nhap(iCap + 1);
		Them(t);
	}
	while (iChon != 0);
}

int LThuMuc::LayLoai()
{
	return THUMUC;
}

void LThuMuc::ThongKe(int &iSoThuMuc, int &iSoTapTin)
{	
	for (int i = 0; i < m_arrNoiDung.size(); ++i)
	{
		switch (m_arrNoiDung[i]->LayLoai())
		{
		case TAPTIN:
			++iSoTapTin;
			break;

		case THUMUC:		
			++iSoThuMuc;
			
			LThuMuc *t = (LThuMuc*) m_arrNoiDung[i];
			t->ThongKe(iSoThuMuc, iSoTapTin);
			break;
		}		
	}
}

string LThuMuc::Xuat(int iCap)
{
	char s[10];

	string kq = LThongTin::Xuat(iCap) + " (" + string(itoa(DocKichThuoc(), s, 10)) + " bytes)";
		
	// Xuat thu muc 
	for (int i = 0; i < m_arrNoiDung.size(); ++i)
		if (m_arrNoiDung[i]->LayLoai() == THUMUC)
			kq += "\n" + m_arrNoiDung[i]->Xuat(iCap + 1);
	// Xuat tap tin
	for (i = 0; i < m_arrNoiDung.size(); ++i)
		if (m_arrNoiDung[i]->LayLoai() == TAPTIN)
			kq += "\n" + m_arrNoiDung[i]->Xuat(iCap + 1);
	return kq;
}