// Cap nhat 8/4/2007, 15:55
#include "CDoiSanhChuoi.h"
#include <string.h>
CDoiSanhChuoi::CDoiSanhChuoi()
{
	m_strT = 0;
	m_strP = 0;
}

CDoiSanhChuoi::CDoiSanhChuoi(char *T1, char *P1)
{
	GanT(T1);
	GanP(P1);
}

CDoiSanhChuoi::CDoiSanhChuoi(const CDoiSanhChuoi& Q)
{
	GanT(Q.m_strT);
	GanP(Q.m_strP);
}

CDoiSanhChuoi& CDoiSanhChuoi::operator = (const CDoiSanhChuoi& Q)
{
	if (!m_strT)
		delete []m_strT;

	if (!m_strP)
		delete []m_strP;

	GanT(Q.m_strT);
	GanP(Q.m_strP);

	return *this;
}

CDoiSanhChuoi::~CDoiSanhChuoi()
{
	if (!m_strT)
		delete []m_strT;

	if (!m_strP)
		delete []m_strP;
}

void CDoiSanhChuoi::GanT(char *T1)
{
	int lenT = strlen(T1);
	m_strT = new char[lenT + 1];

	strcpy(m_strT, T1);
}

void CDoiSanhChuoi::GanP(char *P1)
{
	int lenP = strlen(P1);
	m_strP = new char[lenP + 1];

	strcpy(m_strP, P1);
}

char *CDoiSanhChuoi::LayP()
{
	char *temp = new char[strlen(m_strP) + 1];

	strcpy(temp, m_strP);
	return temp;
}

char *CDoiSanhChuoi::LayT()
{
	char *temp = new char[strlen(m_strT) + 1];

	strcpy(temp, m_strT);
	return temp;
}