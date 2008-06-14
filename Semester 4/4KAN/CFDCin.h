#ifndef _CFDCIN_H_
#define _CFDCIN_H_

#include "syscall.h"
#include "console.h"
#include "CFDBase.h"

class CFDCin: public CFDBase
{	
public:
	CFDCin();
	virtual ~CFDCin();

	int fCreate(char *name);
	OpenFileId fOpen(char *name, int filetype);
	int fClose(OpenFileId id);
	int fRead(char *buffer, int charcount, OpenFileId id);	
	int fWrite(char *buffer, int charcount, OpenFileId id);
	int fSeek(int pos, OpenFileId id);
};

#endif
