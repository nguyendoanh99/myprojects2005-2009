#include <iostream.h>
#include <fstream.h>
#include <stdlib.h>
#include <limits.h>

#define MAX_N 100
#define MAX_W 120

int A[MAX_N + 1];
int C[MAX_N + 1];
int L[MAX_N + 1][MAX_W + 1]; // L[i, j] chua tong gia tri lon nhat cua valy co trong luong j va
							 // dang xet i vat
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
	// Khoi tao 
	for (int i = 0; i <= n; ++i)
		L[i][0] = 0;

	for (int j = 0; j <= w; ++j)
		L[0][j] = 0;

	// Tim phuong an toi uu cho valy co trong luong j va dang xet i vat
	for (i = 1; i <= n; ++i)
	{
		for (j = 1; j <= w; ++j)
			if (A[i] > j)
				L[i][j] = L[i - 1][j];
			else	
				L[i][j] = __max(L[i - 1][j], L[i][j - A[i]] + C[i]);
	}
	
	for (i = 1; i <= n ; ++i )
	{
		for (j = 1; j <= w; ++j)
			cout << L[i][j] << "  ";
		cout << endl;
	}
	// Tim ket qua toi uu
	tong = L[n][w];
	i = n;
	j = w;
	do
	{
		if (L[i][j] == L[i - 1][j])		
			i = i - 1;		
		else		
		{
			j = j - A[i];
			++kq[i];
		}				
	} while (L[i][j] != 0);

}