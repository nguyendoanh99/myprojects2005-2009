#pragma once

class _AreaFilling
{
private:
	static CString strError;
	int m_iColor; // Mau to
public:
	static CString GetError();
	_AreaFilling(int Color);
	virtual void Fill(CDC *pDC) = 0;
	virtual ~_AreaFilling(void);
	int GetColor();
};
