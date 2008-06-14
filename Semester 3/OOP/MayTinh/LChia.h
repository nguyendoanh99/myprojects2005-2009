#ifndef _LCHIA_
#define _LCHIA_

#include "LPhepTinh.h"

class LChia: public LPhepTinh
{
public:
	LChia();
	LChia(float, float);
	virtual ~LChia();

	float TinhToan();
	LPhepTinh* TaoDoiTuong(float, float);
	char* TenDoiTuong();
};

#endif