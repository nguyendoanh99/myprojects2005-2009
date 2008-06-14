#include "stdafx.h"
#include "_Line.h"

_Line::_Line(POINT pBegin, POINT pEnd, int color)
{
	m_pBegin = pBegin;
	m_pEnd = pEnd;
	m_iColor = color;
}

_Line::_Line(int x1, int y1, int x2, int y2, int color)
{
	m_pBegin.x = x1;
	m_pBegin.y = y1;
	m_pEnd.x = x2;
	m_pEnd.y = y2;
	m_iColor = color;
}
int _Line::GetX1()
{
	return m_pBegin.x;
}
int _Line::GetX2()
{
	return m_pEnd.x;
}
int _Line::GetY1()
{
	return m_pBegin.y;
}
int _Line::GetY2()
{
	return m_pEnd.y;
}
POINT _Line::GetPointBegin()
{
	return m_pBegin;
}
POINT _Line::GetPointEnd()
{
	return m_pEnd;
}
int _Line::GetColor()
{
	return m_iColor;
}