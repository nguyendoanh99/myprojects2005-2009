#include "StdAfx.h"
#include "_Rectangle.h"

CString _Rectangle::strError = CString("");

// (x1,y1) toa do goc tren trai cua hinh chu nhat
// (x2, y2) toa do goc duoi phai cua hinh chu nhat
// iColor mau bien
_Rectangle::_Rectangle(int x1, int y1, int x2, int y2, int iColor)
{
	CreateRectangle(x1, y1, x2, y2, iColor);
}
// p1: toa do goc tren trai cua hinh chu nhat
// p2 toa do goc duoi phai cua hinh chu nhat
// iColor mau bien
_Rectangle::_Rectangle(POINT p1, POINT p2, int iColor)
{
	CreateRectangle(p1.x, p1.y, p2.x, p2.y, iColor);
}
// (x1,y1) toa do goc tren trai cua hinh chu nhat
// (x2, y2) toa do goc duoi phai cua hinh chu nhat
// iColor mau bien
void _Rectangle::CreateRectangle(int x1, int y1, int x2, int y2, int iColor)
{
	CArray<POINT> arrTemp;
	POINT temp;
	
	temp.x = x1;
	temp.y = y1;
	arrTemp.Add(temp);

	temp.x = x2;
	temp.y = y1;
	arrTemp.Add(temp);

	temp.x = x2;
	temp.y = y2;
	arrTemp.Add(temp);

	temp.x = x1;
	temp.y = y2;
	arrTemp.Add(temp);

	CreatePolygon(arrTemp, iColor);
	strError += _Polygon::GetError(); // Gan loi
}
_Rectangle::~_Rectangle(void)
{
}
CString _Rectangle::GetError()
{
	return strError;
}