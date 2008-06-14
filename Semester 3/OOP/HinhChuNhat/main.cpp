#include "LHCN.h"
#include <iostream.h>
#include <conio.h>
#include <sys/timeb.h>

int LayThoiGian();
void delay(int);

void UngDung1();
void UngDung2();

void main()
{
//	UngDung1();
//	cout<<endl;
	UngDung2();
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
	LHCN P(0, 0, 79, 24, 14);
	
	P.In();

	getch();
	getch();

	P.Xoa();
	P.DichTrai(10);
	P.In();

	getch();
	getch();

	P.Xoa();
	P.GanDai(P.DocDai() * 2);
	P.In();

	getch();
	getch();
	
	P.Xoa();
	P.GanRong(P.DocRong() - 3);
	P.In();
}

void UngDung2()
{
	LHCN P(0,0,79,24,14);	
	// i = 1: phong to hinh chu nhat
	// i = -1: thu nho hinh chu nhat
	int i = -1;
	
	P.In();
	while (1)
	{
		delay(100);
		if (i == 1)
			P.Xoa();

		P.DichTrai(3 * i);
		P.DichLen(i);
		P.GanDai(P.DocDai() + (2 * i));
		P.GanRong(P.DocRong() + (6 * i));
	
		P.In();
		// mY == 0: Neu hinh chu nhat to cuc dai thi thu nho hinh lai
		// mY == 11:Neu hinh chu nhat nho cuc tieu thi phong to hinh len
		if (P.DocY() == 0 || P.DocY() == 11)		
			i = -i;
		
		// Neu nguoi su dung an 1 phim bat ky thi dung lai
		if (kbhit())
			return;
		
	}
}