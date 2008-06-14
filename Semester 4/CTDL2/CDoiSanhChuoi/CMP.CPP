// Cap nhat 8/4/2007, 15:55
#include "CMP.h"
#include <string.h>

CMP::CMP(): CDoiSanhChuoi()
{
	m_iNext = 0;
}

CMP::CMP(char *T, char *P): CDoiSanhChuoi(T, P)
{
	TaoBangNext();
}

CMP::CMP(const CMP& Q): CDoiSanhChuoi(Q)
{
	int n = strlen(m_strP);
	m_iNext = new int[n];
	memcpy(m_iNext, Q.m_iNext, sizeof(m_iNext) * n);
}

CMP::CMP(const CDoiSanhChuoi &Q): CDoiSanhChuoi(Q)
{
	TaoBangNext();
}

CMP& CMP::operator =(const CMP& Q)
{
	if (m_iNext)
		delete [] m_iNext;

	CDoiSanhChuoi::operator =(Q);

	int n = strlen(m_strP);
	m_iNext = new int[n];
	memcpy(m_iNext, Q.m_iNext, sizeof(m_iNext) * n);

	return *this;
}

CMP& CMP::operator =(const CDoiSanhChuoi& Q) 
{
	if (m_iNext)
		delete []m_iNext;

	CDoiSanhChuoi::operator =(Q);
	TaoBangNext();
	return *this;
}

CMP::~CMP()
{
	if (m_iNext)
		delete []m_iNext;
}

void CMP::TaoBangNext()
{
	m_iNext = new int[strlen(m_strP)];
	
	int j = m_iNext[0] = -1;
	int i = 0;

  	while (i < strlen(m_strP) - 1)
	{
		if (j == -1 || m_iNext[i] == m_iNext[j])
		{
			++i;
			++j;
			m_iNext[i] = j;
		}
		else
			j = m_iNext[j];
	}
}

int CMP::ViTriTimThay(int iBatDau)
{
	int i = 0;
	int j = 0;
	int lenP = strlen(m_strP);

	while (i < strlen(m_strT))
	{
		while (j!= -1 && m_strT[i] != m_strP[j])
			j = m_iNext[j];

		++i;
		++j;
		if (j == lenP)
			return i - j;
	}

	return -1;
}

void CMP::GanP(char *P)
{
	CDoiSanhChuoi::GanP(P);

	if (m_iNext)
		delete []m_iNext;

	TaoBangNext();
}