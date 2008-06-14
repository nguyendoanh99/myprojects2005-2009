#include <stdio.h>
class A
	{
	 public:
	  virtual void Display() { puts("\nClass A"); }
	};
class B:public A
	{
	 public:
	  virtual void Display() { puts("\nClass B"); }
	};
void Show(A* a)
{
 a->Display();
}
void main()
{
 A* a=new A;
 B* b=new B;
 a->Display();
 b->Display();
 Show(a); // Goi ham A::Display()
 Show(b); // Goi ham B::Display()
}
