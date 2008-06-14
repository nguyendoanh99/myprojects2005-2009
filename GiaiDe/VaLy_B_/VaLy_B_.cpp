#include <iostream.h>
#include <fstream.h>
#include <stdlib.h> 

#define MAX_N 100
#define MAX_W 1000

int N;
int W;
int A[MAX_N + 1];
int C[MAX_N + 1];
int L[MAX_N + 1][MAX_W + 1]; // L[i, j] Luu gia tri lon nhat cua valy co trong luong la j 
							 // va dang xet i do vat
int kq[MAX_N + 1]; // Chua so hieu cua cac vat duoc chon trong phuong an toi uu
int n_kq; // So vat duoc chon trong phuong an toi uu

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

	f >> N >> W;
	for (int i = 1; i <= N; ++i)
		f >> A[i] >> C[i];
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);

	f << L[N][W] << endl;
	for (int i = n_kq; i >= 1; --i)
		f << kq[i] << " " << A[kq[i]] << " " << C[kq[i]] << endl;
}

void ThucHien()
{
	// Khoi tao
	for (int i = 0; i <= N; ++i)
		L[i][0] = 0;

	for (int j = 0; j <= W; ++j)
		L[0][j] = 0;
	// Tim phuong an toi uu
	for (i = 1; i <= N; ++i)
	{
		for (j = 1; j <= W; ++j)
			if (A[i] > j)
				L[i][j] = L[i - 1][j];
			else
				L[i][j] = __max(L[i - 1][j], L[i - 1][j - A[i]] + C[i]);
	}
	
	for (i = 1; i <= N; ++i)
	{
		for (j = 1; j <= W; ++j)
			cout << L[i][j] << "\t";
		cout << endl;
	}
	
	// Lan nguoc de tim ket qua
	n_kq = 0;	
	j = W;
	for (i = N; i >= 1; --i)
	{
		if (L[i][j] != L[i - 1][j])			
		{
			++n_kq;
			kq[n_kq] = i;			
			j = j - A[i];			
		}
	}
}
