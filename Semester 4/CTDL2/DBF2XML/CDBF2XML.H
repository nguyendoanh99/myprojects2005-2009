#ifndef _CDBF2XML_H_
#define _CDBF2XML_H_

#include "CDBF.h"
#include <fstream.h>

class CDBF2XML: public CDBF
{
private:
	ifstream m_File;
public:
	CDBF2XML(char *filename);
	virtual ~CDBF2XML();
	int WriteXML(char *filename);
};

#endif 