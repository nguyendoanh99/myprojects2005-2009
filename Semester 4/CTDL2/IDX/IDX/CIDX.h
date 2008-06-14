#ifndef _CIDX_H_
#define _CIDX_H_
#include <fstream>

template <class T>
void Convert(T *kq, char* arr, int size)
{
	T temp = 0xff;
	*kq = 0;
	for (int i = size - 1; i >= 0; --i)
	{
		*kq <<= 8;
		*kq |= (arr[i] & temp);
	}
}

class CIDX
{
private:	
	struct HEADER
	{
		long pRootNode;
		long pFreeNodeList;
		long lFileSize;
		unsigned short usLengthKey;
		char cIndexOptions;
		char cIndexSignature;
		char arrKeyExpression[220];
		char arrForExpression[220];
		char arrUnused[56];
	} m_Header;

	struct NODE
	{
		unsigned short usNodeAttribute;
		unsigned short usNumKey;
		long pLeft;
		long pRight;
		char **arrKey;
		long *arrPointer;
	} m_Node;
	std::ifstream m_File;

	int m_iIndex; // Vi tri tim thay cua key
	char *m_strKey; // key dung de tim kiem
	void GetNode(long Pointer);
	long Find(long Pointer, char *key);
	int SearchKeyInNode(int begin, char *key, int &how);
	void Clean();
	void Init();
public:
	CIDX();	
	CIDX(char *filename);
	virtual ~CIDX();
	void Input(char *filename);
	long Find(char *key);
	long FindNext();
};

#endif