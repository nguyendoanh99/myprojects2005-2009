// Ho ten: Nguyen Dang Khoa
// MSSV:   0512175
// Lop:	   05C1
// Ca TH:  ca 2 chieu thu 6
#include <iostream.h>
#include <stdlib.h>
#include <time.h>
#include "Farm.h"

void main()
{
	srand( (unsigned)time( NULL ) );

	Farm farm;	
	while (farm.LuaChon() != 0);
}
