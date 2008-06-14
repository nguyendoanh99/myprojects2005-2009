#include <iostream>
#include <fstream.h>
#include "QuanLy.h"
#include "NVBanHang.h"
#include "NVCongNhat.h"
#include "NVQuanLy.h"

QuanLy::QuanLy()
{
	m_iSoNhanVien = 0;
	m_iHienHanh = -1;
}

QuanLy::~QuanLy()
{
	for (int i = 0; i < m_iSoNhanVien; ++i)
		delete m_arrNhanVien[i];
}

void QuanLy::ThemNVQuanLy()
{
	char s[50];
	int iLuongThang;
	cout << "THEM NHAN VIEN QUAN LY" << endl;
	cout << "Nhap ho ten nhan vien: ";
	cin.ignore(1);
	cin.getline(s, 50, '\n');
	cout << "Nhap luong thang: ";
	cin >> iLuongThang;

	++m_iSoNhanVien;
	++m_iHienHanh;
	for (int i = m_iSoNhanVien - 1; i > m_iHienHanh; --i)
		m_arrNhanVien[i] = m_arrNhanVien[i - 1];
	m_arrNhanVien[m_iHienHanh] = new NVQuanLy(s, iLuongThang);
}

void QuanLy::ThemNVCongNhat()
{
	char s[50];
	int iLuongGio;
	int iSoGio;
	cout << "THEM NHAN VIEN CONG NHAT" << endl;
	cout << "Nhap ho ten nhan vien: ";
	cin.ignore(1);
	cin.getline(s, 50, '\n');
	cout << "Nhap luong gio: ";
	cin >> iLuongGio;
	cout << "Nhap so gio da lam: ";
	cin >> iSoGio;

	++m_iSoNhanVien;
	++m_iHienHanh;
	for (int i = m_iSoNhanVien - 1; i > m_iHienHanh; --i)
		m_arrNhanVien[i] = m_arrNhanVien[i - 1];
	m_arrNhanVien[m_iHienHanh] = new NVCongNhat(s, iLuongGio, iSoGio);
}

void QuanLy::ThemNVBanHang()
{
	char s[50];
	int iLuongGio;
	int iSoGio;
	int iHueHong;
	int iSanPham;

	cout << "THEM NHAN VIEN BAN HANG" << endl;
	cout << "Nhap ho ten nhan vien: ";
	cin.ignore(1);
	cin.getline(s, 50, '\n');
	cout << "Nhap luong gio: ";
	cin >> iLuongGio;
	cout << "Nhap so gio da lam: ";
	cin >> iSoGio;
	cout << "Nhap hue hong: ";
	cin >> iHueHong;
	cout << "Nhap so san pham: ";
	cin >> iSanPham;

	++m_iSoNhanVien;
	++m_iHienHanh;
	for (int i = m_iSoNhanVien - 1; i > m_iHienHanh; --i)
		m_arrNhanVien[i] = m_arrNhanVien[i - 1];
	m_arrNhanVien[m_iHienHanh] = new NVBanHang(s, iLuongGio, iSoGio, iHueHong, iSanPham);
}

void QuanLy::InBCC()
{
	if (m_iHienHanh != -1)
	{
		std::cout << m_arrNhanVien[m_iHienHanh]->InBCC() << endl;
		
	}
}

int QuanLy::LuaChon()
{
	int iChon;
	cout << "Cong ty hien co " << m_iSoNhanVien << " nhan vien." << endl;
	cout << "Con tro hien hanh dang o vi tri thu " << m_iHienHanh + 1<< endl;
	cout << "1. Them nhan vien quan ly" << endl;
	cout << "2. Them nhan vien cong nhat" << endl;
	cout << "3. Them nhan vien ban hang" << endl;
	cout << "4. Den nhan vien ke" << endl;
	cout << "5. Den nhan vien truoc" << endl;
	cout << "6. In ban cham cong" << endl;
	cout << "7. In bang luong" << endl;
	cout << "8. Luu du lieu xuong dia" << endl;
	cout << "9. Lay du lieu tu dia" << endl;
	cout << "0. Thoat" << endl;
	cout << "-----------> Chon: ";
	cin >> iChon;
	cout << endl;

	switch (iChon)
	{
	case 1:
		ThemNVQuanLy();
		break;
	case 2:
		ThemNVCongNhat();
		break;
	case 3:
		ThemNVBanHang();
		break;
	case 4:
		NhanVienKe();
		break;
	case 5:
		NhanVienTruoc();
		break;
	case 6:
		InBCC();
		break;
	case 7:
		InBangLuong();
		break;
	case 8:
		LuuDuLieu("Data.txt");
		break;
	case 9:
		LayDuLieu("Data.txt");
		break;
	}

	return iChon;
}

