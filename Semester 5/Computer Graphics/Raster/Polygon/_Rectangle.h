#pragma once
#include "_Polygon.h"
class _Rectangle :
	public _Polygon
{
private:
	static CString strError;
	// (x1,y1) toa do goc tren trai cua hinh chu nhat
	// (x2,y2) toa do goc duoi phai cua hinh chu nhat
	// iColor mau bien
	void CreateRectangle(int x1, int y1, int x2, int y2, int iColor);
public:
	// Cho biet loi phat sinh khi xu ly
	static CString GetError();
	// (x1,y1) toa do goc tren trai cua hinh chu nhat
	// (x2,y2) toa do goc duoi phai cua hinh chu nhat
	// iColor mau bien
	_Rectangle(int x1, int y1, int x2, int y2, int iColor);
	// p1: toa do goc tren trai cua hinh chu nhat
	// p2 toa do goc duoi phai cua hinh chu nhat
	// iColor mau bien
	_Rectangle(POINT p1, POINT p2, int iColor);	
	virtual ~_Rectangle(void);
};
