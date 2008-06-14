// Cap nhat 8/4/2007, 15:55
#ifndef _CKMP
#define _CKMP

#include "CDoiSanhChuoi.h"

class CKMP: public CDoiSanhChuoi
{
private:
	int *m_iNext;
	void TaoBangNext();
public:
	CKMP();
	CKMP(char *, char *);
	CKMP(const CKMP&);
	CKMP(const CDoiSanhChuoi&);
	CKMP& operator= (const CKMP&);
	CKMP& operator= (const CDoiSanhChuoi&);
	virtual ~CKMP();

	int ViTriTimThay(int iBatDau = 0);
	void GanP(char *P);
};
#endif