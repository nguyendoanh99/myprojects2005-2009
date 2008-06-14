#ifndef _CEDGE_H_
#define _CEDGE_H_

class CEdge
{
private:
	int v1;
	int v2;
	int w;
public:
	CEdge(int v1 = 0, int v2 = 0, int w = 0);
	int operator < (const CEdge &p);
	int operator > (const CEdge &p);
	int operator ==(const CEdge &p);
	int LayV1();
	int LayV2();
	int LayW();
};

#endif