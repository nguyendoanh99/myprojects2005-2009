#include "COLuoi.h"
#include <iostream.h>

void main()
{
	COLuoi a;
	if (!a.Input("test.txt"))
		cout << "Loi";

	cout << a;
	cout << endl;
	COLuoi b = a;
	cout << b;
	cout << endl;
	COLuoi c;
	c = b;
	cout << c;
	c.Output("out.txt");
	
	int *h[10];
	h[1] = new int [3];
	h[1][1] = 2;
	h[1][2] = 3;
	h[2] = new int [3];
	h[2][1] = 1;
	h[2][2] = 5;
	COLuoi d(2, 2, h);
	cout << endl << d;
}