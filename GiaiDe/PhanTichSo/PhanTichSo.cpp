#include <iostream.h>
#include <fstream.h>

#define MAX 100

int A[MAX + 1][MAX + 1];
int L[MAX + 1][26];
int B[26];
int M;
int N;
int k;

void Input(char *filename);
void Output(char *filename);
int qhd(int x, int w);
void TaoSoNT();
void KhoiTao();

void main()
{
	Input("PTS.INP");
	KhoiTao();
	TaoSoNT();
	Output("PTS.OUT");
}

void KhoiTao()
{	
	for (int i = 1; i <= MAX; ++i)
	{
		L[i][0] = 0;
		for (int j = 1; j <= 25; ++j)
			L[i][j] = -1;
	}	

	for (i = 0; i <= 25; ++i)
		L[0][i] = 1;
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);

	f >> M >> N >> k;
	for (int i = 1; i <= M; ++i)
		for (int j = 1; j <= N; ++j)
			f >> A[i][j];
}

void TaoSoNT()
{
	int T[100] = {0};
	int d = 0;
	for (int i = 2; i < 100; ++i)
		if (!T[i])
		{
			B[++d] = i;
			int j = i + i;
			
			while (j < 100)
			{				
				T[j] = 1;
				j += i;
			}
		}	
}

int qhd(int x, int w)
{	
	int y = x;
	if (L[y][w] == -1)
	{
		int s = 0;
		int dem = k;
		while (x >= B[w] && dem >= 1)
		{
			x -= B[w];
			--dem;
			s += qhd(x, w - 1);
		}

		s += qhd(y, w - 1);
		L[y][w] = s;
	}

	return L[y][w];
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);

	for (int i = 1; i <= M; ++i)
	{
		for (int j = 1; j <= N; ++j)
			f << qhd(A[i][j], 25) << " ";
		f << endl;
	}
}