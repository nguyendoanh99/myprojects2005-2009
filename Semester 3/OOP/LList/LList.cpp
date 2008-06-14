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
	m_iLength = 0;
}

LList::LList()
{
	TaoListRong();	
}

LList::LList(const LList &L)
{
	TaoListRong();
	// Sao chep tat ca cac Node tu L sang *this
	for (Node *p = L.m_pHead; p; p = p->m_pNext)
		AddTail(p->m_info);
}

LList::~LList()
{
	Empty();
}

LList& LList::operator =(const LList& L)
{	
	// Neu so node cua *this nhieu hon cua L thi xoa bot node cua *this de so node cua
	// *this va L bang nhau
	if (m_iLength > L.m_iLength)
	{
		for (;m_iLength > L.m_iLength; --m_iLength)
			DelHead();
	}
	// Neu so node cua *this it hon cua L thi them node cho *this de so node cua
	// *this va L bang nhau
	else 
	{
		while (m_iLength < L.m_iLength)
			AddHead((void*) NULL);
	}
	// Thay doi noi dung cac node trong *this
	int i = 0;	
	for (Node *p = L.m_pHead; p; p = p->m_pNext, ++i)
		SetNode(i, p->m_info);

	return *this;
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
	++m_iLength;

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
	++m_iLength;

	return *this;
}

LList& LList::AddTail(void *p)
{
	return AddTail(::GetNode(p));
}

LList& LList::DelNode(int iViTri)
{
	// Neu iViTri nam ngoai tam kiem soat cua List thi thoat
	if (iViTri < 0 && iViTri >= m_iLength)
		return *this;

	Node *p = m_pHead;
	// Truong hop Node can xoa nam dau List
	if (iViTri == 0)
	{		
		m_pHead = m_pHead->m_pNext;

		p->m_pNext = NULL;
		p->m_info = NULL;

		delete p;
	}
	else // Truong hop Node can xoa nam o giua List
	{
		int i = 0;
		while (i < iViTri - 1)
		{
			p = p->m_pNext;		
			++i;
		}
		
		Node *pNode = p->m_pNext;

		p->m_pNext = pNode->m_pNext;

		pNode->m_info = NULL;
		pNode->m_pNext = NULL;
		// Truong hop pNode nam cuoi List
		if (pNode == m_pTail)
			m_pTail = p;

		delete pNode;		
	}
	// Neu List truoc khi xoa chi co 1 Node duy nhat thi cho List rong
	if (IsEmpty())
		m_pTail = NULL;

	// Neu viec xoa thanh cong thi giam so Node trong List xuong 1 don vi
	--m_iLength;

	return *this;
}

LList& LList::DelHead()
{
	return DelNode(0);
}

LList& LList::DelTail()
{
	return DelNode(m_iLength - 1);
}

LList& LList::Empty()
{
	// Xoa tat ca cac Node trong List
	while (m_iLength)
		DelHead();	

	return *this;
}

void* LList::GetNode(int iViTri) const
{
	// Neu iViTri nam ngoai tam kiem soat cua List thi tra ve NULL
	if (iViTri < 0 && iViTri > m_iLength - 1)
		return NULL;

	Node *pNode = m_pHead; 
	for (int i = 0; i < iViTri; ++i, pNode = pNode->m_pNext);

	return pNode->m_info;
}

bool LList::IsEmpty() const
{
	return m_pHead == NULL;
}

bool LList::SetNode(int iViTri, void *p)
{
	// Neu iViTri nam ngoai tam kiem soat cua List thi thoat
	if (iViTri < 0 && iViTri > m_iLength - 1)
		return false;

	Node *pNode = m_pHead; 
	for (int i = 0; i < iViTri; ++i, pNode = pNode->m_pNext);

	pNode->m_info = p;

	return true;
}

int LList::GetLength() const
{
	return m_iLength;
}

/*
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
	--m_iLength;

	return *this;
}
*/