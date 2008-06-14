#include "CHuffman.h"
#include "CHuffmanU.h"
#include "iostream.h"
void main()
{	
	char str[255];
	char str1[255];
	cout << "Nhap ten file muon giai nen : ";
	cin.getline(str, 255);
	cout << "Nhap ten file sau khi giai nen : ";
	cin.getline(str1, 255);

	cout << "Dang thuc hien. Xin cho trong choc lat..." << endl;
	CHuffman *a = new CHuffmanU(str);	
	a->Output(str1);
	cout << "Da giai nen xong." << endl;
}