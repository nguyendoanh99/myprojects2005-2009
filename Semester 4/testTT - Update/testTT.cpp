// testTT.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string.h>
#include <iostream>
#include <fstream>
using namespace std;
char s1[200];
int key = 208;
int n = 128;
int* Tao(char *, int k);
//void out(char *, int *, int );
void out1(char *, char *);
int main(int argc, char* argv[])
{
	int i;
	for (i = 0; i < 127; ++i)
		s1[i - 1] = i;
	s1[i] = '\0';
	//strcpy(s1,  "4KAN tuwj tin, doanf kets");	
//	int *s = Tao(s1, 100);
	out1("_test1.txt",s1);
	return 0;
}

void out1(char *filename, char *s)
{
	ofstream f;
	f.open(filename);
//	char buffer[65];
	f << "Chieu dai chuoi : " << strlen(s) << endl;
//	cout << "Chieu dai chuoi : " << strlen(s) << endl;
	for (int i = 0; i < n; ++i)
//		if (i % 4 == 0)
	{
		ofstream g;
		g.open("team.txt");
		f << i;
		cout << i << "\t";
		for (int j = 0; j < 3; ++j)
		{
			g << ((i ^ (key + j)) - ((i-1) ^ (key + j))) << " ";
			f<< "\t" << (i ^ (key + j));
//			cout<< "\t" << (i ^ (key + j)) << "(" << ((i ^ (key + j)) - ((i-1) ^ (key + j))) << ")";
			cout << (i ^ (key + j)) << "(" << ((i ^ (key + j)) - ((i-1) ^ (key + j))) << ")" << "\t\t";
		}
		cout << endl;
		f << endl;
		g << endl;
	}

}
/*
void out(char *filename, int *s, int k)
{
	ofstream f;
	f.open(filename);
	char buffer[65];
	f << k << endl;
	cout << k << endl;
	int len = strlen(s1);
	for (int i = 0; i < strlen(s1); ++i)
	{
		 _itoa_s(s[i], buffer, 65, 2 );
		 for ( int j = strlen(buffer); j < 8; ++j)
		 {
			 f << "0 ";
			 cout << "0 ";
		 }
		for (int j = 0; j <strlen(buffer); j++)
		{
			f << buffer[j] << " ";
			cout << buffer[j] << " ";
		}
//		f << buffer;
	}
}
*/
int *Tao(char *s, int k)
{
	int len = strlen(s);
	int *temp = new int[strlen(s)];
	for (int i = 0; i < strlen(s); ++i)
		temp[i] = s[i] ^ k;
	
	return temp;
}
