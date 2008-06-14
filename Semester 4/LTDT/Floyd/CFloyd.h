#ifndef _CFLOYD_H_
#define _CFLOYD_H_

struct Vertex
{
	float fLength;
	int iNextV;
};

class CFloyd
{
private:
	Vertex **m_L;
	int m_iVer;
	int m_iDau;
	int m_iCuoi;

	void Run();
public:
	CFloyd();
	virtual ~CFloyd();
	int Input(char *filename);
	int Output(char *filename);
	int PrintPath(int x, int y, int *A);
};

#endif