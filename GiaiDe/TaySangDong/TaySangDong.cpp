#include <iostream.h>
#include <fstream.h>
#include <limits.h>
#define MAX_N 100
int A[MAX_N][MAX_N];
int F[MAX_N + 1][MAX_N + 1]; // F[i][j] co gia tri bang tong cac so tren cac o di qua theo con duong tot nhat
int T[MAX_N][MAX_N]; // T[i][j] ghi lai chi so dong cua cot j-1 den o (i,j)
int kq[MAX_N]; // ghi lai chi so dong cua cac o di qua tu cot 1 den cot N

int m;
int n;

void Input(char *filename);
void Output(char *filename);
void ThucHien();
int min(int A[][MAX_N + 1], int i, int j); // Lay chi so dong cua min(A[i][j], A[i - 1][j], A[i + 1][j])

void main()
{
	Input("BL.inp");
	ThucHien();
	Output("BL.out");
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);

	f >> m;
	f >> n;
	for (int i = 1; i <= m; ++i)
		for (int j = 1; j <= n; ++j)
			f >> A[i][j];
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);

	// Tim duong di
	// Tim chi so dong vt ma tai F[vt][n] nho nhat
	for (int a = 1; a <= m; ++a)
	{
		for (int b = 1; b <= n; ++b)
			cout << F[a][b] << "   ";
		cout << endl;
	}

	int vt = 1;
	for (int i = 2; i <= m; ++i)
		if (F[vt][n] > F[i][n])
			vt = i;
	f << F[vt][n] << endl;

	for (int d = 1; d <= n; ++d)
	{		
		kq[d] = vt;		
		vt = T[vt][n - d + 1];
	}

	for (d = n; d >= 1; --d)
		f << kq[d] << " ";
}

void ThucHien()
{

	for (int k = 1; k < n; ++k)	
		F[0][k] = F[m + 1][k] = INT_MAX;
	// Tao duong di
	for (k = 1; k <= m; ++k)
		F[k][1] = A[k][1];
	
	for (int j = 2; j <= n; ++j)
	{
		for (int i = 1; i <= m; ++i)
		{
			T[i][j] = min(F, i, j - 1);
			F[i][j] = F[T[i][j]][j - 1] + A[i][j];
		}
	}
}

int min(int F[][MAX_N + 1],int i, int j)
{
	int kq = i;

	if (F[i - 1][j] < F[kq][j])
		kq = i - 1;

	if (F[i + 1][j] < F[kq][j])
		kq = i + 1;
	
	return kq;
}