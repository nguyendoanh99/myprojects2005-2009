// Viet chuong trinh dieu khien viec nhap vao dung so duong, neu nhap so am
// thi yeu cau nhap lai.(do...while).
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int a;
 do
 {
  cout<<"a=";
  cin>>a;
  if (a<0) cout<<"Ban nhap sai roi! Xin hay nhap lai.\n";
 }
 while (a<0);
 getch();
}