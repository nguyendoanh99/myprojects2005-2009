#pragma once
#include "_areafilling.h"

class _Seed :
	public _AreaFilling
{
private:
	POINT m_pStart; // Diem bat dau de to
	static CString strError;
public:
	static CString GetError();
	_Seed(POINT Start, int Color);
	_Seed(int x, int y, int Color);
	void Fill(CDC *pDC);	
	virtual ~_Seed(void);
};
