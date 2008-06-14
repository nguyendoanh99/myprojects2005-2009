/*
#include <iostream.h>
#include <fstream.h>
#include <limits.h>

#define MAX 100

int a[MAX + 1];
int w[MAX + 1]; // w[j] tong muc hao phi thap nhat khi giang tu van de j den van de n
int s[MAX + 1]; // s[j] so buoi it nhat khi giang tu van de j den van de n
int L;
int C;
int n;

void Input(char *filename);
void Output(char *filename);
void ThucHien();
int MucPhi(int t); // Muc hao phi tuong ung voi t

void main()
{
	Input("LICH.INP");
	ThucHien();
	cout << s[1] << " " << w[1];
	Output("LICH.OUT");
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);
	f << s[1] << endl;
	f << w[1];
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);
	f >> n;
	f >> L >> C;
	for (int i = 1; i <= n; ++i)
		f >> a[i];
}

void ThucHien()
{
	// Khoi tao
	int B = 0;
	s[ n + 1] = 1;
	int t;
	for (int i = n; i >= 1; --i)
	{		
		B += a[i];

		if (B <= L)			
			s[i] = s[i + 1];		
		else
		{		
			B = a[i]; 
			s[i] = s[i + 1] + 1;
		}
		w[i] = INT_MAX;
	}
	s[n + 1] = 0;
	w[n + 1] = 0;
	// Tim phuong an toi uu	
	for (i = n; i >= 1; --i)
	{
		B = 0;
		for (int j = i; j <= n; ++j)
		{
			B += a[j];
			if (B <= L)
			{
				if (s[i] == s[j + 1] + 1)
				{
					t = MucPhi(L - B);
					if (w[j + 1] + t < w[i])
						w[i] = t + w[j + 1];
				}
			}
			else
				break;
		}
	}
}

int MucPhi(int t)
{
	if (t == 0)
		return 0;
	else
		if (1 <= t && t <= 10)
			return -C;
		else
			return (t - 10) * (t - 10);
}
*/