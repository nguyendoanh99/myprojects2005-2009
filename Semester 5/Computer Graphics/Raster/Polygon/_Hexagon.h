#pragma once
#include "_Polygon.h"
class _Hexagon :
	public _Polygon
{
private:
	static CString strError;
	// (x,y) tam cua hinh luc giac deu
	// iRadius: ban kinh
	// iColor mau bien
	void CreateHexagon(int x, int y, int iRadius, int iColor);
public:
	// Cho biet loi phat sinh khi xu ly
	static CString GetError();	
	// (x,y) tam cua hinh luc giac deu
	// iRadius: ban kinh
	// iColor mau bien
	_Hexagon(int x, int y, int iRadius, int iColor);
	// pCenter: tam cua hinh luc giac deu
	// iRadius: ban kinh
	// iColor mau bien
	_Hexagon(POINT pCenter, int iRadius, int iColor);
	virtual ~_Hexagon(void);
};
