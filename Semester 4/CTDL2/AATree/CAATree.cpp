#include "CAATree.h"
#include <fstream.h>
#include <queue>
CAATree::CAATree()
{
	m_AATree = 0;
}

CAATree::~CAATree()
{
	XoaCay(m_AATree);
}

void CAATree::XoaCay(CAATree::AANODE *t)
{
	// Xoa cay con ben trai
	if (t->pLeft)
		XoaCay(t->pLeft);
	// Xoa cay con ben phai
	if (t->pRight)
		XoaCay(t->pRight);

	t->pLeft = t->pRight = 0;
	t->iLevel = 0;
	t->key = 0;
	delete t;
	t = 0;
}

void CAATree::Insert(int key)
{
	Insert_AANode(key, m_AATree);
}

void CAATree::Input(char *filename)
{
	int key;
	ifstream f;
	f.open(filename);


	while (f)
	{
		f >> key;
		m_AATree = Insert_AANode(key, m_AATree);
	}
}

void CAATree::Output(char *filename)
{
	std::queue<AANODE *> q;
	AANODE *temp;
	ofstream f;
	f.open(filename);	

	f << m_AATree->iLevel << endl;
	
	q.push(m_AATree);
	
	int icurLevel = m_AATree->iLevel;

	while (!q.empty())
	{
		temp = q.front();
		q.pop();

		// Nut dang xet ma co muc nho hon muc hien tai 
		// co nghia la vua chuyen sang mot muc thap hon
		// nen phai cap nhat lai muc hien tai
		if (icurLevel > temp->iLevel)
		{
			f << endl;
			icurLevel = temp->iLevel;
		}

		f << temp->key << " ";

		// Dua cay con trai vao queue
		if (temp->pLeft)
			q.push(temp->pLeft);

		// Dua cay con phai vao queue (neu cay con phai co muc nho hon nut hien tai)
		if (temp->pRight)
		{
			if (temp->pRight->iLevel == temp->iLevel)
			{
				f << temp->pRight->key << " ";				
				
				if (temp->pRight->pLeft)
					q.push(temp->pRight->pLeft);

				if (temp->pRight->pRight)
					q.push(temp->pRight->pRight);
			}
			else			
				q.push(temp->pRight);		
		}		
	}
}

CAATree::AANODE* CAATree::Insert_AANode(int key, AANODE *t)
{
	if (!t)
	{
		t = new AANODE;
		t->iLevel = 1;
		t->key = key;
		t->pLeft = t->pRight = 0;
	}
	else
		if (key < t->key)
			t->pLeft = Insert_AANode(key, t->pLeft);
		else
			if (t->key < key)
				t->pRight = Insert_AANode(key, t->pRight);
			else 
				return t;

	t = Skew(t);
	t = Split(t);

	return t;
}

CAATree::AANODE* CAATree::Skew(AANODE *t)
{
	if (t->pLeft && t->pLeft->iLevel == t->iLevel)
	{
		AANODE *temp = t->pLeft;
		t->pLeft = temp->pRight;
		temp->pRight = t;
		return temp;
	}

	return t;
}

CAATree::AANODE* CAATree::Split(AANODE *t)
{
	if (t->pRight && t->pRight->iLevel == t->iLevel)
	{
		AANODE *temp = t->pRight;

		if (temp->pRight && temp->pRight->iLevel == temp->iLevel)
		{
			t->pRight = temp->pLeft;
			temp->pLeft = t;
			++temp->iLevel;

			return temp;
		}
	}

	return t;
}