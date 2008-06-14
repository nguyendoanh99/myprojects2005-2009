#ifndef _NVBANHANG_
#define _NVBANHANG_

#include <iostream.h>
#include "NVCongNhat.h"
//#include <iostream.h>

class NVBanHang : public NVCongNhat
{
private:
	int m_iHueHong;
	int m_iSanPham;
public:
	NVBanHang(char*, int iLuongGio, int iSoGio, int iHueHong, int iSanPham);	
	NVBanHang(){};
	virtual ~NVBanHang();

	void GanHueHong(int);
	int DocHueHong() const;
	void GanSanPham(int);
	int DocSanPham() const;
	std::string InBCC() const;
	int TinhLuong() const;
	int LoaiNV() const;
	friend ostream& operator << (ostream&, const NVBanHang&);
	friend istream& operator >> (istream&, NVBanHang&);
};

#endif