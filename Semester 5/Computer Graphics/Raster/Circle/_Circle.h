#pragma once

class _Circle
{
private:
	POINT m_pCenter; // Tam duong tron
	int m_iRadius; // Ban kinh
	int m_iColor; // Mau bien
	static CString strError;
	void CreateCircle(int x, int y, int Radius, int Color);
public:
	static CString GetError();
	_Circle(int x, int y, int Radius, int Color);
	_Circle(POINT, int Radius, int Color);
	virtual void Show(CDC *pDC) = 0;
	POINT GetCenter();
	int GetRadius();
	int GetColor();
	virtual ~_Circle(void);
};
