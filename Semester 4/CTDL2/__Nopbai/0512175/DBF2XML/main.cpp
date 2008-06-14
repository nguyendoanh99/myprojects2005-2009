#include "CDBF2XML.h"
#include "stdio.h"

int main(int argc, char* argv[])
{
	char str[255];

	sprintf(str, "%s.dbf", argv[1]);
	cout << "Dang doc file " << str << endl;
	
	CDBF2XML t(str);

	sprintf(str, "%s.xml", argv[1]);
	if (!t.WriteXML(str))
	{
		cout << "Khong the ghi file " << str << endl;
		return 1;
	}
	else
		cout << "Tao file " << str << " thanh cong" << endl;

	return 0;
}