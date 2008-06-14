#include "StdAfx.h"
#include "_8Puzzle.h"
#include "fstream"
#include "_Data8Puzzle.h"
#include "math.h"
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
void _8Puzzle::Output(char *filename, int time)
{
	ofstream f(filename);

	vector<int> Goal = m_Info->GetGoal();
	vector<int> Start = m_Info->GetStart();
	
	
	int i = m_Info->GetPrevious(Goal[0]);
	if (i == -1)
	{
		f << "Khong co cach toi dich" << endl;
		cout << "Khong co cach toi dich" << endl;
		int m = GetSumNode();		
		f << "m = " << m << endl;		
		cout << "m = " << m << endl;
		cout << "t = " << time << endl;
		return;
	}

	vector<int> kq;
	kq.push_back(Goal[0]);
	for (;i != Start[0]; i = m_Info->GetPrevious(i))
		kq.push_back(i);

	kq.push_back(Start[0]);
	int temp[3][3];		
	for (int i = (int) kq.size() - 1; i >= 0; --i)
	{
		_Data8Puzzle::IntToMatrix(kq[i], temp);
		for (int j = 0; j < 3; ++j)
		{
			for (int k = 0; k < 3; ++k)
			{
				f << temp[j][k] << " ";
				cout << temp[j][k] << " ";
			}
			f << endl;
			cout << endl;
		}
		f << endl;
		cout << endl;
	}	

	int l = (int) kq.size();
	int m = GetSumNode();
	double b = pow(m - 1, 1.0 / l);
	f << "m = " << m << endl;
	f << "l = " << l << endl;
	f << "b = " << b << endl;
	f << "t = " << (time / 1000.0) << "s" << endl;
	cout << "m = " << m << endl;
	cout << "l = " << l << endl;
	cout << "b = " << b << endl;
	cout << "t = " << (time / 1000.0) << "s" << endl;
}