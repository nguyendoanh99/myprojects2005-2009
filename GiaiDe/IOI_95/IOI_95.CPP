/*
#include <iostream.h>
#include <fstream.h>
#include <limits.h>

int b;
int L[6][6][6][6][6];
int c[6] = {0};
int k[6] = {0};

void Input(char *filename1, char *filename2);
void Output(char *filename);
void ThucHien();
int tim(int c1); // Tim vi tri xuat hien cua c1 trong mang c
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

	for (int i = 1; i <= b; ++i)
		n[i] = 5;

	for (; i <= 5; ++i)
		n[i] = 0;

	for (int i1 = 0; i1 <= n[1]; ++i1)
		for (int i2 = 0; i2 <= n[2]; ++i2)
			for (int i3 = 0; i3 <= n[3]; ++i3)
				for (int i4 = 0; i4 <= n[4]; ++i4)
					for (int i5 = 0; i5 <= n[5]; ++i5)
						L[i1][i2][i3][i4][i5] = INT_MAX;

	L[0][0][0][0][0] = 0;
}

void Input(char *filename1, char *filename2)
{
	ifstream f;
	int t[6] = {0};
	int p;
	f.open(filename1);

	f >> b;

	KhoiTao();

	for (int i = 1; i <= b; ++i)
	{
		f >> c[i] >> k[i] >> p;
		
		t[i] = 1;
		L[t[1]][t[2]][t[3]][t[4]][t[5]] = p;
		t[i] = 0;
	}
	// Doc file thu 2
	int s;
	int n;
	int vt;
	int c1;
	int k1;

	f.close();
	f.open(filename2);

	f >> s;

	for (i = 1; i <= s; ++i)
	{		
		f >> n;
		int flag = 1;
		for (int j = 1; j <= n; ++j)
		{
			f >> c1 >> k1;

			if (flag == 1)
			{
				vt = tim(c1);
				if (vt == -1)
					flag = 0;
				else
					t[vt] = k1;
			}
		}

		f >> p;

		if (flag == 1)
			L[t[1]][t[2]][t[3]][t[4]][t[5]] = p;

		for (j = 1; j <= 5; ++j)
			t[j] = 0;
	}
}

int tim(int c1)
{
	for (int i = 1; i <= b; ++i)
		if (c1 == c[i])
			return i;

	return -1;
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
	int temp;
	cout << "L[" << n1 << "," << n2 << "," << n3 << "," << n4 << "," << n5 << "] = ";
	cout << L[n1][n2][n3][n4][n5] << " = ";
	for (int i1 = 0; i1 <= n1; ++i1)
		for (int i2 = (int) (i1 * ((n2 + 1.0) / (n1 + 1))); i2 <= n2; ++i2)
			for (int i3 = (int) (i2 * ((n3 + 1.0) / (n2 + 1))); i3 <= n3; ++i3)
				for (int i4 = (int) (i3 * ((n4 + 1.0) / (n3 + 1))); i4 <= n4; ++i4)
					for (int i5 = (int) (i4 * ((n5 + 1.0) / (n4 + 1))); i5 <= n5; ++i5)
					{
						if (L[i1][i2][i3][i4][i5] == INT_MAX 
							|| L[n1 - i1][n2 - i2][n3 - i3][n4 - i4][n5 - i5] == INT_MAX)
							temp = INT_MAX;
						else
							temp = L[i1][i2][i3][i4][i5] + L[n1 - i1][n2 - i2][n3 - i3][n4 - i4][n5 - i5];
						if (L[n1][n2][n3][n4][n5] > temp)
						{
							L[n1][n2][n3][n4][n5] = temp;
							cout << "L[" << i1 << "," << i2 << "," << i3 << "," << i4 << "," << i5 << "] + ";
							cout << "L[" << n1 - i1 << "," << n2 - i2 << "," << n3 - i3 << "," << n4 - i4 << "," << n5 - i5 << "]; ";
						}
					}		

	cout << "(" << L[n1][n2][n3][n4][n5] << ")" << endl;
}
*/