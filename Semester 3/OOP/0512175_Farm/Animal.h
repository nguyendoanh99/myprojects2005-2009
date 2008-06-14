// Ho ten: Nguyen Dang Khoa
// MSSV:   0512175
// Lop:	   05C1
// Ca TH:  ca 2 chieu thu 6
#ifndef _Animal_
#define _Animal_

#include <vector>

using namespace std;

#define MAX_BIRTH 5
#define COW 1
#define SHEEP 2
#define GOAT 3

class Animal  
{
public:	
	virtual ~Animal(){}
	
	virtual vector<Animal*> GiveBirth() = 0; // Sinh con
	virtual int Eat() = 0; // Tra ve so kg co ma loai vat da an
	virtual int GiveMilk() = 0; // Tra ve so lit sua cua loai vat tuong ung
	virtual char* Talk() = 0; // Tra ve tieng keu cua loai vat tuong ung
	virtual int GetType() = 0; // Tra ve loai cua lop tuong ung
	virtual Animal* CreateObject() = 0; // Tao doi tuong cua lop tuong ung
	virtual char* GetName() = 0; // Lay ten cua lop tuong ung
};

#endif