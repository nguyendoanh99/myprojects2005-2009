#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 for (int i=1;i<=100;i++)
  if (i%6==0) cout<<setw(4)<<i;
 getch();
}