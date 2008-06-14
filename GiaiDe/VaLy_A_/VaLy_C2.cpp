/*
#include <iostream.h>
#include <fstream.h>
#include <stdlib.h>
#include <limits.h>

#define MAX_N 100
#define MAX_W 120

int A[MAX_N + 1];
int C[MAX_N + 1];
int L[MAX_W + 1];   // L[i] chua tong gia tri cua valy co trong luong i trong cach chon toi uu
int p1[MAX_W + 1];  // valy co trong luong L[i] duoc tach thanh 1 valy co trong luong p1[i]
int p2[MAX_W + 1];  // va 1 valy co trong luong p2[i] trong cach chon toi uu
int kq[MAX_N + 1];  // kq[i] so luong cua vat co so hieu i
int tong;
int n;
int w;

void Input(char *filename);
void Output(char *filename);
void ThucHien();
void PhanRa(int t); // Tim cach chon toi uu cho valy co trong luong la t
void Try(int t); // Lan nguoc de tim ket qua

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
	C[0] = 0;
	L[0] = 0;
	p1[0] = 0;
	p2[0] = 0;
	for (int i = 1; i <= w; ++i)
	{
		// Tim vat thu t co C[t] lon nhat va A[t] <= i
		int t = 0;
		for (int j = 1; j <= n; ++j)
			if (A[j] <= i && C[t] < C[j])
				t = j;
		// Bo vat thu t vao valy co trong luong i
		L[i] = C[t];
		p1[i] = t;
		p2[i] = 0;
	}
	
	for (i = 1; i <= w; ++i)
		PhanRa(i);

	Try(w);
	tong = L[w];
}

void PhanRa(int t)
{
	for (int i = t; i >= (t + 1) / 2; --i)
		if (L[t] < L[i] + L[t - i])
		{
			L[t] = L[i] + L[t - i];
			p1[t] = i;
			p2[t] = t - i;
		}
}

void Try(int t)
{
	// neu valy thu 2 bang 0 thi vat co so hieu p1[t] duoc chon de bo vao valy co trong luong t
	// trong cach chon toi uu
	if (p2[t] == 0)	
		++kq[p1[t]];
	else
	{
		Try(p1[t]);
		Try(p2[t]);
	}	
}

*/