// Cap nhat 8/4/2007, 15:55
#include "CBruteForce.h"
#include <string.h>

CBruteForce::CBruteForce(): CDoiSanhChuoi()
{
}

CBruteForce::CBruteForce(char *T, char *P): CDoiSanhChuoi(T, P)
{
}

CBruteForce::CBruteForce(const CBruteForce& Q): CDoiSanhChuoi(Q)
{
}

CBruteForce::CBruteForce(const CDoiSanhChuoi &Q): CDoiSanhChuoi(Q)
{
}

CBruteForce::~CBruteForce()
{
}

CBruteForce& CBruteForce::operator = (const CBruteForce& Q)
{
	CDoiSanhChuoi::operator =(Q);
	return *this;
}

CBruteForce& CBruteForce::operator = (const CDoiSanhChuoi& Q)
{
	CDoiSanhChuoi::operator =(Q);
	return *this;
}

int CBruteForce::ViTriTimThay(int iBatDau)
{
	int lenT = strlen(m_strT);
	int lenP = strlen(m_strP);

	for (int i = iBatDau; i <= lenT - lenP; ++i)
	{
		for (int j = 0; j < lenP; ++j)
		{
			if (m_strT[i + j] != m_strP[j])
				break;
		}

		if (j == lenP)
			return i;
	}

	return -1;
}