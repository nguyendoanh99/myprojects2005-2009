#pragma once
#include "_Polygon.h"
class _Star5 :
	public _Polygon
{
private:
	static CString strError;
	// (x,y) tam cua hinh sao 5 canh
	// iRadius: ban kinh
	// iColor mau bien
	void CreateStar5(int x, int y, int iRadius, int iColor);
public:
	// Cho biet loi phat sinh khi xu ly
	static CString GetError();	
	// (x,y) tam cua hinh sao 5 canh
	// iRadius: ban kinh
	// iColor mau bien
	_Star5(int x, int y, int iRadius, int iColor);
	// pCenter: tam cua hinh sao 5 canh
	// iRadius: ban kinh
	// iColor mau bien
	_Star5(POINT pCenter, int iRadius, int iColor);
	virtual ~_Star5(void);
};
