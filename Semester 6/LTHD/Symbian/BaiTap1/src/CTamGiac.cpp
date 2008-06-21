#include "CTamGiac.h"
#include <e32math.h>
CTamGiac::~CTamGiac()
{
	delete iA;
	delete iB;
	delete iC;
}
void CTamGiac::ConstructL(TDiem aA, TDiem aB, TDiem aC)
{
	iA = new (ELeave) TDiem(aA);
	iB = new (ELeave) TDiem(aB);
	iC = new (ELeave) TDiem(aC);
}
CTamGiac* CTamGiac::NewL(TDiem aA, TDiem aB, TDiem aC)
{
	CTamGiac* self=NewLC(aA, aB, aC);
	CleanupStack::Pop();
	return self;
}
CTamGiac* CTamGiac::NewLC(TDiem aA, TDiem aB, TDiem aC)
{
	CTamGiac* self = new (ELeave) CTamGiac();
	CleanupStack::PushL(self);
	self->ConstructL(aA, aB, aC);
	return self;
}
TReal CTamGiac::ChuVi()
{
	TReal kq = 0;
	
	TReal AB = iA->KhoangCach(*iB);
	TReal AC = iA->KhoangCach(*iC);
	TReal BC = iB->KhoangCach(*iC);
	kq = AB + AC + BC;
	
	return kq;
}
TReal CTamGiac::DienTich()
{
	TReal kq = 0;
	
	TReal p = ChuVi() / 2;
	TReal AB = iA->KhoangCach(*iB);
	TReal AC = iA->KhoangCach(*iC);
	TReal BC = iB->KhoangCach(*iC);
	Math::Sqrt(kq, p * (p - AB) * (p - BC) * (p - AC));
	
	return kq;
}
void CTamGiac::TaoLoiL()
{
	TReal kq;
	
	TReal p = ChuVi() / 2;
	TReal AB = iA->KhoangCach(*iB);
	TReal AC = iA->KhoangCach(*iC);
	TReal BC = iB->KhoangCach(*iC);
	Math::Sqrt(kq, -p * (p - AB) * (p - BC) * (p - AC));
	
}