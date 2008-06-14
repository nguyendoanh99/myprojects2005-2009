#include <iostream.h>
#include "LDiem.h"
#include <conio.h>
#include <stdlib.h>
#include <sys/timeb.h>
#include <time.h>

int LayThoiGian();
void delay(int);

void UngDung1();
void UngDung2();
void UngDung3();
void UngDung4();
void UngDung5();

void main()
{
//	const LDiem a;
//	a.GanKyTu('a');
//	UngDung1();
//	UngDung2();
	UngDung3();
//	UngDung4();
//	UngDung5();
}
// Lay thoi gian hien hanh va doi thanh don vi 1/1000 cua giay
int LayThoiGian()
{
	struct _timeb timebuffer;

	_ftime( &timebuffer );
	return (timebuffer.time * 1000) + timebuffer.millitm;
}
// Tao khoang thoi gian tre iCho/1000 giay
void delay(int iCho)
{
	int iBanDau = LayThoiGian();
	int iHienTai;
	while (1)
	{
		iHienTai = LayThoiGian();
		if (iHienTai-iBanDau > iCho)
			return ;
	}
}

void UngDung1()
{
	LDiem P('A', 3, 4, 14);	
	P.In();
	
	getch();
	P.Xoa();
	P.DichPhai(54);
	P.In();

	getch();
	getch();
	P.Xoa();
	P.DichXuong(60);
	P.In();
}

void UngDung2()
{
	LDiem P('A', 2, 2, 15);	
	P.In();

	int c1, c2;
	
	while (1)
	{
		if (kbhit())
		{
			if ((c1 = getch()) == 224) 
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

void UngDung3()
{
	LDiem P('A', 40, 12, 15);	
	P.In();
	
	srand( (unsigned)time( NULL ) );	
	while (1)
	{		
		Sleep(10);
//		delay(100);
		
		P.Xoa();
		switch (rand() % 4)
		{
		case 0: // dich phai
			P.DichPhai();
			break;
		case 1: // dich trai
			P.DichTrai();
			break;
		case 2: // dich xuong
			P.DichXuong();
			break;
		case 3: // dich len
			P.DichLen();
		}	
		P.In();				
		
		if (kbhit())
			return ;		
	}
}

void UngDung4()
{
	LDiem P('A', 40, 12, 15);	
	P.In();
	
	srand( (unsigned)time( NULL ) );	
	while (1)
	{	
		P.GanKyTu(rand() % 93 + 33);
		
		delay(300);		
		P.Xoa();
		switch (rand() % 4)
		{
		case 0: // dich phai
			P.DichPhai();
			break;
		case 1: // dich trai
			P.DichTrai();
			break;
		case 2: // dich xuong
			P.DichXuong();
			break;
		case 3: // dich len
			P.DichLen();
		}	
		P.In();				
		
		if (kbhit())
			return ;		
	}
}

void UngDung5()
{
	LDiem P('A', 40, 12, 15);	
	P.In();
	
	srand( (unsigned)time( NULL ) );	
	while (1)
	{	
		P.GanKyTu(rand() % 93 + 33);

		delay(300);		
		
		switch (rand() % 4)
		{
		case 0: // dich phai
			P.DichPhai();
			break;
		case 1: // dich trai
			P.DichTrai();
			break;
		case 2: // dich xuong
			P.DichXuong();
			break;
		case 3: // dich len
			P.DichLen();
		}	
		P.In();				
		
		if (kbhit())
			return ;		
	}
}