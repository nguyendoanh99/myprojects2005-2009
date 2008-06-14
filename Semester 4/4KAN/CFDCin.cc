#include "CFDCin.h"
#include "system.h"

CFDCin::CFDCin()
{
	glSynchConsole  = new SynchConsole;
}

CFDCin::~CFDCin()
{
	delete glSynchConsole;
}

int CFDCin::fRead(char *buffer, int charcount, OpenFileId id)
{
	int Kq;

	if(id != 0)
	{
		printf("Truy xuat khong hop le.");
		return -1;
	}

	Kq = glSynchConsole->Read(buffer, charcount);

	if(Kq == -1)
		return -2; 
	
	return Kq; // So ki tu thuc su doc duoc
}

int CFDCin::fWrite(char *buffer, int charcount, OpenFileId id)
{
	printf("Can't not write in console input");
	return -1;
}

int CFDCin::fCreate(char *name)
{
	printf("Unexpected function!");
	return -1;
}

OpenFileId CFDCin::fOpen(char *name, int filetype)
{
	printf("Unexpected function!");
	return -1;
}

int CFDCin::fClose(OpenFileId id)
{
	printf("Unexpected function!");
	return -1;
}

int CFDCin::fSeek(int pos, OpenFileId id)
{
	printf("unexpected function!");
	return -1;
}
