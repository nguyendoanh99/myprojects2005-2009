#ifndef _LLUYTHUA_
#define _LLUYTHUA_

#include "LPhepTinh.h"

class LLuyThua: public LPhepTinh
{
public:
	LLuyThua();
	LLuyThua(float, float);
	virtual ~LLuyThua();

	float TinhToan();
	LPhepTinh* TaoDoiTuong(float, float);
	char* TenDoiTuong();
};

#endif