#include "LTru.h"

LTru::LTru() 
{}

LTru::LTru(float f1, float f2): LPhepTinh(f1, f2)
{}

LTru::~LTru()
{}

LPhepTinh* LTru::TaoDoiTuong(float f1, float f2)
{
	return new LTru(f1, f2);
}

char* LTru::TenDoiTuong()
{
	return "Tru";
}

float LTru::TinhToan()
{
	return m_fSoHang1 - m_fSoHang2;
}