#include <iostream.h>
#include <fstream.h>
#include <limits.h>
#include <stdlib.h> 

#define MAX 10000

int A[MAX + 1]; // A[i] muc chi phi di tu ga s den ga i
int d[MAX + 1];
int L[4];
int C[4];
int s;
int t;
int n;

void Input(char *filename);
void Output(char *filename);
void ThucHien();
int Chon(int kc); // Chon muc ve ung voi khoang cach cho truoc

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

	C[0] = INT_MAX;
	f >> L[1] >> L[2] >> L[3] >> C[1] >> C[2] >> C[3];
	f >> n;
	f >> s >> t;
	d[1] = 0;
	for (int i = 2; i <= n; ++i)
		f >> d[i];
}

void ThucHien()
{
	// Khoi tao
	int p;
	int j;
	for (int i = s + 1; i <= t; ++i)	
		A[i] = INT_MAX;

	A[s] = 0;
	// Tim phuong an toi uu	
	for (i = s; i <= t - 1; ++i)
		for (j = i + 1; j <= t; ++j)
		{			
			p = Chon(d[j] - d[i]);
			if (p != 0 && A[i] != INT_MAX)
				A[j] = __min(A[j], A[i] + C[p]);
		}
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);
	f << A[t];
}

int Chon(int kc)
{
	if (kc <= L[1])
		return 1;
	
	if (kc <= L[2])
		return 2;

	if (kc <= L[3])
		return 3;

	return 0;
}