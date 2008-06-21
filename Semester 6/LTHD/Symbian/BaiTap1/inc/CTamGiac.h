#ifndef CTAMGIAC_H_
#define CTAMGIAC_H_

#include <e32base.h>
#include "TDiem.h"
class CTamGiac : public CBase
{
public:
//	CTamGiac();
	virtual ~CTamGiac();
	static CTamGiac* NewL(TDiem aA, TDiem aB, TDiem aC);
	static CTamGiac* NewLC(TDiem aA, TDiem aB, TDiem aC);
	TReal ChuVi();
	TReal DienTich();
	void TaoLoiL();
protected:
	CTamGiac(){}
	void ConstructL(TDiem aA, TDiem aB, TDiem aC);
private:
	TDiem* iA;
	TDiem* iB;
	TDiem* iC;
};

#endif /*CTAMGIAC_H_*/
