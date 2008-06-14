#include "LList.h"

void main()
{
	LList l;
	int a[3] = {3,4,5};
	l.AddHead(a+1);
	l.AddTail(a+2);
	l.AddHead(a);
	LList p = l;
	LList q;
	q = l;
}
