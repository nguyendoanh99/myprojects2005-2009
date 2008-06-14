#include <iostream.h>
#include <iomanip.h>

#define MAX_M 100
#define MAX_N 100

int A[MAX_M + 1][MAX_N + 1];
int t[MAX_M + 1]; // t[i] da tinh den phan tu thu t[i] cua dong thu i

int Try(int &n, int i, int j); // Tinh A[i][j]
int Ackerman(int m, int n);

void main()
{
	int m = 3;
	int n = 100;
	
	for (int i = 0; i <= m; ++i)
	{
		for (int j = 0; j <= n; ++j)
			cout << "A[" << i << "][" << j << "] = " << Ackerman(i, j) << endl;
//			cout << setw(5) << Ackerman(i, j) << flush;
		cout << endl;
	}
	
}

int Ackerman(int m, int n)
{
	// Khoi tao
	for (t[0] = 0; t[0] <= n; ++t[0])
		A[0][t[0]] = t[0] + 1;
	t[0] = n;
	//
	for (int i = 1; i <= m; ++i)
	{
		A[i][0] = Try(n, i - 1, 1);
		for (t[i] = 1; t[i] <= n; ++t[i])		
			A[i][t[i] % (n + 1)] = Try(n, i - 1, A[i][(t[i] - 1) % (n + 1)]);			
		
		t[i] = n;
	}

	return A[m][n];
}

int Try(int &n, int i, int j)
{
	if (t[i] < j)
	{
		if (i == 0)
		{
			for (++t[i]; t[i] <= j; ++t[i])
				A[i][t[i] % (n + 1)] = t[i] + 1;		
		}
		else
		{
			for (++t[i]; t[i] <= j; ++t[i])
				A[i][t[i] % (n + 1)] = Try(n, i - 1, A[i][(t[i] - 1) % (n + 1)]);
		}
		t[i] = j;
	}
	
	return A[i][j % (n + 1)];
}