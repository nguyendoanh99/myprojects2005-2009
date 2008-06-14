#pragma once
#include "_Polygon.h"
class _Pentagon :
	public _Polygon
{
private:
	static CString strError;
	// (x,y) tam cua hinh ngu giac deu
	// iRadius: ban kinh
	// iColor mau bien
	void CreatePentagon(int x, int y, int iRadius, int iColor);
public:
	// Cho biet loi phat sinh khi xu ly
	static CString GetError();	
	// (x,y) tam cua hinh ngu giac deu
	// iRadius: ban kinh
	// iColor mau bien
	_Pentagon(int x, int y, int iRadius, int iColor);
	// pCenter: tam cua hinh ngu giac deu
	// iRadius: ban kinh
	// iColor mau bien
	_Pentagon(POINT pCenter, int iRadius, int iColor);
	virtual ~_Pentagon(void);
};
