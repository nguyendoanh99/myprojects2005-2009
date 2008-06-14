#pragma once
#include "_Information.h"
#include "fstream"
#include "vector"
class _DataFindPath: public _Information<int, int>
{
private:
	int A[100][100];
	int B[100]; // Cho biet chi phi di tu S den B[i]
	int Previous[100];
	int n;
	int S;
	int G;
public:
	_DataFindPath(char *filename)
	{
		ifstream f(filename);
		// Chua kiem tra co ton tai file
		f >> n >> S >> G;
		for (int i = 0; i < n; ++i)
		{
			for (int j = 0; j < n; ++j)
				f >> A[i][j];
		}
		B[S] = 0;
		Previous[S] = -1;
	}
	int GetCost(int X, int Y)// Chi phi di tu X den Y
	{
		return A[X][Y];
	}
	std::vector<int> GetSucc(int X) // Tra ve cac trang thai sinh ra tu X
	{
		vector<int> kq;
		for (int i = 0; i < n; ++i)
			if (A[X][i])
				kq.push_back(i);

		return kq;
	}
	std::vector<int> GetStart() // Tra ve cac trang thai bat dau cua bai toan
	{
		vector<int> kq;
		kq.push_back(S);
		return kq;
	}
	std::vector<int> GetGoal() // Tra ve cac trang thai dich cua bai toan
	{
		vector<int> kq;
		kq.push_back(G);
		return kq;
	}
	int GetG(int X) // Tra ve chi phi di tu trang thai bat dau den trang thai X (goi la chi phi g)
	{
		return B[X];
	}
	void SetG(int X, int m) // Thay doi chi phi g bang m
	{
		B[X] = m;
	}
	int GetH(int X) // Tra ve gia tri cua ham heuristic tai trang thai X
	{
		return 0;
	}
	int GetPrevious(int X) // Lay trang thai cha cua X
	{
		return Previous[X];
	}
	void SetPrevious(int X, int Y) // Gan trang thai cha cua X la Y
	{
		Previous[X] = Y;
	}
};