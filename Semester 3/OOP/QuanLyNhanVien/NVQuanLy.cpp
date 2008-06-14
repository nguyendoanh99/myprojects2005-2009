#include "NVQuanLy.h"

NVQuanLy::NVQuanLy(char *str, int iLuongThang) : NhanVien(str)
{
	GanLuongThang(iLuongThang);
}

NVQuanLy::~NVQuanLy()
{
}

void NVQuanLy::GanLuongThang(int iLuongThang)
{
	if (iLuongThang > 0)
		m_iLuongThang = iLuongThang;
	else
		m_iLuongThang = 0;
}

int NVQuanLy::DocLuongThang() const
{
	return m_iLuongThang;
}

int NVQuanLy::TinhLuong() const
{
	return m_iLuongThang;
}

std::string NVQuanLy::InBCC() const
{
	char s[10];
	return NhanVien::InBCC() + "\nLuong thang: " + std::string(itoa(m_iLuongThang, s, 10)) 
		+ "\nLuong linh: " + std::string(itoa(TinhLuong(), s, 10));
}

int NVQuanLy::LoaiNV() const
{
	return NV_QUAN_LY;
}

ostream& operator << (ostream& os, const NVQuanLy& P)
{
	os << NV_QUAN_LY << " ";
	os << P.DocTen() << endl;
	os << P.DocLuongThang() << endl;

	return os;
}

istream& operator >> (istream& is, NVQuanLy& P)
{
	char s[50];
	int t;

	is.ignore(1);
	is.getline(s, 50);
	P.GanTen(s);

	is >> t; // Doc luong thang
	P.GanLuongThang(t);

	return is;
}