#ifndef CDUONGTRON_H_
#define CDUONGTRON_H_

#include <e32base.h>
#include "TDiem.h"
class CDuongTron : public CBase
{
public:
	virtual ~CDuongTron();
	static CDuongTron* NewL(TDiem aI, TInt aR);
	static CDuongTron* NewLC(TDiem aI, TInt aR); 
	TReal ChuVi();
	TReal DienTich();
	void TaoLoiL();
	TDiem* LayTam();
	TInt LayBanKinh();
private:
	TDiem* iI;
	TInt iR;
protected:
	CDuongTron(TInt aR);	
	void ConstructL(TDiem aI);
};

#endif /*CDUONGTRON_H_*/
