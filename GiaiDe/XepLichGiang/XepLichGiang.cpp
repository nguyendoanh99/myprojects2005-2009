/*
#include <iostream.h>
#include <fstream.h>
#include <limits.h>

#define MAX 50

int a[MAX + 1];
int d[MAX + 1][MAX + 1]; // d[i][j] tong muc hao phi thap nhat khi giang tu van de i den van de j
int b[MAX + 1][MAX + 1]; // b[i][j] tong so gio khi giang tu van de i den van de j
int ngay[MAX + 1][MAX + 1]; // ngay[i][j] so ngay it nhat khi giang tu van de i den van de j
int L;
int C;
int n;

void Input(char *filename);
void Output(char *filename);
void ThucHien();
int MucPhi(int t); // Muc hao phi tuong ung voi t

void main()
{
	Input("LICH.INP");
	ThucHien();
	cout << ngay[1][n] << " " << d[1][n];
	Output("LICH.OUT");
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);
	f << ngay[1][n] << endl;
	f << d[1][n];
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);
	f >> n;
	f >> L >> C;
	for (int i = 1; i <= n; ++i)
		f >> a[i];
}

void ThucHien()
{
	for (int i = 1; i <= n; ++i)
		b[i][i - 1] = 0;

	int j;
	int tngay;
	for (int s = 0; s <= n - 1; ++s)
	{
		for (i = 1; i <= n - s; ++i)
		{
			j = i + s;
			// Khoi tao cho b[i][j], d[i][j], ngay[i][j]
			b[i][j] = b[i][j - 1] + a[j];
			d[i][j] = 0;
			if (b[i][j] > L)
			{
				ngay[i][j] = INT_MAX;
				d[i][j] = INT_MAX;
			}
			else
			{
				ngay[i][j] = 1;
				d[i][j] = MucPhi(L - b[i][j]);
			}

			for (int k = i; k <= j - 1; ++k)
			{
				tngay = ngay[i][k] + ngay[k + 1][j];
				if (tngay < ngay[i][j])
				{
					ngay[i][j] = tngay;
					d[i][j] = d[i][k] + d[k + 1][j];
				}
				else
					if (tngay == ngay[i][j] && d[i][k] + d[k + 1][j] < d[i][j])
						d[i][j] = d[i][k] + d[k + 1][j];					
			}
		}
	}
}

int MucPhi(int t)
{
	if (t == 0)
		return 0;
	else
		if (1 <= t && t <= 10)
			return -C;
		else
			return (t - 10) * (t - 10);
}
*/