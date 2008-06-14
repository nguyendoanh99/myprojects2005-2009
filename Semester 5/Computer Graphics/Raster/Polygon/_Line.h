#ifndef _LINE_
#define _LINE_
class _Line
{
private:
	POINT m_pBegin;
	POINT m_pEnd;
	int m_iColor;
public:
	_Line(POINT pBegin, POINT pEnd, int color = 0);
	_Line(int x1, int y1, int x2, int y2, int color = 0);
	virtual void Show(CDC *pDC) = 0;
//	virtual void Hide() = 0;
	//virtual ~_Line();
	POINT GetPointBegin();
	POINT GetPointEnd();
	int GetX1();
	int GetX2();
	int GetY1();
	int GetY2();
	int GetColor();
};

#endif
