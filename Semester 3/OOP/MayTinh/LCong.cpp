#include "LCong.h"

LCong::LCong() 
{}

LCong::LCong(float f1, float f2): LPhepTinh(f1, f2) 
{}

LCong::~LCong()
{}

LPhepTinh* LCong::TaoDoiTuong(float f1, float f2)
{
	return new LCong(f1, f2);
}

char* LCong::TenDoiTuong()
{
	return "Cong";
}

float LCong::TinhToan()
{
	return m_fSoHang1 + m_fSoHang2;
}