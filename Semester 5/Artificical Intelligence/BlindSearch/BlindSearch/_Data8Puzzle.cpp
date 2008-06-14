#include "StdAfx.h"
#include "_Data8Puzzle.h"
#include "fstream"
#include "iostream"
using namespace std;
int _Data8Puzzle::SumState()
{
	return m_State.SumNode();
}
_Data8Puzzle::_Data8Puzzle(char *filename,int H)
{
	fstream f(filename);
	// Chua xu ly truong hop khong co file
	if (f)
	{	
		m_Start = 0;
		int temp;
		for (int i = 0; i < 3; ++i)
		{
			for (int j = 0; j < 3; j++)
			{
				f >> temp;
				if (temp == 0)
					temp = 9;
				m_Start = m_Start * 10 + temp;
			}
		}

		m_Goal = 0;
		for (int i = 0; i < 3; ++i)
		{
			for (int j = 0; j < 3; j++)
			{
				f >> temp;

				if (temp == 0)
					temp = 9;
				m_Goal = m_Goal * 10 + temp;
			}
		}
		// g(Start) = 0
		Element t;
		t.state = m_Start;
		t.previous = -1;
		t.g = 0;
		m_State.Add(t);

		temp = m_Goal;
		int _t;
		for (int i = 8; i >= 0; --i)
		{
			_t = temp % 10;
			if (_t != 9)
				A[_t / 3][_t % 3] = i; // Cho biet t nam tai vi tri nao trong ma tran
			temp /= 10;
		}
		// Chon ham H tuong ung
		switch(H)
		{
		case 1:
			HFunction = GetH1;
			break;
		case 2:
			HFunction = GetH2;
			break;
		case 3:
			HFunction = GetH3;
			break;
		default:
			HFunction = GetH3;
		}				
	}
	else
		cout << "Loi mo file";

}

int _Data8Puzzle::GetCost(int X, int Y) // Chi phi di tu X den Y
{
	vector<int> temp = GetSucc(X);
	
	int size = (int) temp.size();
	for (int i = 0; i < size; ++i)
	{
		if (temp[i] == Y)
			return 1; // Y la trang thai tiep theo cua X
	}
	return 0;	
}
std::vector<int> _Data8Puzzle::GetSucc(int X) // Tra ve cac trang thai sinh ra tu X
{
	static int Ax[4] = {0, 1, 0, -1};
	static int Ay[4] = {-1, 0, 1, 0};
	vector<int> kq;
	int StateTemp[3][3];
	
	IntToMatrix(X, StateTemp);
	
	int x0;
	int y0;
	int i;
	// Tim vi tri cua o trong
	for (i = 0; i < 9; ++i)
	{
		x0 = i / 3;
		y0 = i % 3;
		if (StateTemp[x0][y0] == 0)
			break;
	}

	int x;
	int y;
	int temp;
	int ParentX = GetPrevious(X);
	for (i = 0; i < 4; ++i)
	{
		x = x0 + Ax[i];
		y = y0 + Ay[i];
		if (0 <= x && x < 3 && 0 <= y && y < 3)
		{
			swap(StateTemp[x0][y0], StateTemp[x][y]);
			MatrixToInt(StateTemp, temp);
			// Khong dua trang thai cha cua X vao tap sinh
			if (temp != ParentX)
				kq.push_back(temp);

			swap(StateTemp[x0][y0], StateTemp[x][y]);
		}
	}

	return kq;
}
std::vector<int> _Data8Puzzle::GetStart() // Tra ve cac trang thai bat dau cua bai toan
{
	vector<int> kq;
	kq.push_back(m_Start);
	return kq;
}
std::vector<int> _Data8Puzzle::GetGoal() // Tra ve cac trang thai dich cua bai toan
{
	vector<int> kq;
	kq.push_back(m_Goal);
	return kq;
}
int _Data8Puzzle::GetG(int X) // Tra ve chi phi di tu trang thai bat dau den trang thai X (goi la chi phi g)
{
	Element x;
	x.state = X;
	Element *temp = m_State.Find(x);
	if (temp == m_State.GetSentinel()) // Phan tu nay chua co trong cay
		return -1;
	else
		return temp->g;	
}
void _Data8Puzzle::SetG(int X, int m) // Thay doi chi phi g bang m
{
	Element x;
	x.state = X;
	Element *temp = m_State.Find(x);
	if (temp == m_State.GetSentinel()) // Phan tu nay chua co trong cay
	{
		x.g = m;
		m_State.Add(x);
	}
	else
		temp->g = m;	
}
int _Data8Puzzle::GetH(int X) // Tra ve gia tri cua ham heuristic tai trang thai X
{
	return HFunction(*this, X);
}
int _Data8Puzzle::GetPrevious(int X) // Lay trang thai cha cua X
{
	Element x;
	x.state = X;
	Element *temp = m_State.Find(x);
	if (temp == m_State.GetSentinel()) // Phan tu nay chua co trong cay
		return -1;	
	else
		return temp->previous;	
}
void _Data8Puzzle::SetPrevious(int X, int Y) // Gan trang thai cha cua X la Y
{
	Element x;
	x.state = X;
	Element *temp = m_State.Find(x);
	if (temp == m_State.GetSentinel()) // Phan tu nay chua co trong cay
	{
		x.previous = Y;
		m_State.Add(x);
	}
	else
		temp->previous = Y;
}

_Data8Puzzle::~_Data8Puzzle(void)
{
}

void _Data8Puzzle::MatrixToInt(int State[][3], int &Number)
{
	Number = 0;
	for (int i = 0; i < 3; ++i)
		for (int j = 0; j < 3; ++j)
		{
			if (State[i][j] != 0)
				Number = Number * 10 + State[i][j];
			else // Neu la so 0 thi cho la so 9
				Number = Number * 10 + 9;
		}
}
void _Data8Puzzle::IntToMatrix(int Number, int State[][3])
{
	int temp;
	for (int i = 2; i >= 0; --i)
		for (int j = 2; j >= 0; --j)
		{
			temp = Number % 10;

			if (temp == 9)
				temp = 0;

			State[i][j] = temp;
			Number = Number / 10;
		}
}
int GetH1(const _Data8Puzzle& info, int X) // h = 0
{
	return 0;
}
int GetH2(const _Data8Puzzle& info, int X) // h = so o sai vi tri cua trang thai ban dau so voi trang thai dich
{
	int dem = 0;
	int temp1;
	int temp2;
	int Goal = info.m_Goal;
	for (int i = 0; i < 9; ++i)
	{
		temp1 = X % 10;
		temp2 = Goal % 10;
		if (temp1 != 9 && temp1 != temp2)
			++dem;

		X /= 10;
		Goal /= 10;
	}
	return dem;
}
int GetH3(const _Data8Puzzle& info, int X) // tong khoang cach Mahattan
{
	int t;
	int temp;
	int dem = 0;	
	for (int i = 8; i >= 0; --i)
	{
		t = X % 10;
		if (t != 9)
		{
			temp = info.A[t / 3][t % 3]; // Cho biet t nam tai vi tri nao
			dem += abs((i / 3) - (temp / 3)) + abs((i % 3) - (temp % 3));
		}
		X /= 10;
	}

	return dem;
}