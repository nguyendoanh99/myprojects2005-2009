#include "CDijkstra_MTK.h"
#include "fstream.h"
#include "iomanip.h"
int CDijkstra_MTK::Input(char *filename)
{
	ifstream f;
	f.open(filename, ios::nocreate | ios::in);
	if (!f)
		return 0;

	int n, m;
	int x, y, w;

	f >> n >> m >> m_iDau >> m_iCuoi;

	int **A = new int*[n + 1];
	for (int i = 1; i <= n; ++i)
		A[i] = new int[n + 1];

	for (i = 0; i < m; ++i)
	{
		f >> x >> y >> w;
		A[x][y] = w;
	}

	Tao(n, A);
	for (i = 1; i <= n; ++i)
		delete []A[i];
	delete []A;
	
	m_fTongTrongSo = Run(m_iDau, m_iCuoi);
	return 1;
}

int CDijkstra_MTK::Output(char *filename)
{
	ofstream f;
	f.open(filename);
	
	if (!f)
		return 0;

	if (m_fTongTrongSo == Extremity)
		f << "0";
	else
	{
		char A[100];
		int kq = PrintPath(m_iDau, m_iCuoi, A);
		f << setiosflags(ios::fixed);
		f << setprecision(0) << m_fTongTrongSo << " " << kq << endl;
		
		for (int i = kq - 1; i >= 0; --i)
			f << (int) A[i] << " ";	
	}
	return 1;
}

int CDijkstra_MTK::nVer()
{
	return LaySoDinh();
}

float CDijkstra_MTK::Distance(int i, int j)
{
	return (float) LayCanhNoi(i, j);
}

CDijkstra_MTK::~CDijkstra_MTK()
{
}
