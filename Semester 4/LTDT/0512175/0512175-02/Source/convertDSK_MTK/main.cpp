#include <iostream.h>
#include <fstream.h>

void ThucHien(char *ifile, char *ofile);

void main()
{
	ThucHien("dske.txt", "mtke.txt");
}

void ThucHien(char *ifile, char *ofile)
{
	ifstream f;
	f.open(ifile);

	ofstream g;
	g.open(ofile);

	int n;
	int temp;

	f >> n;
	g << n << endl;
	

	int a[100][100] = {0};

	for (int i = 1; i <= n; ++i)
	{
		while (1)
		{
			f >> temp;
			if (temp == 0)
				break;

			a[i][temp] = 1;
		}
	}

	for (i = 1; i <= n; ++i)
	{
		for (int j = 1; j <= n; ++j)
			g << a[i][j] << " ";
		
		g << endl;
	}
}