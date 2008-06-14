#ifndef _LHCN_DAC_
#define _LHCN_DAC_

#include "LHCN.h"

class LHCNDac: public LHCN
{
public:
	LHCNDac(int iX = 1, int iY = 1, int iRong = 1, int iDai = 1, int iMau = 15);
	LHCNDac(const LDiem& , int iRong = 1, int iDai = 1);
	LHCNDac(const LDiem& Diem1, const LDiem& Diem2);
	LHCNDac(const LHCN&);
	LHCNDac(const LHCNDac&);

	void In() const;
	void Xoa() const;
};

#endif