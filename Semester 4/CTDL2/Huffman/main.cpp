#include "CHuffman.h"
#include "CHuffmanC.h"
#include "CHuffmanU.h"
#include "iostream.h"
void main()
{	

	CHuffman *a = new CHuffmanC("test.txt");
	a->Output("test.huf");

	delete a;
	a = new CHuffmanU("test.huf");
	a->Output("test1.txt");
}