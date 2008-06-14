#include "StdAfx.h"
#include "_MidPoint.h"

CString _MidPoint::strError = CString("");
_MidPoint::_MidPoint(int x, int y, int iRadius, int iColor): _Circle(x, y, iRadius, iColor)
{
}
_MidPoint::_MidPoint(POINT pCenter, int iRadius, int iColor): _Circle(pCenter, iRadius, iColor)
{
}
CString _MidPoint::GetError()
{
	return strError;
}
void _MidPoint::Show(CDC *pDC)
{
	strError = "";
	int iColor = GetColor();
	POINT pCenter = GetCenter();
	int x = 0;
	int y = GetRadius();
	double f = 1 - GetRadius();

	pDC->SetPixel(x + pCenter.x, y + pCenter.y, iColor);
	pDC->SetPixel(x + pCenter.x, -y + pCenter.y, iColor);
	pDC->SetPixel(y + pCenter.x, x + pCenter.y, iColor);
	pDC->SetPixel(-y + pCenter.x, -x + pCenter.y, iColor);
	while (x < y)
	{
		if (f < 0)	
			f += 2 * x + 3;
		else
		{
			f += 2 * x - 2 * y + 5;
			--y;
		}
		++x;		
		pDC->SetPixel(x + pCenter.x, y + pCenter.y, iColor);
		pDC->SetPixel(-x + pCenter.x, y + pCenter.y, iColor);
		pDC->SetPixel(x + pCenter.x, -y + pCenter.y, iColor);
		pDC->SetPixel(-x + pCenter.x, -y + pCenter.y, iColor);
		pDC->SetPixel(y + pCenter.x, x + pCenter.y, iColor);
		pDC->SetPixel(-y + pCenter.x, x + pCenter.y, iColor);
		pDC->SetPixel(y + pCenter.x, -x + pCenter.y, iColor);
		pDC->SetPixel(-y + pCenter.x, -x + pCenter.y, iColor);
		Sleep(10);
	}
}
_MidPoint::~_MidPoint(void)
{
}
