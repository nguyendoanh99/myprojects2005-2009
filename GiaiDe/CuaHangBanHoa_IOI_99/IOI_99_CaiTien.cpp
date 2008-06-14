#include <iostream.h>
#include <fstream.h>

#define MAX 100

int f;
int V;
short A[MAX + 1][MAX + 1];
int L[2][MAX + 1];
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

	int t; 
	if (f % 2 == 0)
		t = 1; // Chon L[1]
	else
		t = 0; // Chon L[0]

	g << L[t][V] << endl;
	// Lan nguoc tim ket qua
	int k = f;
	int B[MAX + 1];
	int n = 0;
	
	for (int i = k + 1; i <= V; ++i)
		if (L[t][i] > L[t][k])
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

	int *K[2];
	K[0] = L[0];
	K[1] = L[1];
	for (int i = 2; i <= f; ++i)
	{
		for (int t = 1; t <= V; ++t)
			cout << K[0][t] << "     ";
		cout << endl;

		K[1][i] = K[0][i - 1] + A[i][i];
		KQ[i][i] = i - 1;
		
		for (int j = i + 1; j <= V - f + i; ++j)
		{
			if (K[1][j - 1] - A[i][j - 1] > K[0][j - 1])
			{
				K[1][j] = K[1][j - 1] - A[i][j - 1] + A[i][j];
				KQ[i][j] = KQ[i][j - 1];
			}
			else
			{
				K[1][j] = K[0][j - 1] + A[i][j];
				KQ[i][j] = j - 1;
			}
		}
		int *temp = K[0];
		K[0] = K[1];
		K[1] = temp;
	}	
}

void KhoiTao()
{
	for (int j = 1; j <= V - f + 1; ++j)
	{
		L[0][j] = A[1][j];
		KQ[1][j] = 0;
	}
}
