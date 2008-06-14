#include "CDBF.h"

CDBF::CDBF()
{
	m_Field = 0;
}

CDBF::~CDBF()
{
	if (m_Field)
		delete []m_Field;
}