#ifndef _CDIJKSTRA_H_
#define _CDIJKSTRA_H_

const float Extremity = -1;
class CDijkstra
{
private:
	float *m_arrfLength;
	int *m_arriLastV;
	char *m_arrcBelongT;

	void Init(int x, int y);	// Buoc 1 cua thuat toan
	int FindVertex();			// Buoc 3 cua thuat toan
	void ImprovePaths(int v);	// Buoc 4 cua thuat toan
public:
	CDijkstra();
	virtual ~CDijkstra();
	float Run(int x, int y); // Tra ve tong trong so cua duong di ngan nhat
	virtual int nVer() = 0;
	virtual float Distance(int i, int j) = 0;
	int PrintPath(int x, int y, char *str); // Tra ve so dinh tren duong di
};
#endif