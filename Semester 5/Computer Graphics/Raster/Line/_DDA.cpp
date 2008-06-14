#include "stdafx.h"
#include "_DDA.h"

int Round(float x)
{
	return (int) (x + 0.5);
}
_DDA::_DDA(POINT pBegin, POINT pEnd, int color): _Line(pBegin, pEnd, color)
{
}

_DDA::_DDA(int x1, int y1, int x2, int y2, int color): _Line(x1, y1, x2, y2, color)
{
}

void _DDA::Show(CDC *pDC)
{
	if (GetX1() == GetX2() && GetY1() == GetY2())
	{
		pDC->SetPixel(GetPointBegin(), GetColor());
		return;
	}
	if (abs(GetX2() - GetX1())  >= abs(GetY2() - GetY1()))	
		Draw1(pDC);	
	else
		Draw2(pDC);
}
// Truong hop 1: tang cham, giam cham
void _DDA::Draw1(CDC *pDC)
{
	int x;
	int stepX; // stepX = 1 : duong thang di tu trai sang phai; -1: nguoc lai
	int color = GetColor();
	float y;	
	float m;

	pDC->SetPixel(GetPointBegin(), color);
	stepX = (GetX1() < GetX2()) ? 1 : -1;
	x = GetX1();
	y = GetY1();
	m = (float) (GetY2() - GetY1()) / (GetX2() - GetX1());
	m *= stepX;

	while (x != GetX2())
	{
		x += stepX;
		y += m;
		pDC->SetPixel(x, Round(y), color);
		Sleep(5);
	}
}
// Truong hop 2: tang nhanh, giam nhanh
void _DDA::Draw2(CDC *pDC)
{
	int y;
	int stepY; // stepY = 1 : duong thang di tu trai sang phai; -1: nguoc lai 
	int color = GetColor();
	float x;	
	float k;

	pDC->SetPixel(GetPointBegin(), color);
	stepY = (GetY1() < GetY2()) ? 1 : -1;
	x = GetX1();
	y = GetY1();
	k = (float) (GetX2() - GetX1())/ (GetY2() - GetY1());
	k *= stepY;

	while (y != GetY2())
	{
		y += stepY;
		x += k;
		pDC->SetPixel(Round(x), y, color);
		Sleep(5);
	}
}