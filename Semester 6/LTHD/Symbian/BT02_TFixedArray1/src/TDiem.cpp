#include "TDiem.h"
#include <e32math.h>
TDiem::TDiem()
{
	iX = 0;
	iY = 0;
}
TDiem::TDiem(TInt aX, TInt aY)
{
	iX = aX;
	iY = aY;
}
TDiem::TDiem(const TDiem& aDiem)
{
	iX = aDiem.iX;
	iY = aDiem.iY;
}
TDiem::~TDiem()
{
}
void TDiem::Gan(TInt aX, TInt aY)
	{
		iX = aX;
		iY = aY;
	}
TInt TDiem::DiemX()
	{
	return iX;
	}
TInt TDiem::DiemY()
	{
	return iY;
	}
TReal TDiem::KhoangCach(TDiem aDiem)
{
	TReal kq = 0;

	TReal deltaX = aDiem.iX - iX;
	TReal deltaY = aDiem.iY - iY;

	Math::Sqrt(kq, deltaX * deltaX + deltaY * deltaY);
	return kq;	
}