/*
#include <iostream.h>
#include <fstream.h>

#define MAX 100

int f;
int V;
short A[MAX + 1][MAX + 1];
int L[MAX + 1][MAX + 1];
short KQ[MAX + 1][MAX + 1];

void Input(char *filename);
void Output(char *filename);
void ThucHien();
void KhoiTao();

void main()
{
	Input("FLOWER.INP");
	ThucHien();
	Output("FLOWER.OUT");
}

void Input(char *filename)
{
	ifstream g;
	g.open(filename);

	g >> f >> V;

	for (int i = 1; i <= f; ++i)
		for (int j = 1; j <= V; ++j)
			g >> A[i][j];
}

void Output(char * filename)
{
	ofstream g;
	g.open(filename);

	g << L[f][V] << endl;
	// Lan nguoc tim ket qua
	int k = f;
	int B[MAX + 1];
	int n = 0;
	for (int i = k + 1; i <= V; ++i)
		if (L[f][i] > L[f][k])
			k = i;
	
	B[++n] = k;
	for (i = 0; i < f - 1; ++i)
	{
		k = KQ[f - i][k];
		B[++n] = k;
	}

	for (i = n; i >= 1; --i)
		g << B[i] << " ";
}
void ThucHien()
{
	KhoiTao();

	for (int i = 2; i <= f; ++i)
	{
		for (int j = i + 1; j <= V - f + i; ++j)
			if (L[i][j - 1] - A[i][j - 1] > L[i - 1][j - 1])
			{
				L[i][j] = L[i][j - 1] - A[i][j - 1] + A[i][j];
				KQ[i][j] = KQ[i][j - 1];
			}
			else
			{
				L[i][j] = L[i - 1][j - 1] + A[i][j];
				KQ[i][j] = j - 1;
			}
	}

	for (i = 1; i <= f; ++i)
	{
		for (int j = 1; j <= V; ++j)
			cout << L[i][j] << "   ";
		cout << endl;
	}
}

void KhoiTao()
{
	for (int j = 1; j <= V - f + 1; ++j)
	{
		L[1][j] = A[1][j];
		KQ[1][j] = 0;
	}

	for (int i = 2; i <= f; ++i)
	{
		L[i][i] = L[i - 1][i - 1] + A[i][i];
		KQ[i][i] = i - 1;
	}
}

*/