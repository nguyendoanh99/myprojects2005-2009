#pragma once
#include "_astar.h"

class _FindPath :
	public _AStar<int, int>
{
public:
	_FindPath(_Information<int, int> *data);
	string Result();
public:
	virtual ~_FindPath(void);
};
