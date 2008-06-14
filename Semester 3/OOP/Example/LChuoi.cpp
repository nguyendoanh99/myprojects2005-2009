#include "LChuoi.h"
#include <string.h>
#include <iostream.h>
LChuoi::LChuoi()
{
	p = NULL;
	n = 0;
	cout << "Thuc hien ham dung mac dinh tu doi tuong" << endl;
}

LChuoi::LChuoi(const LChuoi& P)
{
	n = P.n;
	p = new char[n + 1];
	strcpy(p, P.p);
	cout << "Thuc hien ham dung sao chep tu doi tuong '" << P.p << "'" << endl;
}

LChuoi::LChuoi(char *str)
{
	n = strlen(str);
	p = new char[n + 1];
	strcpy(p, str);
	cout << "Thuc hien ham dung tu chuoi '" << str << "'" << endl;
}

LChuoi::~LChuoi()
{
	cout << "Thuc hien ham huy doi tuong ";
	if (p)
	{
		cout << "'" << p << "'";
		delete []p;
	}
	cout << endl;
	
}

LChuoi LChuoi::operator +(const LChuoi& P)
{
	LChuoi kq;
	kq.n = P.n + n;
	char *t = new char[kq.n + 1];
	strcpy(t, p);
	strcat(t, P.p);
	kq.p = t;
	return kq;
}
/*
LChuoi& LChuoi::operator +(const LChuoi& P)
{
	char *t = p;
	n += P.n;
	p = new char[n + 1];
	strcpy(p, t);
	strcat(p, P.p);
	delete []t;		
	return *this;
}
*/
LChuoi& LChuoi::operator =(const LChuoi& P)
{
	if (p)
		delete []p;
	n = P.n;
	p = new char[n +1];
	strcpy(p, P.p);
	return *this;
}