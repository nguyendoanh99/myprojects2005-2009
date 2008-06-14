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
#include "wchar.h"
int _tmain(int argc, _TCHAR* argv[])
{
	int h = 3;
	char strInput[100];
	char strOutput[100];
	size_t sizeInput;
	size_t sizeOutput;
	cout << "Dang xu ly. Xin cho ..." << endl;

//	h = _wtoi(argv[1]);
	wcstombs_s(&sizeInput, strInput, 100, argv[2], 100);
	wcstombs_s(&sizeOutput, strOutput, 100, argv[3], 100);

	_Data8Puzzle d(strInput, h);
	_8Puzzle t(&d);		

	int t1 = GetTickCount();
	bool flag = t.Run();
	int t2 = GetTickCount();
	t.Output(strOutput, t2 - t1);
}

