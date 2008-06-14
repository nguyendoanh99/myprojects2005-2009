#include "LLoaiC.h"

LLoaiC::~LLoaiC()
{
}

LLoaiC::LLoaiC(int iSoNgay) : LLoaiPhong(iSoNgay)
{
}

void LLoaiC::Nhap()
{
	LLoaiPhong::Nhap();
}

int LLoaiC::TinhTien()
{	
	return GIA_C * DocSoNgay();
}

string LLoaiC::Xuat()
{
	char s[10];
	return "Phong loai B, don gia " + string(itoa(GIA_B, s, 10)) + "USD/ngay\n" 
		+ LLoaiPhong::Xuat();
}

int LLoaiC::LoaiPhong()
{
	return LOAI_C;
}