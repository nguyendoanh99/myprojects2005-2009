#include "NVCongNhat.h"

NVCongNhat::NVCongNhat(char *str, int iLuongGio, int iSoGio) : NhanVien(str)
{
	GanLuongGio(iLuongGio);
	GanSoGio(iSoGio);
}

NVCongNhat::~NVCongNhat()
{
}

void NVCongNhat::GanLuongGio(int iLuongGio)
{
	if (iLuongGio > 0)
		m_iLuongGio = iLuongGio;
	else 
		m_iLuongGio = 0;
}

int NVCongNhat::DocLuongGio() const
{
	return m_iLuongGio;
}

void NVCongNhat::GanSoGio(int iSoGio)
{
	if (iSoGio > 0)
		m_iSoGio = iSoGio;
	else
		m_iSoGio = 0;
}

int NVCongNhat::DocSoGio() const
{
	return m_iSoGio;
}

int NVCongNhat::TinhLuong() const
{
	return m_iSoGio * m_iLuongGio;
}

std::string NVCongNhat::InBCC() const
{
	char s[10];

	return NhanVien::InBCC() + "\nSo gio: " + std::string(itoa(m_iSoGio, s, 10)) 
		+ " \nLuong gio: " + std::string(itoa(m_iLuongGio, s, 10)) + "\nLuong linh: " + std::string(itoa(TinhLuong(), s, 10));
}

int NVCongNhat::LoaiNV() const
{
	return NV_CONG_NHAT;
}

ostream& operator << (ostream& os, const NVCongNhat& P)
{
	os << NV_CONG_NHAT << " ";
	os << P.DocTen() << endl;
	os << P.DocLuongGio() << " " << P.DocSoGio() << endl;

	return os;
}

istream& operator >> (istream& is, NVCongNhat& P)
{
	char s[50];
	int t;

	is.ignore(1);
	is.getline(s, 50);
	P.GanTen(s);

	is >> t; // Doc luong gio
	P.GanLuongGio(t);

	is >> t; // Doc so gio
	P.GanSoGio(t);

	return is;
}