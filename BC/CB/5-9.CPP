// Viet chuong trinh de giai bai toan sau: Xet phep cong cac so nguyen duong
// 1+2+3+... Hoi cong den so may thi tong cua chung bat dau>1000.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int i=0,a=0;
 while (a<=1000)
 {
  i++;
  a+=i;
 }
 cout<<"So "<<i;
 getch();
}