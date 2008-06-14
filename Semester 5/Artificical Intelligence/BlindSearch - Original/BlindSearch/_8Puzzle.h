#pragma once
#include "_astar.h"

class _8Puzzle :
	public _AStar<int, int>
{
public:
	_8Puzzle(_Information<int, int> *data); 
	string Result();
	void Output(char *filename);
	virtual ~_8Puzzle(void);
};
