// Viet chuong trinh de giai bai toan sau: Vua ga vua cho bo lai cho tron 36
// con 100 chan chan.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int i=1;
 while (i<=35)
 {
  if (i*2+(36-i)*4==100) cout<<"\aGa = "<<i<<"\t\tCho = "<<36-i<<"\n";
  i++;
 }
 getch();
}