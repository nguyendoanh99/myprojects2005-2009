#pragma once
#include "_circle.h"

class _MidPoint :
	public _Circle
{
private:
	static CString strError;	
public:
	static CString GetError();
	_MidPoint(int x, int y, int Radius, int Color);
	_MidPoint(POINT Center, int Radius, int Color);
	void Show(CDC *pDC);
	virtual ~_MidPoint(void);
};
