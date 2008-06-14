// stdafx.cpp : source file that includes just the standard includes
// Circle.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <fstream>
#include "_Circle.h"
#include "_MidPoint.h"

// Ve hinh tron
// Doc tu tap tin thong tin cac hinh tron can ve va ve ra man hinh
// Cau truc file nhu sau:
// Dong dau gom 1 so nguyen duong n
// n: so hinh tron can ve
// n dong tiep theo, moi dong gom 6 so nguyen: x y Radius r g b
// (x,y) tam cua hinh tron
// Radius: Ban kinh cua hinh tron (Radius > 0)
// (r,g,b) mau bien cua hinh tron do, xac dinh boi ham RGB (r >= 0,  g >= 0, b >= 0)
int ReadFileCircle(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int r, g, b;
	int x, y, Radius;	
	int i;
	CArray<_Circle*> arrCircle;

	if (!f)
	{
		return 0;
	}

	f >> n;	

	for (i = 0; i < n; ++i)
	{
		f >> x >> y >> Radius >> r >> g >> b;
		arrCircle.Add(new _MidPoint(x, y, Radius, RGB(r, g, b)));
		arrCircle[i]->Show(pDC);
	}	
	for (i = 0; i < n; ++i)
	{
		delete arrCircle[i];
	}

	return 1;
}