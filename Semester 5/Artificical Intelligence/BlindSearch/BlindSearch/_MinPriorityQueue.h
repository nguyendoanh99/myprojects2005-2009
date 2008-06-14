#pragma once
#include "stdafx.h"
#include "vector"

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

	vector<Element> c;	
public:	
	// Cho biet do uu tien cao nhat cua PriorityQueue la bao nhieu (gia tri min)
	// Cho c[0] la phan tu min
	_MinPriorityQueue(VALUE min)
	{	
		// The array have one extra for sentinel
		Element temp;
		temp.value = min;
		c.push_back(temp);
	}
	bool empty() const
	{	// test if queue is empty
		return c.size() - 1 == 0;
	}

	int size() const
	{	// return length of queue		
		return (int) (c.size() - 1);
	}

	// true: neu co phan tu trong Queue
	// false: khong con phan tu trong Queue
	bool top(KEY &key, VALUE& value)
	{	// return highest-priority element
		if (empty())
			return false;

		key = c[1].key;
		value = c[1].value;
		return true;
	}

	void push(const KEY& key, const VALUE& value)
	{	
		Element temp;
		temp.key = key;
		temp.value = value;
		
		c.push_back(c[0]);
		int i;
		for (i = (int) c.size() - 1; c[i / 2].value > value; i /= 2)
			c[i] = c[i / 2];

		c[i] = temp;
	}
	
	void pop()
	{	
		if (empty())
			return;

		int i, Child;
		Element LastElement;		
		int size = (int) c.size();

		LastElement = c[size - 1];
		--size;
		for (i = 1; i * 2 < size; i = Child)
		{
			// Find smaller find
			Child = i * 2;
			if (Child != size - 1 && c[Child + 1].value < c[Child].value)
				++Child;
			// Percolate on level
			if (LastElement.value > c[Child].value)
				c[i] = c[Child];
			else
				break;
		}
		c[i] = LastElement;
		c.pop_back();
	}

	// Tang do uu tien cua key len k gia tri	
	// true: thuc hien thanh cong (tuc la tim thay key trong Queue)
	// false: that bai
/*
	bool DecreaseKey(KEY key, VALUE k)
	{
		Element temp;
		temp.key = key;
		
		iterator index = find(c.begin() + 1, m_end, temp);
//		iterator index = find(c.begin() + 1, c.end(), temp);
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
*/
	friend ostream& operator<< (ostream& os, _MinPriorityQueue &x)
	{
		for (iterator i = x.c.begin() + 1; i != x.c.end(); ++i)

			os << "(" << i->key << "," << i->value << ") ";

		return os;
	};
};