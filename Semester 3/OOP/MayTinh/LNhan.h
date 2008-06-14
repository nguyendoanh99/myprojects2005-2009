#ifndef _LNHAN_
#define _LN_

#include "LPhepTinh.h"

class LNhan: public LPhepTinh
{
public:
	LNhan();
	LNhan(float, float);
	virtual ~LNhan();

	float TinhToan();
	LPhepTinh* TaoDoiTuong(float, float);
	char* TenDoiTuong();
};

#endif