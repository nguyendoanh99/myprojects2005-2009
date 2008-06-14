#pragma once
#include "stdafx.h"
#include <queue>
using namespace std;

template<class T>
class _MinPriorityQueue
{
private:
	vector<T> c;
public:
	typedef typename vector<T>::iterator iterator;
	// Cho c[0] la phan tu min
	_MinPriorityQueue():c(1)
	{	
	}
	bool empty() const
	{	// test if queue is empty
		return (c.size() - 1 == 0);
	}

	int size() const
	{	// return length of queue
		return (c.size() - 1);
	}

	const T& top()
	{	// return highest-priority element
		return (*(c.begin() + 1));
	}

	const iterator push(const T& _Pred)
	{	// insert value in priority order
		iterator temp;
		c.push_back(_Pred);
		temp = c.end() - 1;
		push_heap(c.begin() + 1, c.end(), greater<T>());
		return temp;
	}

	void pop()
	{	// erase highest-priority element
		pop_heap(c.begin() + 1, c.end(), greater<T>());
		c.pop_back();
	}
	// Tang do uu tien cua key len k gia tri
	// index: vi tri cua key
	void DecreaseKey(iterator index, T k)
	{
		T value = *index - k;
		if (value < c[0])
			value = c[0];

		iterator i = index;
		iterator parent = (index - ((index + 1 - c.begin()) / 2)); // parent = index / 2
		while (*parent > value)
		{
			*i = *parent;
			i = parent;
			parent -= (parent + 1 - c.begin()) / 2; // parent = parent / 2
		}
		*i = value;
	}
	friend ostream& operator<< (ostream& os, _MinPriorityQueue &x)
	{
		for (iterator i = x.c.begin() + 1; i != x.c.end(); ++i)
			os << *i << " ";

		return os;
	};
};