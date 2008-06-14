#include <float.h>
#include "LChia.h"

LChia::LChia(): LPhepTinh(0, 1)
{}

LChia::LChia(float f1, float f2): LPhepTinh(f1, f2) 
{
}

LChia::~LChia()
{}

LPhepTinh* LChia::TaoDoiTuong(float f1, float f2)
{
	return new LChia(f1, f2);
}

char* LChia::TenDoiTuong()
{
	return "Chia";
}

float LChia::TinhToan()
{
	if (m_fSoHang2 == 0)
		return FLT_MAX;		
	return m_fSoHang1 / m_fSoHang2;
}