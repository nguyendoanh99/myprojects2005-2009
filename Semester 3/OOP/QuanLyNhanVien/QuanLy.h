#ifndef _QUANLY_
#define _QUANLY_

#include "NVCongNhat.h"
#include "NVQuanLy.h"
#include "NVBanHang.h"
#include "NhanVien.h"

class QuanLy
{
private:
	NhanVien* m_arrNhanVien[100];
	int m_iHienHanh;
	int m_iSoNhanVien;

	void _ThemNVCongNhat(const NVCongNhat&);
	void _ThemNVBanHang(const NVBanHang&);
	void _ThemNVQuanLy(const NVQuanLy&);
public:
	QuanLy();
	virtual ~QuanLy();
	void ThemNVQuanLy();
	void ThemNVCongNhat();
	void ThemNVBanHang();
	void NhanVienKe();
	void NhanVienTruoc();
	void InBCC();
	void InBangLuong();
	int LuaChon();
	void LuuDuLieu(char *);
	void LayDuLieu(char *);
};

#endif