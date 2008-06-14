#include "CFloyd.h"
#include "fstream.h"
#include "iomanip.h"

CFloyd::~CFloyd()
{
	if (m_L)
	{
		for (int i = 1; i <= m_iVer; ++i)
			delete []m_L[i];
		delete []m_L;
	}
}

CFloyd::CFloyd()
{
	m_L = 0;
	m_iVer = 0;
}

int CFloyd::Input(char *filename)
{
	ifstream f;
	f.open(filename, ios::nocreate | ios::in);
	if (!f)
		return 0;

	int n, m;
	int x, y, w;

	f >> n >> m >> m_iDau >> m_iCuoi;
	
	m_iVer = n;
	m_L = new Vertex*[n + 1];
	for (int i = 1; i <= n; ++i)
	{
		m_L[i] = new Vertex[n + 1];
		for (int j = 1; j <= n; ++j)
		{
			m_L[i][j].fLength = 0;
			m_L[i][j].iNextV = -1;

		}
	}

	for (i = 0; i < m; ++i)
	{
		f >> x >> y >> w;
		m_L[x][y].fLength = (float) w;
		if (w)
		{
			m_L[x][y].iNextV = y;

		}
	}
	
	Run();
	return 1;
}

int CFloyd::Output(char *filename)
{
	ofstream f;
	f.open(filename);

	f << setiosflags(ios::fixed);
	for (int i = 1; i <= m_iVer; ++i)
	{		
		for (int j = 1; j <= m_iVer; ++j)
			f << setprecision(0) << m_L[i][j].fLength << " ";
		f << endl;
	}

	if (m_L[m_iDau][m_iCuoi].fLength != 0)
	{
		int *A = new int[m_iVer];
		int k = PrintPath(m_iDau, m_iCuoi, A);

		f << k << endl;
		for (int i = 0; i < k; ++i)
			f << A[i] << " ";
		delete A;
	}

	return 1;
}

void CFloyd::Run()
{
	for (int i = 1; i <= m_iVer; ++i)
		for (int j = 1; j <= m_iVer; ++j)
			if (m_L[j][i].fLength != 0)
			{
				for (int k = 1; k <= m_iVer; ++k)
					if (m_L[i][k].fLength != 0)	
						if (j != k && (m_L[j][k].fLength == 0 || m_L[j][i].fLength + m_L[i][k].fLength < m_L[j][k].fLength))
						{
							m_L[j][k].fLength = m_L[j][i].fLength + m_L[i][k].fLength;
							m_L[j][k].iNextV = m_L[j][i].iNextV;
						}
			}
}

int CFloyd::PrintPath(int x, int y, int *A)
{
	int kq = 0;
	if (m_L[x][y].fLength != 0)
	{	
		A[kq++] = x;
		int v = x;
		while (v != y)
		{		
			A[kq++] = m_L[v][y].iNextV;			
			v = m_L[v][y].iNextV;
		}		
	}

	return kq;
}