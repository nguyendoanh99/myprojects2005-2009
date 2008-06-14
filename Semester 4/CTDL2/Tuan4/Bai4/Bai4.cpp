#include <iostream>
#include <fstream>

#define FILENAME1 "NUMBER1.TXT"
#define FILENAME2 "NUMBER2.TXT"
#define FILENAME "NUMBER.TXT"
using namespace std;

void main()
{
	ifstream f1;
	ifstream f2;
	ofstream f;
	int t1, t2;

	f1.open(FILENAME1);
	f2.open(FILENAME2);
	f.open(FILENAME);

	f1 >> t1;
	f2 >> t2;
	
	while (1)
	{
		if (t1 > t2)
		{
//			if (f2.eof())
//				break;

			f << t2 << " ";			
		
			if (f2.eof())
				break;

			f2 >> t2;
		}
		else
		{
//			if (f1.eof())
//				break;

			f << t1 << " ";			
		
			if (f1.eof())
				break;

			f1 >> t1;

		}
	}
	

	if (f1.eof())
	{
		f << t2 << " ";
		while (1)
		{
			if (f2.eof())
				break; 
			f2 >> t2;
			
			f << t2 << " ";
		}
	}
	else
	{
		f << t1 << " ";
		while (1)
		{
			if (f1.eof())
				break;
			f1 >> t1;
			
			f << t1 << " ";
		}
	}
}
