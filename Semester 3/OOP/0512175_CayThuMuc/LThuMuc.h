#ifndef _LTHUMUC_
#define _LTHUMUC_

#include "LThongTin.h"
#include <vector>
class LThuMuc : public LThongTin
{
private:
	std::vector<LThongTin *> m_arrNoiDung;
public:
	LThuMuc() {};
	LThuMuc(const std::string &strTen, const std::string &strNgayTao);
	int DocKichThuoc();
	~LThuMuc();
	void Them(LThongTin*);
	void Nhap(int iCap);
	int LayLoai();
//	LThongTin* TimKiem(std::string strTen,int iLoai);
	void ThongKe(int &iSoThuMuc, int &iSoTapTin);
	std::string Xuat(int iCap);
};

#endif