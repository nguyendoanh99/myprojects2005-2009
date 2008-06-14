#include "LThongTin.h"
#include <iostream>
using namespace std;
LThongTin::LThongTin(string strTen, string strNgayTao)
{
	m_strTen = strTen;
	m_strNgayTao = strNgayTao;
}
LThongTin::~LThongTin()
{
}

string LThongTin::DocNgayTao()
{
	return m_strNgayTao;
}

string LThongTin::DocTen()
{
	return m_strTen;
}

void LThongTin::Nhap(int iCap)
{
	char s[255];
	string str;

	for (int i = 0; i < iCap; ++i)
		str += "\t";

	cout << str << "Nhap ten: ";
	cin.ignore(1);
	cin.getline(s, 255);
	m_strTen = s;

	cout << str << "Nhap ngay khoi tao: ";
//	cin.ignore(1);
	cin.getline(s, 25);
	
	m_strNgayTao = s;
}

string LThongTin::Xuat(int iCap)
{
	string kq;
	for (int i = 0; i < iCap; ++i)
		kq += "\t";

	return kq + m_strTen + " (" + m_strNgayTao + ")";
}