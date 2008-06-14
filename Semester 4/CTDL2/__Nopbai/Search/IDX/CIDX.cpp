#include "CIDX.h"
#include <iostream>
using namespace std;
CIDX::CIDX()
{	
	Init();
}

void CIDX::Init()
{
	m_iIndex = -1;
	m_strKey = 0;
	m_Node.arrPointer = 0;
	m_Node.arrKey = 0;
}
void CIDX::Clean()
{
	if (m_Node.arrPointer)
	{
		delete m_Node.arrPointer;	
		for (int i = 0; i < 500 / (m_Header.usLengthKey + 4); ++i)
		{
			if (m_Node.arrKey[i])
			{
				delete m_Node.arrKey[i];
				m_Node.arrKey[i] = 0;
			}
		}
		m_Node.arrPointer = 0;	
	}

	if (m_Node.arrKey)
	{
		delete m_Node.arrKey;
		m_Node.arrKey = 0;
	}

	if (m_strKey)
	{
		delete m_strKey;
		m_strKey = 0;
	}
}

CIDX::~CIDX()
{	
	Clean();
}

CIDX::CIDX(char *filename)
{
	Init();
	Input(filename);	
}

void CIDX::Input(char *filename)
{		
	Clean();

	m_File.open(filename, ios_base::binary);
	if (!m_File)
	{
		cout << "Khong mo duoc file " << filename << endl;
		exit(1);
	}
	// Header
	m_File.read((char*) &m_Header, 512);
	// Cap phat bo nho cho mang arrKey va arrPointer voi so key toi da co trong mot node
	int NumKey = 500 / (m_Header.usLengthKey + 4);
	m_Node.arrPointer = new long[NumKey];
	m_Node.arrKey = new char*[NumKey];
	for (int i = 0; i < NumKey; ++i)
		m_Node.arrKey[i] = new char[m_Header.usLengthKey];

	GetNode(m_Header.pRootNode);
}
// Tim key trong file IDX
// Tra ve vi tri cua record
long CIDX::Find(char *key)
{	
	m_iIndex = -1;
	if (m_strKey)
		delete m_strKey;

	m_strKey = new char[strlen(key) + 1];
	strcpy(m_strKey, key);
	return Find(m_Header.pRootNode, m_strKey);
}
// Tim key trong file IDX
// Tra ve vi tri cua record
long CIDX::Find(long Pointer, char *key)
{
	GetNode(Pointer);
	static int how;	
	m_iIndex = SearchKeyInNode(0, key, how);

	// Khong co key tuong ung
	if (m_iIndex == -1) 
		return -1;

	// Tim thay va o node la
	if (how == 0 && (m_Node.usNodeAttribute == 2 || m_Node.usNodeAttribute == 3))	
		return m_Node.arrPointer[m_iIndex];	
	else	
		if (m_Node.usNodeAttribute != 2 && m_Node.usNodeAttribute != 3)
			return Find(m_Node.arrPointer[m_iIndex], key);

	return -1;
}
// Tim vi tri xuat hien tiep theo cua key tu ket qua duoc cung cap Find(key)
long CIDX::FindNext()
{
	// Khong co key trong cay
	if (m_iIndex == -1)
		return -1;

	int how;

	// key nam o cuoi node
	if (m_iIndex == m_Node.usNumKey - 1)
	{		
		// node cuoi cung
		if (m_Node.pRight == -1)
			return -1;

		m_iIndex = -1;
		GetNode(m_Node.pRight);
	}

	m_iIndex = SearchKeyInNode(m_iIndex + 1, m_strKey, how);

	// Khong co key tuong ung
	if (how != 0) 
	{
		m_iIndex = -1;
		return -1;
	}
	else
		return m_Node.arrPointer[m_iIndex];
}

// Tim key trong mot node voi vi tri bat dau la begin
// Neu key <= mot key trong node thi tra ve vi tri tim thay
// tham so "how" nhan ve kieu tim thay (0: bang nhau, 1: nho hon)
int CIDX::SearchKeyInNode(int begin, char *key, int &how)
{	
	for (int i = begin; i < m_Node.usNumKey; ++i)
	{
		how = strncmp(m_Node.arrKey[i], key, strlen(key));
		if (how >= 0)
			return i;		
	}

	return -1;
}

void CIDX::GetNode(long Pointer)
{
	char node[512];
	char *p;
	int size;

	m_File.seekg(Pointer - m_File.tellg(), ios_base::cur);
	m_File.read(node, 512);	
	p = node;
	// Node attributes
	size = sizeof(m_Node.usNodeAttribute);
	Convert(&m_Node.usNodeAttribute, p, size);
	p += size;
	// Numbers of keys present
	size = sizeof(m_Node.usNumKey);
	Convert(&m_Node.usNumKey, p, size);
	p += size;
	// Pointer to the node directly to left of the current node
	size = sizeof(m_Node.pLeft);
	Convert(&m_Node.pLeft, p, size);
	p += size;
	// Pointer to the node directly to right of the current node
	size = sizeof(m_Node.pRight);
	Convert(&m_Node.pRight, p, size);
	p += size;
	// Key values and Pointer
	char temp[4];
	for (int i = 0; i < m_Node.usNumKey; ++i)
	{		
		// Key value
		size = m_Header.usLengthKey;
		memcpy(m_Node.arrKey[i], p, size);
		p += size;
		// Pointer
		size = 4;
		for (int j = 0; j < size; ++j)
			temp[j] = p[size - 1 - j];

		Convert(&m_Node.arrPointer[i], temp, size);
		p += size;
//		cout << dec;
//		for (int j = 0; j < m_Header.usLengthKey; ++j)
//			cout << m_Node.arrKey[i][j];
//		cout << "\t0x" << hex << m_Node.arrPointer[i] << endl;
	}
}