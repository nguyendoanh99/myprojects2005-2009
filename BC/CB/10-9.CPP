// In ra man hinh tat ca cac uoc so cua 1 so cho truoc.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 int a;
 cout<<"Nhap vao 1 so = ";
 cin>>a;
 cout<<"Tat ca cac uoc so cua "<<a<<" la\n";
 int i=1;
 do
 {
  if (a%i==0) cout<<setw(3)<<i;
  i++;
 }
 while (i<=a);
 getch();
}