void QuanLy::NhanVienKe()
{	
	if (m_iHienHanh  < m_iSoNhanVien - 1)
		++m_iHienHanh;
}

void QuanLy::NhanVienTruoc()
{
	if (m_iHienHanh > -1)
		--m_iHienHanh;
}

void QuanLy::InBangLuong()
{
	cout << "\t\t\t\tBANG LUONG THANG" << endl << endl;
	cout << "\tSTT\t\t" << "Ten\t\t\t" << "Chuc Vu\t\t" << "Luong lanh" << endl;

	for (int i = 0; i < m_iSoNhanVien; ++i)
	{
		cout << "\t " << i + 1 << "\t\t" << m_arrNhanVien[i]->DocTen() << "\t\t\t";
		switch (m_arrNhanVien[i]->LoaiNV())
		{
		case NV_BAN_HANG:
			cout << "Ban Hang";
			break;
		case NV_CONG_NHAT:
			cout << "Cong Nhat";
			break;
		case NV_QUAN_LY:
			cout << "Quan Ly";
			break;
		}

		cout << "\t\t    " << m_arrNhanVien[i]->TinhLuong() << endl;
	}
}

void QuanLy::LayDuLieu(char *filename)
{
	ifstream is(filename);
	int n;
	int iLoai;
	NVBanHang nvbh;
	NVCongNhat nvcn;
	NVQuanLy nvql;

	is >> n;

	for (int i = 0; i < n; ++i)
	{
		is >> iLoai;
		switch (iLoai)
		{
		case NV_BAN_HANG:
			is >> nvbh;
			_ThemNVBanHang(nvbh);
			break;
		case NV_QUAN_LY:
			is >> nvql;
			_ThemNVQuanLy(nvql);
			break;
		case NV_CONG_NHAT:
			is >> nvcn;
			_ThemNVCongNhat(nvcn);
			break;
		}
		
	}
}

void QuanLy::LuuDuLieu(char *filename)
{
	ofstream os(filename);
	os << m_iSoNhanVien << endl;
	for (int i = 0; i < m_iSoNhanVien; ++i)
	{
		switch (m_arrNhanVien[i]->LoaiNV())
		{
		case NV_BAN_HANG:
			os << *((NVBanHang* ) m_arrNhanVien[i]);
			break;
		case NV_CONG_NHAT:
			os << *((NVCongNhat* ) m_arrNhanVien[i]);
			break;
		case NV_QUAN_LY:
			os << *((NVQuanLy* ) m_arrNhanVien[i]);
			break;
		}		
	}
}

void QuanLy::_ThemNVCongNhat(const NVCongNhat& P)
{
	char *s = P.DocTen();
	int iLuongGio = P.DocLuongGio();
	int iSoGio = P.DocSoGio();

	++m_iSoNhanVien;
	++m_iHienHanh;
	for (int i = m_iSoNhanVien - 1; i > m_iHienHanh; --i)
		m_arrNhanVien[i] = m_arrNhanVien[i - 1];
	m_arrNhanVien[m_iHienHanh] = new NVCongNhat(s, iLuongGio, iSoGio);

	delete s;
}

void QuanLy::_ThemNVBanHang(const NVBanHang& P)
{
	char *s = P.DocTen();
	int iLuongGio = P.DocLuongGio();
	int iSoGio = P.DocSoGio();
	int iHueHong = P.DocHueHong();
	int iSanPham = P.DocSanPham();
	
	++m_iSoNhanVien;
	++m_iHienHanh;
	for (int i = m_iSoNhanVien - 1; i > m_iHienHanh; --i)
		m_arrNhanVien[i] = m_arrNhanVien[i - 1];
	m_arrNhanVien[m_iHienHanh] = new NVBanHang(s, iLuongGio, iSoGio, iHueHong, iSanPham);

	delete s;
}

void QuanLy::_ThemNVQuanLy(const NVQuanLy& P)
{
	char *s = P.DocTen();
	int iLuongThang = P.DocLuongThang();

	++m_iSoNhanVien;
	++m_iHienHanh;
	for (int i = m_iSoNhanVien - 1; i > m_iHienHanh; --i)
		m_arrNhanVien[i] = m_arrNhanVien[i - 1];
	m_arrNhanVien[m_iHienHanh] = new NVQuanLy(s, iLuongThang);

	delete s;
}