// stdafx.cpp : source file that includes just the standard includes
// Line.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "_DDA.h"
#include "_Bresenham.h"
#include <fstream>
// Ve theo phuong phap DDA
// Doc tu tap tin thong tin cua cac doan thang va ve
// Cau truc file nhu sau:
// Dong dau: n: so doan thang 
// n dong tiep theo, moi dong gom 7 so nguyen: x1 y1 x2 y2 r g b
// (x1,y1) toa do dau cua doan thang
// (x2,y2) toa do cuoi cua doan thang
// (r,g,b) mau ve xac dinh boi ham RGB (r >= 0, g >= 0, b >= 0)
int ReadFileDDA(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int x1, y1, x2, y2, r, g, b;		
	_Line *l;		
	if (!f)
	{
		return 0;
	}

	f >> n;
	for (int i = 0; i < n; ++i)
	{
		f >> x1 >> y1 >> x2 >> y2 >> r >> g >> b;
		l = new _DDA(x1, y1, x2, y2, RGB(r,g,b));
		l->Show(pDC);
		delete l;
	}	
	return 1;
}
// Ve theo phuong phap Bresenham
int ReadFileBresenham(char *filename, CDC *pDC)
{
	std::ifstream f(filename);	
	int n;
	int x1, y1, x2, y2, r, g, b;		
	_Line *l;		
	if (!f)
	{
		return 0;
	}

	f >> n;
	for (int i = 0; i < n; ++i)
	{
		f >> x1 >> y1 >> x2 >> y2 >> r >> g >> b;
		l = new _Bresenham(x1, y1, x2, y2, RGB(r,g,b));
		l->Show(pDC);
		delete l;
	}	
	return 1;
}