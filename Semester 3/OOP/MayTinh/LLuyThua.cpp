#include "LLuyThua.h"
#include <Math.h>
LLuyThua::LLuyThua() 
{}

LLuyThua::LLuyThua(float f1, float f2): LPhepTinh(f1, f2) 
{}

LLuyThua::~LLuyThua()
{}

LPhepTinh* LLuyThua::TaoDoiTuong(float f1, float f2)
{
	return new LLuyThua(f1, f2);
}

char* LLuyThua::TenDoiTuong()
{
	return "Luy Thua";
}

float LLuyThua::TinhToan()
{
	return pow(m_fSoHang1, m_fSoHang2);
}