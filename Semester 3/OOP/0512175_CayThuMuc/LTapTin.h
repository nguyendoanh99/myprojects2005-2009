#ifndef _LTAPTIN_
#define _LTAPTIN_
#include "LThongTin.h"
class LTapTin : public LThongTin
{
private:
	std::string m_strNoiDung;
public:
	LTapTin(){};
	LTapTin(std::string strTen, std::string strNgayTao);
	LTapTin(std::string strTen, std::string strNgayTao, std::string strNoiDung);
	virtual ~LTapTin();
	int DocKichThuoc();
	void Nhap(int iCap);
	int LayLoai();
	std::string Xuat(int iCap);
};

#endif