#ifndef _LSTACK_
#define _LSTACK_

#include "LList.h"
class LStack: private LList
{
public:
	LStack();
	LStack(const LStack&);
	LStack(const LList&);
	virtual ~LStack();

	LStack& operator =(const LList&);
	LStack& operator =(const LStack&);
	LStack& Push(void *info); // Dua info vao Stack
	LStack& Push(Node *); // Dua 1 node vao Stack
	void *Pop(); // Lay thong tin cua node o dinh Stack ra khoi Stack
	LStack& Empty(); // Lam rong Stack
	bool SetNode(void*); // Ghi thong tin vao node o dinh Stack
	
	void *GetInfo() const; // Xem thong tin cua node o dinh Stack
	bool IsEmpty() const; // Kiem tra xem Stack co rong khong
};

#endif