#ifndef _LQUANLY_
#define _LQUANLY_

#include "LThuMuc.h"

class LQuanLy
{
private:
	LThuMuc m_NoiDung;
public:
	LQuanLy();
	virtual ~LQuanLy();
	void Nhap();
	void Xuat();
	int LuaChon();
	void ThemTapTin();
	void ThemThuMuc();
//	void ThongKe();
};

#endif