#include <iostream>
#include <string>

#define MAX 100
using namespace std;

char P[MAX];
char T[MAX];
int m;
int n;
int Next[MAX];

void initNext(char *);
int Search_KMP(char *,char *);
void main()
{
	cout << "Nhap T: ";
	cin.getline(T,100);
	cout << "Nhap P: ";
	cin.getline(P, 100);
	
	m = strlen(P);
	n = strlen(T);

	initNext(P);
	cout << "Vi tri cua P trong T: ";
	cout << Search_KMP(T, P);
}

void initNext(char *P)
{
	int j = Next[0] = -1;
	int i = 0;

	while (i < m)
	{
		if (j == -1 || P[i] == P[j])
		{
			++i;
			++j;

			if (P[i] != P[j])
				Next[i] = j;
			else
				Next[i] = Next[j];
		}
		else
			j = Next[j];
	}
}

int Search_KMP(char *T, char *P)
{
	int i = 0;
	int j = 0;

	while (i < n)
	{
		while (j >= 0 && T[i] != P[j])
		{
			j = Next[j];
		}

		++i;
		++j;
		
		if (j >= m)
			return (i - j);
	}

	return -1;
}