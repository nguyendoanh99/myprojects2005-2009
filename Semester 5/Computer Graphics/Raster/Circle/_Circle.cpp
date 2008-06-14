#include "StdAfx.h"
#include "_Circle.h"

CString _Circle::strError = CString("");
_Circle::_Circle(int x, int y, int iRadius, int iColor)
{
	CreateCircle(x, y, iRadius, iColor);
}
_Circle::_Circle(POINT pCenter, int iRadius, int iColor)
{
	CreateCircle(pCenter.x, pCenter.y, iRadius, iColor);
}
void _Circle::CreateCircle(int x, int y, int iRadius, int iColor)
{
	strError = "";
	if (iRadius <= 0)
	{
		strError = "_Circle::CreateCircle() --> iRadius: ban kinh phai lon hon 0";
		iRadius = 1;
	}
	m_pCenter.x = x;
	m_pCenter.y = y;
	m_iRadius = iRadius;
	m_iColor = iColor;
}
POINT _Circle::GetCenter()
{
	return m_pCenter;
}
int _Circle::GetColor()
{
	return m_iColor;
}
int _Circle::GetRadius()
{
	return m_iRadius;
}
_Circle::~_Circle(void)
{
}

