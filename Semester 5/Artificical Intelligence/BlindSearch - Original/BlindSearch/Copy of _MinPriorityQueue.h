#pragma once
#include "stdafx.h"
#include <queue>
using namespace std;

template<class KEY, class VALUE>
class _MinPriorityQueue
{
private:
	class Element
	{
	public:
		KEY key;
		VALUE value;	
		bool operator ==(const Element& x) const
		{
			return key == x.key;
		}
	};
	struct Compare{
		bool operator()(const Element& x, const Element& y) {
			return x.value > y.value;
		}
	};
	vector<Element> c;
public:
	typedef typename vector<Element>::iterator iterator;
	// Cho biet do uu tien cao nhat cua PriorityQueue la bao nhieu (gia tri min)
	// Cho c[0] la phan tu min
	_MinPriorityQueue(VALUE min):c(1)
	{	
		c[0].value = min;		
	}
	bool empty() const
	{	// test if queue is empty
		return (c.size() - 1 == 0);
	}

	int size() const
	{	// return length of queue
		return (c.size() - 1);
	}

	// true: neu co phan tu trong Queue
	// false: khong con phan tu trong Queue
	bool top(KEY &key, VALUE& value)
	{	// return highest-priority element
		if (empty())
			return false;

		iterator element = c.begin() + 1;
		key = element->key;
		value = element->value;		
		return true;
	}

	void push(const KEY& key, const VALUE& value)
	{	// insert value in priority order
		Element temp;
		temp.key = key;
		temp.value = value;

		c.push_back(temp);		
		push_heap(c.begin() + 1, c.end(), Compare());		
	}

	void pop()
	{	// erase highest-priority element
		if (empty())
			return;

		pop_heap(c.begin() + 1, c.end(), Compare());		
		c.pop_back();
	}
	// Tang do uu tien cua key len k gia tri	
	// true: thuc hien thanh cong (tuc la tim thay key trong Queue)
	// false: that bai
	bool DecreaseKey(KEY key, VALUE k)
	{
		Element temp;
		temp.key = key;
		temp.value = k;
		iterator index = find(c.begin() + 1, c.end(), temp);
		if (index == c.end())
			return false;

		temp.value = index->value - k;	
		if (temp.value < c[0].value)
			temp.value = c[0].value;

		iterator i = index;
		iterator parent = (index - ((index + 1 - c.begin()) / 2)); // parent = index / 2
		while (parent->value > temp.value)
		{
			*i = *parent;
			i = parent;
			parent -= (parent + 1 - c.begin()) / 2; // parent = parent / 2
		}
		*i = temp;
		return true;
	}
	friend ostream& operator<< (ostream& os, _MinPriorityQueue &x)
	{
		for (iterator i = x.c.begin() + 1; i != x.c.end(); ++i)

			os << "(" << i->key << "," << i->value << ") ";

		return os;
	};
};