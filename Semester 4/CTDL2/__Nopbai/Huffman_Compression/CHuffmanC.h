#ifndef _CHUFFMANC_H_
#define _CHUFFMANC_H_

#include "CHuffman.h"

class CHuffmanC: public CHuffman
{
private:
	CBitmap m_DaChon; // m_DaChon[i] = 1: phan tu thu i da duoc xet, nguoc lai thi chua duoc xet
	int Tim(char c);	// Tra ve vi tri tim thay c trong m_HuffTree
						// Neu khong tim thay tra ve -1
	void Chon(int &x, int &y);	// Tim 2 phan tu x, y co iFreq nho nhat trong m_HuffTree								
	void LayTanSuat();	// Duyet file lay tan suat cua cac ky tu
	void XDHuffman();	// Tu bang tan suat xay dung cay Huffman
	void XDBangMa(int iRoot, char *A, int n);	// Tu cay Huffman xay dung bang ma hoa thong tin
	int Write(CBitmap bitmap, fstream f);	// Ghi bitmap len file, tra ve so bit cua bitmap da ghi len file
public:
	CHuffmanC();
	CHuffmanC(char *filename);
	virtual ~CHuffmanC();
	void Input(char *filename); // Duyet file, xay dung cay Huffman --> xay dung bang ma
	void Output(char *filename); // Duyet file, thong qua bang ma --> ma hoa
};

#endif