#include "CHuffmanC.h"
#include <iostream.h>

CHuffmanC::CHuffmanC(char *filename): CHuffman(filename)
{
	m_DaChon.Resize(MAXNODE);

	LayTanSuat();
	XDHuffman();
	for (int i = 0; i < m_iNHuffTree; ++i)
	{
		cout << i << " " << m_HuffTree[i]->cKyTu << " " << m_HuffTree[i]->iFreq << " " << m_HuffTree[i]->iLeft 
			<< " " << m_HuffTree[i]->iRight << endl;
	}
	char A[256];
	XDBangMa(m_iNHuffTree - 1, A, 0);
	
	for (i = 0; i < m_iNTable; ++i)
		cout << m_Table[i].cChar << m_Table[i].bitmap << endl;
}

CHuffmanC::CHuffmanC(): CHuffman()
{
	m_DaChon.Resize(MAXNODE);
}

CHuffmanC::~CHuffmanC()
{
	
}

int CHuffmanC::Tim(char c)
{
	char kq;
	for (int i = 0; i < m_iNHuffTree; ++i)
	{
		m_DaChon.Read(i, &kq);
		if (kq == 0 && m_HuffTree[i]->cKyTu == c)
			return i;
	}

	return -1;
}

void CHuffmanC::LayTanSuat()
{
	char c[BLOCK + 1];
	int index;
	int n;
	while(m_File.read(c, BLOCK))
	{
		n = m_File.gcount();
		for (int i = 0; i < n; ++i)
		{
			index = Tim(c[i]);
			if (index == -1)
			{
				m_HuffTree[m_iNHuffTree] = new HuffNode;
				m_HuffTree[m_iNHuffTree]->cKyTu = c[i];
				m_HuffTree[m_iNHuffTree]->iFreq = 1;
				m_HuffTree[m_iNHuffTree]->iLeft = -1;
				m_HuffTree[m_iNHuffTree]->iRight = -1;
				++m_iNHuffTree;
			}
			else			
				++m_HuffTree[index]->iFreq;
			
		}
		
	}
}
// cho x < y
void CHuffmanC::Chon(int &x, int &y)
{	
	x = -1;
	y = -1;
	char kq;

	for (int i = 0; i < m_iNHuffTree; ++i)
	{
		m_DaChon.Read(i, &kq);
		if (kq == 1) // Da chon
			continue;

		if (x == -1 || m_HuffTree[i]->iFreq < m_HuffTree[x]->iFreq)
		{
			y = x;
			x = i;
		}
		else
			if (y == -1 || m_HuffTree[i]->iFreq < m_HuffTree[y]->iFreq)			
				y = i;
	}	
	
	// Neu 2 phan tu co so lan xuat hien bang nhau ma phan tu dau co ma ASCII lon hon phan tu sau
	// thi hoan vi 2 phan tu lai
	if ( m_HuffTree[x]->iFreq == m_HuffTree[y]->iFreq && m_HuffTree[x]->cKyTu > m_HuffTree[y]->cKyTu)
	{
		int t = x;
		x = y;
		y = t;
	}
}

void CHuffmanC::XDHuffman()
{
	int x;
	int y;
	HuffNode *temp;
	int n = m_iNHuffTree;
	for (int i = 0; i < n - 1; ++i)
	{
		// Buoc 1
		Chon(x, y);		
		temp = new HuffNode;
		temp->cKyTu = m_HuffTree[x]->cKyTu + m_HuffTree[y]->cKyTu; // Khong can thiet
		temp->iFreq = m_HuffTree[x]->iFreq + m_HuffTree[y]->iFreq;
		temp->iLeft = x;
		temp->iRight = y;

		// Buoc 2: loai 2 nut ra khoi bang thong ke
		m_DaChon.Write(x, 1);
		m_DaChon.Write(y, 1);
		
		// Buoc 3: them nut temp vao cay
		m_HuffTree[m_iNHuffTree] = temp;
		++m_iNHuffTree;
	}
}

