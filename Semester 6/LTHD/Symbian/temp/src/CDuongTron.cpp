#include "CDuongTron.h"
#include <e32Math.h>
#define PI 3.1415926535897932384626433832795
CDuongTron::CDuongTron(TInt aR)
{
	iR = aR;
}

CDuongTron::~CDuongTron()
{
	delete iI;
}
void CDuongTron::ConstructL(TDiem aI)
{
	iI = new (ELeave) TDiem(aI);
}
CDuongTron* CDuongTron::NewL(TDiem aI, TInt aR)
{
	CDuongTron* self=NewLC(aI, aR);
	CleanupStack::Pop();
	return self;
}
CDuongTron* CDuongTron::NewLC(TDiem aI, TInt aR)
{
	CDuongTron* self=new (ELeave) CDuongTron(aR);
	CleanupStack::PushL(self);
	self->ConstructL(aI);
	return self;
}
TDiem* CDuongTron::LayTam()
	{
		return iI;
	}
TInt CDuongTron::LayBanKinh()
	{
	return iR;
	}
TReal CDuongTron::ChuVi()
{
	TReal kq = 0;
	kq = 2 * PI * iR;
	return kq;
}

TReal CDuongTron::DienTich()
{
	TReal kq = 0;
	kq = PI * iR * iR;
	return kq;
}
void CDuongTron::TaoLoiL()
{
	TReal t;
	Math::Sqrt(t, -3);
}