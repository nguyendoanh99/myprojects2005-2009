
#ifndef _CFDRO_H_
#define _CFDRO_H_

#include "filesys.h"
#include "CFDBase.h"
#include "openfile.h"
#include "system.h"

class CFDRo: public CFDBase
{
private:
	OpenFile *m_File;
public:	
	CFDRo();
	virtual ~CFDRo();

	int fCreate(char *name);
	OpenFileId fOpen(char *name);
	int fWrite(char *buffer, int size);
	int fRead(char *buffer, int size);
	int fClose();
	int fSeek(int pos);
};


#endif

