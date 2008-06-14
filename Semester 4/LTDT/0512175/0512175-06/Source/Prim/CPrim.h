#ifndef _CPRIM_H_
#define _CPRIM_H_

#include "CDoThiMTK.h"
#include <vector>

typedef struct Edge
{
	int v1;
	int v2;
	int w;
} EDGE;

class CPrim
{
private:
	CDoThiMTK m_Input;
	std::vector<Edge> m_T;	// Tap canh
	std::vector<int> m_V;	// Tap dinh
	int m_W;				// Tong trong so

	int FindEdge(Edge &e);
	int ThuocV(int y);
	void PutToVSet(int y);
	void PutToTree(Edge e);
	int Run(int x0);
public:
	CPrim();
	virtual ~CPrim();
	int Input(char *filename);
	int Output(char *filename);
};

#endif