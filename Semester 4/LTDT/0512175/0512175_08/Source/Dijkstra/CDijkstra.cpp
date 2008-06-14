#include "CDijkstra.h"
#include "stdio.h"

CDijkstra::CDijkstra()
{
	m_arrcBelongT = 0;
	m_arrfLength = 0;
	m_arriLastV = 0;
}

CDijkstra::~CDijkstra()
{
	if (m_arrcBelongT)
		delete []m_arrcBelongT;

	if (m_arrfLength)
		delete []m_arrfLength;

	if (m_arriLastV)
		delete []m_arriLastV;
}

void CDijkstra::Init(int x, int y)
{
	int n = nVer();

	m_arrcBelongT = new char[n + 1];
	m_arrfLength = new float[n + 1];
	m_arriLastV = new int[n + 1];

	for (int i = 1; i <= n; ++i)
	{
		m_arrcBelongT[i] = 1;
		m_arrfLength[i] = Extremity;
		m_arriLastV[i] = -1;
	}

	m_arrfLength[x] = 0;
}

int CDijkstra::FindVertex()
{
	int kq = -1;
	for (int i = 1; i <= nVer(); ++i)
		if (m_arrcBelongT[i] == 1 && m_arrfLength[i] != Extremity && 
			(kq == -1 || m_arrfLength[i] < m_arrfLength[kq]))
			kq = i;

	return kq;
}

void CDijkstra::ImprovePaths(int v)
{
	float kc;

	for (int i = 1; i <= nVer(); ++i)
	{
		kc = Distance(v, i);
		if (m_arrcBelongT[i] == 1 && kc > 0 && 
			(m_arrfLength[i] == Extremity || (m_arrfLength[i] > m_arrfLength[v] + kc)))
		{
			m_arrfLength[i] = m_arrfLength[v] + kc;
			m_arriLastV[i] = v;
		}
	}
}

float CDijkstra::Run(int x, int y)
{
	int v;
	Init(x, y);
	while (m_arrcBelongT[y])	// Buoc 2
	{
		v = FindVertex();		// Buoc 3
		if (v == -1)
			break;
		m_arrcBelongT[v] = 0;

		ImprovePaths(v);		// Buoc 4
	}

	return m_arrfLength[y];
}

int CDijkstra::PrintPath(int x, int y, char *A)
{
	int kq = 0;
	if (m_arrcBelongT[y] == 0)
	{
		char *temp = new char[1000];
		int v = y;
		while (v != x)
		{		
			A[kq] = v;
			++kq;
			v = m_arriLastV[v];
		}
		
		A[kq] = v;
		++kq; // dinh dau
	}

	return kq;
}