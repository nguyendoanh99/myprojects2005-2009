// Ho ten: Nguyen Dang Khoa
// MSSV:   0512175
// Lop:	   05C1
// Ca TH:  ca 2 chieu thu 6
#ifndef _Farm_
#define _Farm_

#include "Animal.h"

class Farm
{
private:
	vector<Animal*> m_arrAnimals; // chua gia suc trong nong trai
	vector<Animal*> m_arrObjects; // Dung de tao doi tuong mau
	vector<int> m_arrCount; // m_arrCount[i] la so luong cua gia suc "i" trong nong trai
public:
	Farm();	
	
	virtual ~Farm();
	
	void MakeNoise(); // Phat tieng keu cua toan bo gia suc co trong nong trai
	void Reproduce(); // Moi gia suc trong nong trai deu sinh con

	int Count(int iType); // Dem so luong gia suc iType co trong nong trai

	int GetTotalMilk(); // Lay tong so sua ma cac gia suc trong nong trai da cho
	int GetTotalGrass(); // Lay so kg co ma tat ca gia suc trong nong trai da an
	
	void Add(int iType, int n = 1); // Them n gia suc iType vao trong nong trai
	void Init(int *iSoLuong); // Khoi tao nong trai voi gia suc loai "i" thi co so luong la iSoLuong[i]
	int LuaChon(); // Hien bang thong bao nhap
};

#endif