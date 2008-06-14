#include <iostream.h>
#include <fstream.h>
#include <string.h>
#include <stdlib.h>

#define MAX 255

char x[255];
char y[255];
int L[MAX + 1][MAX + 1]; // L[i][j] la so phep bien doi khi bien doi xau x1..xj thanh y1..yi
int m; // Chieu dai cua chuoi y
int n; // Chieu dai cua chuoi x
int d[2 * MAX + 1]; // chua vi tri dang xet tren Y
int c[2 * MAX + 1]; // chua vi tri dang xet tren X
int k; 

void Input(char *filename);
void Output(char *filename);
void ThucHien();

void main()
{
	Input("QHD06.INP");
	ThucHien();
	Output("QHD06.OUT");
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);
	f.getline(x, 255);
	f.getline(y, 255);
	n = strlen(x);
	m = strlen(y);
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);
	f << L[m][n] << endl;

	int t = 0; // Chieu dai them cua X hien tai so voi X ban dau

	for (int i = k; i >= 2; --i)
	{
		if (c[i] == c[i - 1])
		{
			f << "I " << y[d[i - 1] - 1] << " " << c[i] + t + 1 << endl;
			cout << "I " << y[d[i - 1] - 1] << " " << c[i] + t + 1 << endl;
			++t;
		}

		if (d[i] == d[i - 1])
		{
			f << "D " << c[i - 1] + t << endl;
			cout << "D " << c[i - 1] + t << endl;
			--t;
		}

		if (c[i] == c[i - 1] - 1 && d[i] == d[i - 1] - 1)
			if (x[c[i - 1] - 1] != y[d[i - 1] - 1])
			{			
				f << "R " << c[i - 1] + t<< " " << y[d[i - 1] - 1] << endl;
				cout << "R " << c[i - 1] + t<< " " << y[d[i - 1] - 1] << endl;
			}
	}
}

void ThucHien()
{
	// Khoi tao
	for (int i = 0; i <= m; ++i)
		L[i][0] = i;
	
	for (int j = 0; j <= n; ++j)
		L[0][j] = j;
	// Tim phuong an toi uu
	for (i = 1; i <= m; ++i)
		for (j = 1; j <= n; ++j)
			if (y[i - 1] == x[j - 1])
				L[i][j] = L[i - 1][j - 1];
			else
				L[i][j] = __min(L[i - 1][j], __min(L[i][j - 1], L[i - 1][j - 1])) + 1;

	for (i = 0; i <= m; ++i)
	{
		for (j = 0; j <= n; ++j)
			cout << L[i][j] << " ";
		cout << endl;
	}
	// Lan nguoc tim ket qua
	i = m;
	j = n;
	k = 0;
	do
	{
		++k;
		d[k] = i;
		c[k] = j;
		if (i > 0 && j > 0)
		{
			if (x[j - 1] == y[i - 1])
			{
				--i;
				--j;
			}
			else
			{
				if (L[i][j] == L[i - 1][j - 1] + 1)
				{
					--i;
					--j;
				}
				else
					if (L[i][j] == L[i - 1][j] + 1)
						--i;
					else
						--j;
			}
		}
		else
		{
			if (i > 0)
				--i;
			else
				--j;
		}
	} while (i != 0 || j != 0);
	++k;
	d[k] = 0;
	c[k] = 0;
}