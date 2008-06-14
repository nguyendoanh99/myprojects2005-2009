#include "LList.h"
#include <stdlib.h>

Node* GetNode(void *q)
{
	Node *p = new Node;

	if (!p)
		return NULL;

	p->m_info = q;
	p->m_pNext = NULL;

	return p;
}

void LList::TaoListRong()
{
	m_pHead = NULL;
	m_pTail = NULL;
	m_iSoNode = 0;
}
LList::LList()
{
	TaoListRong();
}

LList::LList(const LList &L)
{
	TaoListRong();
	// Sao chep tat ca cac Node tu L sang *this
	for (Node *p = m_pHead; p; p = p->m_pNext)
		AddTail(p->m_info);	
}

LList::~LList()
{
	Empty();
}

LList& LList::operator =(const LList& L)
{
	// Sao chep tat ca cac Node tu L sang *this
	for (Node *p = m_pHead; p; p = p->m_pNext)
		AddTail(p->m_info);	
}

LList& LList::AddHead(Node *pNode)
{
	// Neu pNode == NULL thi thoat
	if (!pNode)
		return *this;

	if (IsEmpty())
	{
		m_pHead = m_pTail = pNode;
	}
	else
	{
		pNode->m_pNext = m_pHead;
		m_pHead = pNode;
	}

	// Neu viec them thanh cong thi tang so Node trong List them 1 don vi
	++m_iSoNode;

	return *this;
}

LList& LList::AddHead(void *p)
{
	return AddHead(::GetNode(p));	
}

LList& LList::AddTail(Node *pNode)
{
	// Neu pNode == NULL thi thoat
	if (!pNode)
		return *this;

	if (IsEmpty())
	{
		m_pHead = m_pTail = pNode;
	}
	else
	{
		m_pTail->m_pNext = pNode;
		m_pTail = pNode;
	}
	
	// Neu viec them thanh cong thi tang so Node trong List them 1 don vi
	++m_iSoNode;

	return *this;
}

LList& LList::AddTail(void *p)
{
	return AddTail(::GetNode(p));
}

LList& LList::DelNode(Node *pNode)
{
	// Neu pNode == NULL thi thoat
	if (!pNode)
		return *this;

	Node *p = m_pHead;
	// Truong hop pNode nam dau List
	if (pNode == m_pHead)
	{		
		m_pHead = m_pHead->m_pNext;

		p->m_pNext = NULL;
		p->m_info = NULL;

		delete p;
	}
	else // Truong hop pNode nam o giua List
	{
		while (p && p->m_pNext == pNode)
			p = p->m_pNext;
		// Neu pNode khong co trong List thi thoat ra
		// Nguoc lai thuc hien cac thao tac xoa 1 node ra khoi List
		if (p)
		{
			p->m_pNext = pNode->m_pNext;

			pNode->m_info = NULL;
			pNode->m_pNext = NULL;
			// Truong hop pNode nam cuoi List
			if (pNode == m_pTail)
				m_pTail = p;

			delete pNode;
		}
	}
	// Neu List truoc khi xoa chi co 1 Node duy nhat thi cho List rong
	if (IsEmpty())
		m_pTail = NULL;

	// Neu viec xoa thanh cong thi giam so Node trong List xuong 1 don vi
	--m_iSoNode;

	return *this;
}

LList& LList::Empty()
{
	// Xoa tat ca cac Node trong List
	for (Node *pNode = m_Head; pNode; pNode = pNode->m_pNext)
		DelNode(pNode);	
}

void* LList::GetNode(int iViTri)
{
	// Neu iViTri nam ngoai tam kiem soat cua List thi tra ve NULL
	if (iViTri < 0 && iViTri > m_iSoNode -1)
		return NULL;

	Node *pNode = m_pHead; 
	for (int i = 0; i < iViTri; ++i, pNode = pNode->m_pNext);

	return pNode->m_info;
}

bool IsEmpty()
{
	return m_pHead == NULL;
}

