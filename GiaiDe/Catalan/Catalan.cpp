#include <iostream.h>

int Catalan(int n);

void main()
{
	cout << Catalan(15);
}

int Catalan(int n)
{
	int *T = new int[n + 1];

	T[1] = 1;

	for (int j = 2; j <= n; ++j)
	{
		// Tinh T[j]
		T[j] = 0;
		for (int i = 1; i < j; ++i)
			T[j] += T[i] * T[j - i];
	}
	
	int kq = T[n];
	delete T;
	return kq;
}