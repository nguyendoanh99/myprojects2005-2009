#include "StdAfx.h"
#include "_8Puzzle.h"
#include "fstream"
#include "_Data8Puzzle.h"
using namespace std;
_8Puzzle::_8Puzzle(_Information<int, int> *data): _AStar(data)
{
}

_8Puzzle::~_8Puzzle(void)
{
}
string _8Puzzle::Result()
{
	string kq;
	vector<int> Goal = m_Info->GetGoal();
	vector<int> Start = m_Info->GetStart();
	char s[20];
	_itoa_s(Goal[0], s, 20, 10);
	kq = s;
	int i = m_Info->GetPrevious(Goal[0]);
	if (i == -1)
		return "-1";

	for (;i != Start[0]; i = m_Info->GetPrevious(i))
	{
		_itoa_s(i, s, 20, 10);
		kq = string(s) + "-->" + kq;
	}
	_itoa_s(Start[0], s, 20, 10);
	kq = string(s) + "-->" + kq;
	return kq;
}
void _8Puzzle::Output(char *filename)
{
	ofstream f(filename);

	vector<int> Goal = m_Info->GetGoal();
	vector<int> Start = m_Info->GetStart();
	
	
	int i = m_Info->GetPrevious(Goal[0]);
	if (i == -1)
	{
		f << "Khong co cach toi dich" << endl;
		return;
	}

	vector<int> kq;
	kq.push_back(Goal[0]);
	for (;i != Start[0]; i = m_Info->GetPrevious(i))
		kq.push_back(i);

	kq.push_back(Start[0]);
	int temp[3][3];	
	for (int i = kq.size() - 1; i >= 0; --i)
	{
		_Data8Puzzle::IntToMatrix(kq[i], temp);
		for (int j = 0; j < 3; ++j)
		{
			for (int k = 0; k < 3; ++k)
				f << temp[j][k] << " ";
			f << endl;
		}
		f << endl;
	}
}