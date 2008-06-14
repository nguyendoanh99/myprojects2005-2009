class X
	{
	  friend X operator+(X&,X&);
	 public :
	  int value;
	  X(int i): value(i) {}
	  X(char *cp): value(0) {}
	  X &operator=(X&);
	};

void main()
{
 X g(2),h(5),i(3);

 g=h+h+i;
 g=h+"ABC";
 g="ABC"+h;
// g="sd"+"ABC";
// operator+("ASD","SD");
}

X &X::operator=(X &b)
{
 value=b.value;
 return *this;
}

X operator+(X &a,X &b)
{
 return X(a.value+b.value);
}