// stdafx.cpp : source file that includes just the standard includes
// Polygon.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "_Polygon.h"
#include "_Triangle.h"
#include "_Rectangle.h"
#include "_Pentagon.h"
#include "_Hexagon.h"
#include "_Star5.h"
#include <fstream>
// Ve da giac
// Doc tu tap tin thong tin cua da giac can ve va ve ra man hinh
// Cau truc file nhu sau:
// Dong dau gom 4 so nguyen duong n r g b
// n: so dinh cua da giac (n > 2)
// (r,g,b) mau bien cua da giac xac dinh boi ham RGB
// n dong tiep theo, moi dong gom 2 so nguyen: x y
// (x,y) toa do dinh da giac
int ReadFilePolygon(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	POINT temp;
	CArray<POINT> arrPoint;
	if (!f)
	{
		return 0;
	}

	f >> n >> r >> g >> b;
	int color = RGB(r, g, b);
	for (int i = 0; i < n; ++i)
	{
		f >> temp.x >> temp.y;
		arrPoint.Add(temp);
	}	
	_Polygon p(arrPoint, color);
	p.Show(pDC);
	return 1;
}
// Ve tam giac
// Doc tu tap tin thong tin cac tam giac can ve va ve ra man hinh
// Cau truc file nhu sau:
// Dong dau gom 1 so nguyen duong n
// n: so tam giac can ve
// n dong tiep theo, moi dong gom 9 so nguyen: x1 y1 x2 y2 x3 y3 r g b
// (x1,y1) (x2,y2) (x3,y3) la toa do 3 dinh cua tam giac
// (r,g,b) mau bien cua tam giac do, xac dinh boi ham RGB (r >= 0,  g >= 0, b >= 0)
int ReadFileTriangle(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	int x1, y1, x2, y2, x3, y3;	
	int i;
	CArray<_Polygon*> arrTriangle;

	if (!f)
	{
		return 0;
	}

	f >> n;	

	for (i = 0; i < n; ++i)
	{
		f >> x1 >> y1 >> x2 >> y2 >> x3 >> y3 >> r >> g >> b;
		arrTriangle.Add(new _Triangle(x1, y1, x2, y2, x3, y3, RGB(r, g, b)));
		arrTriangle[i]->Show(pDC);
	}	
	for (i = 0; i < n; ++i)
	{
		delete arrTriangle[i];
	}

	return 1;
}
// Ve hinh chu nhat
// Doc tu tap tin thong tin cac hinh chu nhat can ve va ve ra man hinh
// Cau truc file nhu sau:
// Dong dau gom 1 so nguyen duong n
// n: so hinh chu nhat can ve
// n dong tiep theo, moi dong gom 7 so nguyen: x1 y1 x2 y2 r g b
// (x1,y1) la toa do dinh tren trai cua hinh chu nhat
// (x2,y2) la toa do dinh duoi phai cua hinh chu nhat
// (r,g,b) mau bien cua hinh chu nhat do, xac dinh boi ham RGB (r >= 0,  g >= 0, b >= 0)
int ReadFileRectangle(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	int x1, y1, x2, y2;	
	int i;
	CArray<_Polygon*> arrRectangle;

	if (!f)
	{
		return 0;
	}

	f >> n;	

	for (i = 0; i < n; ++i)
	{
		f >> x1 >> y1 >> x2 >> y2 >> r >> g >> b;
		arrRectangle.Add(new _Rectangle(x1, y1, x2, y2, RGB(r, g, b)));
		arrRectangle[i]->Show(pDC);
	}	
	for (i = 0; i < n; ++i)
	{
		delete arrRectangle[i];
	}

	return 1;
}
// Ve hinh ngu giac deu
// Doc tu tap tin thong tin cac hinh ngu giac deu can ve va ve ra man hinh
// Cau truc file nhu sau:
// Dong dau gom 1 so nguyen duong n
// n: so hinh ngu giac deu can ve
// n dong tiep theo, moi dong gom 6 so nguyen: x y Radius r g b
// (x,y) tam cua hinh ngu giac deu
// Radius: Ban kinh cua hinh ngu giac deu (Radius > 0)
// (r,g,b) mau bien cua hinh ngu giac deu do, xac dinh boi ham RGB (r >= 0,  g >= 0, b >= 0)
int ReadFilePentagon(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	int x, y, Radius;	
	int i;
	CArray<_Polygon*> arrPentagon;

	if (!f)
	{
		return 0;
	}

	f >> n;	

	for (i = 0; i < n; ++i)
	{
		f >> x >> y >> Radius >> r >> g >> b;
		arrPentagon.Add(new _Pentagon(x, y, Radius, RGB(r, g, b)));
		arrPentagon[i]->Show(pDC);
	}	
	for (i = 0; i < n; ++i)
	{
		delete arrPentagon[i];
	}

	return 1;
}
// Ve hinh luc giac deu
// Doc tu tap tin thong tin cac hinh luc giac deu can ve va ve ra man hinh
// Cau truc file nhu sau:
// Dong dau gom 1 so nguyen duong n
// n: so hinh luc giac deu can ve
// n dong tiep theo, moi dong gom 6 so nguyen: x y Radius r g b
// (x,y) tam cua hinh luc giac deu
// Radius: Ban kinh cua hinh luc giac deu (Radius > 0)
// (r,g,b) mau bien cua hinh luc giac deu do, xac dinh boi ham RGB (r >= 0,  g >= 0, b >= 0)
int ReadFileHexagon(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	int x, y, Radius;	
	int i;
	CArray<_Polygon*> arrHexagon;

	if (!f)
	{
		return 0;
	}

	f >> n;	

	for (i = 0; i < n; ++i)
	{
		f >> x >> y >> Radius >> r >> g >> b;
		arrHexagon.Add(new _Hexagon(x, y, Radius, RGB(r, g, b)));
		arrHexagon[i]->Show(pDC);
	}	
	for (i = 0; i < n; ++i)
	{
		delete arrHexagon[i];
	}

	return 1;
}
// Ve hinh sao 5 canh
// Doc tu tap tin thong tin cac hinh sao 5 canh can ve va ve ra man hinh
// Cau truc file nhu sau:
// Dong dau gom 1 so nguyen duong n
// n: so hinh sao 5 canh can ve
// n dong tiep theo, moi dong gom 6 so nguyen: x y Radius r g b
// (x,y) tam cua hinh sao 5 canh
// Radius: Ban kinh cua hinh sao 5 canh (Radius > 0)
// (r,g,b) mau bien cua hinh sao 5 canh do, xac dinh boi ham RGB (r >= 0,  g >= 0, b >= 0)
int ReadFileStar5(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	int x, y, Radius;	
	int i;
	CArray<_Polygon*> arrStar5;

	if (!f)
	{
		return 0;
	}

	f >> n;	

	for (i = 0; i < n; ++i)
	{
		f >> x >> y >> Radius >> r >> g >> b;
		arrStar5.Add(new _Star5(x, y, Radius, RGB(r, g, b)));
		arrStar5[i]->Show(pDC);
	}	
	for (i = 0; i < n; ++i)
	{
		delete arrStar5[i];
	}

	return 1;
}