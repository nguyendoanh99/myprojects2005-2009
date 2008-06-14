// Cap nhat 8/4/2007, 15:55
#ifndef _CMP
#define _CMP

#include "CDoiSanhChuoi.h"

class CMP: public CDoiSanhChuoi
{
protected:
	int *m_iNext;
private:
	virtual void TaoBangNext();
public:
	CMP();
	CMP(char *T, char *P);
	CMP(const CMP&);
	CMP(const CDoiSanhChuoi&);
	CMP& operator = (const CMP&);
	CMP& operator = (const CDoiSanhChuoi&);
	virtual ~CMP();

	int ViTriTimThay(int iBatDau = 0);
	void GanP(char *P);
};

#endif