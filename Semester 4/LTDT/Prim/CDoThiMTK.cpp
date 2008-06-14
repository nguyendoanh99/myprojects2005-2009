// Cap nhat 8/4/2007, 15:30
#include "CDoThiMTK.h"
#include <memory.h>
#include <fstream.h>

void CDoThiMTK::ThuHoi()
{
	if (m_iSoDinh > 0)
	{
		for (int i = 1; i <= m_iSoDinh; ++i)
			delete []m_arrDinh[i];

		delete []m_arrDinh;
	}

	m_iSoDinh = 0;
	m_arrDinh = 0;
}

CDoThiMTK::CDoThiMTK()
{
	m_iSoDinh = 0;
	m_arrDinh = 0;
}

int CDoThiMTK::TaoDoThi(int n, int **A)
{
	if (n <= 0)
	{
		m_iSoDinh = 0;
		m_arrDinh = 0;
		return 0;
	}

	m_iSoDinh = n;
	m_arrDinh = new int*[n + 1];

	int i;
	for (i = 1; i <= n; ++i)
	{
		m_arrDinh[i] = new int[n + 1];
		memcpy(m_arrDinh[i], A[i], sizeof(m_arrDinh[0][0]) * (n + 1));
	}

	return 1;
}
CDoThiMTK::CDoThiMTK(int n, int **A)
{
	TaoDoThi(n, A);
}

CDoThiMTK::CDoThiMTK(const CDoThiMTK& P)
{
	TaoDoThi(P.m_iSoDinh, P.m_arrDinh);
}

CDoThiMTK& CDoThiMTK::operator = (const CDoThiMTK& P)
{
	ThuHoi();

	TaoDoThi(P.m_iSoDinh, P.m_arrDinh);
	return *this;
}

CDoThiMTK::~CDoThiMTK()
{	
	ThuHoi();
}

int CDoThiMTK::Input(char *filename)
{
	ThuHoi();

	ifstream f;

	f.open(filename, ios::in | ios::nocreate);

	if (!f)
		return 0;

	f >> m_iSoDinh;

	if (m_iSoDinh <= 0)
	{
		m_iSoDinh = 0;
		m_arrDinh = 0;
		return 0;
	}

	m_arrDinh = new int*[m_iSoDinh + 1];

	int i;
	int j;
	
	for (i = 1; i <= m_iSoDinh; ++i)
	{
		m_arrDinh[i] = new int[m_iSoDinh + 1];

		for (j = 1; j <= m_iSoDinh; ++j)
			f >> m_arrDinh[i][j];
		
	}

	return 1;
}

int CDoThiMTK::Output(char *filename) const
{
	ofstream f;

	f.open(filename);
	
	if (!f)
		return 0;

	f << m_iSoDinh << endl;

	for (int i = 1; i <= m_iSoDinh; ++i)
	{
		for (int j = 1; j <= m_iSoDinh; ++j)
			f << m_arrDinh[i][j] << " ";
		f << endl;
	}

	return 1;
}

ostream& operator << (ostream& os, const CDoThiMTK& P)
{
	os << P.m_iSoDinh << endl;

	for (int i = 1; i <= P.m_iSoDinh; ++i)
	{
		for (int j = 1; j <= P.m_iSoDinh; ++j)
			os << P.m_arrDinh[i][j] << " ";
		os << endl;
	}
	
	return os;
}

int CDoThiMTK::LaySoDinh() const
{
	return m_iSoDinh;
}

int CDoThiMTK::LayCanhNoi(int i, int j) const
{
	return m_arrDinh[i][j];
}


int CDoThiMTK::Tao(int n, int **A)
{
	ThuHoi();

	return TaoDoThi(n, A);
}
