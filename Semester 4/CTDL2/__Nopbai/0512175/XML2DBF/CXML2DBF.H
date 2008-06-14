#ifndef _CXML2DBF_H_
#define _CXML2DBF_H_

#include "CDBF.h"
#include <fstream.h>

class CXML2DBF: public CDBF
{
private:
	ifstream m_File;
	int LayDuLieu(char *s, char *element, char *kq);
public:
	CXML2DBF(char *filename);
	virtual ~CXML2DBF();
	int WriteDBF(char *filename);
};

#endif 