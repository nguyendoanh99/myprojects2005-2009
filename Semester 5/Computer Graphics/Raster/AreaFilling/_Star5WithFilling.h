#pragma once
#include "_star5.h"
#include "_AreaFilling.h"

class _Star5WithFilling : 
	public _Star5
{
private:
	CArray<_AreaFilling*> m_BackGround; // To mau nen
	static CString strError;
	void CreateStar5WithFilling(int BackGround);
	void RemoveAreaFilling(); // Thu hoi cac vung to da duoc cap phat
public:
	// Cho biet loi phat sinh khi xu ly
	static CString GetError();	
	// (x,y) tam cua hinh sao 5 canh
	// iRadius: ban kinh
	// iColor mau bien
	// BackGround mau nen
	_Star5WithFilling(int x, int y, int iRadius, int iColor, int BackGround);
	// pCenter: tam cua hinh sao 5 canh
	// iRadius: ban kinh
	// iColor mau bien
	// BackGround mau nen
	_Star5WithFilling(POINT pCenter, int iRadius, int iColor, int BackGround);
	void Show(CDC *pDC);
	virtual ~_Star5WithFilling(void);
};
