#include <iostream>
#include <fstream>
#include <string>
#include <windows.h>
using namespace std;

char *filename = "c:\\windows\\ODBCINST.INI";
// ".//ABC.ini" cach chi duong dan tuong doi
void main()
{
	char s[255];
//	GetPrivateProfileString
//	GetPrivateProfileSection
//	GetPrivateProfileSectionName
//	GetCurrentDirectory
/*
	
	GetPrivateProfileString("Microsoft ODBC for Oracle (32 bit)", "Driver", "Khong tim thay", 
		s, 255, filename);
	cout << s << endl;
*/
	ifstream f;	
	char s1[255] = "SQL Server (32 bit)";//"Microsoft ODBC for Oracle (32 bit)";
	char *stemp;
	int flag = 0;

	f.open(filename);

	while (flag == 0 && !f.eof())
	{
		f.getline(s,255);
		stemp = s;
		stemp++;
		stemp[strlen(stemp) - 1] = 0;
		if (strcmp(stemp, s1) == 0)		
			flag = 1;		
	}

	if (flag == 1)
	{
		f.getline(s, 255);
		stemp = strstr(stemp, "=") + 1;
		cout << stemp << endl;
	}
}  