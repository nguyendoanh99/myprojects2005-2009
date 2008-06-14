#ifndef _LCONG_
#define _LCONG_

#include "LPhepTinh.h"

class LCong: public LPhepTinh
{
public:
	LCong();
	LCong(float, float);
	virtual ~LCong();

	float TinhToan();
	LPhepTinh* TaoDoiTuong(float, float);
	char* TenDoiTuong();
};
#endif