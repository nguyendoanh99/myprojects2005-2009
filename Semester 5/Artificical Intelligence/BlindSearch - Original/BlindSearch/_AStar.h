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
	// la phan tu trong IsOpen, Close
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
	
public:
//	typedef typename _MinPriorityQueue<STATE, VALUE>::iterator iterator;
	_AStar(_Information<STATE, VALUE> *data): _BlindSearch(data)
	{
	}
	~_AStar()
	{
	}
	virtual string Result() = 0;
	// true: tim thay duong di
	// false: khong tim thay duong di
	bool Run()
	{
		_MinPriorityQueue<STATE, VALUE> Open(0); // Chua xu ly triet de (phai tuy thuoc vao VALUE moi dung)
		_AVLTree<Element> IsOpen; // cho biet cac phan tu nam trong Open
		_AVLTree<Element> Close; // cho biet cac phan tu nam trong Close
		Element element;
		bool flag = false; // true: tim thay duong di
		vector<STATE> Start = m_Info->GetStart();
		vector<STATE> Goal = m_Info->GetGoal();
		VALUE g;
		VALUE f;
/*
		cout << "Begin() --> Insert S into Open" << endl;
*/
		for (vector<STATE>::iterator i = Start.begin(); i != Start.end(); ++i)
		{
			element.state = *i;			
			f = m_Info->GetG(*i) + m_Info->GetH(*i); // f = g + h
			element.value = f;			
			Open.push(element.state, element.value); // Them phan tu moi vao Open
			IsOpen.Add(element); // Cho biet Open co phan tu element
		}	
/*
		cout << "Open = {" << Open << "}" << endl;
		cout << "IsOpen ={"<< IsOpen << "}" << endl;
		cout << "Close = {" << Close << "}" << endl;
		cout << "*************************" << endl;
*/
		STATE x;
		vector<STATE> Set; // tap hop cac trang thai sinh ra tu X

		while (!Open.empty())
		{			
			Open.top(element.state, element.value); // Lay phan tu dau tien ra khoi Queue
			Open.pop();
			x = element.state;			

			IsOpen.Remove(element);	
			Close.Add(element); // Dua trang thai vua lay ra vao Close
			
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
/*
			// Xuat ra man hinh
			cout << "x = Open.pop() and Close.push(x)" << endl;
			cout << "x = (" << element.state << "," << element.value << ")" << endl;
			cout << "Open ={"<< Open << "}" << endl;
			cout << "IsOpen ={"<< IsOpen << "}" << endl;
			cout << "Close = {" << Close << "}" << endl << endl;
*/
			Set = m_Info->GetSucc(x); // Lay cac trang thai sinh ra tu X
/*
			// Xuat ra man hinh
			cout << "Succ(x) = {";
			for (vector<STATE>::iterator i =Set.begin(); i != Set.end(); ++i)
				cout << *i << ", ";
			cout << "}" << endl;
*/
			for (vector<STATE>::iterator y = Set.begin(); y != Set.end(); ++y)
			{
				g = m_Info->GetG(x) + m_Info->GetCost(x, *y); // g(y) = g(x) + cost(x, y)
				f = g + m_Info->GetH(*y); // f(y) = g(y) + h(y)				
				
				
				element.state = *y;
				element.value = f;

//				cout << "\ty = (" << element.state << ", " << element.value << ")" << endl;
				Element* k = Close.Find(element);
				if (k != Close.GetSentinel()) // k thuoc Close
				{					
					if (k->value > f) // f cu > f moi
					{
						Close.Remove(element);

						element.value = f;						
						Open.push(element.state, element.value);
						IsOpen.Add(element);
						m_Info->SetG(element.state, g); // Cap nhat lai G(state)
						m_Info->SetPrevious(element.state, x);
/*
						cout << "\t\ty is element of Close and f'(y) < f(y)" << endl;
						cout << "\t\tPrevious(" << element.state << ") = " << x << endl;
						cout << "\t\tOpen ={"<< Open << "}" << endl;
						cout << "\t\tIsOpen ={"<< IsOpen << "}" << endl;
						cout << "\t\tClose = {" << Close << "}" << endl;
*/
						}		
//					else
//						cout << "\t\ty is element of Close but f'(y) >= f(y)=" << k->value << endl;
				}
				else
				{		
					k = IsOpen.Find(element);
					if (k == IsOpen.GetSentinel()) // y khong co trong Open
					{
						Open.push(element.state, element.value); // Dua element vao Open
						IsOpen.Add(element);
						m_Info->SetG(element.state, g); // Cap nhat lai G(state)
						m_Info->SetPrevious(element.state, x);
/*
						cout << "\t\ty is not element of Open" << endl;
						cout << "\t\tPrevious(" << element.state << ") = " << x << endl;
						cout << "\t\tOpen ={"<< Open << "}" << endl;
						cout << "\t\tIsOpen ={"<< IsOpen << "}" << endl;
*/
						}
					else // y nam trong Open
					{
						if (k->value > f) // f cu > f moi					
						{
							Open.DecreaseKey(element.state, k->value - f);
							k->value = f;
							m_Info->SetG(element.state, g); // Cap nhat lai G(state)
							m_Info->SetPrevious(element.state, x);
/*
							cout << "\t\ty is element of Open and f'(y) < f(y)" << endl;
							cout << "\t\tPrevious(" << element.state << ") = " << x << endl;
							cout << "\t\tOpen ={"<< Open << "}" << endl;
							cout << "\t\tIsOpen ={"<< IsOpen << "}" << endl;
*/
						}
//						else 
//						{
//							cout << "\t\ty is element of Open but f'(y) >= f(y)=" << k->value << endl;
//						}
					}
				}				
			}
//			cout << "\t-------------------------------------" << endl;
		}
		return flag;
	}
};