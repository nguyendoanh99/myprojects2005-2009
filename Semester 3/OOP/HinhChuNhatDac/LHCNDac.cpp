#include "LHCNDac.h"

LHCNDac::LHCNDac(int iX, int iY, int iRong, int iDai, int iMau):
LHCN(iX, iY, iRong, iDai, iMau)
{
}

LHCNDac::LHCNDac(const LDiem& P, int iRong, int iDai): LHCN(P, iRong, iDai)
{
}

LHCNDac::LHCNDac(const LDiem& Diem1, const LDiem& Diem2): LHCN(Diem1, Diem2)
{
}

LHCNDac::LHCNDac(const LHCN& P): LHCN(P)
{
}

LHCNDac::LHCNDac(const LHCNDac& P): LHCN(P)
{
}

void LHCNDac::In() const
{	
	LDiem Ve(LHCN::DocGoc());
	
	Ve.GanKyTu(219);
	for (int i = 1; i <= LHCN::DocDai(); ++i)
	{
		for (int j = 1; j <= LHCN::DocRong(); ++j)
		{
			Ve.In();
			Ve.DichPhai();			
		}
		Ve.DichTrai(LHCN::DocRong());
		Ve.DichXuong();
	}	
}

void LHCNDac::Xoa() const
{	
	LDiem Ve(LHCN::DocGoc());	
	
	for (int i = 1; i <= LHCN::DocDai(); ++i)
	{
		for (int j = 1; j <= LHCN::DocRong(); ++j)
		{
			Ve.Xoa();
			Ve.DichPhai();			
		}
		Ve.DichTrai(LHCN::DocRong());
		Ve.DichXuong();
	}
}