#include <iostream.h>
#include <fstream.h>
#include <stdlib.h>
#include <string.h>

int N;
int M;
int K;
int P;
char s[100][101];
int L[101][34]; // L[i][j] tong so ma cua bo ma (i, j, K)

void Input(char *filename);
void Output(char *filenmae);
void ThucHien();
int qhd(int n, int m);
void KhoiTao();
int ViTriMa(char *s); // tra ve vi tri cua ma s trong bo ma (N, M, K)
int TimViTri(char *s, char c); // tra ve vi tri cua c co trong "s"

void main()
{
	Input("MV.INP");
	ThucHien();
	for (int i = 1; i <= N; ++i)
	{
		for (int j = 1; j <= i; ++j)
			cout << L[i][j] << "\t";
		cout << endl;
	}
	Output("MV.OUT");
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);

	f >> N >> M >> K;
	f >> P;
	f.ignore(1);
	for (int i = 1; i <= P; ++i)
		f.getline(s[i], 101);
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);

	f << L[N][M] << endl;
	for (int i = 1; i <= P; ++i)
		f << ViTriMa(s[i]) << endl;
}

void ThucHien()
{
	KhoiTao();

	for (int i = 2; i <= N; ++i)
	{
		for (int j = 2; j <= M; ++j)
			L[i][j] = qhd(i, j);
	}
}

int qhd(int n, int m)
{
	int kq = 0;
	for (int i = n - 1; i >= __max(n - K, m - 1); --i)
		kq += L[i][m - 1];

	return kq;
}

void KhoiTao()
{
	L[0][0] = 0;

	for (int i = 1; i <= N; ++i)
	{
		L[i][0] = 0;
		if (i <= K)
			L[i][1] = 1;
		else
			L[i][1] = 0;
	}
}

int ViTriMa(char *s)
{
	int d = 1;
	int M1 = M;	
	int N1;
	int flag = 1; // Cho biet trang thai dang xet la chan hay le
				  // flag = 1: le
				  // flag = 0: chan
	int vt;
	int min;
	int max;
	// Bo qua phan tu dau tien cua chuoi
	++s; 

	do
	{					
		// Neu lan dang xet la chan thi tim '1' trong s
		// nguoc lai tim '0' trong s
		vt = TimViTri(s, (flag == 0 ? '1' : '0'));
		// Dieu kien dung
		if (vt == -1)
			break;

		N1 = strlen(s);
		--M1;
		// Lay 2 so min, max phu hop voi lan xet thu i
		// phuc vu cho vong for ben duoi
		if (flag == 0) // i chan
		{
			// Cong tu tren xuong: d += L[min][M1] + ... + L[N1 - vt - 1][M1]
			min = __max(M1, N1 - K + 1);
			max = N1 - vt - 1;
		}
		else // i le
		{
			// Cong tu duoi len: d += L[N1][M1] + ... + L[N1 - vt + 1][M1]
			max = N1;
			min = N1 - vt + 1;
		}
		
		for (int j = min; j <= max; ++j)
			d += L[j][M1];
		// neu tong so ma cua bo ma (N1 - vt, M1, K) = 1 thi dung
		if (L[N1 - vt][M1] == 1)
			break;

		flag = !flag;
		s = &s[vt + 1];
	} while (1);

	return d;
}

int TimViTri(char *s, char c)
{
	for (int k = 0; k < strlen(s); ++k)
		if (s[k] == c)
			return k;

	return -1;
}