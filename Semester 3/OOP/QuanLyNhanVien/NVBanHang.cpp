#include "NVBanHang.h"

NVBanHang::NVBanHang(char *str,int iLuongGio, int iSoGio, int iHueHong, int iSanPham) : NVCongNhat(str, iLuongGio, iSoGio)
{
	GanHueHong(iHueHong);
	GanSanPham(iSanPham);
}

NVBanHang::~NVBanHang()
{
}

void NVBanHang::GanHueHong(int iHueHong)
{
	if (iHueHong > 0)
		m_iHueHong = iHueHong;
	else
		m_iHueHong = 0;
}

int NVBanHang::DocHueHong() const 
{
	return m_iHueHong;
}

void NVBanHang::GanSanPham(int iSanPham)
{
	if (iSanPham > 0)
		m_iSanPham = iSanPham;
	else
		m_iSanPham = 0;
}

int NVBanHang::DocSanPham() const
{
	return m_iSanPham;
}

int NVBanHang::TinhLuong() const 
{
	return NVCongNhat::TinhLuong() + m_iHueHong * m_iSanPham;
}

std::string NVBanHang::InBCC() const 
{
	char s[10];
	return NVCongNhat::InBCC() + "\n" + "Hue hong: " + std::string(itoa(m_iHueHong, s, 10))
		+ "So san pham: " + std::string(itoa(m_iSanPham, s, 10)) 
		+ "\nLuong linh: " + std::string(itoa(TinhLuong(), s, 10));
}

int NVBanHang::LoaiNV() const
{
	return NV_BAN_HANG;
}

ostream& operator << (ostream& os, const NVBanHang& P)
{
	os << NV_BAN_HANG << " ";
	os << P.DocTen() << endl;
	os << P.DocLuongGio() << " " << P.DocSoGio() << " " << P.DocHueHong() << " " << P.DocSanPham() << endl;

	return os;
}

istream& operator >> (istream& is, NVBanHang& P)
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

	is >> t; // Doc hue hong
	P.GanHueHong(t);

	is >> t; // Doc san pham
	P.GanSanPham(t);

	return is;
}