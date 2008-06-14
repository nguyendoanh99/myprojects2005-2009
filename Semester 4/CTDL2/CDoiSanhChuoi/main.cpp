// Ho ten : Nguyen Dang Khoa
// MSSV : 0512175
// Thuc hanh ca 2 sang thu 7

// Chuong trinh chi lam viec dung voi file khong co ki tu xuong dong
#include "CDoiSanhChuoi.h"
#include "CBruteForce.h"
#include "CMP.h"
#include "CKMP.h"
#include <iostream.h>
#include <fstream.h>
#include <string.h>
#include <windows.h>
#define MAX 200

int ThuatToan(char *fileT, char *fileP, CDoiSanhChuoi *P);
void ThucHien(char *fileT, char *fileP, CDoiSanhChuoi *P);
void main()
{
	CDoiSanhChuoi *P;
	// Thuat toan Brute Forece
	P = new CBruteForce;
	cout << "Thuat toan Brute Force" << endl;
	ThucHien("string.txt", "pattern.txt", P);
	cout << endl;
	delete P;

	// Thuat toan Morris-Pratt
	P = new CMP;
	cout << "Thuat toan Morris-Pratt" << endl;
	ThucHien("string.txt", "pattern.txt", P);
	cout << endl;
	delete P;

	// Thuat toan Knuth-Morris-Pratt
	P = new CKMP;
	cout << "Thuat toan Knuth-Morris-Pratt" << endl;
	ThucHien("string.txt", "pattern.txt", P);
	cout << endl;
	delete P;
}

void ThucHien(char *fileT, char *fileP, CDoiSanhChuoi *P)
{
	int index;
	int t1, t2;
	
	t1 = GetTickCount();
	index = ThuatToan(fileT, fileP, P);
	t2 = GetTickCount();
	cout << "Vi tri tim thay: " << index << endl;
	cout << "Thoi gian thuc hien thuat toan: " << t2 - t1 << endl;
}

int ThuatToan(char *fileT, char *fileP, CDoiSanhChuoi *Q)
{
	char *T = new char[MAX];
	char *temp = new char[MAX];
	char *P = new char[MAX];
	int lenP;
	int index;
	int i = 0; // Luu vet cua chuoi cu
	ifstream f;
	// Doc P
	f.open(fileP);
	f.get(P, MAX);
	f.close();

	lenP = strlen(P);
	Q->GanP(P);
	// Doc T
	f.open(fileT);
	f.getline(T, MAX);
	Q->GanT(T);
	index = Q->ViTriTimThay();

	if (index != -1)
	{
		delete []T;
		delete []temp;
		delete []P;
		return i + index;
	}

//	i += MAX - lenP;
	i += (strlen(T) - lenP) + 1;
	while (!f.eof())
	{		
		strcpy(temp, &T[MAX - lenP]);
		f.getline(&temp[lenP - 1], MAX - lenP + 1);
		
		// Hoan vi
		char *temp1 = temp;
		temp = T;
		T = temp1;
		// Tim kiem
		Q->GanT(T);
		index = Q->ViTriTimThay();

		if (index != -1)
		{
			delete []T;
			delete []temp;
			delete []P;
			return i + index;
		}
//		i += MAX - lenP;
		i += (strlen(T) - lenP) + 1;
	}

	delete []T;
	delete []temp;
	delete []P;
	return -1;
}
