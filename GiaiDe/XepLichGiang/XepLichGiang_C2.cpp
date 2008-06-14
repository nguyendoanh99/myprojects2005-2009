
#include <iostream.h>
#include <fstream.h>
#include <limits.h>

#define MAX 1000

int a[MAX + 1];
int d[MAX + 1]; // d[j] tong muc hao phi thap nhat khi giang tu van de 1 den van de j
int Ngay[MAX + 1]; // ngay[j] so ngay it nhat khi giang tu van de 1 den van de j
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
	cout << Ngay[n] << " " << d[n];
	Output("LICH.OUT");
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);
	f << Ngay[n] << endl;
	f << d[n];
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
	Ngay[0] = 1;	
	int T = 0;
	for (int i = 1; i <= n; ++i)
	{
		T += a[i];
		if (T <= L)
			Ngay[i] = Ngay[i - 1];
		else
		{
			T = a[i];
			Ngay[i] = Ngay[i - 1] + 1;
		}
		
		d[i] = INT_MAX;
	}	

	Ngay[0] = 0;	
	// Tim phuong an toi uu
	int B; // tong so gio khi giang tu van de i + 1 den van de j
	for (i = 0; i <= n - 1; ++i)
	{
		B = 0;
		for (int j = i + 1; j <= n; ++j)
		{
			B += a[j];
			
			if (B <= L)
			{
				if (Ngay[j] == Ngay[i] + 1)
				{
					int t = MucPhi(L - B);
					if (d[j] > d[i] + t)
						d[j] = d[i] + t;
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
