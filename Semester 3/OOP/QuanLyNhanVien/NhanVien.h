#ifndef _NHANVIEN_
#define _NHANVIEN_

#define NV_QUAN_LY 1
#define NV_CONG_NHAT 2
#define NV_BAN_HANG 3

#include <string>
//using namespace std;

class NhanVien
{
private:
	char m_strTen[50];
public:
	NhanVien(char*);
	NhanVien(){};
	virtual ~NhanVien();

	void GanTen(char*);
	char* DocTen() const;
	virtual std::string InBCC() const;
	virtual int TinhLuong() const = 0;
	virtual int LoaiNV() const = 0;
};

#endif