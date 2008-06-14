// stdafx.cpp : source file that includes just the standard includes
// AreaFilling.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <fstream>
#include "_Polygon.h"
#include "_Star5.h"
#include "_AreaFilling.h"
#include "_Seed.h"
#include "_ScanLineTriangle.h"
#include "_Star5WithFilling.h"
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
	_AreaFilling *fill;
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
	// To mau
	fill = new _Seed(x, y + 10, RGB(r, g, b));
	fill->Fill(pDC);

	for (i = 0; i < n; ++i)
	{
		delete arrStar5[i];
	}

	return 1;
}
// To tam giac
// Doc tu tap tin thong tin cac tam giac can to
// Cau truc file nhu sau:
// Dong dau gom 1 so nguyen duong n
// n: so tam giac can to
// n dong tiep theo, moi dong gom 9 so nguyen: x1 y1 x2 y2 x3 y3 r g b
// (x1,y1) (x2,y2) (x3,y3) la toa do 3 dinh cua tam giac
// (r,g,b) mau to cua tam giac do, xac dinh boi ham RGB (r >= 0,  g >= 0, b >= 0)
int ReadFileScanLineTriangle(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	int x1, y1, x2, y2, x3, y3;	
	int i;
	CArray<_AreaFilling*> arrScanLineTriangle;

	if (!f)
	{
		return 0;
	}

	f >> n;	

	for (i = 0; i < n; ++i)
	{
		f >> x1 >> y1 >> x2 >> y2 >> x3 >> y3 >> r >> g >> b;
		arrScanLineTriangle.Add(new _ScanLineTriangle(x1, y1, x2, y2, x3, y3, RGB(r, g, b)));
		arrScanLineTriangle[i]->Fill(pDC);
	}	
	for (i = 0; i < n; ++i)
	{
		delete arrScanLineTriangle[i];
	}

	return 1;
}
// Ve hinh sao 5 canh co to mau nen
// Doc tu tap tin thong tin cac hinh sao 5 canh can ve va ve ra man hinh
// Cau truc file nhu sau:
// Dong dau gom 1 so nguyen duong n
// n: so hinh sao 5 canh can ve
// n dong tiep theo, moi dong gom 9 so nguyen: x y Radius r1 g1 b1 r2 g2 b2
// (x,y) tam cua hinh sao 5 canh
// Radius: Ban kinh cua hinh sao 5 canh (Radius > 0)
// (r1,g1,b1) mau bien cua hinh sao 5 canh do, xac dinh boi ham RGB (r1 >= 0,  g1 >= 0, b1 >= 0)
// (r2,g2,b2) mau nen cua hinh sao 5 canh do, xac dinh boi ham RGB (r2 >= 0,  g2 >= 0, b2 >= 0)
int ReadFileStar5WithFilling(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	int r2, g2, b2;
	int x, y, Radius;	
	int i;
	CArray<_Polygon*> arrStar5WithFilling;	
	if (!f)
	{
		return 0;
	}

	f >> n;	

	for (i = 0; i < n; ++i)
	{
		f >> x >> y >> Radius >> r >> g >> b >> r2 >> g2 >> b2;
		arrStar5WithFilling.Add(new _Star5WithFilling(x, y, Radius, RGB(r, g, b), RGB(r2, g2, b2)));
		arrStar5WithFilling[i]->Show(pDC);
	}		

	for (i = 0; i < n; ++i)
	{
		delete arrStar5WithFilling[i];
	}

	return 1;
}