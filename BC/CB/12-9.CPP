// In ra man hinh cac so co 4 chu so ma moi so co tinh chat sau: Tong cua chu
// so hang tram voi hang ngan bang tong cua chu so hang chuc voi hang don vi.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 int a,b,c,d;
 a=1;
 while (a<=9)
 {
  b=0;
  while (b<=9)
  {
   c=0;
   while (c<=9)
   {
    d=0;
    while (d<=9)
    {
     if (a+b==c+d) cout<<setw(5)<<a<<b<<c<<d;
     d++;
    }
    c++;
   }
   b++;
  }
  a++;
 }
 getch();
}