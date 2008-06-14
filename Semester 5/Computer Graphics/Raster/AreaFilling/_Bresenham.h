#ifndef  _BRESENHAM_
#define  _BRESENHAM_

#include "_Line.h"
class _Bresenham: public _Line
{
private:
	void Draw1(CDC *pDC); // truong hop 1
	void Draw2(CDC *pDC); // truong hop 2
public:
	_Bresenham(POINT pBegin, POINT pEnd, int color = 0);
	_Bresenham(int x1, int y1, int x2, int y2, int color = 0);
//	virtual ~_Bresenham();
	void Show(CDC *pDC);
};
#endif