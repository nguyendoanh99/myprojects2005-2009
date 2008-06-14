#include <iostream.h>
#include <fstream.h>
#include <stdlib.h>

#define MAX_M 100
#define MAX_N 100

int A[MAX_M + 1][MAX_N + 1];
int kq[MAX_N + 1];
int m;
int n;

void Input(char *filename);
void Output(char *filename);
void ThucHien();

void main()
{
	Input("TSP.INP");
	ThucHien();	
	Output("TSP.OUT");
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);
	f >> m >> n;
	for (int i = 1; i <= m; ++i)
		for (int j = 1; j <= n; ++j)
			f >> A[i][j];
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);
	// Tim dong vt ma tai do A[vt][n] lon nhat
	int vt = 1;
	for (int i = 2; i <= m; ++i)
		if (A[vt][n] < A[i][n])
			vt = i;

	f << A[vt][n] << endl;
	// Lan nguoc
	int t = 1;
	kq[t] = vt;
	for (int j = n - 1; j >= 1; --j)
	{
		i = vt;
		if (A[i][j] < A[vt + 1][j])
			i = vt + 1;
		if (A[i][j] < A[vt - 1][j])
			i = vt - 1;

		if (i == 0)
			i = m;
		else
			if (i == m + 1)
				i = 1;

		vt = i;
		kq[++t] = vt;
	}

	for (i = t; i >= 1; --i)
		f << kq[i] << " ";
	
}

void ThucHien()
{
	// Khoi tao
	for (int j = 1; j <= n; ++j)
	{
		A[0][j] = A[m][j];
		A[m + 1][j] = A[1][j];
	}
	// Tim duong di lon nhat
	for (j = 2; j <= n; ++j)
	{
		for (int i = 1; i <= m; ++i)
			A[i][j] += __max(A[i - 1][j - 1], __max(A[i][j - 1], A[i + 1][j - 1]));

		A[0][j] = A[m][j];
		A[m + 1][j] = A[1][j];
	}
}