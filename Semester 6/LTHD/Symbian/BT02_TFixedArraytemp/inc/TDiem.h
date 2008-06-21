#ifndef TDIEM_H_
#define TDIEM_H_
#include "e32def.h"

class TDiem
{
private:
	TInt iX;
	TInt iY;
public:
	TDiem();
	TDiem(TInt aX, TInt aY);
	TDiem(const TDiem& aDiem);
	TInt DiemX();
	TInt DiemY();
	void Gan(TInt aX, TInt aY);
	TReal KhoangCach(TDiem aDiem);
	virtual ~TDiem();
};

#endif /*TDIEM_H_*/
