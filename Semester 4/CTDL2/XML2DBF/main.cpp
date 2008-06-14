#include "CXML2DBF.h"
#include "stdio.h"
int main(int argc, char* argv[])
{
	char str[255];

	sprintf(str, "%s.xml", argv[1]);
	cout << "Dang doc file " << str << endl;
	CXML2DBF a(str);

	sprintf(str, "%s.dbf", argv[1]);
	if (!a.WriteDBF(str))
	{
		cout << "Khong the ghi file " << str << endl;
		return 1;
	}
	else
		cout << "Tao file " << str << " thanh cong" << endl;

	return 0;
}