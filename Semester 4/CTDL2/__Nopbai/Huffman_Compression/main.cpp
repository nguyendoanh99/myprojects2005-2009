#include "CHuffman.h"
#include "CHuffmanC.h"
#include "iostream.h"
void main()
{	
	char str[255];
	char str1[255];
	cout << "Nhap ten file muon nen : ";
	cin.getline(str, 255);
	cout << "Nhap ten file sau khi nen: ";
	cin.getline(str1, 255);
	cout << "Dang thuc hien. Xin cho trong choc lat..." << endl;
	CHuffman *a = new CHuffmanC(str);
	a->Output(str1);
	cout << "Da nen xong" << endl;

}