#include <iostream.h>
class X
	{
	 public:
          int value;
	  X():value(0) {}
	  X(int i): value(i){};
	  X &operator++();
	  X operator++(int);
	  X &operator+(X);
	  X operator=(X&);
	};

void main()
{
 X x1(23),x2(34),x3;

 x3=++x1+1;
 cout<<"x3="<<x3.value;
 x3=x2+++1;
 cout<<"x3="<<x3.value;
 x3=x2+1;
 cout<<"x3="<<x3.value;
}

X &X::operator++()
{
 value+=1;
 return *this;
}
/*
X X::operator++(int)
{
 value+=1;
 return X(value);
}
*/
X X::operator++(int)
{
 X m;
 m.value=value;
 value+=1;
 return m;
}
X &X::operator+(X m)
{
 value+=m.value;
 return *this;
}

X X::operator=(X &m)
{
 value=m.value;
 return X(value);
}