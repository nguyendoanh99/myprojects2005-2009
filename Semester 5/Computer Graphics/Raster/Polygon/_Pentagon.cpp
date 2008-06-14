#include "StdAfx.h"
#include "_Pentagon.h"
#include "math.h"

#define PI 3.1415926535897932384626433832795
CString _Pentagon::strError = CString("");

CString _Pentagon::GetError()
{
	return strError;
}
// (x,y) tam cua hinh ngu giac deu
// iRadius: ban kinh
// iColor mau bien
_Pentagon::_Pentagon(int x, int y, int iRadius, int iColor)
{
	CreatePentagon(x, y, iRadius, iColor);
}
// pCenter: tam cua hinh ngu giac deu
// iRadius: ban kinh
// iColor mau bien
_Pentagon::_Pentagon(POINT pCenter, int iRadius, int iColor)
{
	CreatePentagon(pCenter.x, pCenter.y, iRadius, iColor);
}
// (x,y) tam cua hinh ngu giac deu
// iRadius: ban kinh
// iColor mau bien
void _Pentagon::CreatePentagon(int x, int y, int iRadius, int iColor)
{
	strError = "";
	CreateEquilateralPolygon(5, -PI/2, x, y, iRadius, iColor);
	strError += _Polygon::GetError();
}
_Pentagon::~_Pentagon(void)
{
	
}
