#ifndef _NVQUANLY_
#define _NVQUANLY_

#include <iostream.h>
#include "NhanVien.h"

class NVQuanLy : public NhanVien
{
private:
	int m_iLuongThang;
public:
	NVQuanLy(char*, int iLuongThang);	
	NVQuanLy(){};
	virtual ~NVQuanLy();

	void GanLuongThang(int);
	int DocLuongThang() const;
	std::string InBCC() const;
	int TinhLuong() const;
	int LoaiNV() const;
	friend ostream& operator << (ostream&, const NVQuanLy&);
	friend istream& operator >> (istream&, NVQuanLy&);
};

#endif