// 0512175_BTTuan5.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string>
#include <vector>
#include <iostream>

using namespace std;

int main(int argc, char* argv[])
{
	vector<VecStr> T;
	DocFile("ex.txt", T);
	GhiFile("out.txt", T);
	return 0;
}
 