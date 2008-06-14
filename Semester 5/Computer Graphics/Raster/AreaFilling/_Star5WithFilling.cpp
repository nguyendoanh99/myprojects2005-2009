#include "StdAfx.h"
#include "_Star5WithFilling.h"
#include "_ScanLineTriangle.h"
CString _Star5WithFilling::strError = CString("");

CString _Star5WithFilling::GetError()
{
	return strError;
}
void _Star5WithFilling::CreateStar5WithFilling(int BackGround)
{
	strError = "";
	RemoveAreaFilling();
	
	int i;

	for (i = 1; i <= 9; i += 2)	
		m_BackGround.Add(new _ScanLineTriangle(GetPoint(i % 10), GetPoint((i + 1) % 10), GetPoint((i + 2) % 10), BackGround));

	m_BackGround.Add(new _ScanLineTriangle(GetPoint(1), GetPoint(3), GetPoint(5), BackGround));
	m_BackGround.Add(new _ScanLineTriangle(GetPoint(1), GetPoint(5), GetPoint(9), BackGround));
	m_BackGround.Add(new _ScanLineTriangle(GetPoint(5), GetPoint(7), GetPoint(9), BackGround));	
}
_Star5WithFilling::_Star5WithFilling(POINT pCenter, int iRadius, int iColor, int iBackGround): _Star5(pCenter, iRadius, iColor)
{
	CreateStar5WithFilling(iBackGround);
}
_Star5WithFilling::_Star5WithFilling(int x, int y, int iRadius, int iColor, int iBackGround): _Star5(x, y, iRadius, iColor)
{
	CreateStar5WithFilling(iBackGround);
}
void _Star5WithFilling::Show(CDC *pDC)
{
	// Ve hinh sao
	_Star5::Show(pDC);
	// To hinh
	for (int i = 0; i < m_BackGround.GetCount(); ++i)
	{
		m_BackGround[i]->Fill(pDC);
	}
}
_Star5WithFilling::~_Star5WithFilling(void)
{
	RemoveAreaFilling();
}
void _Star5WithFilling::RemoveAreaFilling()
{
	for (int i = 0; i < m_BackGround.GetCount(); ++i)
		delete m_BackGround[i];

	m_BackGround.RemoveAll();
}