#include <iostream.h>
#include <fstream.h>

int a[101];
int b[101];
int C[101][101];
int pa[101];
int pb[101];
int dem;
int n;
int m;

void Input(char *filename);
void Output(char *filename);
int max(int i, int j, int k);
int Thuoc(int so, int a[], int k);
void ThucHien();

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

	f >> n;
	for (int i = 1; i <= n; ++i)
		f >> a[i];

	f >> m;
	for (i = 1; i <= m; ++i)
		f >> b[i];
}

void ThucHien()
{
	// Khoi tao cac gia tri ban dau cho C
	for (int j = 1; j <= m; ++j)
		if (Thuoc(a[1], b, j) == 1)
			C[1][j] = 1;
		else
			C[1][j] = 0;

	for (int i = 1; i <= n; ++i)
		if (Thuoc(b[1], a, i) == 1)
			C[i][1] = 1;
		else
			C[i][1] = 0;
	// Tao C[i, j]
	for (i = 2; i <= n; ++i)
		for (j = 2; j <= m; ++j)
			C[i][j] = max(C[i - 1][j], C[i][j - 1], C[i - 1][j - 1] + (a[i] == b[j]));

	for (i = 1; i <= n; ++i)
	{
		for (j = 1; j <= m; ++j)
			cout << C[i][j] << " ";
		cout << endl;
	}
	// Luu ket qua
	dem = 0;
	i = n;
	j = m;
	do
	{
		if (a[i] == b[j])
		{
			++dem;
			pa[dem] = i;
			pb[dem] = j;
			--i;
			--j;
		}
		else
			if (C[i][j] == C[i - 1][j])
				--i;
			else
				--j;
	} while (i > 0 && j > 0);
}

int max(int i, int j, int k)
{
	int kq = i;
	
	if (kq < j)
		kq = j;

	if (kq < k)
		kq = k;

	return kq;
}
// Kiem tra so co thuoc mang a gom k phan tu hay khong
int Thuoc(int so, int a[], int k)
{
	for (int i = 1; i <= k; ++i)
		if (so == a[i])
			return 1;
	return 0;
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);

	f << dem << endl;
	for (int i = dem; i > 0; --i)
		f << a[pa[i]] << " ";
	
	f << endl;
	for (i = dem; i > 0; --i)
		f << pa[i] << " ";

	f << endl;
	for (i = dem; i > 0; --i)
		f << pb[i] << " ";
}