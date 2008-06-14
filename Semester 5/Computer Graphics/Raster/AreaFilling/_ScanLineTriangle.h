#pragma once
#include "_areafilling.h"

class _ScanLineTriangle :
	public _AreaFilling
{
private:
	POINT m_pPoint[3];	
	static CString strError;
	void CreateScanLineTriangle(int x1, int y1, int x2, int y2, int x3, int y3);
	void Fill1(CDC *pDC); // truong hop 1: Y1 = Y2 = Y3
	void Fill2(CDC *pDC); // truong hop 2: Y1 < Y2 = Y3
	void Fill3(CDC *pDC); // truong hop 3: Y1 = Y2 < Y3
	void Fill4(CDC *pDC); // truong hop 4: Y1 < Y2 < Y3
	void Row(CDC *pDC, int l, int r, int y); // To dong ngang
public:
	static CString GetError();
	_ScanLineTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int Color);
	_ScanLineTriangle(POINT p1, POINT p2, POINT p3, int Color);
	void Fill(CDC *pDC);
	virtual ~_ScanLineTriangle(void);
};
