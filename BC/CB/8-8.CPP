#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 cout<<"Nhap vao 10 so in ra tong cua chung\n";
 int t=0,so;
 for (int i=1;i<=10;i++)
 {
  cout<<"So thu "<<i<<" = ";
  cin>>so;
  t+=so;
 }
 cout<<"Tong cua 10 so vua nhap la "<<t;
 getch();
}