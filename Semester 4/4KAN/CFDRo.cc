
#include "CFDRo.h"

CFDRo::CFDRo()
{
	m_File = NULL;
}

CFDRo::~CFDRo()
{
	if(!m_File)
		delete m_File;
}

int CFDRo::fCreate(char *name)
{
	return glTab->fdCreate(name);
}

OpenFileId CFDRo::fOpen(char *name)
{
	m_File = fileSystem->Open(name);
	if(m_File == NULL)
		return -1;

	return 0;
}

int CFDRo::fWrite(char *buffer, int size)
{
	printf("Can't write in ""readonly file"".");
	return -1;
}

int CFDRo::fRead(char *buffer, int size)
{
	int Kq;
	Kq = m_File->Read(buffer, size);	
	if(Kq == 0)
		return -1;
//	printf("%d", Kq);
	return Kq;
}

int CFDRo::fClose()
{
	if(m_File == NULL)
		return -1;

	delete m_File;
	m_File = NULL;

	return 0;
}

int CFDRo::fSeek(int pos)
{
	int Kq = m_File->Seek(pos);
	return Kq;
}

