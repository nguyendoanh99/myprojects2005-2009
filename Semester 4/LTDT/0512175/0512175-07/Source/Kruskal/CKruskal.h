#ifndef _CKRUSKAL_H_
#define _CKRUSKAL_H_
#include <vector>
#include "CEdge.h"

class CKruskal
{
private:
	std::vector<CEdge> m_Edges;
	std::vector<CEdge*> m_T;
	std::vector<int> m_Label;
	int m_nVer;
	int m_W; // Tong trong so

	void UpdateLabels(int v1, int v2);
	void Init();
	int Run();
public:
	CKruskal();
	virtual ~CKruskal();

	int Input(char *filename);
	int Output(char *filename);

};

#endif