// Tinh tong cua S=1+1/2+1/3+1/4+... Cong den so hang thu may thi: (2-S)<0,01.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 float s=1,i=1;
 while (2-s>=0.01)
 {
  i++;
  s+=1/i;
 }
 cout<<i;
 getch();
}