#ifndef _CBITMAP_H_
#define _CBITMAP_H_

#include <iostream.h>

class CBitmap
{
private:
	char *m_arrBit;
	unsigned short m_usLen;
public:
	CBitmap();
	CBitmap(char);
	CBitmap(unsigned short ucLen);
	CBitmap(const CBitmap &P);
	virtual ~CBitmap();

	void Convert(char *)const;
	CBitmap& operator=(const CBitmap &P);
	void Resize(unsigned short ucLen);
	bool Read(unsigned short ucIndex, char *kq) const;
	bool Write(unsigned short ucIndex, char c);
	unsigned short GetLength() const;

	friend ostream& operator << (ostream &os, const CBitmap& P);
};

#endif