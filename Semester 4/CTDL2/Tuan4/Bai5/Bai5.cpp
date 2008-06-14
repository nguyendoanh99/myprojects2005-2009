#include <iostream>
#include <fstream>

#define FILENAME1 "README.TXT"
#define FILENAME2 "THONGKE.TXT"

using namespace std;

void main()
{
	ifstream f1;
	ofstream f2;
	char c;
	int n = 'z' - 'a' + 1;

	int *thuong = new int[n];
	int *hoa = new int[n];

	f1.open(FILENAME1);
	f2.open(FILENAME2);

	for (int i = 0; i < n; ++i)
	{
		thuong[i] = 0;
		hoa[i] = 0;
	}
// Doc file
	while (1)
	{
		if (f1.eof())
			break;
		f1 >> c;
		if (f1.eof())
			break;

		if (c >= 'a' && c <='z')
			++thuong[c - 'a'];
		else
			if (c >= 'A' && c <= 'Z')
				++hoa[c - 'A'];
	}
//  Dem so luong ky tu
	int dem = 0;
	
	for (i = 0; i < n; ++i)
	{
		if (thuong[i])
			++dem;
		if (hoa[i])
			++dem;
	}
// Ghi file
	f2 << "So loai ky tu = " << dem << endl;
	for (i = 0; i < n; ++i)
	{
		if (thuong[i])		
			f2 << char(i + 'a') << " = " << thuong[i] << endl;
	}

	for (i = 0; i < n; ++i)
	{
		if (hoa[i])		
			f2 << char(i + 'A') << " = " << hoa[i] << endl;
	}	
	delete []hoa;
	delete []thuong;
}