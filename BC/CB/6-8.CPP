#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 for (int i=100;i<=10000;i++)
  if (i%7==0) cout<<setw(5)<<i;
 getch();
}