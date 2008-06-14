#include <iostream.h>
#include <fstream.h>
#include <stdlib.h>
#include <time.h>

void TaoMang(int m, int n, char *filename);

void main()
{
	TaoMang(100, 11, "bando.txt");
}

void TaoMang(int m, int n, char *filename)
{
	ofstream f;
	f.open(filename);

	srand((unsigned) time(NULL));
	f << m << " " << n << endl;
	int t;
	for (int i = 1; i <= m; i++)
	{
		for (int j = 1; j <= n; j++)
		{
//			if (i == 1 && j <= n / 2)
//				t = 0;
//			else
				t = 1;//(rand() % 2);
			f << t << " ";
		}
		f << endl;
	}
}
