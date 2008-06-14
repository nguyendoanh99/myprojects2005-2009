#include <stdio.h>
class A
	{
	 public:
	  virtual void printOn() { puts("\nClass A"); }
	};
class B:public A
	{
	 public:
	  virtual void printOn() {}
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
 A* a=new A;
 B* b=new B;
 C* c=new C;
 puts("\nVi du 6.2");
 Show(a);
 Show(b);
 Show(c);
}