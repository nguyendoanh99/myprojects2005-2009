#include "StdAfx.h"
#include "_Hexagon.h"
#include "math.h"

#define PI 3.1415926535897932384626433832795
CString _Hexagon::strError = CString("");

CString _Hexagon::GetError()
{
	return strError;
}
// (x,y) tam cua hinh luc giac deu
// iRadius: ban kinh
// iColor mau bien
_Hexagon::_Hexagon(int x, int y, int iRadius, int iColor)
{
	CreateHexagon(x, y, iRadius, iColor);
}
// pCenter: tam cua hinh luc giac deu
// iRadius: ban kinh
// iColor mau bien
_Hexagon::_Hexagon(POINT pCenter, int iRadius, int iColor)
{
	CreateHexagon(pCenter.x, pCenter.y, iRadius, iColor);
}
// (x,y) tam cua hinh luc giac deu
// iRadius: ban kinh
// iColor mau bien
void _Hexagon::CreateHexagon(int x, int y, int iRadius, int iColor)
{
	strError = "";
	CreateEquilateralPolygon(6, -PI/2, x, y, iRadius, iColor);
	strError += _Polygon::GetError();
}
_Hexagon::~_Hexagon(void)
{

}
