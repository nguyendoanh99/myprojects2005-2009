#include <iostream.h>
#include <fstream.h>
#include <math.h>
#include <float.h>
#include <iomanip.h>

#define MAX 100

int x[MAX];
int y[MAX];
float L[MAX][MAX];
int kq[MAX][MAX]; // Luu vi tri 
int n;
ofstream f;

void Input(char *filename);
void Output(char *filename);
void ThucHien();
void Try(int q, int p);
float kc(int i, int j);

void main()
{
	Input("CHIADAGIAC.INP");
	ThucHien();
	Output("CHIADAGIAC.OUT");
	int vt = 0;
	for (int i = 1; i < n; ++i)
	{
		if (L[vt][n - 2] > L[i][n - 2])
			vt = i;
	}
	for (i = 0; i < n; ++i)
	{
		for (int j = 0; j < n - 1; ++j)
			cout << setprecision(2) << L[i][j] << "  ";
		cout << endl;
	}
	cout << endl << endl;
	for (i = 0; i < n; ++i)
	{
		for (int j = 0; j < n - 1; ++j)
			cout << kq[i][j] << " ";
		cout << endl;
	}
	f << L[vt][n - 2] << endl;
/*
	struct 
	{
		int d;
		int t;
	} s[MAX + 1];
	int top = 1;
	int q;
	int p;
	s[top].d = vt;
	s[top].t = n - 2;

	while (top > 0)
	{
		q = s[top].d;
		p = s[top].t;
		top--;
		f << q << " " << (q + p) % n << endl;
		cout << q << " " << (q + p) % n << endl;
		if (kq[q][p] != 0)
		{
			s[top + 1].d = q;
			s[top + 1].t = kq[q][p];
			if (kq[q][p] != 1)
				top++;
			s[top + 1].d = (q + kq[q][p]) % n;
			s[top + 1].t = p - kq[q][p];
			if (p - kq[q][p] != 1)
				++top;
		}
	}
*/
	Try(vt, n - 2);
}

void Output(char *filename)
{
	f.open(filename);
}

void Try(int q, int p)
{
	f << q << " " << (q + p) % n << endl;
	cout << q << " " << (q + p) % n << endl;
	if (kq[q][p] != 0)
	{
		if (kq[q][p] != 1)
			Try(q, kq[q][p]);
		if (p - kq[q][p] != 1)
			Try((q + kq[q][p]) % n, p - kq[q][p]);
	}
}
void Input(char *filename)
{
	ifstream f;
	f.open(filename);

	f >> n;
	for (int i = 0; i < n; ++i)
		f >> x[i] >> y[i];
}

void ThucHien()
{
	// Khoi tao
	for (int q = 0; q < n; ++q)
	{
		L[q][0] = 0;
		L[q][1] = 0;
		L[q][2] = kc(q, q + 2);
	}
	// Tim phuong an toi uu
	float min;
	int vt;
	for (int p = 3; p < n - 1; ++p)
	{		
		for (q = 0; q < n; ++q)
		{
			
			min = FLT_MAX;
			
			for (int i = 1; i < p; ++i)
				if (min > L[q][i] + L[(q + i) % n][p - i])
				{
					min = L[q][i] + L[(q + i) % n][p - i];
					vt = i;
				}
			L[q][p] = min + kc(q, q + p); 
			kq[q][p] = vt;
		}
	}
}

float kc(int i, int j)
{
	i = i % n;
	j = j % n;
	int kx = x[i] - x[j];
	int ky = y[i] - y[j];

	return sqrt(kx * kx + ky * ky);
}