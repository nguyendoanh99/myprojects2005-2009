#include "LHCNDac.h"
#include <conio.h>
void main()
{
	LHCNDac P(0,0,21,1);
	LHCNDac Q(2,1,19,1);
	Q.In();
	P.In();
	int c1, c2;
	
	while (1)
	{
		if (kbhit())
		{
			if ((c1 = getch()) == 224 || c1 == 0) 
				c2 = getch();

			if (c1 == 27)
				return;

			if (c1 == 224)
			{				
				P.Xoa();

				switch (c2)
				{
				case 77: // phim phai
					P.DichPhai();
					break;
				case 75: // phim trai
					P.DichTrai();
					break;
				case 80: // phim duoi
					P.DichXuong();
					break;
				case 72: // phim len
					P.DichLen();
				}
			
				P.In();				
			}
		}
	}
}