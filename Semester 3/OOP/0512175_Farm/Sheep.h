// Ho ten: Nguyen Dang Khoa
// MSSV:   0512175
// Lop:	   05C1
// Ca TH:  ca 2 chieu thu 6
#ifndef _Sheep_
#define _Sheep_

#include "Animal.h"
#define MAX_GRASS_SHEEP 3
#define MAX_MILK_SHEEP 5

class Sheep: public Animal
{
public:
	virtual ~Sheep(){}

	int Eat();
	vector<Animal*> GiveBirth();
	int GiveMilk();
	char* Talk();
	int GetType();
	Animal* CreateObject();
	char* GetName();
};

#endif