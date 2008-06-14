#include <iostream.h>
#include "LMayTinh.h"

void main()
{
	LMayTinh MayTinh;
	while (MayTinh.Nhap() != 0)
	{
		cout << "Ket qua: " << MayTinh << endl;
		cout << "-----------------------------------------------" << endl << endl;
	}
}