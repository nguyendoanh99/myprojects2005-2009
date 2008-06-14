/*
#include <iostream.h>
#include <fstream.h>
#include <stdlib.h>

#define MAX_N 100
#define MAX_W 1000

int A[MAX_N + 1];
int C[MAX_N + 1];
int g1[MAX_W + 1];  // g1[y]: tong gia tri cac vat da chon khi trong luong cua valy la y 
					// va vua xet xong do vat so hieu le
int g2[MAX_W + 1];  // g2[y]: tong gia tri cac vat da chon khi trong luong cua valy la y 
					// va vua xet xong do vat so hieu chan
int v1[MAX_W + 1];  // v1[y] la so hieu do vat duoc chon cuoi cung khi trong luong cua valy la y
					// va vua xet xong do vat so hieu le
int v2[MAX_W + 1];  // v2[y] la so hieu do vat duoc chon cuoi cung khi trong luong cua valy la y
					// va vua xet xong do vat so hieu chan
int kq[MAX_N + 1];  // kq[i] so luong cua vat co so hieu i
int tong;
int n;
int w;

void Input(char *filename);
void Output(char *filename);
void ThucHien();

void main()
{
	Input("VALY.INP");
	ThucHien();
	Output("VALY.OUT");
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);

	f >> n >> w;
	for (int i = 1; i <= n; ++i)
		f >> A[i] >> C[i];
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);	
	f << tong << endl;

	for (int i = 1; i <= n; ++i)
		if (kq[i] != 0)
			f << i << " " << kq[i] << endl;
}

void ThucHien()
{
	// Khoi tao cac gia tri ban dau
	g1[0] = 0;
	g2[0] = 0;
	v1[0] = 0;
	v2[0] = 0;

	for (int i = 1; i <= w; ++i)
	{
		g1[i] = i / A[1];
		if (g1[i] != 0)
			v1[i] = 1;
		else
			v1[i] = 0;
	}
	// Tim duong di
	for (i = 2; i <= n; ++i)
	{
		if (i % 2 == 0)
		{
			for (int j = 1; j <= w; ++j)
			{
				if (A[i] > j)
					g2[j] = g1[j];
				else
					g2[j] = __max(C[i] + g2[j - A[i]], g1[j]);

				if (g2[j] == g1[j])
					v2[j] = v1[j];
				else
					v2[j] = i;
			}
		}
		else
		{
			for (int j = 1; j <= w; ++j)
			{
				if (A[i] > j)
					g1[j] = g2[j];
				else
					g1[j] = __max(C[i] + g1[j - A[i]], g2[j]);

				if (g2[j] == g1[j])
					v1[j] = v2[j];
				else
					v1[j] = i;
			}
		}
	}
	// Lan nguoc
	for (i = 1; i <= n; ++i)
		kq[i] = 0;

	int s = w;
	if (n % 2 == 0)
	{
		int j;
		do 
		{
			j = v2[s];
			++kq[j];
			s -= A[j];
		} while (v2[s] != 0);

		tong = g2[w];
	}
	else
	{
		int j;
		do 
		{
			j = v1[s];
			++kq[j];
			s -= A[j];
		} while (v1[s] != 0);

		tong = g1[w];
	}
}
*/