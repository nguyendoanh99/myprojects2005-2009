#include "LLoaiB.h"

LLoaiB::~LLoaiB()
{
}

LLoaiB::LLoaiB(int iSoNgay) : LLoaiPhong(iSoNgay)
{
}

void LLoaiB::Nhap()
{
	LLoaiPhong::Nhap();
}

int LLoaiB::TinhTien()
{	
	if (DocSoNgay() >= SO_NGAY_GIAM)
		return ((GIA_B * (SO_NGAY_GIAM - 1)) 
		+ (GIA_B - ((GIA_B * MUC_GIAM) / 100)) * (DocSoNgay() - (SO_NGAY_GIAM - 1)));
	return GIA_B * DocSoNgay();
}

string LLoaiB::Xuat()
{
	char s[10];
	return "Phong loai B, don gia " + string(itoa(GIA_B, s, 10)) + "USD/ngay\n" 
		+ LLoaiPhong::Xuat();
}

int LLoaiB::LoaiPhong()
{
	return LOAI_B;
}