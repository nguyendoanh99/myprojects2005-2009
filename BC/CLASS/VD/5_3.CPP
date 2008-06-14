#include <iostream.h>
class Couter
	{
	  int value;
	 public:
	  Couter(): value(10) {}
	  operator int() {return value;}
	};

void main()
{
 int *ip=new int;
 int a;
 Couter *c=new Couter,d;
 *ip=(int)*c;
 a=(int)d;
}