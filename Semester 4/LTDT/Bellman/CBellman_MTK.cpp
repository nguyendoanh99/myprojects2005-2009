#include "CBellman_MTK.h"
#include "fstream.h"
#include "iomanip.h"

CBellman_MTK::~CBellman_MTK()
{
}

int CBellman_MTK::nVer()
{
	return m_DoThi.LaySoDinh();
}

float CBellman_MTK::Distance(int x, int y)
{
	return (float) m_DoThi.LayCanhNoi(x, y);
}

int CBellman_MTK::Input(char *filename)
{
	ifstream f;
	f.open(filename, ios::nocreate | ios::in);
	if (!f)
		return 0;

	int n, m;
	int x, y, w;
	int iDau;

	f >> n >> m >> iDau;

	int **A = new int*[n + 1];
	for (int i = 1; i <= n; ++i)
	{		
		A[i] = new int[n + 1];
		for (int j = 1; j <= n; ++j)
			A[i][j] = 0;
	}

	for (i = 0; i < m; ++i)
	{
		f >> x >> y >> w;
		A[x][y] = w;
	}

	m_DoThi.Tao(n, A);

	for (i = 1; i <= n; ++i)
		delete []A[i];
	delete []A;
	
 	Run(iDau);
	return 1;
}

int CBellman_MTK::Output(char *filename)
{
	ofstream f;
	f.open(filename);
	
	if (!f)
		return 0;
	
	float A[100];
	Print(A);
	f << setiosflags(ios::fixed);

	for (int i = 0; i < m_DoThi.LaySoDinh(); ++i)
	{
		f << setprecision(0) << A[i] << " ";	
		char B[100];
		int n;
		n = PrintPath(i + 1, B);
		for (int j = n - 1; j >= 0; --j)
			cout << (int) B[j] << " ";
		cout << endl;
	}
	
	return 1;
}