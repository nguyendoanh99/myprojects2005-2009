#ifndef _CBELLMAN_H_
#define _CBELLMAN_H_

struct Vertex
{
	float fLength;
	char cFlag;
	int iLastV;
};

class CBellman
{
private:
	Vertex *m_Row[2];
	int m_iStartVer;
	void Init(int x);		// Buoc 1
	void UpdateNextRow();	// Buoc 2
	int TwoRowsEqual();		// Trong buoc 3 cua thuat toan
	
public:
	virtual ~CBellman();
	CBellman();
	virtual int nVer() = 0;
	virtual float Distance(int x, int y) = 0;
	int Run(int x);
	void Print(float *A);
	int PrintPath(int y, char *A);
};

#endif