#ifndef _KHACHSAN_
#define _KHACHSAN_

#include "LLoaiPhong.h"
#include <vector>

class KhachSan
{
private:
	std::vector<LLoaiPhong*> m_Phong;
public:
	virtual ~KhachSan();

	int TinhTienPhong(int );
	int TongTien();
	int LuaChon();
	string Xuat();
};

#endif