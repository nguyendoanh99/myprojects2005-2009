// Cap nhat 8/4/2007, 15:30
#include "CLienThong.h"
#include "memory.h"
#include <fstream.h>

void CLienThong::ThuHoi()
{
	if (LaySoDinh() > 0)
		delete []m_arrNhanDinh;
}

void CLienThong::KhoiTao(int n)
{
	m_iSoTPLT = 0;
	if (LaySoDinh() <= 0)
	{
		m_arrNhanDinh = 0;
		return ;
	}

	m_arrNhanDinh = new int[n + 1];
	
	memset(m_arrNhanDinh, 0, (n + 1) * sizeof(m_arrNhanDinh[0]));
}

void CLienThong::KhoiTao_XacDinh(int n)
{
	KhoiTao(n);
	// Tim so thanh phan lien thong
	XacDinhTPLT();
}

CLienThong::CLienThong(): CDoThiMTK()
{
	KhoiTao(0);
}

CLienThong::CLienThong(int n, int **A): CDoThiMTK(n, A)
{
	KhoiTao_XacDinh(n);
}

CLienThong::CLienThong(const CLienThong& P): CDoThiMTK(P)
{
	KhoiTao(P.LaySoDinh());
	m_iSoTPLT = P.m_iSoTPLT;

	if (LaySoDinh() > 0)
		memcpy(m_arrNhanDinh, P.m_arrNhanDinh, (P.LaySoDinh() + 1) * sizeof(m_arrNhanDinh[0]));
}

CLienThong::CLienThong(const CDoThiMTK& P): CDoThiMTK(P)
{
	KhoiTao_XacDinh(LaySoDinh());
}

CLienThong& CLienThong::operator=(const CDoThiMTK& P)
{
	ThuHoi();
	CDoThiMTK::operator =(P);

	KhoiTao_XacDinh(LaySoDinh());

	return *this;
}

CLienThong& CLienThong::operator =(const CLienThong& P)
{
	ThuHoi();
	CDoThiMTK::operator =(P);

	KhoiTao(P.LaySoDinh());
	m_iSoTPLT = P.m_iSoTPLT;

	if (LaySoDinh() > 0)
		memcpy(m_arrNhanDinh, P.m_arrNhanDinh, (P.LaySoDinh() + 1) * sizeof(m_arrNhanDinh[0]));

	return *this;
}

CLienThong::~CLienThong()
{
	ThuHoi();
}

int CLienThong::SoTPLT() const
{
	return m_iSoTPLT;
}

bool CLienThong::LaDoThiLT() const
{
	return (m_iSoTPLT == 1);
}

void CLienThong::XacDinhTPLT()
{
	for (int i = 1; i <= LaySoDinh(); ++i)
		if (m_arrNhanDinh[i] == 0)
			Visit(i, ++m_iSoTPLT);	
}

void CLienThong::Visit(int iDinh, int iNhan)
{
	m_arrNhanDinh[iDinh] = iNhan;

	for (int i = 1; i <= LaySoDinh(); ++i)
		if (LayCanhNoi(iDinh, i) == 1 && m_arrNhanDinh[i] == 0)		
			Visit(i, iNhan);		
}

int CLienThong::TPLT(int t, int *&pKQ) const
{
	if (t > 0 && t <= m_iSoTPLT)
	{
		int *temp = new int[LaySoDinh()];
		int iDem = 0;

		for (int i = 1; i <= LaySoDinh(); ++i)
		{
			if (m_arrNhanDinh[i] == t)
			{				
				temp[iDem] = i;
				++iDem;
			}
		}
	
		pKQ = new int[iDem];
		memcpy(pKQ, temp, iDem * sizeof(int));

		delete []temp;

		return iDem;
	}

	return 0;
}

int CLienThong::Output(char *filename) const
{
	int *temp;
	ofstream f;
	
	f.open(filename);
	if (!f)
		return 0;
	
	f << m_iSoTPLT << endl;

	for (int i = 1; i <= m_iSoTPLT; ++i)
	{
		int iDem = TPLT(i, temp);
		
		for (int j = 0;  j < iDem; ++j)
			f << temp[j] << " ";
		f << endl;

		delete []temp;
	}

	return 1;
}

ostream& operator << (ostream& os, const CLienThong& P)
{
	int *temp;
	
	os << P.m_iSoTPLT << endl;

	for (int i = 1; i <= P.m_iSoTPLT; ++i)
	{
		int iDem = P.TPLT(i, temp);
		
		for (int j = 0;  j < iDem; ++j)
			os << temp[j] << " ";
		os << endl;

		delete []temp;
	}

	return os;
}

int CLienThong::Input(char *filename)
{
	ThuHoi();
	if (!CDoThiMTK::Input(filename))
		return 0;
	KhoiTao_XacDinh(LaySoDinh());

	return 1;
}