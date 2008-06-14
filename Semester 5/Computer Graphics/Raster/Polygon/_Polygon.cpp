#include "stdafx.h"
#include "_Polygon.h"
#include "_Bresenham.h"
#include "math.h"

#define PI 3.1415926535897932384626433832795
CString _Polygon::strError = CString("");

_Polygon::_Polygon()
{
}
void _Polygon::CreatePolygon(const CArray<POINT> &arrPoint, int iColor)
{
	strError = "";	
	RemovePolygon(); // Bo da giac cu
	// chi kiem tra so canh co hop le khong?
	if (arrPoint.GetCount() <= 2)	
		strError = "_Polygon::CreatePolygon() Khong phai la da giac";	
	else
	{		
		int i;
		int count = (int) arrPoint.GetCount();
		for (i = 1; i < count; ++i)		
			m_arrLine.Add(new _Bresenham(arrPoint[i - 1], arrPoint[i], iColor));
		m_arrLine.Add(new _Bresenham(arrPoint[count - 1], arrPoint[0], iColor));
	}
}
// Ve cac doan thang bang thuat toan Bresenham
_Polygon::_Polygon(const CArray<POINT>& arrPoint, int iColor)
{	
	CreatePolygon(arrPoint, iColor);
}
void _Polygon::Show(CDC *pDC)
{
	strError = "";
	if (m_arrLine.GetCount() <= 2)
	{
		strError = "_Polygon::Show() Khong the ve duoc vi thieu canh";
		return;
	}
	
	for (int i = 0; i < m_arrLine.GetCount(); ++i)
		m_arrLine[i]->Show(pDC);
}
CString _Polygon::GetError()
{
	return strError;
}
_Polygon::~_Polygon()
{
	RemovePolygon();
}
void _Polygon::RemovePolygon()
{
	for (int i = 0; i < m_arrLine.GetCount(); ++i)
		delete m_arrLine[i];
	m_arrLine.RemoveAll();
}
// Tao da giac deu voi
// iIdentity > 2: nhan dang da giac deu, = 5: ngu giac deu, = 6: luc giac deu ...
// dAlpha: diem bat dau cua da giac deu co goc la dAlpha
// (x,y) tam cua da giac deu
// iRadius: ban kinh
// iColor: mau cua duong bien da giac deu
void _Polygon::CreateEquilateralPolygon(int iIdentity, double dAlpha, int x, int y, int iRadius, int iColor)
{
	CString _strError("");

	if (iIdentity <= 2)
	{
		_strError = "_Polygon::CreateEquilateralPolygon() --> iIdentity: Khong phai da giac";
		iIdentity = 3;
	}	
	
	CArray<POINT> arrTemp;
	POINT temp;
	double dAngle = 2*PI / iIdentity; // goc quay
	
	// Tao cac dinh cua da giac deu
	for (int i = 0; i < iIdentity; ++i)
	{
		temp.x = iRadius * cos(dAlpha + dAngle * i) + x;
		temp.y = iRadius * sin(dAlpha + dAngle * i) + y;
		arrTemp.Add(temp);
	}

	CreatePolygon(arrTemp, iColor);
	strError += _strError; // Gan loi
}
// Tao hinh sao voi
// iIdentity > 2: nhan dang hinh sao, = 5: hinh sao 5 canh, = 6: hinh sao 6 canh ...
// dAlpha: diem bat dau cua hinh sao co goc la dAlpha
// (x,y) tam cua hinh sao
// iRadius: ban kinh
// iColor: mau cua duong bien hinh sao
void _Polygon::CreateStar(int iIdentity, double dAlpha, int x, int y, int iRadius, int iColor)
{
	CString _strError("");

	if (iIdentity <= 2)
	{
		_strError = "_Polygon::CreateStar() --> iIdentity: Khong du canh de tao hinh sao";
		iIdentity = 3;
	}	

	CArray<POINT> arrTemp;
	POINT temp;
	double dAngle = PI / iIdentity; // goc quay
	double dBeta = (1 - 3.0 / (2*iIdentity)) * PI;
	double dGamma = PI / (2 * iIdentity);
	int iRadius2 = iRadius * (sin(dGamma) / sin(dBeta));

	// Tao cac dinh cua hinh sao
	for (int i = 0; i < 2 * iIdentity; ++i)
	{
		if (i % 2 == 0)
		{		
			temp.x = iRadius * cos(dAlpha + dAngle * i) + x;
			temp.y = iRadius * sin(dAlpha + dAngle * i) + y;
		}
		else
		{
			temp.x = iRadius2 * cos(dAlpha + dAngle * i) + x;
			temp.y = iRadius2 * sin(dAlpha + dAngle * i) + y;
		}
		arrTemp.Add(temp);
	}

	CreatePolygon(arrTemp, iColor);
	strError += _strError; // Gan loi
}