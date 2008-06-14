#ifndef _CHUFFMAN_H_
#define _CHUFFMAN_H_

#include "CBitmap.h"
#include <fstream.h>
#define MAXNODE 511

// n (1 byte): so ky tu xuat hien trong file
// 3 phan: ky tu (1 byte), chieu dai cua chuoi ma hoa (1 byte), chuoi ma hoa
class CHuffman
{
protected:
	struct INFO
	{
		char cChar;
		CBitmap bitmap;
	};

	struct HuffNode
	{
		char cKyTu;
		int iFreq;
		int iLeft;
		int iRight;
	};

	ifstream m_File;
	char *filename;
	HuffNode *m_HuffTree[MAXNODE];
	int m_iNHuffTree; // So phan tu hien tai co trong m_HuffTree
	INFO m_Table[256];
	int m_iNTable; // So phan tu hien tai co trong m_Table

public:
	CHuffman();
	CHuffman(char *filename);
	virtual ~CHuffman();

	virtual void Input(char *filename);
	virtual void Output(char *filename) = 0;
};

#endif