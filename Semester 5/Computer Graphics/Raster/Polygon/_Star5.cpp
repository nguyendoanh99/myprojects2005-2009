#include "StdAfx.h"
#include "_Star5.h"
#include "math.h"

#define PI 3.1415926535897932384626433832795
CString _Star5::strError = CString("");

CString _Star5::GetError()
{
	return strError;
}
// (x,y) tam cua hinh sao 5 canh
// iRadius: ban kinh
// iColor mau bien
_Star5::_Star5(int x, int y, int iRadius, int iColor)
{
	CreateStar5(x, y, iRadius, iColor);
}
// pCenter: tam cua hinh sao 5 canh
// iRadius: ban kinh
// iColor mau bien
_Star5::_Star5(POINT pCenter, int iRadius, int iColor)
{
	CreateStar5(pCenter.x, pCenter.y, iRadius, iColor);
}
// (x,y) tam cua hinh sao 5 canh
// iRadius: ban kinh
// iColor mau bien
void _Star5::CreateStar5(int x, int y, int iRadius, int iColor)
{
	strError = "";
	CreateStar(5, -PI/2, x, y, iRadius, iColor);
	strError += _Polygon::GetError();
}
_Star5::~_Star5(void)
{

}
