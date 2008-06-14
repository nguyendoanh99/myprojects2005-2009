#include "stdafx.h"
#include "_Triangle.h"

CString _Triangle::strError = CString("");

CString _Triangle::GetError()
{
	return strError;
}
_Triangle::_Triangle(POINT p1, POINT p2, POINT p3, int iColor)
{
	CreateTriangle(p1.x, p1.y, p2.x, p2.y, p3.x, p3.y, iColor);
}
_Triangle::_Triangle(int x1, int y1, int x2, int y2, int x3, int y3, int iColor)
{
	CreateTriangle(x1, y1, x2, y2, x3, y3, iColor);
}
void _Triangle::CreateTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int iColor)
{
	strError = "";
	CArray<POINT> arrtemp;
	POINT temp;
	temp.x = x1;
	temp.y = y1;
	arrtemp.Add(temp);

	temp.x = x2;
	temp.y = y2;
	arrtemp.Add(temp);

	temp.x = x3;
	temp.y = y3;
	arrtemp.Add(temp);
	
	CreatePolygon(arrtemp, iColor);
	strError += _Polygon::GetError(); // Gan loi
}
_Triangle::~_Triangle(void)
{
}
