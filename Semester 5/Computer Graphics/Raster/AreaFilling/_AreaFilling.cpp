#include "StdAfx.h"
#include "_AreaFilling.h"

CString _AreaFilling::strError = CString("");
_AreaFilling::_AreaFilling(int iColor)
{
	m_iColor = iColor;
}

_AreaFilling::~_AreaFilling(void)
{
}
CString _AreaFilling::GetError()
{
	return strError;
}
int _AreaFilling::GetColor()
{
	return m_iColor;
}