#pragma  once
#include "_BlindSearch.h"
#include "_MinPriorityQueue.h"
#include "_AVLTreeStructure.h"
#include "iostream"
#include "string"

template <class STATE, class VALUE>
class _AStar: public _BlindSearch<STATE, VALUE>
{
private:
	// la phan tu trong Close
	class Element
	{
	public:
		STATE state;
		VALUE value;
		bool operator==(const Element& x) const
		{
			return state == x.state;
		}
		bool operator>(const Element& x) const
		{
			return state > x.state;
		}
		bool operator<(const Element& x) const
		{
			return state < x.state;
		}
		friend std::ostream& operator<< (std::ostream& os, const Element& x)
		{
			return os << "(" << x.state << "," << x.value << ")";
		};
	};	
	int SumNode; // tong so node phat duoc phat sinh
public:
	_AStar(_Information<STATE, VALUE> *data): _BlindSearch(data)
	{
		SumNode = 0;
	}
	~_AStar()
	{
	}
	virtual string Result() = 0;
	// Tong so node phat sinh	
	int GetSumNode()
	{
		return SumNode;
	};
	// true: tim thay duong di
	// false: khong tim thay duong di

	bool Run()
	{
		_MinPriorityQueue<STATE, VALUE> Open(0); // Chua xu ly triet de (phai tuy thuoc vao VALUE moi dung)
		_AVLTree<Element> Close; // cho biet cac phan tu nam trong Close

		Element element;
		bool flag = false; // true: tim thay duong di
		vector<STATE> Start = m_Info->GetStart();
		vector<STATE> Goal = m_Info->GetGoal();
		VALUE g;
		VALUE f;
		VALUE temp;
//		double w = 0.4;
		for (vector<STATE>::iterator i = Start.begin(); i != Start.end(); ++i)
		{
			element.state = *i;			
			f = m_Info->GetG(*i) + m_Info->GetH(*i); // f = g + h
//			f = w*m_Info->GetG(*i) + (1 - w) * m_Info->GetH(*i); // f = g + h
			element.value = f;			
			Open.push(element.state, element.value); // Them phan tu moi vao Open
			++SumNode;
		}	

		STATE x;
		vector<STATE> Set; // tap hop cac trang thai sinh ra tu X

		while (!Open.empty())
		{			
			Open.top(element.state, element.value); // Lay phan tu dau tien ra khoi Queue
			Open.pop();
			x = element.state;			

			// Kiem tra element co phai la dich hay khong
			for (vector<STATE>::iterator i = Goal.begin(); i != Goal.end(); ++i)
			{
				if (x == *i)
				{
					flag = true;
					break;
				}
			}
			if (flag)
				break;

			// Them that bai, tuc la da element da co trong Close
			if (Close.Add(element) == 0)
			{
//				Element* t = Close.Find(element);
//				cout << *t << " " << element << endl;
//				continue;
			}
//			Close.Add(element);
			Set = m_Info->GetSucc(x); // Lay cac trang thai sinh ra tu X
			temp = m_Info->GetG(x);
			for (vector<STATE>::iterator y = Set.begin(); y != Set.end(); ++y)
			{
				g = temp + m_Info->GetCost(x, *y); // g(y) = g(x) + cost(x, y)
				f = g + m_Info->GetH(*y); // f(y) = g(y) + h(y)				
//				f = w * g + (1 - w) * m_Info->GetH(*y); // f(y) = g(y) + h(y)				
							
				element.state = *y;
				element.value = f;

				Element* k = Close.Find(element);
				if (k != Close.GetSentinel()) // k thuoc Close
				{					
					if (k->value > f) // f cu > f moi
					{
						k->value = f;
						m_Info->SetG(element.state, g); // Cap nhat lai G(state)
						m_Info->SetPrevious(element.state, x);
						// Dua element da co trong Close vao lai Open
						Open.push(element.state, element.value);
						++SumNode;
					}		
				}
				else
				{				
					Open.push(element.state, element.value); // Dua element vao Open
					++SumNode;					

					m_Info->SetG(element.state, g); // Cap nhat lai G(state)
					m_Info->SetPrevious(element.state, x);
				}				
			}
		}

		return flag;
	}
};