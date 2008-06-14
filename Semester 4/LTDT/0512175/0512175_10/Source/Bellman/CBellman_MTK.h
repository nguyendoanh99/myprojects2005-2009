#ifndef _CBELLMAN_MTK_H
#define _CBELLMAN_MTK_H

#include "CDoThiMTK.h"
#include "CBellman.h"

class CBellman_MTK: public CBellman
{
private:
	CDoThiMTK m_DoThi;
public:
	~CBellman_MTK();
	int nVer();
	float Distance(int x, int y);
	int Input(char *filename);
	int Output(char *filename);
};

#endif