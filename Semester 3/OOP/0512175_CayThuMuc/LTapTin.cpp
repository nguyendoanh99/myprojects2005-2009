#include "LTapTin.h"
#include <iostream>
using namespace std;
LTapTin::LTapTin(std::string strTen, std::string strNgayTao) : LThongTin(strTen, strNgayTao)
{
}

LTapTin::LTapTin(std::string strTen, std::string strNgayTao, std::string strNoiDung) : LThongTin(strTen, strNgayTao)
{
	m_strNoiDung = strNoiDung;
}

LTapTin::~LTapTin()
{
}

int LTapTin::DocKichThuoc()
{
	return m_strNoiDung.length();
}

void LTapTin::Nhap(int iCap)
{
	char s[255];
	string str;

	for (int i = 0; i < iCap; ++i)
		str += "\t";

	LThongTin::Nhap(iCap);

	cout << str << "Nhap noi dung tap tin : " << endl;
	cout << str;
	cin.ignore(1);	
	cin.getline(s, 255);
	m_strNoiDung = s;
}

int LTapTin::LayLoai()
{
	return TAPTIN;
}

string LTapTin::Xuat(int iCap)
{
	char s[10];
	
	return LThongTin::Xuat(iCap) + ".txt (" + string(itoa(DocKichThuoc(), s, 10)) + " bytes)";
}