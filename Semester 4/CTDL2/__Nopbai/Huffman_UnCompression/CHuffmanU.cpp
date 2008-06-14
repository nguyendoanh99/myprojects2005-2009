#include "CHuffmanU.h"

int CHuffmanU::Read(CBitmap &bitmap)
{
	static char n = 8; // So bit da duoc doc
	static char c = 0;
	static char c1 = 0;
	static char n1 = 7;
	static bool flag = false;
	char kq;	

	for (int i = bitmap.GetLength() - 1; i >= 0; --i)
	{
		if (n > n1)
		{
			c = c1;			
			m_File.read(&c1, 1);
			if (m_File.eof())
			{
				if (!flag)				
					n1 = m_cBit;				
				else
				{
					++i;
					int t = bitmap.GetLength() - i - 1;
					if (t < 0)
					{
						bitmap = CBitmap((unsigned short) 0);
						break;
					}

					char kq;
					CBitmap temp((unsigned short) t);
					for (int j = t - 1; j >= 0; --j)
					{
						bitmap.Read(bitmap.GetLength() - 1 - (t - 1 - j), &kq);
						temp.Write(j, kq);
					}
					bitmap = temp;					
					break;
				}

				flag = true;				
			}
			
			n = 0;
		}

		kq = ((c & 0x80) == 0) ? 0 : 1;
		bitmap.Write(i, kq);
		c <<= 1;
		++n;	
	}

	return bitmap.GetLength();
}

void CHuffmanU::XDHuffman()
{ 
	int root;
	char kq;
	
	// Khoi tao
	m_HuffTree[0] = new HuffNode;
	m_HuffTree[0]->iLeft = -1;
	m_HuffTree[0]->iRight = -1;
	m_iNHuffTree = 1;

	for (int i = 0; i <= m_iNTable; ++i)
	{
		root = 0;
		for (int j = m_Table[i].bitmap.GetLength() - 1; j >= 0; --j)
		{
			m_Table[i].bitmap.Read(j, &kq);
			if (kq == 1)
			{
				if (m_HuffTree[root]->iRight == -1)
				{
					// Tao node moi
					m_HuffTree[m_iNHuffTree] = new HuffNode;					
					m_HuffTree[m_iNHuffTree]->iLeft = -1;
					m_HuffTree[m_iNHuffTree]->iRight = -1;

					m_HuffTree[root]->iRight = m_iNHuffTree;
					++m_iNHuffTree;
				}
				root = m_HuffTree[root]->iRight;
			}
			else
			{
				if (m_HuffTree[root]->iLeft == -1)
				{
					// Tao node moi
					m_HuffTree[m_iNHuffTree] = new HuffNode;					
					m_HuffTree[m_iNHuffTree]->iLeft = -1;
					m_HuffTree[m_iNHuffTree]->iRight = -1;

					m_HuffTree[root]->iLeft = m_iNHuffTree;
					++m_iNHuffTree;
				}
				root = m_HuffTree[root]->iLeft;
			}
		}

		m_HuffTree[root]->cKyTu = m_Table[i].cChar;
	}
}

void CHuffmanU::DocMoTa()
{
	char temp;
	
	//
	CBitmap temp1((unsigned short) 8);
	Read(temp1);

	temp1.Resize(3);
	Read(temp1);
	
	temp1.Convert(&m_cBit);
	if (m_cBit == 0)
		m_cBit = 8;
	// So ky tu xuat hien trong file
	temp1.Resize(8);
	Read(temp1);
	
	unsigned char t;
	temp1.Convert((char*)&t);
	
	m_iNTable = t;	
	
	for (int i = 0; i <= m_iNTable; ++i)
	{
		// Ky tu
		temp1.Resize(8);
		Read(temp1);
		temp1.Convert(&m_Table[i].cChar);		

		// Chieu dai chuoi ma hoa
		Read(temp1);
		temp1.Convert(&temp);
		unsigned char n = (unsigned char) temp;		

		// Doc chuoi ma hoa		
		m_Table[i].bitmap.Resize(n);
		Read(m_Table[i].bitmap);		
	}
}

void CHuffmanU::Input(char *filename)
{
	CHuffman::Input(filename);
	DocMoTa();
	XDHuffman();
}

void CHuffmanU::Output(char *filename) // Doc noi dung dua vao cay Huffman --> giai nen
{
	ofstream f;
	f.open(filename, ios::out | ios::binary);

	CBitmap bitmap((unsigned short) 8);
	int root = 0;
	char kq;
	char n;

	while (n = Read(bitmap))
	{		
		for (int i = n - 1; i >= 0; --i)
		{
			bitmap.Read(i, &kq);
			if (kq == 1)
				root = m_HuffTree[root]->iRight;
			else
				root = m_HuffTree[root]->iLeft;

			// Node la
			if (m_HuffTree[root]->iRight == -1 && m_HuffTree[root]->iLeft == -1)
			{

				f.write(&m_HuffTree[root]->cKyTu, 1);
				root = 0;
			}
		}
	}

}

CHuffmanU::CHuffmanU()
{
}

CHuffmanU::CHuffmanU(char *filename)
{
	Input(filename);
}

CHuffmanU::~CHuffmanU()
{
}