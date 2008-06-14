#include "CDoThiMTK.h"

void main()
{
	CDoThiMTK a;
	if (!a.Input("test.txt"))
		cout << "Loi!"<< endl;

	CDoThiMTK b = a;
	CDoThiMTK c;
	c = a;
	a.Output("out.txt");
	cout << a;
}