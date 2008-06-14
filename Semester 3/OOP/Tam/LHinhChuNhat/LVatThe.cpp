#include "LVatThe.h"

void LVatThe::KhoiDong(LHinhChuNhat *arr)
{
	mSoHCN = sizeof(arr) / sizeof(LHinhChuNhat);
	mHCN = new LHinhChuNhat[mSoHCN];
	for (int i = 0; i < mSoHCN; ++i)
		mHCN[i].KhoiDong(arr[i]);
}