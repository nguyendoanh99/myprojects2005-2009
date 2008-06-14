// testTT.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string.h>
#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <stdio.h>
#include <time.h>

using namespace std;
char s1[200];
int key = 90;
int* Tao(char *, int k);
void out(char *, int *, int );
void out1(char *, char *);
int _tmain(int argc, _TCHAR* argv[])
{
	  srand( (unsigned)time( NULL ) );

//	int i;
//	for (i = 1; i < 127; ++i)
//		s1[i - 1] = i;
//	s1[i] = '\0';
	//strcpy(s1,  "4KAN tuwj tin, doanf kets");	
	key = rand() % 256;
	strcpy(s1,  "Chu'c muwngf sinh nha^.t! ^~^");	
	int *s = Tao(s1, key);
	out1("_test1.txt",s1);
	out("test1.txt", s, key);

	key = rand() % 256;
	strcpy(s1,  "Ke? tha('ng mo+'i la` ke? ma.nh");	
	//strcpy(s1, "Ho6m_nay_se~_laf_mo^.t_nga'y_d9e.p_tr[fi_?");	
	s = Tao(s1, key);
	out1("_test2.txt",s1);
	out("test2.txt", s, key);

	key = rand() % 256;
	strcpy(s1,  "Khoong bao giowf du7o7c5 bo3 cuo6c5");	
	
//	strcpy(s1, "D]ngf-bao-gi[f-da'nh-ma^'t-chi1nh-minh2");	
	s = Tao(s1, key);
	out1("_test3.txt", s1);
	out("test3.txt", s, key);
	
	key = rand() % 256;
	strcpy(s1,  "Chie^'n tha('ng la` mu.c tie^u cuo^'i cu`ng");	
//	strcpy(s1, "Moi5.ng][if.haxy.co^'.le6n?");	
	s = Tao(s1, key);
	out1("_test4.txt",s1);
	out("test4.txt", s, key);
	
	return 0;
}

void out1(char *filename, char *s)
{
	ofstream f;
	f.open(filename);
	char buffer[65];
	f << "Chieu dai chuoi : " << strlen(s) << endl;
	cout << "Chieu dai chuoi : " << strlen(s) << endl;
	f << "key = " << key << endl;
	f << s << endl;
	for (int i = 0; i < strlen(s); ++i)
	{
		/*
		 _itoa_s(s[i], buffer, 65, 2 );
		 for ( int j = strlen(buffer); j < 8; ++j)
		 {
			 f << "0";
			 cout << "0";
		 }
*/
		f << int(s[i]) << "\t " << int(s[i] ^ key) << " (" << s[i] << ") " << endl;
//		f << buffer << " (" << s[i] << ") " << int(s[i]) << endl;
//		cout << buffer << "\t" << int(s[i]) << "\t" << int(s[i] ^ key) << " (" << s[i] << ")" << endl;
	}

}

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
int *Tao(char *s, int k)
{
	int len = strlen(s);
	int *temp = new int[strlen(s)];
	for (int i = 0; i < strlen(s); ++i)
		temp[i] = s[i] ^ k;
	
	return temp;
}