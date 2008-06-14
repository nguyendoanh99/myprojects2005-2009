#include <iostream.h>
#include <stdlib.h>
#include <stdio.h>
class A
{
	int a;
	public:
		A(int y)
		{
			a=y;
		}
		A ()
		{
			a = 1;
		}
		virtual void f()
		{

		}
		virtual ~A()
		{
		}
};

class B: public A
{
	int b;
	public:	
		B(int t)
		{
			b = t;
		}

		B()
		{
			b = 2;
		}
		void f() {}
};

class C: public B
{
	int c;
public:	
	C()
	{
		c = 3;
	}
	void f()
	{
	}
	void in()
	{
		f();
	}
	void gh()
	{
		c++;
	}
};

char *f()
{
	return "sadf";
}
void main()
{
	cout<<f();
	cout<<f();
	cout<<f();
	char *t = f();
	t[0] =3;
//	int	a[10];
//	a[0] = 1;
//	a[1] = 5;
//	for (int i = 2; i <= 9; ++i)
//		a[i] = 3*a[i-1] - 5 * a[i - 2];
//	A* t[4];
//	int a=5;
//	cout << a;
//	cout << 5;
//	A(2);
//	t[0] = &A(2);
//	CMy a("ijkgh");
//	cout <<a;
//		cout<< CMY("kljl");
//	a =4 +3 +2;
//	A a;
///	B b;
//	C c;
//	a = b;
///	a = &b;
//	c = (C*) a;
//	c->gh();
//	c->f();
}
/*#include <iostream.h>
class A 
{ 
public: 
~A() 
{ 
cout << "Destructor of class A." << endl; 
} 
}; 
class B : public A 
{ 
public: 
~B() 
{ 
cout << "Destructor of class B." << endl; 
} 
}; 
class C : public B 
{ 
public: 
~C() 
{ 
cout << "Destructor of class C." << endl; 
} 
};
void main() 
{ 
C obj; 
} 

*/