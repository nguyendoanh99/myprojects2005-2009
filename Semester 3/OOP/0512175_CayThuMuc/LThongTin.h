#ifndef _LTHONGTIN_
#define _LTHONGTIN_

#include <string>
#define TAPTIN 1
#define THUMUC 2

class LThongTin
{
private:
	std::string m_strTen;
	std::string m_strNgayTao;
public:
	LThongTin(){};
	LThongTin(std::string strTen, std::string strNgayTao);
	virtual int DocKichThuoc() = 0;
	std::string DocNgayTao();
	std::string DocTen();
	virtual void Nhap(int iCap);
	virtual ~LThongTin();
	virtual int LayLoai() = 0;
	virtual std::string Xuat(int iCap);
};

#endif