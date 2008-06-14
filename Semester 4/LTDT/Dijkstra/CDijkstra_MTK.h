#ifndef _CDIJKSTRA_MTK_H_
#define _CDIJKSTRA_MTK_H_

#include "CDijkstra.h"
#include "CDoThiMTK.h"

class CDijkstra_MTK: public CDijkstra, public CDoThiMTK
{
private:
	float m_fTongTrongSo;
	int m_iDau;
	int m_iCuoi;
public:
	virtual ~CDijkstra_MTK();

	int Input(char *filename);
	int Output(char *filename);
	int nVer();
	float Distance(int i, int j);
};

#endif