// Ho ten: Nguyen Dang Khoa
// MSSV:   0512175
// Lop:	   05C1
// Ca TH:  ca 2 chieu thu 6
#ifndef _Cow_
#define _Cow_

#include "Animal.h"
#define MAX_GRASS_COW 5
#define MAX_MILK_COW 20

class Cow: public Animal
{
public:
	virtual ~Cow(){}
	
	int Eat();
	vector<Animal*> GiveBirth();
	int GiveMilk();
	char* Talk();
	
	int GetType();	
	Animal* CreateObject();
	char* GetName();
};
#endif
