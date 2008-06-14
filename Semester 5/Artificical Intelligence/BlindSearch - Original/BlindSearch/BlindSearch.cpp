// BlindSearch.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "_MinPriorityQueue.h"
#include "_AStar.h"
#include "_DataFindPath.h"
#include "iostream"
#include "_FindPath.h"
#include "_8Puzzle.h"
#include "_Data8Puzzle.h"
#include "Windows.h"
int _tmain(int argc, _TCHAR* argv[])
{
	_Data8Puzzle d("test8puzzle.txt");
	_8Puzzle t(&d);		

	int t1 = GetTickCount();
	bool flag = t.Run();
	int t2 = GetTickCount();
	cout << "time" << t2 - t1 << endl;
	if (flag)
	{
		cout << t.Result();		
	}
	else
		cout << "Khong co duong di";

	t.Output("output8puzzle.txt");
}

