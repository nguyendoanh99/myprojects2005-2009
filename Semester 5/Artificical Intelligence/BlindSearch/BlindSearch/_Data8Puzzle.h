#pragma once
#include "_information.h"
#include "_AVLTreeStructure.h"
class _Data8Puzzle :
	public _Information<int, int>
{
private:
	class Element
	{
	public:
		int state;
		int g;
		int previous;
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
			return os << "(" << x.state << "," << x.g << "," << x.previous << ")";
		};
	};	
	int m_Start;
	int m_Goal;
	int (*HFunction)(const _Data8Puzzle& info, int X); // Con tro ham de giu ham H muon tinh
	_AVLTree<Element> m_State; // chua gia tri g va previous cua cac trang thai 
	int A[3][3]; // Dung cho ham H3
	
public:
	static void MatrixToInt(int State[][3], int &Number); // Chuyen ma tran 3x3 thanh so
	static void IntToMatrix(int Number, int State[][3]); // Chuyen 1 so thanh ma tran 3x3
	_Data8Puzzle(char *filename, int H); // H = 1, 2, 3 tuong ung voi ham H1, H2, H3	
	int GetCost(int X, int Y); // Chi phi di tu X den Y
	std::vector<int> GetSucc(int X); // Tra ve cac trang thai sinh ra tu X
	std::vector<int> GetStart(); // Tra ve cac trang thai bat dau cua bai toan
	std::vector<int> GetGoal(); // Tra ve cac trang thai dich cua bai toan
	int GetG(int X); // Tra ve chi phi di tu trang thai bat dau den trang thai X (goi la chi phi g)
	void SetG(int X, int m); // Thay doi chi phi g bang m
	int GetH(int X); // Tra ve gia tri cua ham heuristic tai trang thai X
	int GetPrevious(int X); // Lay trang thai cha cua X
	void SetPrevious(int X, int Y); // Gan trang thai cha cua X la Y
	int SumState();
	virtual ~_Data8Puzzle(void);
	friend int GetH1(const _Data8Puzzle& info, int X); // h = 0
	friend int GetH2(const _Data8Puzzle& info, int X); // h = so o sai vi tri cua trang thai ban dau so voi trang thai dich
	friend int GetH3(const _Data8Puzzle& info, int X); // tong khoang cach Mahattan
};
