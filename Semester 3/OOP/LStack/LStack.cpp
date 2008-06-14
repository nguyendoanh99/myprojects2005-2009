#include "LStack.h"

LStack::LStack(): LList()
{
}

LStack::LStack(const LList& L): LList(L)
{
}

LStack::LStack(const LStack& S): LList(S)
{
}

LStack::~LStack()
{
}

LStack& LStack::Empty()
{
	LList::Empty();
	return *this;
}

void* LStack::GetInfo() const
{
	return LList::GetNode(0);
}

bool LStack::IsEmpty() const
{
	return LList::IsEmpty();
}

LStack& LStack::operator =(const LStack& S)
{
	LList::operator =(S);
	return *this;
}

LStack& LStack::operator =(const LList& L)
{
	LList::operator =(L);
	return *this;
}

void* LStack::Pop()
{

	void *p = LList::GetNode(0);
	LList::DelHead();

	return p;
}

LStack& LStack::Push(Node *pNode)
{
	LList::AddHead(pNode);
	return *this;
}

LStack& LStack::Push(void *pInfo)
{
	LList::AddHead(pInfo);
	return *this;
}

bool LStack::SetNode(void* pInfo)
{
	return LList::SetNode(0, pInfo);	
}