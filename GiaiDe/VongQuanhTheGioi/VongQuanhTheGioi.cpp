#include <iostream.h>
#include <fstream.h>
#include <float.h>
#include <stdlib.h>

#define MAX 10000
#define INT64_MAX 9223372036854775807
int N;
int P;
int A[MAX + 1];
__int64 L[MAX + 1]; // L[i] muc phat thap nhat khi di tu diem xuat phat 
					// toi khach san thu i
short KQ[4100]; // chua vi tri cac khach san da dung

void Input(char *filename);
void Output(char *filename);
void ThucHien();
__int64 MucPhat(int x, int y);
ostream& operator << (ostream& os, __int64 t);

void main()
{
	Input("VQTG.INP");
	ThucHien();
	Output("VQTG.OUT");
}

void Output(char *filename)
{	
	ofstream f;
	f.open(filename);

	f << L[N] << endl;
	// Lan nguoc, tim vi tri cac khach san da dung
	int k = 1; // tong so khach san da dung
	int j;
	KQ[1] = N;
	for (int i = N; i != 0; i = j)
	{
		for (j = i - 1; L[j] + MucPhat(j, i) != L[i]; --j);

		++k;
		KQ[k] = j;		
	}
	--k; // Bo diem xuat phat tuc vi tri thu 0

	f << k << endl;
	for (i = k; i >= 1; --i)
		f << KQ[i] << " ";

}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);

	f >> N;
	f >> P;
	
	for (int i = 1; i <= N; ++i)
		f >> A[i];
}

void ThucHien()
{		
	L[0] = 0;

	for (int i = 1; i <= N; ++i)
	{
		L[i] = INT64_MAX;
		__int64 min = INT64_MAX;

		for (int j = i - 1; j >= 0; --j)
		{
			__int64 M = MucPhat(j, i);
			// Dieu kien dung
			if (M > min)
				break;
			else
				min = M;
			
			L[i] = __min(L[i], L[j] + M);
		}
	}
}

__int64 MucPhat(int x, int y)
{
	__int64 t = (A[y] - A[x]) - P;
	return t * t;
}

ostream& operator << (ostream& os, __int64 t)
{
	int h = 0;
	short b[20];
	for (; t != 0; t /= 10)
		b[++h] = (short) (t % 10);
	for (;h >= 1; --h)
		os << b[h];	

	return os;
}