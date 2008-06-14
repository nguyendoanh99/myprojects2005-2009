#include "CBellman.h"
#include "iostream.h"
CBellman::~CBellman()
{
	if (m_Row[0])
		delete m_Row[0];

	if (m_Row[1])
		delete m_Row[1];
}

CBellman::CBellman()
{
	m_Row[0] = 0;
	m_Row[1] = 0;
}
	
void CBellman::Init(int x)
{
	int n = nVer();
	m_iStartVer = x;
	
	m_Row[0] = new Vertex[n + 1];
	m_Row[1] = new Vertex[n + 1];

	// Do trong thuat toan chinh buoc dau tien la haon vi giua 2 dong nen moi khoi tao gia 
	// tri cho m_Row[1]
	for (int i = 1; i <= n; ++i)
	{
		m_Row[1][i].fLength = 0;
		m_Row[1][i].cFlag = 1; // so vo cuc
	}
	
	m_Row[1][x].cFlag = 0;
}

void CBellman::UpdateNextRow()	// Buoc 2
{
	float len;
	for (int i = 1; i <= nVer(); ++i)
	{
		m_Row[1][i] = m_Row[0][i];

		for (int j = 1; j <= nVer(); ++j)
		{
			len = Distance(j, i);
			if (len && !m_Row[0][j].cFlag && 
				(m_Row[1][i].cFlag || m_Row[0][j].fLength + len < m_Row[1][i].fLength))
			{
				m_Row[1][i].fLength = m_Row[0][j].fLength + len;
				m_Row[1][i].cFlag = 0;
			}
		}
				
	}
}

int CBellman::Run(int x)
{
	Init(x);
	int k = 1;
	while (1)
	{
		// Hoan vi 2 dong
		Vertex *temp = m_Row[0];
		m_Row[0] = m_Row[1];
		m_Row[1] = temp;

		UpdateNextRow();
		if (TwoRowsEqual())				
			return 1;
		else
		{
			++k;
			if (k == nVer())
			{					
				for (int i = 01; i <= nVer(); ++i)
					m_Row[1][i].fLength = 0;

				return 0;
			}
		}	
	}
}

int CBellman::TwoRowsEqual()
{
	for (int i = 1; i <= nVer(); ++i)
		if (m_Row[0][i].fLength != m_Row[1][i].fLength || 
			m_Row[0][i].cFlag != m_Row[1][i].cFlag)
			return 0;

	return 1;
}

void CBellman::Print(float *A)
{
	for (int i = 0; i < nVer(); ++i)
		A[i] = m_Row[1][i + 1].fLength;
}