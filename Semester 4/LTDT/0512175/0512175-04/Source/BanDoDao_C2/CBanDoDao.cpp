// Cap nhat 11/4/2007, 11:05
#include "CBanDoDao.h"
#include <fstream.h>
#include <stdlib.h>
// Khai bao bien toan cuc
int ai[] = {-1, 0, 1, 0};
int aj[] = {0, 1, 0, -1};

void CBanDoDao::KhoiTao()
{
	m_iSoDao = 0;

	for (int j = 0; j <= m_iCot + 1; ++j)
	{
		m_arrDinh[0][j] = 0;
		m_arrDinh[m_iDong + 1][j] = 0;
	}

	for (int i = 0; i <= m_iDong + 1; ++i)
	{
		m_arrDinh[i][0] = 0;
		m_arrDinh[i][m_iCot + 1] = 0;
	}

	TimDao();
}

CBanDoDao::CBanDoDao(): COLuoi()
{
	m_iSoDao = 0;
}

CBanDoDao::CBanDoDao(int m, int n, int **A): COLuoi(m, n, A)
{
	KhoiTao();
}

CBanDoDao::CBanDoDao(const CBanDoDao& P): COLuoi(P)
{
	m_iSoDao = P.m_iSoDao;
}

CBanDoDao::CBanDoDao(const COLuoi& P): COLuoi(P)
{
	KhoiTao();
}

CBanDoDao::~CBanDoDao()
{
}

CBanDoDao& CBanDoDao::operator = (const CBanDoDao& P)
{
	COLuoi::operator =(P);

	m_iSoDao = P.m_iSoDao;
	
	return *this;
}

int CBanDoDao::Input(char *filename)
{
	int flag = COLuoi::Input(filename);
	
	KhoiTao();

	return flag;
}

int CBanDoDao::Output(char *filename) const
{
	ofstream f;
	f.open(filename);

	if (!f)
		return 0;

	f << m_iSoDao;

	return 1;
}

int CBanDoDao::SoDao()
{
	return m_iSoDao;
}

ostream& operator << (ostream &os, const CBanDoDao &P)
{
	os << P.m_iSoDao;

	return os;
}
// Chua xet tran queue	
void CBanDoDao::EnQueue(ToaDo P)
{
	m_iCuoiQ++;
	if (m_iCuoiQ >= m_iMaxQ)
		m_iCuoiQ = 0;	

	m_queue[m_iCuoiQ] = P;
}

void CBanDoDao::DeQueue()
{
	m_iDauQ++;

	if (m_iDauQ - m_iCuoiQ == 1)
	{
		m_iDauQ = 0;
		m_iCuoiQ = -1;
	}
	else
		if (m_iDauQ >= m_iMaxQ)
			m_iDauQ = 0;
}

int CBanDoDao::Empty()
{
	return (m_iDauQ == 0 && m_iCuoiQ == -1);
}

CBanDoDao::ToaDo CBanDoDao::front()
{
	return m_queue[m_iDauQ];
}

void CBanDoDao::Visit(int i, int j, int iNhan)
{
	m_arrDinh[i][j] = iNhan;
	ToaDo t = {i, j};
	EnQueue(t);
	ToaDo temp;
	while (!Empty())
	{
		t = front();		
		DeQueue();

		for (int k = 0; k < (sizeof(ai) / sizeof(ai[0])); ++k)
			if (m_arrDinh[t.i + ai[k]][t.j + aj[k]] == 1)
			{				
				// Them vao queue 
				m_arrDinh[t.i + ai[k]][t.j + aj[k]] = iNhan;
				temp.i = t.i + ai[k];
				temp.j = t.j + aj[k];
				EnQueue(temp);				
			}
	}
}

void CBanDoDao::TimDao()
{
	int iNhan = 1;

	m_iMaxQ = __max(m_iDong, m_iCot);
	m_queue = new ToaDo[m_iMaxQ];

	for (int i = 1; i <= m_iDong; ++i)
		for (int j = 1; j <= m_iCot; ++j)
			if (m_arrDinh[i][j] == 1)
			{
				m_iDauQ = 0;
				m_iCuoiQ = -1;
				Visit(i, j, ++iNhan);
			}

	delete []m_queue;

	PhucHoi();

	m_iSoDao = iNhan - 1;
}

void CBanDoDao::PhucHoi()
{
	for (int i = 1; i <= m_iDong; ++i)
		for (int j = 1; j <= m_iCot; ++j)
			if (m_arrDinh[i][j] != 0)
				m_arrDinh[i][j] = 1;
}