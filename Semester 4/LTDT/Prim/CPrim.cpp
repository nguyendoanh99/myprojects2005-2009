#include "CPrim.h"
#include "limits.h"
#include <fstream.h>
#include <iomanip.h>

CPrim::CPrim(): m_Input()
{
	m_W = 0;
}

CPrim::~CPrim()
{
	m_T.clear();
	m_V.clear();
}
// Kiem tra dinh y co thuoc tap dinh V hay khong
int CPrim::ThuocV(int y)
{
	for (int i = 0; i < m_V.size(); ++i)
		if (m_V[i] == y)
			return 1;

	return 0;
}

int CPrim::FindEdge(Edge& e)
{	
	int min = INT_MAX;
	
	for (int i = 0; i < m_V.size(); ++i)
	{
		for (int j = 1; j <= m_Input.LaySoDinh(); ++j)
			if (m_Input.LayCanhNoi(m_V[i], j) != 0 && m_Input.LayCanhNoi(m_V[i], j) < min && !ThuocV(j))
			{
				min = m_Input.LayCanhNoi(m_V[i], j);
				e.v1 = m_V[i];
				e.v2 = j;
				e.w = min;
			}
	}

	if (min == INT_MAX)
		return 0;
	else
		return 1;
}

void CPrim::PutToTree(Edge e)
{
	m_T.push_back(e);
}

void CPrim::PutToVSet(int y)
{
	m_V.push_back(y);
}

int CPrim::Run(int x0)
{
	int nT = 0;
	Edge e;
	PutToVSet(x0);
	
	while (nT < m_Input.LaySoDinh() - 1)
	{
		if (!FindEdge(e))
			return 0;
		
		// Tim thay canh e thoa dieu kien
		PutToVSet(e.v2);
		PutToTree(e);
		++nT;
		m_W += e.w;
	}

	return 1;
}

int CPrim::Input(char *filename)
{
	ifstream f;
	f.open(filename);
	if (!f)
		return 0;

	int **A;
	int m;
	int n;
	int x, y, w;

	f >> n >> m;

	A = new int*[n + 1];
	for (int i = 1; i <= n; ++i)
	{
		A[i] = new int[n + 1];
		A[i][0] = 1;
		memset(A[i], 0, sizeof(A[0][0]) * (n + 1)); // Cho cac phan tu = 0
	}

	for (i = 0; i < m; ++i)
	{
		f >> x >> y >> w;
		A[x][y] = A[y][x] = w;
	}

	m_Input.Tao(n, A);
	if (Run(1) == 0)
	{
		m_W = 0;
		m_T.clear();
	}

	for (i = 1; i <= n; ++i)
	{
		delete []A[i];
	}

	delete []A;
	return 1;
}

int CPrim::Output(char *filename)
{
	ofstream f;
	Edge temp;
	f.open(filename);
	
	if (!f)
		return 0;

	f << m_W << endl;

	for (int i = 0; i < m_T.size(); ++i)
	{
		temp = m_T[i];
		f << temp.v1 << " " << temp.v2 << endl;
	}

	return 1;
}