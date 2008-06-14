class Couter
	{
	 public:
	  int value;
	  Couter(int i): value(i) {}
	  Couter operator!();
	  Couter operator+(Couter&);
	};

void main()
{
 Couter c1(3),c2(4);
 c1=!c1;
 c1=c1+c2;
}

Couter Couter::operator!()
{
 return Couter(!value);
}

Couter Couter::operator+(Couter &c)
{
 return Couter(value+c.value);
}