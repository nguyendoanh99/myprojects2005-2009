#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int max;
 cout<<"Nhap vao 10 so in ra so lon nhat\n";
 cout<<"So thu 1 = ";
 cin>>max;
 int a;
 for (int i=2;i<=10;i++)
 {
  cout<<"So thu "<<i<<" = ";
  cin>>a;
  if (max<a) max=a;
 }
 cout<<"So lon nhat trong 10 so vua nhap la "<<max;
 getch();
}