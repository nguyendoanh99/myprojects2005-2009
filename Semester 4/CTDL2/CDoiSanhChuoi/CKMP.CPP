// Cap nhat 8/4/2007, 15:55
#include "CKMP.h"
#include <string.h>
#include <iostream.h>
CKMP::CKMP(): CDoiSanhChuoi()
{
	m_iNext = 0;
}

CKMP::CKMP(char *T, char *P): CDoiSanhChuoi(T, P)
{
	TaoBangNext();
}

CKMP::CKMP(const CKMP& Q): CDoiSanhChuoi(Q)
{
	int n = strlen(m_strP);
	m_iNext = new int[n];
	memcpy(m_iNext, Q.m_iNext, sizeof(m_iNext[0]) * n);
}

CKMP::CKMP(const CDoiSanhChuoi &Q): CDoiSanhChuoi(Q)
{
	TaoBangNext();
}

CKMP& CKMP::operator =(const CKMP& Q)
{
	if (m_iNext)
		delete [] m_iNext;

	CDoiSanhChuoi::operator =(Q);

	int n = strlen(m_strP);
	m_iNext = new int[n];
	memcpy(m_iNext, Q.m_iNext, sizeof(m_iNext) * n);

	return *this;
}

CKMP& CKMP::operator =(const CDoiSanhChuoi& Q) 
{
	if (m_iNext)
		delete []m_iNext;

	CDoiSanhChuoi::operator =(Q);
	TaoBangNext();

	return *this;
}

CKMP::~CKMP()
{
	if (m_iNext)
		delete []m_iNext;
}

int CKMP::ViTriTimThay(int iBatDau)
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

void CKMP::GanP(char *P)
{
	CDoiSanhChuoi::GanP(P);

	if (m_iNext)
		delete []m_iNext;

	TaoBangNext();
}

void CKMP::TaoBangNext()
{
	m_iNext = new int[strlen(m_strP)];
	int j = m_iNext[0] = -1;
	int i = 0;

	while (i < strlen(m_strP) - 1)
	{
		if (j == -1 || m_strP[i] == m_strP[j])
		{
			++i;
			++j;

			if (m_strP[i] == m_strP[j])
				m_iNext[i] = m_iNext[j];
			else
				m_iNext[i] = j;
		}
		else 
			j = m_iNext[j];
	}
}