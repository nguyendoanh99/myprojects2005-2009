#include "CHuffman.h"
#include <string.h>

CHuffman::CHuffman()
{
	m_iNHuffTree = m_iNTable = 0;
}

CHuffman::CHuffman(char *filename)
{
	Input(filename);
}

CHuffman::~CHuffman()
{
	for (int i = 0; i < m_iNHuffTree; ++i)
		delete m_HuffTree[i];
	delete filename;
}

void CHuffman::Input(char *filename)
{
	m_iNHuffTree = m_iNTable = 0;
	this->filename = new char[strlen(filename) + 1];
	strcpy(this->filename, filename);
	m_File.open(filename, ios::in | ios::binary);
}