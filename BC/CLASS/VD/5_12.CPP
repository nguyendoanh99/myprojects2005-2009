#include <mem.h>
class A
	{
	  int *value;
	 public:
	  A(int i,int j): value(new int[i*j]) {}
	  int &operator()(int x,int y){return value[x+y];};
	};

void main()
{
 A m(10,20);
 m(10,20)+=1;
}