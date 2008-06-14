// Viet chuong trinh doc vao 10 so bat ki va tinh tong cua chung. Viet chuong
// trinh theo 3 kieu vong lap.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 cout<<"Nhap vao 10 so bat ki va tinh tong cua chung.\n";
 int t=0,a;

// Vong lap for
// for (int i=1;i<=10;i++)
// {
//  cout<<"So thu "<<i<<" = ";
//  cin>>a;
//  t+=a;
// }
// cout<<"Tong cua 10 so vua nhap la "<<t;

// Vong lap While
// int i=1;
// while (i<=10)
// {
//  cout<<"So thu "<<i<<" = ";
//  cin>>a;
//  t+=a;
//  i++;
// }
// cout<<"Tong cua 10 so vua nhap la "<<t;

//Vong lap do...while
 int i=1;
 do
 {
  cout<<"So thu "<<i<<" = ";
  cin>>a;
  t+=a;
  i++;
 }
 while (i<=10);
 cout<<"Tong cua 10 so vua nhap la "<<t;
 getch();
}