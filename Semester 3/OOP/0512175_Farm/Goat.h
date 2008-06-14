// Ho ten: Nguyen Dang Khoa
// MSSV:   0512175
// Lop:	   05C1
// Ca TH:  ca 2 chieu thu 6
#ifndef _Goat_
#define _Goat_

#include "Animal.h"
#define MAX_GRASS_GOAT 1
#define MAX_MILK_GOAT 10

class Goat: public Animal
{
public:
	virtual ~Goat(){}

	int Eat();
	vector<Animal *> GiveBirth();
	int GiveMilk();
	char* Talk();	
	int GetType();
	Animal* CreateObject();
	char* GetName();
};

#endif