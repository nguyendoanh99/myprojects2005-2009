// Cap nhat 8/4/2007, 17:50
#ifndef _CCAYKHUNG
#define _CCAYKHUNG

#include "CDoThiMTK.h"

class CCayKhung: public CDoThiMTK
{
private:
	CDoThiMTK m_DuLieu; // Do thi bieu dien cay khung tim duoc
	int TimCayKhung();

public:
	CCayKhung();
	CCayKhung(int n, int **A);
	CCayKhung(const CCayKhung&);
	CCayKhung(const CDoThiMTK&);
	virtual ~CCayKhung();

	CCayKhung& operator=(const CCayKhung&);
	CCayKhung& operator=(const CDoThiMTK&);

	int Input(char *filename);
	int Output(char *filename);
};
#endif