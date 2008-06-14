#pragma once
#include "iostream"
using namespace std;
#define LH -1
#define EH 0
#define RH 1
template <class DATA>
class _AVLTree
{
private:
	struct AVLnode
	{
		int balFactor;
		DATA info;
		struct AVLnode *pLeft;
		struct AVLnode *pRight;
	};
	typedef struct AVLnode *AVLTREE;
	typedef struct AVLnode AVLNODE;
	AVLTREE T;
	DATA sentinel;

	int searchStandFor(AVLTREE &p,AVLTREE &q)
	{
		int res;
		if (q->pLeft)
		{
			res=searchStandFor(p,q->pLeft);
			if (res<2)
				return res;
			switch (q->balFactor)
			{
			case LH:
				q->balFactor=EH;
				return 2;
			case EH:
				q->balFactor=RH;
				return 1;
			case RH:
				return balanceRight(q);
			}
		}
		else
		{
			p->info=q->info;
			p=q;
			q=q->pRight;
			return 2;
		}
	}
	void rotateLL(AVLTREE &T)
	{
		AVLNODE *T1=T->pLeft;
		T->pLeft=T1->pRight;
		T1->pRight=T;
		switch (T1->balFactor)
		{
		case LH:
			T1->balFactor=EH;
			T->balFactor=EH;
			break;
		case EH:
			T1->balFactor=RH;
			T->balFactor=LH;
			break;
		}
		T=T1;
	}
	void rotateRR(AVLTREE &T)
	{
		AVLNODE *T1=T->pRight;
		T->pRight=T1->pLeft;
		T1->pLeft=T;
		switch (T1->balFactor)
		{
		case RH:
			T1->balFactor=EH;
			T->balFactor=EH;
			break;
		case EH:
			T1->balFactor=LH;
			T->balFactor=RH;
			break;
		}
		T=T1;
	}
	void rotateLR(AVLTREE &T)
	{
		AVLNODE *T1=T->pLeft;
		AVLNODE *T2=T1->pRight;
		T->pLeft=T2->pRight;
		T2->pRight=T;
		T1->pRight=T2->pLeft;
		T2->pLeft=T1;
		switch (T2->balFactor)
		{
		case EH:
			T1->balFactor=EH;
			T->balFactor=EH;
			break;
		case LH:
			T1->balFactor=EH;
			T->balFactor=RH;
			break;
		case RH:
			T1->balFactor=LH;
			T->balFactor=EH;
			break;
		}
		T2->balFactor=EH;
		T=T2;
	}
	void rotateRL(AVLTREE &T)
	{
		AVLNODE *T1=T->pRight;
		AVLNODE *T2=T1->pLeft;
		T->pRight=T2->pLeft;
		T2->pLeft=T;
		T1->pLeft=T2->pRight;
		T2->pRight=T1;
		switch (T2->balFactor)
		{
		case EH:
			T1->balFactor=EH;
			T->balFactor=EH;
			break;
		case RH:
			T1->balFactor=EH;
			T->balFactor=LH;
			break;
		case LH:
			T1->balFactor=RH;
			T->balFactor=EH;
			break;
		}
		T2->balFactor=EH;
		T=T2;
	}
	int balanceLeft(AVLTREE &T)
	{
		AVLNODE *T1=T->pLeft;
		switch (T1->balFactor)
		{
		case LH:
			rotateLL(T);
			return 2;
		case EH:
			rotateLL(T);
			return 1;
		case RH:
			rotateLR(T);
			return 2;
		}
		return 0;
	}
	int balanceRight(AVLTREE &T)
	{
		AVLNODE *T1=T->pRight;
		switch (T1->balFactor)
		{
		case RH:
			rotateRR(T);
			return 2;
		case EH:
			rotateRR(T);
			return 1;
		case LH:
			rotateRL(T);
			return 2;
		}
		return 0;
	}	
	void DeleteTree(AVLTREE &T)
	{
		if (T == NULL)
			return;

		if (T->pLeft)
			DeleteTree(T->pLeft);

		if (T->pRight)
			DeleteTree(T->pRight);

		delete T;
		T = NULL;
	}
	// -1	:	khong du bo nho
	// 0	:	da co
	// 1	:	thanh cong
	// 2	:	chieu cao cay tang
	int insertNode(AVLTREE &T,DATA x)
	{
		int res;
		if (T)
		{
			if (T->info==x)
				return 0;
			
			if (T->info>x)
			{
				res=insertNode(T->pLeft,x);
				if (res<2)
					return res;
				switch (T->balFactor)
				{
				case RH:
					T->balFactor=EH;
					return 1;
				case EH:
					T->balFactor=LH;
					return 2;
				case LH:
					balanceLeft(T);
					return 1;
				}
			}
			else
			{
				res=insertNode(T->pRight,x);
				if (res<2)
					return res;
				switch (T->balFactor)
				{
				case LH:
					T->balFactor=EH;
					return 1;
				case EH:
					T->balFactor=RH;
					return 2;
				case RH:
					balanceRight(T);
					return 1;
				}
			}			
		}
		T=new AVLNODE;
		if (T==NULL)
			return -1;
		T->balFactor=EH;
		T->info=x;
		T->pLeft=T->pRight=NULL;
		return 2;
	}
	int delNode(AVLTREE &T,DATA x)
	{
		if (T==NULL)
			return 0;
		int res;
		if (T->info>x)
		{
			res=delNode(T->pLeft,x);
			if (res<2)
				return res;
			switch (T->balFactor)
			{
			case LH:
				T->balFactor=EH;
				return 2;
			case EH:
				T->balFactor=RH;
				return 1;
			case RH:
				return balanceRight(T);
			}
		}

		if (T->info<x)
		{
			res=delNode(T->pRight,x);
			if (res<2)
				return res;
			switch (T->balFactor)
			{
			case RH:
				T->balFactor=EH;
				return 2;
			case EH:
				T->balFactor=LH;
				return 1;
			case LH:
				return balanceLeft(T);
			}
		}
		else
		{
			AVLNODE *p=T;
			if (T->pLeft==NULL)
			{
				T=T->pRight;
				res=2;
			}
			else
				if (T->pRight==NULL)
				{
					T=T->pLeft;
					res=2;
				}
				else
				{				
					res=searchStandFor(p,T->pRight);
					if (res<2)
						return res;
					switch (T->balFactor)
					{
					case RH:
						T->balFactor=EH;
						return 2;
					case EH:
						T->balFactor=LH;
						return 1;
					case LH:
						return balanceLeft(T);
					}
				}
				delete p;
				return res;
		}
	}
	void LNR(ostream& os, AVLTREE T) const
	{
		if (T)
		{
			LNR(os, T->pLeft);
			os << T->info << " ";
			LNR(os, T->pRight);
		}
	}
	int Sum(AVLTREE& T)
	{
		if (T == NULL)
			return 0;
		if (T->pLeft == NULL && T->pRight == NULL)
			return 1;
		return Sum(T->pLeft) + Sum(T->pRight) + 1;
	}
public:
	const DATA* GetSentinel()
	{
		return &sentinel;
	}
	_AVLTree()
	{
		T = NULL;
	}
	~_AVLTree()
	{
		DeleteTree(T);
	}
	// -1	:	khong du bo nho
	// 0	:	da co
	// 1	:	thanh cong
	// 2	:	chieu cao cay tang
	int Add(DATA x)
	{
		return insertNode(T, x);
	}
	// Loai bo x ra khoi cay
	// Tra ve 0 neu x khong ton tai tren cay
	int Remove(DATA x)
	{
		return delNode(T, x);
	}
	DATA* Find(DATA x)
	{
		AVLNODE *p=T;

		while (p)
		{		
			if (p->info>x)
				p=p->pLeft;
			else
				if (p->info<x)
					p=p->pRight;
				else
					return &p->info;			
		}

		return &sentinel;
	}
	bool isEmpty()
	{
		return T == NULL;
	}
	void DeleteTree()
	{
		DeleteTree(T);
	}
	int SumNode()
	{
		return Sum(T);
	}
	friend ostream& operator<<(ostream &os, const _AVLTree& x)
	{
		x.LNR(os, x.T);
		return os;
	}
};