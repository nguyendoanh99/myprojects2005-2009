#include "Sheep.h"

int Sheep::Eat()
{
	return rand() % (MAX_GRASS_SHEEP + 1);
}

int Sheep::GiveMilk()
{
	return rand() % (MAX_MILK_SHEEP + 1);
}

char* Sheep::Talk()
{
	return "Ehhhh... ehhhh... ehhhhhh................";
}

vector<Animal *> Sheep::GiveBirth()
{
	vector<Animal *> kq;
	int n = rand() % (MAX_BIRTH + 1);

	for (int i = 0; i < n; ++i)
		kq.push_back(new Sheep);
	return kq;
}

int Sheep::GetType()
{
	return SHEEP;
}

Animal* Sheep::CreateObject()
{
	return new Sheep;
}

char* Sheep::GetName()
{
	return "CUU";
}