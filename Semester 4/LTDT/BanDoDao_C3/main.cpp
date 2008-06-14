#include "fstream.h"
#include "iostream.h"
// Nhan dao bat dau tu 2
int **A;
int m, n, k;
int *dt; 
int n_dt;

void Input(char *filename);
void Output(char *filename);
void Run();
void main()
{
	n_dt = 0;
	Input("bando.txt");
	Run();
	Output("0512175.txt");	
}

void Output(char *filename)
{
	ofstream f;
	f.open(filename);

	int kq = 0;
	for (int i = 2; i < n_dt + 2; ++i)
	{
		cout << "dien tich dao " << i << " = " << dt[i] << endl;
		if (dt[i] >= k)
			++kq;
	}
	f << kq;
	
	for (i = 1; i <= m; ++i)
	{
		for (int j = 1; j <= n; ++j)
			cout << A[i][j] << " ";
		cout << endl;
	}
	for (i = 0; i <= m; ++i)
		delete []A[i];
	delete []A;
	delete []dt;
}

void Input(char *filename)
{
	ifstream f;
	f.open(filename);

	f >> m >> n >> k;

	A = new int*[m + 1];
	dt = new int[(m * n) / 2 + 2];
	
	for (int i = 0; i <= m; ++i)
		A[i] = new int[n + 2];

	for (i = 1; i <= m; ++i)
		for (int j = 1; j <= n; ++j)
			f >> A[i][j];

	for (int j = 0; j <= n + 1; ++j)	
	{
		A[0][j] = 0; // dong 0		
	}
	
	for (i = 0; i <= m; ++i)
	{
		A[i][0] = 0; // cot 0
		A[i][n + 1] = 0; // cot n + 1
	}
}

void Try(int i, int j, int label)
{
	if (A[i - 1][j] == A[i][j])
		Try(i - 1, j , label);

	int j1 = j - 1;
	while (A[i][j1] == A[i][j])
	{
		A[i][j1] = label;
		--j1;
	}

	j1 = j + 1;
	while (A[i][j1] == A[i][j])
	{
		A[i][j1] = label;
		++j1;
	}

	A[i][j] = label;
}

void Run()
{
	for (int i = 1; i <= m; ++i)
		for (int j = 1; j <= n; ++j)
			if (A[i][j] == 1)
			{
				if (A[i - 1][j] != 0) // dong tren la dao
				{
					// cot ben trai la 1 dao khac voi dao o dong tren
					if (A[i][j - 1] != 0 && A[i - 1][j] != A[i][j - 1]) 
					{
						// Khi gan lai nhan dinh thi lay dao nao co dien tich nho hon de gan lai
						if (dt[A[i - 1][j]] > dt[A[i][j - 1]])
						{
							A[i][j] = A[i - 1][j]; 
							dt[A[i][j]] += dt[A[i][j - 1]];
							dt[A[i][j - 1]] = 0;
							// Gan lai nhan dinh
							Try(i, j - 1, A[i - 1][j]);						
						}
						else
						{
							A[i][j] = A[i][j - 1]; 
							dt[A[i][j]] += dt[A[i - 1][j]];
							dt[A[i - 1][j]] = 0;
							// Gan lai nhan dinh
							Try(i - 1, j, A[i][j - 1]);						
						}

					}
					else
					{	
						A[i][j] = A[i - 1][j]; 
						
						int t = j - 1;
						while (A[i][t])
						{
							A[i][t] = A[i][j];
							--t;
						}
					}
				}
				else
					if (A[i][j - 1] != 0)	// cot ben trai la dao
						A[i][j] = A[i][j - 1];					
					else
					{	// diem dang xet la mot dao moi
						dt[n_dt + 2] = 0;
						A[i][j] = n_dt + 2;
						
						++n_dt;
					}
				++dt[A[i][j]]; // Tang dien tich 
			}	
}