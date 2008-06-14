#include "CIDX.h"
#include "CDBF2Console.h"
#include <iostream>
using namespace std;
void main(int argc, char* argv[])
{
	char X[100];
	char Y[100];
	int vt;
	CIDX t;
	strcpy(X, argv[1] + 6);
	strcpy(Y, argv[2] + 4);
	
	CDBF2Console f("DMHH.DBF");	
	t.Input("MAHH.IDX");		
	if (stricmp(X, "none") == 0)
	{
		vt = f.Find("Mahh", Y);
		if (vt != -1)
		{		
			cout << "Thong tin cua cac record thich hop:" << endl;
			f.WriteConsole(vt);
			while ((vt = f.FindNext()) != -1)
			{
				f.WriteConsole(vt);
			}		
		}
		else
			cout << "Khong tim thay Y" << endl;
	}
	else
	{
		vt = t.Find(Y);
		if (vt != -1)
		{				
			cout << "Thong tin cua cac record thich hop:" << endl;
			f.WriteConsole(vt);
			while ((vt = t.FindNext()) != -1)
			{
				f.WriteConsole(vt);
			}		
		}
		else
			cout << "Khong tim thay Y" << endl;

	}	
}