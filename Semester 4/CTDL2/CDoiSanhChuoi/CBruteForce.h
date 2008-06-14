// Cap nhat 8/4/2007, 15:55
#ifndef _CBRUTEFORCE
#define _CBRUTEFORCE

#include "CDoiSanhChuoi.h"

class CBruteForce: public CDoiSanhChuoi
{
public:
	CBruteForce();
	CBruteForce(char *T, char *P);
	CBruteForce(const CBruteForce&);
	CBruteForce(const CDoiSanhChuoi&);
	virtual ~CBruteForce();
	CBruteForce& operator = (const CBruteForce&);
	CBruteForce& operator = (const CDoiSanhChuoi&);
	int ViTriTimThay(int iBatDau = 0);
};

#endif