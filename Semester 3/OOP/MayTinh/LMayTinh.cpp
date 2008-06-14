#include <iostream.h>
#include "LMayTinh.h"
#include "LCong.h"
#include "LTru.h"
#include "LNhan.h"
#include "LChia.h"
#include "LLuyThua.h"

LMayTinh::LMayTinh()
{
	m_DoiTuong.push_back(new LCong);
	m_DoiTuong.push_back(new LTru);
	m_DoiTuong.push_back(new LNhan);
	m_DoiTuong.push_back(new LChia);
	m_DoiTuong.push_back(new LLuyThua);

	m_pt = 0;
}

LMayTinh::~LMayTinh()
{
	if (m_pt)
		delete m_pt;
}

void LMayTinh::KhoiTao(float f1, float f2, int i_pt)
{
	if (i_pt >= 0 && i_pt < m_DoiTuong.size())
	{
		if (m_pt)
			delete m_pt;
		m_pt = m_DoiTuong[i_pt]->TaoDoiTuong(f1, f2);
	}
}

float LMayTinh::KetQua() const 
{
	if (m_pt)
		return m_pt->TinhToan();
	return 0;
}

int LMayTinh::Nhap()
{
	int iChon;
	cout << "Chon phep tinh: " << endl;

	for (int i = 0; i < m_DoiTuong.size(); ++i)
		cout << i + 1 << ". " << m_DoiTuong[i]->TenDoiTuong() << endl;

	cout << "0. Thoat" << endl;
	cout << "---------> Chon: ";
	cin >> iChon;

	if (iChon > 0 && iChon <= m_DoiTuong.size())
	{
		float f1, f2;
		cout << "Nhap so hang thu nhat: ";
		cin >> f1;
		cout << "Nhap so hang thu hai: ";
		cin >> f2;

		m_pt = m_DoiTuong[iChon - 1]->TaoDoiTuong(f1, f2);
	}

	return iChon;
}

ostream& operator<<(ostream& os, const LMayTinh& mt)
{
	os << mt.KetQua();
	return os;
}
