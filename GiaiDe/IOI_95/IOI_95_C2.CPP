#include <iostream.h>
#include <fstream.h>
#include <stdlib.h>

int b;
int s;
int L[6][6][6][6][6];
int c[6] = {0};
int k[6] = {0};
int p[6];
int t[1000];
int d[100][6] = {0};

void Input(char *filename1, char *filename2);
void Output(char *filename);
void ThucHien();
void KhoiTao();
void qhd(int n1, int n2, int n3, int n4, int n5);

void main()
{
	Input("INPUT.TXT","OFFER.TXT");
	ThucHien();	
	Output("OUTPUT.TXT");
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);
	 
	f << L[k[1]][k[2]][k[3]][k[4]][k[5]];
}

void KhoiTao()
{
	int n[6];

	for (int j = 1; j <= 5; ++j)
		n[j] = k[j];

	int i[6];
	for (i[1] = 0; i[1] <= n[1]; ++i[1])
		for (i[2] = 0; i[2] <= n[2]; ++i[2])
			for (i[3] = 0; i[3] <= n[3]; ++i[3])
				for (i[4] = 0; i[4] <= n[4]; ++i[4])
					for (i[5] = 0; i[5] <= n[5]; ++i[5])
					{
						L[i[1]][i[2]][i[3]][i[4]][i[5]] = 0;
						for (int j = 1; j <= 5; ++j)
							L[i[1]][i[2]][i[3]][i[4]][i[5]] += i[j] * p[j];
					}
}

void Input(char *filename1, char *filename2)
{
	ifstream f;
	f.open(filename1);

	f >> b;

	for (int i = 1; i <= b; ++i)	
	{
		f >> c[i] >> k[i] >> p[i];
		t[c[i]] = i;
	}

	KhoiTao();
	// Doc file thu 2
	int n;	
	int c1;

	f.close();
	f.open(filename2);
	
	f >> s;

	for (i = 1; i <= s; ++i)
	{		
		f >> n;

		for (int j = 1; j <= n; ++j)
		{
			f >> c1;
			f >> d[i][t[c1]];			
		}
		int *tt = d[i];
		f >> L[tt[1]][tt[2]][tt[3]][tt[4]][tt[5]];
	}
}

void ThucHien()
{
	for (int i5 = 0; i5 <= k[5]; ++i5)
		for (int i4 = 0; i4 <= k[4]; ++i4)
			for (int i3 = 0; i3 <= k[3]; ++i3)
				for (int i2 = 0; i2 <= k[2]; ++i2)
					for (int i1 = 0; i1 <= k[1]; ++i1)
						qhd(i1, i2, i3, i4, i5);
}

void qhd(int n1, int n2, int n3, int n4, int n5)
{
	for (int j = 1; j <= s; ++j)
	{
		int *t = d[j];
		if (n1 - t[1] >= 0 && n2 - t[2] >= 0 && n3 - t[3] >= 0
			&& n4 - t[4] >= 0 && n5 - t[5] >= 0)
		{

			L[n1][n2][n3][n4][n5] = __min(L[n1][n2][n3][n4][n5], 
				L[t[1]][t[2]][t[3]][t[4]][t[5]] + 
				L[n1 - t[1]][n2 - t[2]][n3 - t[3]][n4 - t[4]][n5 - t[5]]);
		}
	}
}