int CHuffmanC::Write(CBitmap bitmap, fstream f)
{
	static char n = 0; // So bit that su chua trong c
	static char c[BLOCK + 1] = {0};
	static int j = 0;
	char kq;	
	// Ghi nhung bit con lai vao file
	if (bitmap.GetLength() == 0)
	{		
		int n1 = 0;
		if (n != 0)
		{
			n1 = n;
			c[j] <<= 8 - n;			
			n = 0;			
			f.write(c, j + 1);
		}

		return n1;
	}
	
	for (int i = bitmap.GetLength() - 1; i >= 0; --i)
	{
		c[j] <<= 1;
		bitmap.Read(i, &kq);
		c[j] |= kq;
		++n;

		if (n == 8)
		{
			++j;
			if (j == BLOCK)
			{				
				f.write(c, BLOCK);
				j = 0;
			}
			n = 0;
		}
	}

	return bitmap.GetLength() - n;
}
// Duyet file, xay dung cay Huffman --> xay dung bang ma
void CHuffmanC::Input(char *filename)
{
	CHuffman::Input(filename);
	m_DaChon.Resize(MAXNODE);

	LayTanSuat();
	XDHuffman();
	char A[256];
	XDBangMa(m_iNHuffTree - 1, A, 0);
}

void CHuffmanC::Output(char *filename)
{
	fstream f;
	f.open(filename, ios::out | ios::binary);
	f.close();
	f.open(filename, ios::in | ios::out | ios::binary);

	// Luu thong tin dung de giai nen
	Write(CBitmap((unsigned short) 3), f);
	Write(CBitmap((char) (m_iNTable - 1)), f);
	char Len;
	for (int i = 0; i < m_iNTable; ++i)
	{
		Write(CBitmap(m_Table[i].cChar), f);
		
		Len = (char) m_Table[i].bitmap.GetLength();
		Write(CBitmap(Len), f);
		Write(m_Table[i].bitmap, f);
		if (m_Table[i].cChar == 10)
		{
			cout << m_Table[i].cChar;
			cout << " " << m_Table[i].bitmap << endl;
		}
	}

	m_File.close();
	m_File.open(this->filename, ios::in | ios::binary);
	int index;
	char c[BLOCK + 1];
	int dem = 0;
	int n;
	while(m_File.read(c, BLOCK))
	{
		n = m_File.gcount();
		for (int i = 0; i < n; ++i)
		{
			for (index = 0; index < m_iNTable; ++index)
				if (m_Table[index].cChar == c[i])
					break;
			
			Write(m_Table[index].bitmap, f);
			++dem;
		}
	}
	// Ghi nhung bit con lai vao file
	char nBit = Write(CBitmap(unsigned short(0)), f);
	cout << dem << endl;
	// 
	f.seekg(0, ios::beg);
	f.read(&c[0], 1);	
	CBitmap c1(c[0]);	
	CBitmap nBit1(nBit);

	char kq;
	
	for (i = 0; i <= 2; ++i)
	{
		nBit1.Read(i, &kq);
		c1.Write(5 + i, kq);
	}

	f.seekg(-1, ios::cur);
	c1.Convert(&kq);
	f.write(&kq, 1);
}

// n : chieu cao cua cay 
// A : mang chua duong di
void CHuffmanC::XDBangMa(int iRoot, char *A, int n)
{
	static int dem = 0;
	// Node la
	if (m_HuffTree[iRoot]->iLeft == -1 && m_HuffTree[iRoot]->iRight == -1)
	{
		m_Table[m_iNTable].cChar = m_HuffTree[iRoot]->cKyTu;
		m_Table[m_iNTable].bitmap.Resize(n);
		for (int i = 0; i < n; ++i)
			m_Table[m_iNTable].bitmap.Write(n - i - 1, A[i]);
		++dem;
		
		++m_iNTable;
		if (m_iNTable == 255)
			cout << endl;
		cout << "dem tt:"<<dem << " " << m_iNTable << endl;
		return ;
	}
	
	A[n] = 0;
	XDBangMa(m_HuffTree[iRoot]->iLeft, A, n + 1);
	A[n] = 1;
	XDBangMa(m_HuffTree[iRoot]->iRight, A, n + 1);
}