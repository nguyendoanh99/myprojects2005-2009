#include "LHinhChuNhat.h"
#include <stdlib.h>
#include <windows.h>
#include <iostream.h>

void gotoxy(short x,short y) 
{ 
	HANDLE hConsoleOutput; 
	COORD Cursor_an_Pos = { x,y}; 
	hConsoleOutput = GetStdHandle(STD_OUTPUT_HANDLE); 
	SetConsoleCursorPosition(hConsoleOutput , Cursor_an_Pos); 
} 

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

void LHinhChuNhat::KhoiDong(int iX, int iY, int iNgang, int iDoc, int iMau)
{
	// Cap nhat mX
	mX = __max(iX, 1);
	if (iNgang >= 1 && iNgang <= 78)
		mX = __min(mX, 79 - iNgang);
	else
		mX = __min(mX, 78);
	// Cap nhat mY
	mY = __max(iY, 1);
	if (iDoc >= 1 && iDoc <=22)
		mY = __min(mY, 23 - iDoc);
	else
		mY = __min(mY, 22);
	
	GanNgang(iNgang);
	GanDoc(iDoc);
	GanMau(iMau);
}

void LHinhChuNhat::KhoiDong(const LHinhChuNhat& P)
{
	GanXY(P.mX, P.mY);
	GanNgang(P.mNgang);
	GanDoc(P.mDoc);
	GanMau(P.mMau);
}

int LHinhChuNhat::DocX()
{
	return mX;
}

int LHinhChuNhat::DocY()
{
	return mY;
}

int LHinhChuNhat::DocNgang()
{
	return mNgang;
}

int LHinhChuNhat::DocDoc()
{
	return mDoc;
}

int LHinhChuNhat::DocMau()
{
	return mMau;
}

void LHinhChuNhat::GanX(int iX)
{
	mX = __max(iX, 1);
	mX = __min(mX, 79 - mNgang);
}

void LHinhChuNhat::GanY(int iY)
{
	mY = __max(iY, 1);
	mY = __min(mY, 23 - mDoc);
}

void LHinhChuNhat::GanXY(int iX, int iY)
{
	GanX(iX);
	GanY(iY);
}

void LHinhChuNhat::GanMau(int iMau)
{
	mMau = __max(iMau, 0);
	mMau = __min(mMau, 15);
}

void LHinhChuNhat::GanNgang(int iNgang)
{
	mNgang = __max(iNgang, 1);
	mNgang = __min(mNgang, 79 - mX);
}

void LHinhChuNhat::GanDoc(int iDoc)
{
	mDoc = __max(iDoc, 1);
	mDoc = __min(mDoc, 23 - mY);
}

void LHinhChuNhat::GanNgangDoc(int iNgang, int iDoc)
{
	GanNgang(iNgang);
	GanDoc(iDoc);
}

void LHinhChuNhat::In()
{
	SetColor(mMau);
	gotoxy(mX, mY);

	cout<<char(218);
	for (int i = 1; i < mNgang; ++i)
		cout<<char(196);
	cout<<char(191)<<flush;

	for (i = 1; i < mDoc; ++i)
	{
		gotoxy(mX, mY + i);
		cout<<char(179)<<flush;
		gotoxy(mX + mNgang, mY + i);
		cout<<char(179)<<flush;
	}
	gotoxy(mX, mY + mDoc);
	cout<<char(192)<<flush;
	for (i = 1; i < mNgang; ++i)
		cout<<char(196);
	cout<<char(217)<<flush;
}

void LHinhChuNhat::Xoa()
{
	gotoxy(mX, mY);

	cout<<' ';
	for (int i = 1; i < mNgang; ++i)
		cout<<' ';
	cout<<' '<<flush;

	for (i = 1; i < mDoc; ++i)
	{
		gotoxy(mX, mY + i);
		cout<<' '<<flush;
		gotoxy(mX + mNgang, mY + i);
		cout<<' '<<flush;
	}
	gotoxy(mX, mY + mDoc);
	cout<<' ';
	for (i = 1; i < mNgang; ++i)
		cout<<' ';
	cout<<' '<<flush;
}

void LHinhChuNhat::DichLen(int d)
{
	if (mY - d > 0)
		mY -= d;
}

void LHinhChuNhat::DichXuong(int d)
{
	if (mY + mDoc + d < 24)
		mY += d;
}

void LHinhChuNhat::DichTrai(int d)
{
	if (mX - d > 0)
		mX -= d;
}

void LHinhChuNhat::DichPhai(int d)
{
	if (mX + mNgang + d < 80)
		mX +=d;
}