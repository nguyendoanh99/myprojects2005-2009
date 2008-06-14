// Chua xay dung cac ham tao sao chep, toan tu gan
// vi yeu cau de khong co nen khong can xay dung. 
#ifndef _CAATREE_H
#define _CAATREE_H

class CAATree
{
private:
	struct AANODE
	{
		int key;
		AANODE *pLeft;
		AANODE *pRight;
		int iLevel;
	} *m_AATree;

	AANODE* Insert_AANode(int key, AANODE *t);
	AANODE* Skew(AANODE *t);
	AANODE* Split(AANODE *t);
	void XoaCay(AANODE *t);
public:
	CAATree();
	virtual ~CAATree();

	void Insert(int key);
	void Input(char *filename);
	void Output(char *filename);
};

#endif