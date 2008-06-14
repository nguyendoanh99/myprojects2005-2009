#include "CKruskal.h"
#include <stdlib.h>
#include <algorithm>
#include <fstream.h>
#include <iostream.h>
CKruskal::CKruskal()
{
	m_W = 0;
}

CKruskal::~CKruskal()
{
}

void CKruskal::UpdateLabels(int v1, int v2)
{
	int min = __min(m_Label[v1], m_Label[v2]);
	int max = __max(m_Label[v1], m_Label[v2]);

	for (int i = 1; i <= m_Label.size(); ++i)
		if (m_Label[i] == max)
			m_Label[i] = min;
}

void CKruskal::Init()
{
	m_Label.resize(m_nVer + 1);
	for (int i = 1; i <= m_nVer; ++i)
		m_Label[i] = i;

	std::sort(m_Edges.begin(), m_Edges.end());
}

int CKruskal::Input(char *filename)
{
	ifstream f;
	f.open(filename);
	if (!f)
		return 0;

	int m;
	int x, y, w;

	f >> m_nVer >> m;

	for (int i = 0; i < m; ++i)
	{
		f >> x >> y >> w;
		m_Edges.push_back(CEdge(x, y, w));
	}

	Init();
	if (Run() == 0)
	{
		m_W = 0;
		m_T.clear();
	}

	return 1;
}

int CKruskal::Output(char *filename)
{
	ofstream f;
	f.open(filename);
	
	if (!f)
		return 0;

	f << m_W << endl;

	for (int i = 0; i < m_T.size(); ++i)	
		f << m_T[i]->LayV1() << " " << m_T[i]->LayV2() << endl;
	

	return 1;
}

int CKruskal::Run()
{
	for (int i = 0; i < m_Edges.size(); ++i)
		if (m_Label[m_Edges[i].LayV1()] != m_Label[m_Edges[i].LayV2()])
		{
			m_W += m_Edges[i].LayW();
			m_T.push_back(&m_Edges[i]);
			UpdateLabels(m_Edges[i].LayV1(), m_Edges[i].LayV2());

			if (m_T.size() == m_nVer - 1)
				break;
		}

	return m_T.size() == m_nVer - 1;
}	