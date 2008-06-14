#include <iostream.h>
#include <math.h>
void pt(int ,int);
void main()
{
	pt(2,101);
}
void pt(int sont,int n)
{
	if (sont>sqrt(n))
	{
		cout<<n;
		return;
	}
	if (n%sont==0)
	{
		cout<<sont<<"*";
		pt(sont,n/sont);
	}
	else
		if (sont==2)
			pt(3,n);
		else
			pt(sont+2,n);
}