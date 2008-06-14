#include <iostream.h>
#include <fstream.h>
#include <limits.h>

#define MAX 100

int n;
int d[MAX + 1];
int M[MAX + 1][MAX + 1]; // M[i][j] chua so phep nhan it nhat khi thuc hien nhan ma tran thu i den 
						 // ma tran thu j
int t[MAX + 1][MAX + 1];  // vi tri toi uu
int p1[MAX + 1]; // p1[i] So luong dau ngoac "(" tai vi tri i
int p2[MAX + 1]; // p2[i] So luong dau ngoac ")" tai vi tri i

void Input(char *filename);
void Output(char *filename);
void ThucHien();
void Try(int i, int j); // Lan nguoc de dat cac dau ngoac cho thich hop

void main()
{
	Input("QHD07.INP");
	ThucHien();
	Output("QHD07.OUT");
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);
	f >> n;
	for (int i = 0; i <= n; ++i)
		f >> d[i];
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);

	f << M[1][n] << endl;
	
	for (int i = 1; i <= n; ++i)
		p1[i] = p2[i] = 0;

	Try(1, n);
	--p1[1];
	--p2[n];
	for (char c = 1; c <= n; ++c)
	{
		for (i = 1; i <= p1[c]; ++i)
			f << "(";
		f << char('A' + c - 1);
		for (i = 1; i <= p2[c]; ++i)
			f << ")";
	}
}

void ThucHien()
{
	// Khoi tao
	for (int i = 1; i < n; ++i)
	{
		M[i][i] = 0;
		M[i][i + 1] = d[i - 1] * d[i] * d[i + 1];
	}
	M[n][n] = 0;
	// Tim phuong an toi uu
	for (int s = 2; s < n; ++s)
	{ 
		for (i = 1; i <= n - s; ++i)
		{
			int tam;
			M[i][i + s] = INT_MAX;
			for (int k = i; k < i + s; ++k)
				if (M[i][i + s] > (M[i][k] + M[k + 1][i + s] + d[i - 1] * d[k] * d[i + s]))
				{
					M[i][i + s] = (M[i][k] + M[k + 1][i + s] + d[i - 1] * d[k] * d[i + s]);
					tam = k;
				}
			t[i][i + s] = tam;
		}
	}
}

void Try(int i, int j)
{
	if (i != j)
	{
		++p1[i];
		++p2[j];
	}
	
	if (j - i <= 1)
		return;

	Try(i, t[i][j]);
	Try(t[i][j] + 1, j);
}