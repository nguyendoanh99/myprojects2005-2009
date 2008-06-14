// stdafx.cpp : source file that includes just the standard includes
//	0512175_BTTuan5.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include <fstream>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file


// #include <typeinfo.h>
// LPhanSo A;
// type_info &b = typeid(A);


// Xem chuoi s xuat hien bao nhieu lan trong T
int Tim(const string &s, const vector<VecStr> &T, int iDau, int jDau)
{
	int d = 0;
	for (int i = iDau; i < T.size(); ++i)
	{
		for (int j = jDau; j < T[i].size(); ++j)
			if (s == T[i][j])
				++d;
		jDau = 0;
	}

	return d;
}
// Tim xem trong VS co chuoi s khong
// Tra ve true neu co
// Tra ve false neu khong co
bool TimThay(const string &s, const VecStr &VS)
{
	for (int i = 0; i < VS.size(); ++i)
		if (s == VS[i])
			return true;
	return false;
}
// Tim cac tu xuat hien nhieu nhat trong doan van
void TimTu(const vector<VecStr> &T, VecStr &kq)
{	
	int max = -1;
	for (int i = 0; i < T.size(); ++i)
	{
		for (int j = 0; j < T[i].size(); ++j)
			if (!TimThay(T[i][j], kq))
			{
				int t = Tim(T[i][j], T, i, j);
				// Neu T[i][j] xuat hien nhieu hon max thi lam rong kq
				// roi dua T[i][j] vao kq
				if (t > max)
				{
					max = t;
					kq.erase(kq.begin(), kq.end());
					kq.push_back(T[i][j]);
				}
				else
					// Neu T[i][j] xuat hien bang voi max thi chi them T[i][j] vao kq
					if (t == max)
						kq.push_back(T[i][j]);
			}
	}
}
// Sap xep chuoi tang dan theo thuat toan QuickSort
void QuickSort(VecStr &VS, int l, int r)
{
	string sMid = VS[(l + r) / 2];
	int i = l;
	int j = r;

	do
	{
		while (VS[i] < sMid)
			++i;

		while (sMid < VS[j])
			--j;

		if (i <= j)
		{
			// hoan vi
			string tam = VS[i];
			VS[i] = VS[j];
			VS[j] = tam;

			++i;
			--j;
		}
	}
	while (i < j);

	if (i < r)
		QuickSort(VS, i, r);

	if (l < j)
		QuickSort(VS, l, j);

}
// Tim ky tu ket thuc cau trong chuoi s
int TimKetThucCau(const string &s)
{
	int i[3];
	int iViTri = s.length() + 1;
	i[0] = s.find('.');
	i[1] = s.find('!');
	i[2] = s.find('?');

	for (int j = 0; j < 3; ++j)
		if (i[j] > -1)
			iViTri = __min(iViTri, i[j]);

	if (iViTri == s.length() + 1)
		iViTri = -1;
	
	return iViTri;
}

bool DocFile(char *filename, vector<VecStr> &T)
{		
	ifstream f;
	f.open(filename);

	if (f.bad())	
		return false;

 	string s;
	char stemp[256];
	do 
	{
		f.get(stemp, 10);
		s += stemp;
		
		int iViTri = TimKetThucCau(s);
		
		while (iViTri != -1)
		{			
			VecStr VTam;
			// Tach 1 cau ra khoi doan
			string s1 = s.substr(0, iViTri + 1);			
			s.erase(0, iViTri + 1);

			// Tach cac tu ra khoi 1 cau
			int t = s1.find(' ');

			while (t != -1)
			{
				string sTam = s1.substr(0, t);
				if (sTam.length() != 0)
					VTam.push_back(sTam);
				s1.erase(0, t + 1);				
				t = s1.find(' ');
			}

			string sTam = s1.substr(0, s1.length() - 1);
			if (sTam.length() != 0)
				VTam.push_back(sTam);
			VTam.push_back(s1.substr(s1.length() - 1, 1)); // Lay ky tu ket thuc cau
			T.push_back(VTam);	

			iViTri = TimKetThucCau(s);
		}
	} 
	while(!f.eof() && stemp);

	for (int i = 0; i < T.size(); ++i)
	{
		for (int j = 0; j < T[i].size(); ++j)			
			cout << T[i][j] << " ";
		cout << endl;
	}
	f.close();

	return true;
}

bool GhiFile(char *filename, vector<VecStr> &T)
{
	ofstream f;
	f.open(filename);

	if (f.bad())
		return false;
	
	// Cau a
	f << T.size() << endl;
	
	// Cau b
	for (int i = 0; i < T.size(); ++i)
		f << T[i].size() - 1 << endl; // Do co phan tu cuoi chua ky tu ket thuc cau

	// Cau c
	VecStr kq;
	TimTu(T, kq);

	for (i = 0; i < kq.size(); ++i)
		f << kq[i] << " ";

	f << endl;
	// Cau d
	// Sap xep
	for (i = 0; i < T.size(); ++i)
		QuickSort(T[i], 0, T[i].size() - 2);

	for (i = 0; i < T.size(); ++i)
	{
		f << T[i][0];
		for (int j = 1; j <T[i].size() - 1; ++j)
			f << " " << T[i][j];
		f << T[i][j] << " ";		
	}
	f.close();
	return true;
}