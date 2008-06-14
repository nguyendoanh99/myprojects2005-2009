/*#include <iostream.h>
#include <fstream.h>
#include <limits.h>
#include <stdlib.h> 

#define MAX 100

int A[MAX + 1][MAX + 1];
int d[MAX + 1];
int L1, L2, L3;
int C1, C2, C3;
int s;
int t;
int n;

void Input(char *filename);
void Output(char *filename);
void ThucHien();

void main()
{
	Input("RTICKET.INP");
	ThucHien();
	Output("RTICKET.OUT");
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);

	f >> L1 >> L2 >> L3 >> C1 >> C2 >> C3;
	f >> n;
	f >> s >> t;
	d[1] = 0;
	for (int i = 2; i <= n; ++i)
		f >> d[i];
}

void ThucHien()
{
	// Khoi tao
	int kc;
	int j;
	for (int i = s; i <= t; ++i)
	{
		A[i][i] = 0;
		for (j = i + 1; j <= t; ++j)
		{
			kc = d[j] - d[i];
			if (kc <= L1)
				A[i][j] = C1;
			else
				if (kc <= L2)
					A[i][j] = C2;
				else
					if (kc <= L3)
						A[i][j] = C3;
					else
						A[i][j] = INT_MAX;
		}
	}
	// Tim phuong an toi uu
	// Duyet theo duong cheo
	for (int l = 2; l <= t - s; ++l)
		for (i = s; i <= t - l; ++i)
		{
			j = l + i;
			for (int k = i + 1; k <= j - 1; ++k)
				// Truong hop co the di tu ga i den ga k
				// va co the di tu ga k den ga j
				if (A[i][k] < INT_MAX && A[k][j] < INT_MAX)
					A[i][j] = __min(A[i][j], A[i][k] + A[k][j]);
		}
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);
	f << A[s][t];
}
*/