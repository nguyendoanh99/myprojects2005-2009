// Cap nhat 8/4/2007, 15:30
#include "COLuoi.h"
#include <fstream.h>
#include <memory.h>
void COLuoi::KhoiTao(int m, int n, int **A)
{
	m_iDong = m;
	m_iCot = n;

	if (m_iDong <= 0 || m_iCot <= 0)
	{
		m_iDong = 0;
		m_iCot = 0;
		m_arrDinh = 0;
		return;
	}

	m_arrDinh = new int*[m + 2]; // Khai bao them 2 dong de lam bien

	for (int i = 0; i <= m + 1; ++i)
	{
		m_arrDinh[i] = new int[n + 2]; // Khai bao them 2 cot de lam bien
		memcpy(m_arrDinh[i], A[i], (n + 2) * sizeof(m_arrDinh[0][0]));
//		for (int j = 1; j <= n; ++j)
//			m_arrDinh[i][j] = A[i][j];
	}
}

void COLuoi::ThuHoi()
{
	if (m_arrDinh)
	{
		for (int i = 0; i <= m_iDong + 1; ++i)
			delete []m_arrDinh[i];

		delete []m_arrDinh;
	}

	m_iCot = 0;
	m_iDong = 0;
	m_arrDinh = 0;
}

COLuoi::COLuoi()
{
	m_iDong = 0;
	m_iCot = 0;
	m_arrDinh = 0;
}

COLuoi::COLuoi(int m, int n, int **A)
{
	m_iDong = m;
	m_iCot = n;

	if (m_iDong <= 0 || m_iCot <= 0)
	{
		m_iDong = 0;
		m_iCot = 0;
		m_arrDinh = 0;
		return;
	}

	m_arrDinh = new int*[m + 2]; // Khai bao them 2 dong de lam bien

	m_arrDinh[0] = new int[n + 2];
	m_arrDinh[m + 1] = new int[n + 2];

	for (int i = 1; i <= m; ++i)
	{
		m_arrDinh[i] = new int[n + 2]; // Khai bao them 2 cot de lam bien
//		for (int j = 1; j <= n; ++j)
//			m_arrDinh[i][j] = A[i][j];
		memcpy(m_arrDinh[i], A[i], (n + 1) * sizeof(m_arrDinh[0][0]));
	}
}

COLuoi::COLuoi(const COLuoi &P)
{
	KhoiTao(P.m_iDong, P.m_iCot, P.m_arrDinh);
}

COLuoi& COLuoi::operator = (const COLuoi& P)
{
	ThuHoi();

	KhoiTao(P.m_iDong, P.m_iCot, P.m_arrDinh);
	
	return *this;
}

COLuoi::~COLuoi()
{
	ThuHoi();
}

int COLuoi::Input(char *filename)
{
	ThuHoi();

	ifstream f;
	f.open(filename, ios::in | ios::nocreate);

	// Kiem tra file co doc duoc hay khong
	if (!f)		
		return 0;
	
	f >> m_iDong >> m_iCot;

	if (m_iDong <= 0 || m_iCot <= 0)
	{
		m_iDong = 0;
		m_iCot = 0;
		return 0;
	}

	m_arrDinh = new int*[m_iDong + 2]; // Khai bao du 2 dong de lam bien
	
	m_arrDinh[0] = new int[m_iCot + 2];
	m_arrDinh[m_iDong + 1] = new int[m_iCot + 2];

	for (int i = 1; i <= m_iDong; ++i)
	{
		m_arrDinh[i] = new int[m_iCot + 2]; // Khai bao du 2 cot de lam bien
		for (int j = 1; j <= m_iCot; ++j)
			f >> m_arrDinh[i][j];		
	}

	return 1;
}

int COLuoi::Output(char *filename) const 
{
	ofstream f;
	f.open(filename);

	if (!f)
		return 0;

	f << m_iDong << " " << m_iCot << endl;
	for (int i = 1; i <= m_iDong; ++i)
	{
		for (int j = 1; j <= m_iCot; ++j)
			f << m_arrDinh[i][j] << " ";

		f << endl;
	}
	return 1;
}

ostream& operator << (ostream &os, const COLuoi& P)
{
	os << P.m_iDong << " " << P.m_iCot << endl;

	for (int i = 1; i <= P.m_iDong; ++i)
	{
		for (int j = 1; j <= P.m_iCot; ++j)
			os << P.m_arrDinh[i][j] << " ";

		os << endl;
	}
	return os;
}

int COLuoi::LaySoDong()
{
	return m_iDong;
}

int COLuoi::LaySoCot()
{
	return m_iCot;
}

int COLuoi::GiaTriO(int i, int j)
{
	return m_arrDinh[i][j];
}