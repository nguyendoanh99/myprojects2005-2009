#ifndef _NVCONGNHAT_
#define _NVCONGNHAT_

#include <iostream.h>
#include "NhanVien.h"

class NVCongNhat : public NhanVien
{
private:
	int m_iLuongGio;
	int m_iSoGio;
public:
	NVCongNhat(char*, int iLuongGio, int iSoGio);	
	NVCongNhat(){};
	virtual ~NVCongNhat();

	void GanLuongGio(int);
	int DocLuongGio() const;
	void GanSoGio(int);
	int DocSoGio() const;
	std::string InBCC() const;
	int TinhLuong() const;
	int LoaiNV() const;

	friend ostream& operator << (ostream&, const NVCongNhat&);
	friend istream& operator >> (istream&, NVCongNhat&);
};

#endif