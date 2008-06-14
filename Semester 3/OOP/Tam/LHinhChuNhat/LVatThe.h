#ifndef _L_VAT_THE_H_
#define _L_VAT_THE_H_

#include "LHinhChuNhat.h"

class LVatThe
{
private:
	LHinhChuNhat *mHCN;
	int mSoHCN; // So hinh chu nhat cuc dai
public:
	void KhoiDong(LHinhChuNhat *);
	void In();
	void Xoa();
};

#endif 