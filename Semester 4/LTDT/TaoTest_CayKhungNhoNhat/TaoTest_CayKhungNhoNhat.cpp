// TaoTest_CayKhungNhoNhat.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdlib.h"
#include "fstream.h"
#include <time.h>
#include "memory.h"
#include <vector>
struct Canh
{
	short x;
	short y;
};
void Tao(char *filename, int iDinh, int iCanh);

int main(int argc, char* argv[])
{
	Tao("prim.txt", 100, 4950);
	return 0;
}

void Tao(char *filename, int iDinh, int iCanh)
{
	ofstream f;
	f.open(filename);

	f << iDinh << "\t" << iCanh << endl;

	srand( (unsigned)time( NULL ) );

//	int **A;
//	A = new int*[iDinh + 1];
//	
//	for (int i = 1; i <= iDinh; ++i)
//	{
//		A[i] = new int[iDinh + 1];
//		memset(A[i], 0, sizeof(A[0][0]) * (iDinh + 1));
//	}

	Canh* A = new Canh[(iDinh * (iDinh - 1) / 2)];
	int d = 0;
	for (int i = 1; i < iDinh; ++i)
		for (int j = i + 1; j <= iDinh; ++j)
		{			
			A[d].x = i;
			A[d].y = j;
			++d;
		}

	int t;
	for (i = 0; i < iCanh; ++i)
	{
		t = (rand() % d);

		f << A[t].x << "\t" << A[t].y << "\t" << (rand() % (iDinh * 2)) + 1 << endl;

		--d;
		Canh temp = A[t];
		A[t] = A[d];
		A[d] = temp;		
	}
	delete []A;
	/*
	int x, y;
	for (i = 0; i < iCanh; ++i)
	{
		x = (rand() % (iDinh - 1)) + 1;
		y = (rand() % (iDinh - x)) + 1 + x;

		if (x > iDinh || y > iDinh)
			cout << i << endl;

		if (A[x][y] == 0)
		{
			A[x][y] = A[y][x] = (rand() % iDinh) + 1;
			f << x << " " << y << " " << A[x][y] << endl;
		}
	}	
	*/
//	for (i = 1; i <= iDinh; ++i)
//		delete []A[i];
//	delete []A;
}