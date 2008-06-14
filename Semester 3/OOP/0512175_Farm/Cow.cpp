#include "Cow.h"

int Cow::Eat()
{
	return rand() % (MAX_GRASS_COW + 1);
}

int Cow::GiveMilk()
{
	return rand() % (MAX_MILK_COW + 1);
}

char* Cow::Talk()
{
	return "Uhmmmm... uhmmmm.... uhmmmm........";
}

vector<Animal *> Cow::GiveBirth()
{
	vector<Animal *> kq;
	int n = rand() % (MAX_BIRTH + 1);

	for (int i = 0; i < n; ++i)
		kq.push_back(new Cow);
	return kq;
}

int Cow::GetType()
{
	return COW;
}

Animal* Cow::CreateObject()
{
	return new Cow;
}

char* Cow::GetName()
{
	return "BO";
}