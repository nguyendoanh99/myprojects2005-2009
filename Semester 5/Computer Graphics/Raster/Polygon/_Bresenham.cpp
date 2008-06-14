#include "stdafx.h"
#include "_Bresenham.h"

_Bresenham::_Bresenham(POINT pBegin, POINT pEnd, int color): _Line(pBegin, pEnd, color)
{
}

_Bresenham::_Bresenham(int x1, int y1, int x2, int y2, int color): _Line(x1, y1, x2, y2, color)
{
}

void _Bresenham::Show(CDC *pDC)
{
	int deltaX = GetX2() - GetX1();
	int deltaY = GetY2() - GetY1();

	if (deltaX == 0 && deltaY == 0)
	{
		pDC->SetPixel(GetPointBegin(), GetColor());
		return;
	}
	
	if (abs(deltaX) >= abs(deltaY))
		Draw1(pDC);
	else
		Draw2(pDC);
}
// Truong hop 1: tang cham, giam cham
void _Bresenham::Draw1(CDC *pDC)
{
	int x = GetX1();
	int y = GetY1();
	int deltaX = GetX2() - GetX1();
	int deltaY = GetY2() - GetY1();
	int stepX = deltaX >= 0 ? 1 : -1;
	int stepY = deltaY >= 0 ? 1 : -1;
	deltaX = abs(deltaX);
	deltaY = abs(deltaY);
	int p = 2 * deltaY - deltaX;
	int const1 = 2 * deltaY;
	int const2 = 2 * (deltaY - deltaX);
	int color = GetColor();	
	int X2 = GetX2();

	pDC->SetPixel(GetPointBegin(), color);
	
	while (x != X2)
	{
		if (p < 0)
		{
			p += const1;
		}
		else
		{
			p += const2;
			y += stepY;
		}
		x += stepX;
		pDC->SetPixel(x, y, color);
		Sleep(5);
	}
}
// Truong hop 2: tang nhanh, giam nhanh
void _Bresenham::Draw2(CDC *pDC)
{
	int x = GetX1();
	int y = GetY1();
	int deltaX = GetX2() - GetX1();
	int deltaY = GetY2() - GetY1();
	int stepX = deltaX >= 0 ? 1 : -1;
	int stepY = deltaY >= 0 ? 1 : -1;
	deltaX = abs(deltaX);
	deltaY = abs(deltaY);
	int p = 2 * deltaX - deltaY;
	int const1 = 2 * deltaX;
	int const2 = 2 * (deltaX - deltaY);
	int color = GetColor();	
	int Y2 = GetY2();

	pDC->SetPixel(GetPointBegin(), color);

	while (y != Y2)
	{
		if (p < 0)
		{
			p += const1;
		}
		else
		{
			p += const2;
			x += stepX;
		}
		y += stepY;

		pDC->SetPixel(x, y, color);
		Sleep(5);
	}
}