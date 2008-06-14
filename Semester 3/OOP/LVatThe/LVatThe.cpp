#include "LVatThe.h"

void LVatThe::TaoKhung()
{
	// Lay toa do diem tren trai nhat cua LVatThe
	// va lay to do diem duoi phai nhat cua LVatThe
	int iX1 = 80;
	int iY1 = 25;
	int iX2 = 0;
	int iY2 = 0;
	for (int i = 0; i < m_iSoBoPhan; ++i)
	{
		if (iX1 > m_pBoPhan[i].DocX())
			iX1 = m_pBoPhan[i].DocX();

		if (iY1 > m_pBoPhan[i].DocY())
			iY1 = m_pBoPhan[i].DocY();

		if (iX2 < m_pBoPhan[i].DocX() + m_pBoPhan[i].DocRong())
			iX2 = m_pBoPhan[i].DocX() + m_pBoPhan[i].DocRong();

		if (iY2 < m_pBoPhan[i].DocY() + m_pBoPhan[i].DocDai())
			iY2 = m_pBoPhan[i].DocY() + m_pBoPhan[i].DocDai();
	}
	// Tao khung cho LVatThe
	m_Khung.GanXY(iX1, iY1);
	m_Khung.GanDai(iY2 - iY1);
	m_Khung.GanRong(iX2 - iX1);
}

LVatThe::LVatThe()
{	
	m_iSoBoPhan = 16;
	m_pBoPhan = new LHCN[m_iSoBoPhan];
	if (m_pBoPhan)
	{
		m_pBoPhan[0] = LHCN(5, 3, 11, 6);
		m_pBoPhan[1] = LHCN(7, 4, 2, 1, 14);
		m_pBoPhan[2] = LHCN(12, 4, 2, 1, 14);
		m_pBoPhan[3] = LHCN(8, 6, 5, 2);
		m_pBoPhan[4] = LHCN(9, 6, 1, 1, 12);
		m_pBoPhan[5] = LHCN(11, 6, 1, 1, 12);
		m_pBoPhan[6] = LHCN(3, 0, 2, 4);
		m_pBoPhan[7] = LHCN(16, 0, 2, 4);
		m_pBoPhan[8] = LHCN(8, 9, 5, 2);
		m_pBoPhan[9] = LHCN(4, 11, 14, 7);
		m_pBoPhan[10] = LHCN(2, 11, 2, 3);
		m_pBoPhan[11] = LHCN(1, 14, 2, 3);
		m_pBoPhan[12] = LHCN(18, 11, 2, 3);
		m_pBoPhan[13] = LHCN(19, 14, 8, 1);
		m_pBoPhan[14] = LHCN(6, 18, 3, 6);	
		m_pBoPhan[15] = LHCN(13, 18, 3, 6);
		
		TaoKhung();
	}

}

LVatThe::~LVatThe()
{
	delete m_pBoPhan;
}

LVatThe::LVatThe(const LVatThe& P): m_Khung(P.m_Khung)
{
	m_iSoBoPhan = P.m_iSoBoPhan;
	m_pBoPhan = new LHCN[m_iSoBoPhan];
	for (int i = 0; i < m_iSoBoPhan; ++i)	
		m_pBoPhan[i] = P.m_pBoPhan[i];
}

LVatThe::LVatThe(LHCN *p, int iSoLuong)
{
	m_iSoBoPhan = iSoLuong;
	m_pBoPhan = new LHCN[m_iSoBoPhan];
	for (int i = 0; i < m_iSoBoPhan; ++i)	
		m_pBoPhan[i] = p[i];

	TaoKhung();
}

void LVatThe::In() const
{
	for (int i = 0; i < m_iSoBoPhan; ++i)
		m_pBoPhan[i].In();
}

void LVatThe::Xoa() const
{
	for (int i = 0; i < m_iSoBoPhan; ++i)
		m_pBoPhan[i].Xoa();
}

void LVatThe::DichTrai(int x)
{
	int iX = m_Khung.DocX();	

	m_Khung.DichTrai(x);
	// Neu m_Khung ma dich trai duoc thi moi dich toan bo cac bo phan 
	// cua LVatThe
	if (iX != m_Khung.DocX())
	{
		for (int i = 0; i < m_iSoBoPhan; ++i)
			m_pBoPhan[i].DichTrai(x);
	}
}

void LVatThe::DichPhai(int x)
{
	int iX = m_Khung.DocX();

	m_Khung.DichPhai(x);
	// Neu m_Khung ma dich phai duoc thi moi dich toan bo cac bo phan 
	// cua LVatThe
	if (iX != m_Khung.DocX())
	{
		for (int i = 0; i < m_iSoBoPhan; ++i)	
		m_pBoPhan[i].DichPhai(x);		
	}
}

void LVatThe::DichLen(int x)
{
	int iY = m_Khung.DocY();
	
	m_Khung.DichLen(x);
	// Neu m_Khung ma dich len duoc thi moi dich toan bo cac bo phan
	// cua LVatThe
	if (iY != m_Khung.DocY())
	{
		for (int i = 0; i < m_iSoBoPhan; ++i)
			m_pBoPhan[i].DichLen(x);
	}
}

void LVatThe::DichXuong(int x)
{
	int iY = m_Khung.DocY();

	m_Khung.DichXuong(x);
	// Neu m_Khung ma dich len duoc thi moi dich toan bo cac bo phan
	// cua LVatThe
	if (iY != m_Khung.DocY())
	{
		for (int i = 0; i < m_iSoBoPhan; ++i)
			m_pBoPhan[i].DichXuong(x);
	}
}

LVatThe& LVatThe::operator =(const LVatThe& P)
{
	m_Khung = P.m_Khung;
	m_iSoBoPhan = P.m_iSoBoPhan;
	delete m_pBoPhan;
	m_pBoPhan = new LHCN[m_iSoBoPhan];
	for (int i = 0; i < m_iSoBoPhan; ++i)	
		m_pBoPhan[i] = P.m_pBoPhan[i];
	return *this;
}