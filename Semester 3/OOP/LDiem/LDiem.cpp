#include "LDiem.h"
#include <iostream.h>
#include <ctype.h>
#include <stdlib.h>

void SetColor(WORD color)
{
    HANDLE hConsoleOutput;
    hConsoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);
    
    CONSOLE_SCREEN_BUFFER_INFO screen_buffer_info;
    GetConsoleScreenBufferInfo(hConsoleOutput, &screen_buffer_info);

    WORD wAttributes = screen_buffer_info.wAttributes;
    color &= 0x000f;
    wAttributes &= 0xfff0;
    wAttributes |= color;

    SetConsoleTextAttribute(hConsoleOutput, wAttributes);
}

void gotoxy(short x, short y) 
{ 
	HANDLE hConsoleOutput; 
	COORD Cursor_an_Pos = { x,y}; 
	hConsoleOutput = GetStdHandle(STD_OUTPUT_HANDLE); 
	SetConsoleCursorPosition(hConsoleOutput , Cursor_an_Pos); 
} 

void LDiem::GanKyTu(unsigned char cKT)
{
	if (isgraph(cKT) || cKT > 127)
		mKyTu = cKT;
	else 
		mKyTu = 'A';
}

void LDiem::GanMau(int iMau)
{
	mMau = __max(iMau, 0);
	mMau = __min(mMau, 15);
}

void LDiem::GanX(int iX) 
{
	mX = __max(iX, 0);
	mX = __min(mX, 79);
}

void LDiem::GanY(int iY)
{
	mY = __max(iY, 0);
	mY = __min(mY, 24);
}

void LDiem::GanXY(int iX, int iY)
{
	GanX(iX);
	GanY(iY);
}

LDiem::LDiem(unsigned char cKT, int iX, int iY, int iMau)
{
	GanXY(iX, iY);
	GanKyTu(cKT);
	GanMau(iMau);		
}

LDiem::LDiem(const LDiem &P)
{
	mX = P.mX;
	mY = P.mY;
	mKyTu = P.mKyTu;
	mMau = P.mMau;
}

void LDiem::In() const
{
	gotoxy(mX, mY);
	SetColor(mMau);
	cout << mKyTu << flush;
}

void LDiem::Xoa() const
{
	gotoxy(mX, mY);
	cout<<' '<<flush;
}

unsigned char LDiem::DocKyTu() const 
{
	return mKyTu;
}

int LDiem::DocMau() const 
{
	return mMau;
}

int LDiem::DocX() const 
{
	return mX;
}

int LDiem::DocY() const
{
	return mY;
}

void LDiem::DichLen(int x)
{
	if (mY - x >= 0)
		mY -= x;
}

void LDiem::DichXuong(int x)
{
	if (mY + x < 25)
		mY += x;
}

void LDiem::DichTrai(int x)
{
	if (mX - x >= 0)
		mX -= x;
}

void LDiem::DichPhai(int x)
{
	if (mX + x < 80)
		mX += x;
}