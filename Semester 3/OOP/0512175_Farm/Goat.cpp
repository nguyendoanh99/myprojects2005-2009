#include "Goat.h"

int Goat::Eat()
{
	return rand() % (MAX_GRASS_GOAT + 1);
}

int Goat::GiveMilk()
{
	return rand() % (MAX_MILK_GOAT + 1);
}

char* Goat::Talk()
{
	return "Beheheh... beheheh.... beheheh..........";
}

vector<Animal *> Goat::GiveBirth()
{
	vector<Animal *> kq;
	int n = rand() % (MAX_BIRTH + 1);

	for (int i = 0; i < n; ++i)
		kq.push_back(new Goat);
	return kq;
}

int Goat::GetType()
{
	return GOAT;
}

Animal* Goat::CreateObject()
{
	return new Goat;
}

char* Goat::GetName()
{
	return "DE";
}