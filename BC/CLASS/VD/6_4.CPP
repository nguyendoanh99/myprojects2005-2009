#include <stdio.h>
class A
	{
	 public:
	  virtual void printOn()=0; // Pure virtual function
	};
class B:public A
	{
	 public:
	  virtual void printOn() { puts("\nClass B"); }
	};
class C:public B
	{
	 public:
	  virtual void printOn() { puts("\nClass C"); }
	};
void Show(A* a)
{
 a->printOn();
}
void main()
{
 B* b=new B;
 C* c=new C;
 puts("\nVi du 6.4");
 Show(b); // Su dung B::printOn()
 Show(c); // Su dung C::printOn()
}