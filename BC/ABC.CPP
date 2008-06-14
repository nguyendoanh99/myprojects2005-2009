// Viet chuong trinh tim tat ca cac so co 3 chu so abc sao cho tong cac lap
// phuong cua cac chu so bang chinh so do.
#include <iostream>
#include <conio.h>
#include <math.h>
#include <iomanip.h>

void main()
{
 clrscr();
 for (int a=1;a<10;a++)
  for (int b=0;b<10;b++)
   for (int c=0;c<10;c++)
    if (a*100+b*10+c==pow(a,3)+pow(b,3)+pow(c,3)) cout<<setw(4)<<a*100+10*b+c;
 getch();
}
