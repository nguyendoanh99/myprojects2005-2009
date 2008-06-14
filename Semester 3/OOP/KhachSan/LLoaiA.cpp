#include <iostream.h>
#include "LLoaiA.h"

LLoaiA::~LLoaiA()
{
}

LLoaiA::LLoaiA(int iSoNgay, int iDichVu) : LLoaiPhong(iSoNgay)
{	
	GanDichVu(iDichVu);
}

void LLoaiA::Nhap()
{
	LLoaiPhong::Nhap();
	int iDichVu;
	do
	{
		cout << "Nhap phi dich vu: ";
		cin >> iDichVu;
	}
	while (GanDichVu(iDichVu) == 0);
}

int LLoaiA::TinhTien()
{
	int kq;
	if (DocSoNgay() >= SO_NGAY_GIAM)
		kq = ((GIA_B * (SO_NGAY_GIAM - 1)) 
		+ (GIA_B - ((GIA_B * MUC_GIAM) / 100)) * (DocSoNgay() - (SO_NGAY_GIAM - 1)));
	else kq = GIA_B * DocSoNgay();
	return kq + m_iDichVu;
}

int LLoaiA::DocDichVu()
{
	return m_iDichVu;
}

int LLoaiA::GanDichVu(int iDichVu)
{
	if (iDichVu > 0)
	{
		m_iDichVu = iDichVu;
		return 1;
	}

	m_iDichVu = 1;
	return 0;
}

string LLoaiA::Xuat()
{
	char s[10];
	return "Phong loai A, don gia " + string(itoa(GIA_A, s, 10)) + "USD/ngay\n"
		 + LLoaiPhong::Xuat() + "\nPhi dich vu: " + string(itoa(m_iDichVu, s, 10)) + " USD";
}

int LLoaiA::LoaiPhong()
{
	return LOAI_A;
}