#include "StdAfx.h"
#include "_Seed.h"
#include "fstream"

CString _Seed::strError = CString("");
_Seed::_Seed(POINT pStart, int iColor): _AreaFilling(iColor)
{	
	m_pStart = pStart;
}
_Seed::_Seed(int x, int y, int iColor): _AreaFilling(iColor)
{
	m_pStart.x = x;
	m_pStart.y = y;
}
_Seed::~_Seed(void)
{
}
void _Seed::Fill(CDC *pDC)
{
	strError = "";
	CList<POINT> list;
	// Buoc 1: cat diem hat giong dau tien vao kho
	list.AddTail(m_pStart);

	// Buoc 2
	POINT temp, temp2;	
	int xmin, xmax;
	int x;
	int iColor = GetColor();
	int iBackGroundColor = pDC->GetPixel(m_pStart);

	while (!list.IsEmpty())
	{
		// c1: Lay mot diem hat giong
		temp = list.GetTail();		
		list.RemoveTail();

		xmin = temp.x - 1;
		xmax = temp.x + 1;
		// c2: To diem hat giong sau do to loang sang trai va sang phai
		pDC->SetPixel(temp, iColor);
		int t;
		while ((t = pDC->GetPixel(xmin, temp.y)) == iBackGroundColor)
		{
			pDC->SetPixel(xmin, temp.y, iColor);
			Sleep(1);
			--xmin;
		}

		while (pDC->GetPixel(xmax, temp.y) == iBackGroundColor)
		{
			pDC->SetPixel(xmax, temp.y, iColor);
			Sleep(1);
			++xmax;
		}
		// c3: Bo sung nhung diem hat giong moi vao kho tu nhung diem lan can cua dong vua to
		++xmin;
		--xmax;
		x = xmin;

		while (x <= xmax)
		{
			if (pDC->GetPixel(x, temp.y + 1) != iColor && pDC->GetPixel(x, temp.y + 1) == iBackGroundColor
				&& (x == xmin || pDC->GetPixel(x - 1, temp.y + 1) != iBackGroundColor))
			{
				temp2.x = x;
				temp2.y = temp.y + 1;
				list.AddTail(temp2);
			}

			if (pDC->GetPixel(x, temp.y - 1) != iColor && pDC->GetPixel(x, temp.y - 1) == iBackGroundColor
				&& (x == xmin || pDC->GetPixel(x - 1, temp.y - 1) != iBackGroundColor))
			{
				temp2.x = x;
				temp2.y = temp.y - 1;
				list.AddTail(temp2);
			}
			++x;
		}
	}		
}
CString _Seed::GetError()
{
	return strError;
}