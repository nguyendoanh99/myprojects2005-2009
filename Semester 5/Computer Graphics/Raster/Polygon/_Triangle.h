#pragma once
#include "_Polygon.h"
class _Triangle :
	public _Polygon
{
private:
	// (x1,y1) (x2,y2) (x3,y3) la toa do 3 dinh cua tam giac
	// iColor: mau bien cua tam giac
	void CreateTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int iColor);
	static CString strError;
public:
	// Cho biet loi phat sinh khi xu ly
	static CString GetError();
	// p1, p2, p3: la toa do 3 dinh cua tam giac
	// iColor: mau bien cua tam giac
	_Triangle(POINT p1, POINT p2, POINT p3, int iColor);
	// (x1,y1) (x2,y2) (x3,y3) la toa do 3 dinh cua tam giac
	// iColor: mau bien cua tam giac
	_Triangle(int x1, int y1, int x2, int y2, int x3, int y3, int iColor);
	virtual ~_Triangle(void);
};
