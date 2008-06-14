// Viet chuong trinh nhan biet ma ban phim.
#include <iostream.h>
#include <conio.h>
#include <dos.h>
#include <ctype.h>
void main()
{
 clrscr();
 unsigned char c;
 do
 {
  c=getch();
  gotoxy(1,12);
  delline();
  cout<<"Phim ban vua nhan co ma ASCII la "<<toascii(c);
 }
 while (toascii(c)!=27);
}