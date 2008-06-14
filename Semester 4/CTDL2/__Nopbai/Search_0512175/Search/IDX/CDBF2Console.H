#ifndef _CDBF2CONSOLE_H_
#define _CDBF2CONSOLE_H_

#include "CDBF.h"
#include <fstream>

class CDBF2Console: public CDBF
{
private:
	std::ifstream m_File;
	int m_iIndex; // Vi tri tim thay cua key
	char *m_strKey; // key dung de tim kiem
	char *m_strField; // Truong dung de tim kiem
	int m_SField;	// vi tri cua m_strField
	int SearchField(char *Field); // lay vi tri cua Field
public:
	CDBF2Console(char *filename);
	virtual ~CDBF2Console();
	void WriteConsole(int RecPos);
	long Find(char *Field, char *key);
	long FindNext();
};

#endif 