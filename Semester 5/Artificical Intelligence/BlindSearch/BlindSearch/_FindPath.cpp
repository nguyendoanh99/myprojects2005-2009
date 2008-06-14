#include "StdAfx.h"
#include "_FindPath.h"
#include "stdlib.h"

_FindPath::_FindPath(_Information<int, int> *data): _AStar(data)
{
}

_FindPath::~_FindPath(void)
{
}
string _FindPath::Result()
{
	string kq = "";
	vector<int> Goal = m_Info->GetGoal();
	vector<int> Start = m_Info->GetStart();
	char s[20];
	_itoa_s(Goal[0], s, 20, 10);
	kq = s;
	for (int i = m_Info->GetPrevious(Goal[0]); i != Start[0]; i = m_Info->GetPrevious(i))
	{
		_itoa_s(i, s, 20, 10);
		kq = string(s) + "-->" + kq;
	}
	_itoa_s(Start[0], s, 20, 10);
	kq = string(s) + "-->" + kq;
	return kq;
}