#include "CBitmap.h"
#include "memory.h"

CBitmap::CBitmap()
{
	m_usLen = 0;
	m_arrBit = 0;
}

CBitmap::CBitmap(char c)
{
	m_usLen = 8;
	m_arrBit = new char;
	*m_arrBit = c;
}

CBitmap::CBitmap(unsigned short usLen)
{
	m_arrBit = 0;
	Resize(usLen);
}

CBitmap::~CBitmap()
{
	if (m_arrBit)
		delete []m_arrBit;

	m_arrBit = 0;
	m_usLen = 0;
}

CBitmap::CBitmap(const CBitmap &P)
{
	m_usLen = P.m_usLen;
	int t = (m_usLen / 8) + (m_usLen % 8 ? 1 : 0);
	m_arrBit = new char[t];
	memcpy(m_arrBit, P.m_arrBit, t);
}

CBitmap& CBitmap::operator=(const CBitmap &P)
{
	if (m_arrBit)
		delete []m_arrBit;

	m_usLen = P.m_usLen;
	int t = (m_usLen / 8) + (m_usLen % 8 ? 1 : 0);
	m_arrBit = new char[t];
	memcpy(m_arrBit, P.m_arrBit, t);

	return *this;
}

void CBitmap::Resize(unsigned short usLen)
{
	m_usLen = usLen;
	if (m_usLen)			
	{
		if (m_arrBit)
			delete []m_arrBit;

		int t = (m_usLen / 8) + (m_usLen % 8 ? 1 : 0);
		m_arrBit = new char[t];
		memset(m_arrBit, 0, t);
	}
	else
		m_arrBit = 0;
}

bool CBitmap::Read(unsigned short usIndex, char *kq) const
{
	if (usIndex >= m_usLen)
		return false;

	int t = (m_usLen / 8) + (m_usLen % 8 ? 1 : 0);
	t -= (usIndex / 8);
	*kq = (m_arrBit[t - 1] >> (usIndex % 8)) & 0x1;
	return true;		
}

bool CBitmap::Write(unsigned short usIndex, char c)
{
	if (usIndex >= m_usLen)
		return false;

	char temp;
	int t = (m_usLen / 8) + (m_usLen % 8 ? 1 : 0);
	t -= (usIndex / 8);
	if (c)
	{
		temp = 1;		
		temp <<= (usIndex % 8);

		m_arrBit[t - 1] |= temp;
	}
	else
	{
		temp = (char) 0xff;		
		temp <<= 1;
		for (int i = 0; i < usIndex % 8; ++i)
		{
			temp <<= 1;
			temp |= 0x01;
		}

		m_arrBit[t - 1] &= temp;
	}

	return true;
}

unsigned short CBitmap::GetLength() const 
{
	return m_usLen;
}

ostream& operator << (ostream &os, const CBitmap& P)
{
	char kq;
	for (int i = P.m_usLen - 1; i >= 0; --i)
	{
		P.Read(i, &kq);
		os << (int) kq;
	}

	return os;
}

void CBitmap::Convert(char *kq) const
{
	int t = (m_usLen / 8) + (m_usLen % 8 ? 1 : 0);
	for (int i = 0; i < t; ++i)
		kq[i] = m_arrBit[i];
}