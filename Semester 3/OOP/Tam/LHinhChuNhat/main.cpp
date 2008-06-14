#include "LHinhChuNhat.h"
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
	LHinhChuNhat P;
	P.KhoiDong(2, 3, 3, 4, 14);
	P.In();

	getch();
	getch();

	P.Xoa();
	P.DichTrai(10);
	P.In();

	getch();
	getch();

	P.Xoa();
	P.GanDoc(P.DocDoc() * 2);
	P.In();

	getch();
	getch();
	
	P.Xoa();
	P.GanNgang(P.DocNgang() - 3);
	P.In();
}

void UngDung2()
{
	LHinhChuNhat P;
	P.KhoiDong(39,11,1,1,14);
	// i = 1: phong to hinh chu nhat
	// i = -1: thu nho hinh chu nhat
	int i = 1;
	while (1)
	{
		delay(100);

		P.Xoa();

		P.GanDoc(P.DocDoc() + (2 * i));
		P.GanNgang(P.DocNgang() + (2 * i));
		P.GanXY(P.DocX() - i, P.DocY() - i);
		P.In();
		// mY == 1: Neu hinh chu nhat to cuc dai thi thu nho hinh lai
		// mY == 11:Neu hinh chu nhat nho cuc tieu thi phong to hinh len
		if (P.DocY() == 1 || P.DocY() == 11)
			i = -i;

		P.In();
		// Neu nguoi su dung an 1 phim bat ky thi dung lai
		if (kbhit())
			return;
		
	}
}