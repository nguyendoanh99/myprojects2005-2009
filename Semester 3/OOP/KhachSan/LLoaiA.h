#ifndef _LLOAIA_
#define _LLOAIA_

#include "LLoaiPhong.h"

class LLoaiA : public LLoaiPhong
{
private:
	int m_iDichVu;
public:

	virtual ~LLoaiA();
	LLoaiA(int = 1, int = 0);	
	
	int TinhTien();
	void Nhap();
	int GanDichVu(int);
	int DocDichVu();
	string Xuat();
	int LoaiPhong();
};

#endif