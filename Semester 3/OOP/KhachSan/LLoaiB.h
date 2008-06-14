#ifndef _LLOAIB_
#define _LLOAIB_

#include "LLoaiPhong.h"

class LLoaiB : public LLoaiPhong
{
public:
	virtual ~LLoaiB();
	LLoaiB(int = 1);	
	
	int TinhTien();
	void Nhap();
	string Xuat();
	int LoaiPhong();
};

#endif