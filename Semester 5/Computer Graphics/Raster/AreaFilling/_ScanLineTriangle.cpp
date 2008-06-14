#include "StdAfx.h"
#include "_ScanLineTriangle.h"
#include <map>

CString _ScanLineTriangle::strError = CString("");
CString _ScanLineTriangle::GetError()
{
	return strError;
}
void _ScanLineTriangle::CreateScanLineTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
{
	strError = "";
	m_pPoint[0].x = x1;
	m_pPoint[0].y = y1;
	m_pPoint[1].x = x2;
	m_pPoint[1].y = y2;
	m_pPoint[2].x = x3;
	m_pPoint[2].y = y3;
	// Sap xep tang dan cac diem theo Y
	if (m_pPoint[0].y > m_pPoint[1].y)
		std::swap(m_pPoint[0], m_pPoint[1]);
	if (m_pPoint[0].y > m_pPoint[2].y)
		std::swap(m_pPoint[0], m_pPoint[2]);
	if (m_pPoint[1].y > m_pPoint[2].y)
		std::swap(m_pPoint[1], m_pPoint[2]);

}
_ScanLineTriangle::_ScanLineTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int iColor):_AreaFilling(iColor)
{
	CreateScanLineTriangle(x1, y1, x2, y2, x3, y3);
}
_ScanLineTriangle::_ScanLineTriangle(POINT p1, POINT p2, POINT p3, int iColor):_AreaFilling(iColor)
{
	CreateScanLineTriangle(p1.x, p1.y, p2.x, p2.y, p3.x, p3.y);
}

_ScanLineTriangle::~_ScanLineTriangle(void)
{
}
void _ScanLineTriangle::Fill(CDC *pDC)
{
	strError = "";
	if (m_pPoint[0].y == m_pPoint[1].y && m_pPoint[1].y == m_pPoint[2].y)
		Fill1(pDC);
	else
		if (m_pPoint[0].y < m_pPoint[1].y && m_pPoint[1].y == m_pPoint[2].y)
			Fill2(pDC);
		else
			if (m_pPoint[0].y == m_pPoint[1].y && m_pPoint[1].y < m_pPoint[2].y)
				Fill3(pDC);
			else
				Fill4(pDC);
}
void _ScanLineTriangle::Row(CDC *pDC, int l, int r, int y)
{	
	int iColor = GetColor();
	int x;
	if (l > r) 
		std::swap(l, r);

	for (x = l; x <= r; ++x)
	{
		pDC->SetPixel(x, y, iColor);		
	}
}
void _ScanLineTriangle::Fill1(CDC *pDC)
{
	// Tim xmin, xmax
	int xmin, xmax;
	int i;
	
	xmin = m_pPoint[0].x;
	xmax = m_pPoint[0].x;
	for (i = 1; i < 3; ++i)
	{
		if (xmin > m_pPoint[i].x)
			xmin = m_pPoint[i].x;
		else
			if (xmax < m_pPoint[i].x)
				xmax = m_pPoint[i].x;
	}
	// To mau
	Row(pDC, xmin, xmax, m_pPoint[0].y);
}
void _ScanLineTriangle::Fill2(CDC *pDC)
{
	int y;
	double xl, xr;
	double k1, k2;
	k1 = (double) (m_pPoint[1].x - m_pPoint[0].x) / (m_pPoint[1].y - m_pPoint[0].y);
	k2 = (double) (m_pPoint[2].x - m_pPoint[0].x) / (m_pPoint[2].y - m_pPoint[0].y);
	xr = xl = m_pPoint[0].x;
	
	for (y = m_pPoint[0].y; y <= m_pPoint[1].y; ++y, xl += k1, xr += k2)
	{	
		Row(pDC, (double) xl, (double) xr, y);
		Sleep(1);
	}
	
}
void _ScanLineTriangle::Fill3(CDC *pDC)
{
	int y;
	double xl, xr;
	double k1, k2;
	k1 = (double) (m_pPoint[2].x - m_pPoint[1].x) / (m_pPoint[2].y - m_pPoint[1].y);
	k2 = (double) (m_pPoint[2].x - m_pPoint[0].x) / (m_pPoint[2].y - m_pPoint[0].y);

	xl = m_pPoint[1].x;
	xr = m_pPoint[0].x;

	for (y = m_pPoint[0].y; y <= m_pPoint[2].y; ++y, xl += k1, xr += k2)
	{	
		Row(pDC, (double) xl, (double) xr, y);
		Sleep(1);
	}
}
void _ScanLineTriangle::Fill4(CDC *pDC)
{	
	POINT temp;
	int iColor = GetColor();
	// Tim tung do X tren doan thang p0-p2
	temp.x = (double) (m_pPoint[2].x - m_pPoint[0].x) / (m_pPoint[2].y -m_pPoint[0].y) * (m_pPoint[1].y - m_pPoint[0].y) + m_pPoint[0].x;
	temp.y = m_pPoint[1].y;
	// Chia lam 2 truong hop con
	_ScanLineTriangle(m_pPoint[1], m_pPoint[0], temp, iColor).Fill2(pDC);
	_ScanLineTriangle(m_pPoint[1], m_pPoint[2], temp, iColor).Fill3(pDC);
}