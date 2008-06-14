#include <iostream>

#include "LLoaiPhong.h"

LLoaiPhong::~LLoaiPhong()
{}

LLoaiPhong::LLoaiPhong(int iSoNgay)
{
	GanSoNgay(iSoNgay);
}

int LLoaiPhong::DocSoNgay()
{
	return m_iSoNgay;
}

int LLoaiPhong::GanSoNgay(int iSoNgay)
{
	if (iSoNgay > 0)
	{
		m_iSoNgay = iSoNgay;
		return 1;
	}
	m_iSoNgay = 1;
	return 0;
}

void LLoaiPhong::Nhap()
{
	int iSoNgay;
	do
	{
		cout << "Nhap so ngay thue : ";
		cin >> iSoNgay;
	}
	while (GanSoNgay(iSoNgay) == 0);
}

string LLoaiPhong::Xuat()
{
	char s[10];
	return "So ngay thue : " + string(itoa(m_iSoNgay, s, 10)) + " ngay";
}
