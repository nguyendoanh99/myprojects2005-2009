#include <iostream.h>
#include <fstream.h>
#include <stdlib.h>

#define MAX 10

int N;
int t[MAX + 1];
int r[MAX];
int w[MAX + 1]; // w[i] Tong thoi gian it nhat khi phuc vu i nguoi

void Input(char *filename);
void Output(char *filename);
void ThucHien();

void main()
{
	Input("TICK.INP");
	ThucHien();
	Output("TICK.OUT");
}

void Input(char *filename)
{
	ifstream f;
	f.open("TICK.INP");

	f >> N;

	for (int i = 1; i <= N; ++i)
		f >> t[i];

	for (i = 1; i <= N - 1; ++i)
		f >> r[i];
}

void Output(char *filename)
{
	int KQ[(MAX + 1) / 2]; // Chua chi so cac khach hang can roi khoi hang
	int nKQ = 0;
	ofstream f;
	f.open("TICK.OUT");

	f << w[N] << endl;
	// Lan nguoc tim ket qua
	int j = N;
	while (j > 1)
	{
		if (w[j] == w[j - 1] + t[j])
			--j;
		else
		{
			KQ[++nKQ] = j;
			j = j - 2;
		}
	}

	for (j = nKQ; j >= 1; --j)
		f << KQ[j] << " ";
}
void ThucHien()
{
	// Khoi tao
	w[1] = t[1];
	w[0] = 0;
	// Tim phuong an toi uu
	for (int j = 2; j <= N; ++j)
		w[j] = __min(w[j - 1] + t[j], w[j - 2] + r[j - 1]);
}