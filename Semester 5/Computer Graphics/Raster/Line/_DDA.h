#ifndef  _DDA_
#define  _DDA_

#include "_Line.h"
class _DDA: public _Line
{
private:
	void Draw1(CDC *pDC); // truong hop 1
	void Draw2(CDC *pDC); // truong hop 2
public:
	_DDA(POINT pBegin, POINT pEnd, int color = 0);
	_DDA(int x1, int y1, int x2, int y2, int color = 0);
//	virtual ~_DDA();
	void Show(CDC *pDC);
};
#endif