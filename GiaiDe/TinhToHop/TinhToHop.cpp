#include <iostream.h>

void Xuat(int a[], int n);
int TinhToHop(int n, int k);

void main()
{
	cout << TinhToHop(10, 4);
}

int TinhToHop(int n, int k)
{
	int *C = new int[n+1];

	// C(1, 0) = C(1, 1) = 1
	C[0] = C[1] = 1;
	Xuat(C, 1);

	for (int j = 2; j <= n; ++j)
	{
		// C(j, j) = 1
		C[j] = 1;

		// Tinh C(j, i) voi i = [1, j -1]
		for (int i = j - 1; i >= 1; --i)
			C[i] = C[i-1] + C[i];
		Xuat(C, j);
	}

	int temp = C[k]; // C(n, k)
	delete C;

	return temp;
}

void Xuat(int a[], int n)
{
	for (int i = 0; i <= n; ++i)
		cout << a[i] << "\t";
	cout << endl;
}