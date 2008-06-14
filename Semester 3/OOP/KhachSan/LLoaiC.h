#ifndef _LLOAIC_
#define _LLOAIC_

#include "LLoaiPhong.h"

class LLoaiC : public LLoaiPhong
{
public:
	virtual ~LLoaiC();
	LLoaiC(int = 1);	
	
	virtual int TinhTien();
	void Nhap();
	string Xuat();
	int LoaiPhong();
};

#endif