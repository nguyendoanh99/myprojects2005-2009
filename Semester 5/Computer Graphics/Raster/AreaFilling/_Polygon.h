#ifndef  _POLYGON_
#define _POLYGON_
#include "_Line.h"
class _Polygon
{
private:
	CArray<_Line*> m_arrLine;	
	static CString strError;
	void RemovePolygon(); // Xoa da giac
protected:	
	_Polygon(); // Ham mac dinh, duoc su dung boi cac ham khoi tao cua lop ke thua tu lop _Polygon
	void CreatePolygon(const CArray<POINT> &arrPoint, int iColor); // Tao da giac moi
	void CreateEquilateralPolygon(int iIdentity, double dAlpha, int x, int y, int iRadius, int iColor); // Tao da giac deu
	void CreateStar(int iIdentity, double dAlpha, int x, int y, int iRadius, int iColor); // Tao hinh sao
	POINT GetPoint(int Num); // Cho biet toa do cua 1 dinh bat ky cua da giac
public:
	// Xem loi phat sinh
	static CString GetError();
	// Tao da giac tu mot tap hop diem
	_Polygon(const CArray<POINT> &arrPoint, int iColor);
	virtual ~_Polygon();
	virtual void Show(CDC *pDC);
//	void Hide();
};

#endif