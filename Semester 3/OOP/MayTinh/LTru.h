#ifndef _LTRU_
#define _LTRU_

#include "LPhepTinh.h"

class LTru: public LPhepTinh
{
public:
	LTru();
	LTru(float, float);
	virtual ~LTru();

	float TinhToan();
	LPhepTinh* TaoDoiTuong(float, float);
	char* TenDoiTuong();
};

#endif