#ifndef _CHUFFMANU_H_
#define _CHUFFMANU_H_

#include "CHuffman.h"

class CHuffmanU: public CHuffman
{
private:
	char m_cBit; // So bit co trong byte cuoi cua file
	int Read(CBitmap &bitmap); // Doc bitmap tu file
	void XDHuffman(); // tu Info
	void DocMoTa(); // doc thong tin dung de giai ma
public:
	CHuffmanU();
	CHuffmanU(char *filename);
	virtual ~CHuffmanU();
	void Input(char *filename); // Doc mo ta --> Xay dung cay Huffman
	void Output(char *filename); // Doc noi dung dua vao cay Huffman --> giai nen
};

#endif