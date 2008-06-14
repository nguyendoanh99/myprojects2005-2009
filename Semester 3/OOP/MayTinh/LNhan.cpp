#include "LNhan.h"

LNhan::LNhan() 
{}

LNhan::LNhan(float f1, float f2): LPhepTinh(f1, f2) 
{}

LNhan::~LNhan()
{}

LPhepTinh* LNhan::TaoDoiTuong(float f1, float f2)
{
	return new LNhan(f1, f2);
}

char* LNhan::TenDoiTuong()
{
	return "Nhan";
}

float LNhan::TinhToan()
{
	return m_fSoHang1 * m_fSoHang2;
}